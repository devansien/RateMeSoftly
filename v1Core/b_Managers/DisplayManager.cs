using System;

namespace RateMeSoftly
{
    class DisplayManager : Core
    {
        public static float DeviceHeight { get; set; } = 1080f;


        public static string GetWidth(float percentage)
        {
            return Math.Round(percentage * Echo.Viewport.PixelWidth) + "px";
        }

        public static string GetHeight(float percentage)
        {
            return Math.Round(percentage * Echo.Viewport.PixelHeight) + "px";
        }

        public static string GetWidth(float imageWidth, float imageHeight)
        {
            float ratio = imageHeight / DeviceHeight;
            float scaledImageHeight = ratio * Echo.Viewport.PixelHeight;
            float widthToHeight = imageWidth / imageHeight;

            return Math.Round(widthToHeight * scaledImageHeight) + "px";
        }

        public static string GetHeight(float imageWidth, float imageHeight)
        {
            float ratio = imageHeight / DeviceHeight;
            return GetHeight(ratio);
        }

        public static int GetPixelWidth(float percentage)
        {
            return (int)Math.Round(percentage * Echo.Viewport.PixelWidth);
        }

        public static int GetPixelHeight(float percentage)
        {
            return (int)Math.Round(percentage * Echo.Viewport.PixelHeight);
        }

        public static int GetPixelWidth(float imageWidth, float imageHeight)
        {
            float ratio = imageHeight / DeviceHeight;
            float scaledImageHeight = ratio * Echo.Viewport.PixelHeight;
            float widthToHeight = imageWidth / imageHeight;

            return (int)Math.Round(widthToHeight * scaledImageHeight);
        }

        public static int GetPixelHeight(float imageWidth, float imageHeight)
        {
            float ratio = imageHeight / DeviceHeight;
            return (int)Math.Round(ratio * Echo.Viewport.PixelHeight);
        }

        public static string GetMaxWidth()
        {
            return Math.Round((decimal)Echo.Viewport.PixelWidth) + "px";
        }

        public static string GetMaxHeight()
        {
            return Math.Round((decimal)Echo.Viewport.PixelHeight) + "px";
        }
    }
}
