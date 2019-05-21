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
            Image verySadFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/1_very_bad.png");
            Image sadFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/2_bad.png");
            Image neutralFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/3_ok.png");
            Image happyFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/4_good.png");
            Image veryHappyFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/5_very_good.png");

            Container verySadButton = AplComponentManager.GetTouchWrappedItem(verySadFace, "Very Bad", "very_bad");
            Container sadButton = AplComponentManager.GetTouchWrappedItem(sadFace, "Bad", "bad");
            Container neutralButton = AplComponentManager.GetTouchWrappedItem(neutralFace, "Ok", "ok");
            Container happyButton = AplComponentManager.GetTouchWrappedItem(happyFace, "Good", "good");
            Container veryHappyButton = AplComponentManager.GetTouchWrappedItem(veryHappyFace, "Very Good", "very_good");

            Text counter = new Text
            {
                Content = State.NumPlayed.ToString(),
                Color = Style.White,
                FontSize = "10dp",
                Position = Style.Absolute,
                Top = new AbsoluteDimension(20, "px"),
                Right = new AbsoluteDimension(20, "px")
            };

            Image background = new Image
            {
                Source = "https://s3.amazonaws.com/sonnar-rate-me-softly/dark_background.jpg",
                Scale = ImageScale.BestFill,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight(),
                Position = Style.Absolute
            };

            Text firstLine = new Text
            {
                FontSize = "20dp",
                Color = Style.White,
                Content = "We're always looking to improve",
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetHeight(0.1f),
                AlignSelf = Style.Center,
                TextAlign = Style.Center
            };

            Text secondLine = new Text
            {
                FontSize = "20dp",
                Color = Style.White,
                Content = "Pleae grade today's workshop",
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetHeight(0.1f),
                AlignSelf = Style.Center,
                TextAlign = Style.Center
            };

            Container topBanner = new Container
            {
                PaddingTop = "50",
                JustifyContent = Style.Center,
                Height = DisplayManager.GetHeight(0.2f),
                Width = DisplayManager.GetMaxWidth(),
                Direction = Style.Column,
                Items = new List<APLComponent> { firstLine, secondLine }
            };


            Container buttonContainer = new Container
            {
                Direction = Style.Row,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetHeight(0.8f),
                Items = new List<APLComponent> { verySadButton, sadButton, neutralButton, happyButton, veryHappyButton }
            };

            Container container = new Container
            {
                Direction = Style.Column,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight()
            };

            container.Items = new List<APLComponent> { background, counter, topBanner, buttonContainer };
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
