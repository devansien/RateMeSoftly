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

                    Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMe", string.Empty, a_RateMePage.GetPage()));
                    Response.SetSpeech(false, false, "Welcome, rate me baby. ", "Welcome, rate me baby baby. ");
                });
            });
        }
    }
}
