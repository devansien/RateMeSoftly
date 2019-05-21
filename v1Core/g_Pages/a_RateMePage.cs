using Alexa.NET.APL.Components;
using Alexa.NET.Response.APL;
using System.Collections.Generic;

namespace RateMeSoftly
{
    class a_RateMePage
    {
        public static Container GetPage()
        {
            Image verySadFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/01_verysad.png");
            Image sadFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/02_sad.png");
            Image neutralFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/03_neutral.png");
            Image happyFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/04_happy.png");
            Image veryHappyFace = GetFace("https://s3.amazonaws.com/sonnar-rate-me-softly/05_veryhappy.png");

            Container verySadButton = AplComponentManager.GetTouchWrappedItem(verySadFace, "very_sad");
            Container sadButton = AplComponentManager.GetTouchWrappedItem(sadFace, "sad");
            Container neutralButton = AplComponentManager.GetTouchWrappedItem(neutralFace, "neutral");
            Container happyButton = AplComponentManager.GetTouchWrappedItem(happyFace, "heppy");
            Container veryHappyButton = AplComponentManager.GetTouchWrappedItem(veryHappyFace, "very_heppy");

            Image background = new Image
            {
                Source = "https://s3.amazonaws.com/sonnar-media-player/shared/white_background.jpg",
                Scale = ImageScale.BestFill,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight(),
                Position = Style.Absolute
            };

            Container container = new Container
            {
                Direction = Style.Row,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight()
            };

            container.Items = new List<APLComponent> { background, verySadButton, sadButton, neutralButton, happyButton, veryHappyButton };
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
