using System.Threading.Tasks;

namespace RateMeSoftly
{
    class RateIntentHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{CustomRequest.RateIntent}", async () =>
            {
                await Task.Run(() =>
                {
                    State.NumPlayed++;
                    string inputValue = InputManager.GetInputValue(Input.GetIntentRequest().Intent.Slots["RateEntity"]);
                    Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, b_ThankYouPage.GetPage()));
                    Response.SetSpeech(false, false, $"You rated us {inputValue}. Thank you for your participation. See you soon. ","Rate me baby baby. " );
                });
            });
        }
    }
}
