using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RateMeSoftly
{
    class RateIntentHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{CustomRequest.RateIntent}", async () =>
            {
                await Task.Run(async () =>
                {
                    string inputValue = InputManager.GetInputValue(Input.GetIntentRequest().Intent.Slots[RateEntity.Name]);

                    if (!string.IsNullOrEmpty(inputValue) && RateEntity.Values.Contains(inputValue))
                    {
                        State.NumPlayed++;
                        RecordRating(inputValue);
                        string speechcon = GetSpeechcon();
                        Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                        Response.SetSpeech(false, true,
                            $"<say-as interpret-as=\"interjection\">{speechcon}, </say-as> thank you for your participation. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>",
                            "Please grade today's workshop. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>");
                    }
                    else
                        await new FallbackIntentHandler().HandleRequest();
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
