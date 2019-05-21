using System.Threading.Tasks;

namespace RateMeSoftly
{
    class LaunchRequestHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{BuiltInRequest.LaunchRequest}", async () =>
            {
                await Task.Run(() =>
                {
                    State.NumPlayed++;
                    State.NumPrompted = 0;

                    Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                    Response.SetSpeech(false, false, "Hi there, we are looking to improve. Please grade today's workshop. ", "Please grade today's workshop. ");
                });
            });
        }
    }
}
