using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace BumpKit
{
    public static class FontEffects
    {
        /// <summary>
        /// Measures a string's pixel boundaries (without the extra padding MeasureString gives). <br />
        /// NOTE: This bench tests just under 50% slower than MeasureString.
        /// </summary>
        /// <param name="gfx">The source graphics object</param>
        /// <param name="text">The text to measure</param>
        /// <param name="font">The font to measure</param>
        /// <returns></returns>
        public static RectangleF MeasureStringBoundaries(this Graphics gfx,  string text, Font font)
        {
            var rect = new RectangleF(0, 0, int.MaxValue, int.MaxValue);
            var format = new StringFormat();
            format.SetMeasurableCharacterRanges(new[] { new CharacterRange(0, text.Length) });
            var regions = gfx.MeasureCharacterRanges(text, font, rect, format);
            return regions[0].GetBounds(gfx);
        }

        /// <summary>
        /// Measures a string's pixel boundaries including border width (without the extra padding MeasureString gives). <br />
        /// NOTE: This bench tests just under 50% slower than MeasureString.
        /// </summary>
        /// <param name="gfx">The source graphics object</param>
        /// <param name="text">The text to measure</param>
        /// <param name="font">The font to measure</param>
        /// <param name="border">The intended border width</param>
        /// <returns></returns>
        public static RectangleF MeasureStringBoundaries(this Graphics gfx, string text, Font font, int border)
        {
            const float pathOffset = (float)0.97389271333939476;
            var measure = MeasureStringBoundaries(gfx, text, font);
            return new RectangleF(0, 0, (measure.Width/pathOffset + border*2)/pathOffset, measure.Height + border*2);
        }

        /// <summary>
        /// Draws text with a border.
        /// </summary>
        /// <param name="gfx">The source graphics object</param>
        /// <param name="text">The text to render</param>
        /// <param name="font">The font to render</param>
        /// <param name="brush">The brush to use for the rendered text</param>
        /// <param name="x">The x location to render the text at</param>
        /// <param name="y">The y location to render the text at</param>
        /// <param name="border">The width of the border to render in pixels</param>
        /// <param name="borderColors">A collection of colors to border should cycle through</param>
        /// <param name="colorOffsets">An index-matching collection of offsets to render the border colors at</param>
        public static void DrawString(this Graphics gfx, string text, Font font, Brush brush, int x, int y, int border, Color[] borderColors, float[] colorOffsets)
        {
            if (string.IsNullOrWhiteSpace(text))
                return;
            if (gfx == null)
                throw new ArgumentNullException("gfx");
            if (font == null)
                throw new ArgumentNullException("font");
            if (brush == null)
                throw new ArgumentNullException("brush");
            if (border <= 0)
                throw new ArgumentException("Border must be greater than 0", "border");
            if (borderColors.Length == 0)
                throw new ArgumentException("Border requires at least 1 color", "borderColors");
            if (borderColors.Length > 1 && borderColors.Length != colorOffsets.Length)
                throw new ArgumentException("A border with more than 1 color requires a matching number of offsets", "colorOffsets");
            if (colorOffsets == null || colorOffsets.Length == 0)
                colorOffsets = new[] {(float)0};

            // Organize color fades from inner to outer
            var colors = borderColors
                .Select((c, i) => new KeyValuePair<float, Color>(colorOffsets[i], c))
                .OrderBy(c => c.Key)
                .ToArray();
            // Get bordered boundaries
            var offset = gfx.MeasureStringBoundaries(text, font).Location;
            var measure = gfx.MeasureStringBoundaries(text, font, border);

            using (var workImage = new Bitmap((int)measure.Width, (int)measure.Height))
            using (var gfxWork = Graphics.FromImage(workImage))
            {
                gfxWork.PageUnit = GraphicsUnit.Point;
                gfxWork.SmoothingMode = gfx.SmoothingMode;
                var path = new GraphicsPath();
                path.AddString(text, font.FontFamily, (int) font.Style, font.Size, new PointF((border-offset.X)*(float).75, (border-offset.Y)*(float).75), StringFormat.GenericDefault);

                // Fade the border from outer to inner.
                for (var b = border; b > 0; b--)
                {
                    var colorIndex = (float) 1/border*b;
                    var colorStart = colors.Length > 1 ? colors.Last(c => c.Key <= colorIndex) : colors.First();
                    var colorEnd = colors.Length > 1 ? colors.First(c => c.Key >= colorIndex) : colors.First();
                    var colorOffset = 1/Math.Max((float).0000001, colorEnd.Key - colorStart.Key)*(colorIndex - colorStart.Key);
                    var color = colorStart.Value.FadeTo(colorEnd.Value, colorOffset);

                    const float lineWidthOffset = (float) .65; // This is approximate
                    using (var pen = new Pen(color, b/lineWidthOffset) { LineJoin = LineJoin.Round })
                        gfxWork.DrawPath(pen, path);
                }

                // Draw the text
                gfxWork.FillPath(brush, path);
                var bounds = workImage.DetectPadding();
                var offsetX = ((measure.Width - bounds.Right) - bounds.X)/2;

                // Apply the generated image
                gfx.DrawImage(workImage, x + offsetX, y);
            }
        }
    }
}
