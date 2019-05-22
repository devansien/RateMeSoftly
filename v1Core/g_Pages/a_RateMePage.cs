using Alexa.NET.APL;
using Alexa.NET.APL.Components;
using Alexa.NET.Response.APL;
using System.Collections.Generic;

namespace RateMeSoftly
{
    class a_RateMePage : Core
    {
        public static Container GetPage()
        {
            Container veryBadButton = AplComponentManager.GetTouchWrappedItem(GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/1_very_bad.png"), "Very Bad", "very bad");
            Container badButton = AplComponentManager.GetTouchWrappedItem(GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/2_bad.png"), "Bad", "bad");
            Container okayButton = AplComponentManager.GetTouchWrappedItem(GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/3_ok.png"), "Ok", "ok");
            Container goodButton = AplComponentManager.GetTouchWrappedItem(GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/4_good.png"), "Good", "good");
            Container veryGoodButton = AplComponentManager.GetTouchWrappedItem(GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/5_very_good.png"), "Very Good", "very good");

            Text counter = new Text
            {
                FontSize = "70dp",
                Color = Style.White,
                Position = Style.Absolute,
                Content = State.NumPlayed.ToString(),
                Top = new AbsoluteDimension(20, "px"),
                Right = new AbsoluteDimension(30, "px")
            };

            Text firstLine = new Text
            {
                FontSize = "40dp",
                Color = Style.White,
                AlignSelf = Style.Center,
                TextAlign = Style.Center,
                Content = "We're always looking to improve",
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetHeight(0.08f)
            };

            Text secondLine = new Text
            {
                FontSize = "50dp",
                Color = Style.White,
                AlignSelf = Style.Center,
                TextAlign = Style.Center,
                Content = "Please grade today's workshop",
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetHeight(0.15f)
            };

            Container topBanner = new Container
            {
                PaddingTop = "80",
                Direction = Style.Column,
                JustifyContent = Style.Center,
                Height = DisplayManager.GetHeight(0.2f),
                Width = DisplayManager.GetMaxWidth(),
                Items = new List<APLComponent> { firstLine, secondLine }
            };

            Container buttonContainer = new Container
            {
                Direction = Style.Row,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetHeight(0.8f),
                Items = new List<APLComponent> { veryBadButton, badButton, okayButton, goodButton, veryGoodButton }
            };

            Image sonnarLogo = new Image
            {
                Position = Style.Absolute,
                Width = DisplayManager.GetWidth(0.15f),
                Height = DisplayManager.GetHeight(0.15f),
                Right = new AbsoluteDimension(0, "px"),
                Bottom = new AbsoluteDimension(30, "px"),
                Source = "https://s3.amazonaws.com/sonnar-rate-me-softly/icon_sonnar.png"
            };

            Image amazonLogo = new Image
            {
                Position = Style.Absolute,
                Width = DisplayManager.GetWidth(0.15f),
                Height = DisplayManager.GetHeight(0.15f),
                Left = new AbsoluteDimension(0, "px"),
                Bottom = new AbsoluteDimension(30, "px"),
                Source = "https://s3.amazonaws.com/sonnar-rate-me-softly/icon_amazon.png"
            };

            //Image background = new Image
            //{
            //    Position = Style.Absolute,
            //    Scale = ImageScale.BestFill,
            //    Width = DisplayManager.GetMaxWidth(),
            //    Height = DisplayManager.GetMaxHeight(),
            //    Source = "https://s3.amazonaws.com/sonnar-rate-me-softly/dark_background.jpg"
            //};

            Container container = new Container
            {
                Direction = Style.Column,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight()
            };

            container.Items = new List<APLComponent> { counter, topBanner, sonnarLogo, amazonLogo, buttonContainer };
            return container;
        }

        static Image GetFace(string source)
        {
            return new Image
            {
                Source = source,
                AlignSelf = Style.Center,
                Width = DisplayManager.GetWidth(0.15f),
                Height = DisplayManager.GetHeight(0.2f)
            };
        }
    }
}
