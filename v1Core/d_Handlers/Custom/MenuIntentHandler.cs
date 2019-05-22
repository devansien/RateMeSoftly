using System.Threading.Tasks;

namespace RateMeSoftly
{
    class MenuIntentHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{CustomRequest.MenuIntent}", async () =>
            {
                await Task.Run(async () =>
                {
                    string inputValue = InputManager.GetInputValue(Input.GetIntentRequest().Intent.Slots[MenuEntity.Name]);

                    if (!string.IsNullOrEmpty(inputValue) && MenuEntity.Values.Contains(inputValue))
                    {
                        Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                        Response.SetSpeech(false, false,
                            "Hi there, we are looking to improve. Please grade today's workshop. ",
                            "Please grade today's workshop. ");
                    }
                    else
                        await new FallbackIntentHandler().HandleRequest();
                });
            });
        }
    }
}
