using System;
using System.Collections.Generic;

namespace RateMeSoftly
{
    class SpeechManager
    {
        protected const string replaceTarget = "#";
        protected static Random random = new Random();
        protected static EnPlainSpeech speech = new EnPlainSpeech();


        public static string GetWelcomeSpeech()
        {
            List<string> welcomeSpeeches = speech.GetWelcomeSpeeches();
            string welcomeSpeech = welcomeSpeeches[random.Next(welcomeSpeeches.Count)];

            int targetIndex = welcomeSpeech.IndexOf(replaceTarget);
            welcomeSpeech = welcomeSpeech.Remove(targetIndex, replaceTarget.Length).Insert(targetIndex, SkillMetadata.Name);

            return welcomeSpeech;
        }

        public static string GetWelcomeBackSpeech()
        {
            List<string> welcomeBackSpeeches = speech.GetWelcomeBackSpeeches();
            return welcomeBackSpeeches[random.Next(welcomeBackSpeeches.Count)];
        }

        public static string GetAskReviewSpeech()
        {
            List<string> reviewSpeeches = speech.GetAskReviewSpeeches();
            string reviewSpeech = reviewSpeeches[random.Next(reviewSpeeches.Count)];
            int count = CountTargetString(reviewSpeech);

            for (int i = 0; i < count; i++)
            {
                int targetIndex = reviewSpeech.IndexOf(replaceTarget);
                reviewSpeech = reviewSpeech.Remove(targetIndex, replaceTarget.Length).Insert(targetIndex, SkillMetadata.Name);
            }

            return reviewSpeech;
        }

        public static string GetShortHelpSpeech()
        {
            List<string> shortHelpSpeeches = speech.GetShortHelpSpeeches();
            return shortHelpSpeeches[random.Next(shortHelpSpeeches.Count)];
        }

        public static string GetWhatWouldYouSpeech()
        {
            List<string> whatWouldYouSpeeches = speech.GetWhatWouldYouSpeeches();
            return whatWouldYouSpeeches[random.Next(whatWouldYouSpeeches.Count)];
        }

        public static string GetNotUnderstandSpeech()
        {
            List<string> notUnderstandSpeeches = speech.GetNotUnderstandSpeeches();
            return notUnderstandSpeeches[random.Next(notUnderstandSpeeches.Count)];
        }

        public static string GetTryAgainSpeech()
        {
            List<string> tryAgainSpeeches = speech.GetTryAgainSpeeches();
            return tryAgainSpeeches[random.Next(tryAgainSpeeches.Count)];
        }

        public static string GetForcedEndSpeech()
        {
            List<string> forceEndSpeeches = speech.GetForcedEndSpeeches();
            return forceEndSpeeches[random.Next(forceEndSpeeches.Count)];
        }

        public static string GetExceptionSpeech()
        {
            List<string> exceptionSpeeches = speech.GetExceptionSpeeches();
            return exceptionSpeeches[random.Next(exceptionSpeeches.Count)];
        }

        protected static int CountTargetString(string text)
        {
            int i = 0;
            int count = 0;

            while ((i = text.IndexOf(replaceTarget, i)) != -1)
            {
                i += replaceTarget.Length;
                count++;
            }

            return count;
        }
    }
}
