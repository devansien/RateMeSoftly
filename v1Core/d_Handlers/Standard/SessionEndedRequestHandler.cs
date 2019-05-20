using System.Threading.Tasks;

namespace RateMeSoftly
{
    class SessionEndedRequestHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{BuiltInRequest.SessionEndedRequest}", async () =>
            {
                await Task.Run(() =>
                {
                    Logger.Write("Session expired");
                });
            });
        }
    }
}
