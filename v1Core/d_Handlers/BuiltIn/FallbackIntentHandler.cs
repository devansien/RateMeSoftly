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

                    if (State.NumPrompted % 3 == 0)
                    {
                        Response.SetSpeech(true, false,
                            SpeechManager.GetNotUnderstandSpeech() + SpeechManager.GetForcedEndSpeech());
                    }
                    else
                        Response.SetSpeech(false, false,
                            SpeechManager.GetNotUnderstandSpeech() + SpeechManager.GetTryAgainSpeech() + SpeechManager.GetWhatWouldYouSpeech(),
                            SpeechManager.GetShortHelpSpeech() + SpeechManager.GetWhatWouldYouSpeech());
                });
            });
        }
    }
}
