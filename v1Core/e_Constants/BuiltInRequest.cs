namespace RateMeSoftly
{
    class BuiltInRequest
    {
        public const string RequestHandler = "HandleRequest";

        public const string NoIntent = "AMAZON.NoIntent";
        public const string YesIntent = "AMAZON.YesIntent";

        public const string HelpIntent = "AMAZON.HelpIntent";
        public const string NextIntent = "AMAZON.NextIntent";
        public const string PreviousIntent = "AMAZON.PreviousIntent";
        public const string ResumeIntent = "AMAZON.ResumeIntent";

        public const string StopIntent = "AMAZON.StopIntent";
        public const string PauseIntent = "AMAZON.PauseIntent";
        public const string CancelIntent = "AMAZON.CancelIntent";
        public const string FallbackIntent = "AMAZON.FallbackIntent";

        public const string MoreIntent = "AMAZON.MoreIntent";
        public const string SelectIntent = "AMAZON.SelectIntent";
        public const string RepeatIntent = "AMAZON.RepeatIntent";
        public const string StartOverIntent = "AMAZON.StartOverIntent";

        public const string LoopOnIntent = "AMAZON.LoopOnIntent";
        public const string LoopOffIntent = "AMAZON.LoopOffIntent";
        public const string ShuffleOnIntent = "AMAZON.ShuffleOnIntent";
        public const string ShuffleOffIntent = "AMAZON.ShuffleOffIntent";

        public const string PageUpIntent = "AMAZON.PageUpIntent";
        public const string PageDownIntent = "AMAZON.PageDownIntent";
        public const string ScrollUpIntent = "AMAZON.ScrollUpIntent";
        public const string ScrollDownIntent = "AMAZON.ScrollDownIntent";
        public const string ScrollRightIntent = "AMAZON.ScrollRightIntent";
        public const string ScrollLeftIntent = "AMAZON.ScrollLeftIntent";

        public const string NavigateHomeIntent = "AMAZON.NavigateHomeIntent";
        public const string NavigateSettingsIntent = "AMAZON.NavigateSettingsIntent";

        public const string LaunchRequest = "LaunchRequest";
        public const string IntentRequest = "IntentRequest";
        public const string SessionEndedRequest = "SessionEndedRequest";
        public const string SystemExceptionRequest = "SystemExceptionRequest";
        public const string AplUserEventRequest = "Alexa.Presentation.APL.UserEvent";
        public const string ExceptionEncounteredRequest = "System.ExceptionEncountered";

        public const string PlaybackFailed = "AudioPlayer.PlaybackFailed";
        public const string PlaybackStarted = "AudioPlayer.PlaybackStarted";
        public const string PlaybackStopped = "AudioPlayer.PlaybackStopped";
        public const string PlaybackFinished = "AudioPlayer.PlaybackFinished";
        public const string PlaybackNearlyFinished = "AudioPlayer.PlaybackNearlyFinished";

        public const string PlayCommandIssued = "PlaybackController.PlayCommandIssued";
        public const string NextCommandIssued = "PlaybackController.NextCommandIssued";
        public const string PreviousCommandIssued = "PlaybackController.PreviousCommandIssued";
    }
}
