using System.Collections.Generic;

namespace RateMeSoftly
{
    class StateManager : Core
    {
        public static void InitState()
        {
            State.NumPrompted = 0;
        }

        public static State ValidateState(string userId, State save)
        {
            if (save == null)
                save = GetDefaultState(userId);

            return save;
        }

        public static State GetDefaultState(string userId)
        {
            State state = new State()
            {
                UserId = userId,
                Ok = 0,
                Bad = 0,
                Good = 0,
                VeryBad = 0,
                VeryGood = 0,
                NumPlayed = 0,
                NumPrompted = 0,
                Utterances = new List<Utterance>()
            };

            return state;
        }
    }
}
