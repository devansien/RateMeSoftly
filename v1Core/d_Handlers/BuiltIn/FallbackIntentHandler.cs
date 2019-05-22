using System.Threading.Tasks;

namespace RateMeSoftly
{
    class FallbackIntentHandler : Core, IRequestHandler
    {
        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{BuiltInRequest.FallbackIntent}", async () =>
            {
                await Task.Run(() =>
                {
                    State.NumPrompted++;

                    Response.SetSpeech(false, false,
                        "Sorry, I didn't understand. Please rate us using one of the followings. Very good, good, okay, bad, and very bad. ",
                        "Please rate us using one of the followings. Very good, good, okay, bad, and very bad. ");
                });
            });
        }
    }
}
