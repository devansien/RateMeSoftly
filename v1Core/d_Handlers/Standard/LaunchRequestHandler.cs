using System.Text;
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
                    string breakText = "<break time=\"10s\"/>";
                    string reprompt = "Please grade today's workshop. ";

                    StringBuilder sb = new StringBuilder();
                    sb.Append(reprompt);
                    for (int i = 0; i < 30; i++)
                        sb.Append(breakText);

                    Response.SetDirectives(DirectiveManager.GetRenderDirective("RateMePage", string.Empty, a_RateMePage.GetPage()));
                    Response.SetSpeech(false, true,
                        "Hi there, we are looking to improve. Please grade today's workshop. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>",
                        sb.ToString());
                });
            });
        }
    }
}
