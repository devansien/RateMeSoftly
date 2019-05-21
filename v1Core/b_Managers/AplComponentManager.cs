using Alexa.NET.APL.Commands;
using Alexa.NET.APL.Components;
using Alexa.NET.Response.APL;
using System.Collections.Generic;
using System.Linq;

namespace RateMeSoftly
{
    class AplComponentManager
    {
        public static Container GetTouchWrappedItem(APLComponent component, params string[] args)
        {
            List<string> arguments = new List<string>();

            if (arguments != null && arguments.Any())
                arguments = args.ToList();

            TouchWrapper touchWrapper = new TouchWrapper
            {
                OnPress = new SendEvent
                {
                    Arguments = arguments
                },
                AlignSelf = Style.Center
            };

            List<APLComponent> components = new List<APLComponent> { component };
            touchWrapper.Item = components;

            Container container = new Container
            {
                AlignSelf = Style.Center,
                AlignItems = Style.Center,
                JustifyContent = Style.Center,
                Width = DisplayManager.GetWidth(0.2f),
                Height = DisplayManager.GetMaxHeight(),
                Items = new List<APLComponent> { touchWrapper }
            };

            return container;
        }
    }
}
