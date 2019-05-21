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
                Content = "Thank you for your participation",
                FontSize = "40dp",
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight(),
                Color = Style.White,
                AlignSelf = Style.Center,
                TextAlign = Style.Center,
                TextAlignVertical = Style.Center
            };

            Container container = new Container
            {
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight(),
                JustifyContent = Style.Center,
                Items = new List<APLComponent> { thankYouText }
            };

            return container;
        }
    }
}
