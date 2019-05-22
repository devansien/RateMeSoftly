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
                        Response.SetDirectives(DirectiveManager.GetRenderDirective("ThankYouPage", string.Empty, b_ThankYouPage.GetPage()));
                        Response.SetSpeech(null, false,
                            "Thank you for your participation. See you soon. ",
                            " ");
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
    }
}
