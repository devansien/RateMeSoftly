using System;
using System.Threading.Tasks;

namespace RateMeSoftly
{
    class LaunchRequestHandler : Core, IRequestHandler
    {
        private const int maxValue = 10;


        public async Task HandleRequest()
        {
            await RequestProcessManager.ProcessRequest($"{BuiltInRequest.LaunchRequest}", async () =>
            {
                await Task.Run(() =>
                {
                    State.NumPlayed++;
                    State.NumPrompted = 0;

                    if (Echo.HasScreen)
                    {
                        //if (SkillSettings.ShowLogo)
                        //    // set logo page
                        //else
                        //    // set menus page
                    }

                    SetOutputSpeech();
                });
            });
        }

        private void SetOutputSpeech()
        {
            Random random = new Random();

            if (State.NumPlayed == 5 || State.NumPlayed == 10)
                Response.SetSpeech(false, false,
                    SpeechManager.GetWelcomeSpeech() + SpeechManager.GetAskReviewSpeech() + SpeechManager.GetShortHelpSpeech() + SpeechManager.GetWhatWouldYouSpeech(),
                    SpeechManager.GetShortHelpSpeech() + SpeechManager.GetWhatWouldYouSpeech());

            else if (State.NumPlayed <= 1 || random.Next(maxValue) <= 2)
                Response.SetSpeech(false, false,
                    SpeechManager.GetWelcomeSpeech() + SpeechManager.GetShortHelpSpeech() + SpeechManager.GetWhatWouldYouSpeech(),
                    SpeechManager.GetShortHelpSpeech() + SpeechManager.GetWhatWouldYouSpeech());

            else
                Response.SetSpeech(false, false,
                    SpeechManager.GetWelcomeBackSpeech() + SpeechManager.GetShortHelpSpeech() + SpeechManager.GetWhatWouldYouSpeech(),
                    SpeechManager.GetShortHelpSpeech() + SpeechManager.GetWhatWouldYouSpeech());
        }
    }
}
