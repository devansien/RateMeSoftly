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
                    UserEventRequest userRequest = Input.GetRequest().Request as UserEventRequest;
                    string inputValue = userRequest.Arguments[0];
                    RecordRating(inputValue);

                    Response.SetDirectives(DirectiveManager.GetRenderDirective("ThankYouPage", string.Empty, b_ThankYouPage.GetPage()));
                    Response.SetSpeech(null, false,
                        "Thank you for your participation. See you soon. ",
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
