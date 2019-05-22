using Alexa.NET.APL;
using Alexa.NET.APL.Components;
using Alexa.NET.Response.APL;
using System.Collections.Generic;

namespace RateMeSoftly
{
    class b_ThankYouPage
    {
        public static Container GetPage()
        {
            Text thankYouText = new Text
            {
                FontSize = "70dp",
                Color = Style.White,
                AlignSelf = Style.Center,
                TextAlign = Style.Center,
                TextAlignVertical = Style.Center,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight(),
                PaddingBottom = new AbsoluteDimension(50, "px"),
                Content = "Thank you for your participation"
            };

            Container container = new Container
            {
                JustifyContent = Style.Center,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight(),
                Items = new List<APLComponent> { thankYouText }
            };

            return container;
        }
    }
}
