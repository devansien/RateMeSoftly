using System.Collections.Generic;

namespace RateMeSoftly
{
    class EnPlainSpeech
    {
        private const string WelcomeA = "Welcome to #. ";
        private const string WelcomeBackA = "Welcome back. ";
        private const string AskReviewA = "Sounds like you enjoy using #. Whenever you want, please search for # in your Alexa app, then select write a review. We always value your feedback. ";

        private const string ShortHelpA = "This is a short help speech. ";
        private const string DetailedHelpA = " This is a detailed help speech. ";
        private const string WhatWouldYouA = "What would you like to do next? ";

        private const string NotUnderstandA = "I didn't understand. Please say help for detailed instructions. ";

        private const string TryAgainA = "Please try again. ";
        private const string TryAgainB = "I suggest you to say help. ";
        private const string TryAgainC = "Perhaps, it's better for you to get some instructions by saying help. ";
        private const string TryAgainD = "I was unable to process your request. What about saying help? ";

        private const string CancelA = "Action cancled. ";

        private const string GoodbyeA = "Hope to see you soon. Goodbye. ";
        private const string GoodbyeB = "Pleasure to meet you. Goodbye. ";

        private const string ForceEndA = "Please try again later. Goodbye. ";
        private const string ForceEndB = "Please try again later, or restart the skill. Goodbye. ";

        private const string ExceptionA = "Sorry, something went wrong. Please try again later. ";
        private const string ExceptionB = "Sorry, something is not right. Please try again later. ";
        private const string ExceptionC = "Sorry, something must have happened. I suggest you to try again. ";
        private const string ExceptionD = "Sorry, something went wrong. If problem persists, please contact support. ";


        public List<string> GetWelcomeSpeeches() { return new List<string> { WelcomeA }; }
        public List<string> GetWelcomeBackSpeeches() { return new List<string> { WelcomeBackA }; }
        public List<string> GetAskReviewSpeeches() { return new List<string> { AskReviewA }; }

        public List<string> GetShortHelpSpeeches() { return new List<string> { ShortHelpA }; }
        public List<string> GetDetailedHelpSpeeches() { return new List<string> { DetailedHelpA }; }
        public List<string> GetWhatWouldYouSpeeches() { return new List<string> { WhatWouldYouA }; }

        public List<string> GetNotUnderstandSpeeches() { return new List<string> { NotUnderstandA }; }
        public List<string> GetTryAgainSpeeches() { return new List<string> { TryAgainA, TryAgainB, TryAgainC, TryAgainD }; }

        public List<string> GetCancelSpeeches() { return new List<string> { CancelA }; }
        public List<string> GetGoodbyeSpeeches() { return new List<string> { GoodbyeA, GoodbyeB }; }

        public List<string> GetForcedEndSpeeches() { return new List<string> { ForceEndA, ForceEndB }; }
        public List<string> GetExceptionSpeeches() { return new List<string> { ExceptionA, ExceptionB, ExceptionC, ExceptionD }; }
    }
}
