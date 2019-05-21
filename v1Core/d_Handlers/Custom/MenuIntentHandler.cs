using System.Threading.Tasks;

namespace RateMeSoftly
{
    class MenuIntentHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{CustomRequest.MenuIntent}", async () =>
            {
                await Task.Run(() =>
                {
                    string inputValue = InputManager.GetInputValue(Input.GetIntentRequest().Intent.Slots["MenuEntity"]);
                    if (!string.IsNullOrEmpty(inputValue) && MenuEntity.Values.Contains(inputValue))
                    {
                        Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                        Response.SetSpeech(false, false, $"Please rate us. ", "Rate me baby baby. ");
                    }
                    else
                    {

                    }
                });
            });
        }
    }
}
