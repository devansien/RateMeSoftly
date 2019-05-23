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
                    Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                    Response.SetSpeech(false, true,
                        "Hi there, we are looking to improve. Please grade today's workshop. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>",
                        "Please grade today's workshop. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>");
                });
            });
        }
    }
}
