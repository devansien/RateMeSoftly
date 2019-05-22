using Alexa.NET.APL.Commands;
using Alexa.NET.APL.Components;
using Alexa.NET.Response.APL;
using System.Collections.Generic;
using System.Linq;

namespace RateMeSoftly
{
    class AplComponentManager
    {
        public static Container GetTouchWrappedItem(APLComponent component, string text, string arg)
        {
            Text label = new Text
            {
                Content = text,
                FontSize = "35dp",
                Color = Style.White,
                AlignSelf = Style.Center,
                TextAlign = Style.Center,
                TextAlignVertical = Style.Center,
                Width = DisplayManager.GetWidth(0.15f),
                Height = DisplayManager.GetHeight(0.15f)
            };

            TouchWrapper touchWrapper = new TouchWrapper
            {
                OnPress = new SendEvent
                {
                    Arguments = new List<string> { arg }
                },
                AlignSelf = Style.Center
            };

            List<APLComponent> components = new List<APLComponent> { component };
            touchWrapper.Item = components;

            Container touchContainer = new Container
            {
                Direction = Style.Column,
                Width = DisplayManager.GetWidth(0.2f),
                Height = DisplayManager.GetHeight(0.5f),
                Items = new List<APLComponent> { touchWrapper, label }
            };

            Container container = new Container
            {
                AlignSelf = Style.Center,
                AlignItems = Style.Center,
                JustifyContent = Style.Center,
                Width = DisplayManager.GetWidth(0.2f),
                Height = DisplayManager.GetMaxHeight(),
                Items = new List<APLComponent> { touchContainer }
            };

            return container;
        }
    }
}
