using Alexa.NET.APL.Components;
using Alexa.NET.Response.APL;
using System.Collections.Generic;

namespace RateMeSoftly
{
    class a_RateMePage
    {
        public static Container GetPage()
        {
            Image verySadFace = GetFace("");
            Image sadFace = GetFace("");
            Image nuetralFace = GetFace("");
            Image happyFace = GetFace("");
            Image veryHappyFace = GetFace("");

            Container container = new Container
            {
                Width = DisplayManager.GetMaxWidth(),
                Height = DisplayManager.GetMaxHeight()
            };

            container.Items = new List<APLComponent> { verySadFace, sadFace, nuetralFace, happyFace, veryHappyFace };
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
