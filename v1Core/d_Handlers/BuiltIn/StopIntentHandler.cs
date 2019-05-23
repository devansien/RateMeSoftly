using System.Threading.Tasks;

namespace RateMeSoftly
{
    class StopIntentHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{BuiltInRequest.StopIntent}", async () =>
            {
                await Task.Run(() =>
                {
                    Response.SetSpeech(true, false, "Goodbye. ");
                });
            });
        }
    }
}
