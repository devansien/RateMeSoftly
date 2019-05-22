using Alexa.NET.APL;
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
                    Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                    Response.SetSpeech(null, true,
                        "<say-as interpret-as=\"interjection\">gotcha, </say-as> thank you for your participation. ",
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
    }
}
