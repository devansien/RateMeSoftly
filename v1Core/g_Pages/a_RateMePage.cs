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

            TouchWrapper verySadButton = AplComponentManager.GetTouchWrappedItem(verySadFace, "very_sad");
            TouchWrapper sadButton = AplComponentManager.GetTouchWrappedItem(sadFace, "sad");
            TouchWrapper neutralButton = AplComponentManager.GetTouchWrappedItem(neutralFace, "neutral");
            TouchWrapper happyButton = AplComponentManager.GetTouchWrappedItem(happyFace, "heppy");
            TouchWrapper veryHappyButton = AplComponentManager.GetTouchWrappedItem(veryHappyFace, "very_heppy");

            Container container = new Container
            {
                Direction = Style.Row,
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight()
            };

            container.Items = new List<APLComponent> { verySadButton, sadButton, neutralButton, happyButton, veryHappyButton };
            return container;
        }

        static Image GetFace(string source)
        {
            return new Image
            {
                Source = source,
                AlignSelf = Style.Center,
                Width = DisplayManager.GetWidth(0.2f),
                Height = DisplayManager.GetHeight(0.3f)
            };
        }
    }
}
