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

                    Response.SetSpeech(false, true,
                        "Sorry, I didn't understand. Please rate us using one of the followings. Very good, good, okay, bad, and very bad. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>",
                        "Please rate us using one of the followings. Very good, good, okay, bad, and very bad. <audio src=\"https://s3.amazonaws.com/sonnar-rate-me-softly/230silence.mp3\"/>");
                });
            });
        }
    }
}
