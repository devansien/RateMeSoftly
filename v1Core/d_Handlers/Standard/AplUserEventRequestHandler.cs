using Alexa.NET.APL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RateMeSoftly
{
    class AplUserEventRequestHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{BuiltInRequest.AplUserEventRequest}", async () =>
            {
                await Task.Run(() =>
                {
                    State.NumPlayed++;
                    UserEventRequest userRequest = Input.GetRequest().Request as UserEventRequest;
                    string inputValue = userRequest.Arguments[0];
                    RecordRating(inputValue);
                    string speechcon = GetSpeechcon();
                    Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                    Response.SetSpeech(false, true,
                        $"<say-as interpret-as=\"interjection\">{speechcon}, </say-as> thank you for your participation. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>",
                        " ");
                });
            });
        }

        void RecordRating(string inputValue)
        {
            switch (inputValue)
            {
                case "very bad":
                    State.VeryBad++;
                    break;
                case "bad":
                    State.Bad++;
                    break;
                case "ok":
                    State.Ok++;
                    break;
                case "good":
                    State.Good++;
                    break;
                case "very good":
                    State.VeryGood++;
                    break;
                default:
                    State.VeryGood++;
                    break;
            }
        }

        string GetSpeechcon()
        {
            Random rand = new Random();
            List<string> speechcons = new List<string>
            {
                "bam", "bingo", "bravo", "cheers", "dynomite", "hurray", "okey dokey",
                "ooh la la", "wahoo", "well done", "woo hoo", "yay"
            };

            return speechcons[rand.Next(speechcons.Count)];
        }
    }
}
