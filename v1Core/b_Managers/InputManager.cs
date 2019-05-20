using Alexa.NET.Request;
using System;

namespace RateMeSoftly
{
    class InputManager : Core
    {
        public static string GetInputValue(Slot slot)
        {
            string value;

            if (!string.IsNullOrEmpty(slot.Value))
            {
                Utterance utterance = new Utterance { Input = slot.Value, Time = DateTime.UtcNow };
                State.Utterances.Add(utterance);
            }

            try
            {
                ResolutionAuthority[] resolution = slot.Resolution.Authorities;
                ResolutionValueContainer[] container = resolution[0].Values;
                value = container[0].Value.Name;
                Logger.Write($"Processed input value from user: [{value}]");

                return value;
            }
            catch
            {
                value = slot.Value;
                Logger.Write($"Raw input value from user: [{value}]");

                return value;
            }
        }
    }
}
