using System;
using System.Threading.Tasks;

namespace RateMeSoftly
{
    class RequestProcessManager : Core
    {
        public static async Task ProcessRequest(string requestType, Func<Task> handler)
        {
            try
            {
                Logger.Write($"[{requestType}] handling started");
                await handler();
                Logger.Write($"[{requestType}] handling completed");
            }
            catch (Exception ex)
            {
                Logger.Write($"Unable to process [{requestType}]");
                Logger.Write($"Exception detail: {ex}");
                Response.SetSpeech(true, false, SpeechManager.GetExceptionSpeech());
            }
        }
    }
}
