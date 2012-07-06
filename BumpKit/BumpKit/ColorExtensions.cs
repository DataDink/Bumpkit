using System;
using System.Drawing;

namespace BumpKit
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Compares a pixel and color and determines equality.
        /// </summary>
        public static bool EqualsColor(this UnsafeBitmapContext.Pixel pixel, Color color)
        {
            return (color.A == 0 && pixel.Alpha == 0) 
                || (color.A == pixel.Alpha && color.R == pixel.Red && color.G == pixel.Green && color.B == pixel.Blue);
        }

        /// <summary>
        /// Compares a pixel and color and determines equality.
        /// </summary>
        public static bool EqualsPixel(this Color color, UnsafeBitmapContext.Pixel pixel)
        {
            return pixel.EqualsColor(color);
        }

        /// <summary>
        /// Creates a fade to a target color by percentage
        /// </summary>
        /// <param name="from">The source color</param>
        /// <param name="to">The target color</param>
        /// <param name="fade">The amount of the fade from 0 to 1</param>
        /// <returns></returns>
        public static Color FadeTo(this Color from, Color to, float fade)
        {
            return Color.FromArgb((int) Math.Min(255, Math.Max(0, from.A + (to.A - from.A)*fade)),
                                  (int) Math.Min(255, Math.Max(0, from.R + (to.R - from.R)*fade)),
                                  (int) Math.Min(255, Math.Max(0, from.G + (to.G - from.G)*fade)),
                                  (int) Math.Min(255, Math.Max(0, from.B + (to.B - from.B)*fade)));
        }
    }
}
