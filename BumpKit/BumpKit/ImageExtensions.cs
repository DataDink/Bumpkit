using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BumpKit
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Provides quick but unsafe access to this image's pixels. <br />
        /// ALWAYS ALWAYS ALWAYS wire this in a using block. <br />
        /// DO NOT EVER access the bitmap directly while in this unsafe context. <br />
        /// </summary>
        public static UnsafeBitmapContext CreateUnsafeContext(this Image image)
        {
            return new UnsafeBitmapContext(image);
        }

        /// <summary>
        /// Detects the widest and tallest pixels to determine the image padding based on the optional background color.
        /// </summary>
        /// <param name="image">The original image</param>
        /// <param name="backgroundColor">Specifies a background color for this image or transparent by default.</param>
        /// <returns>A rectangle containing the borders of this image's content.</returns>
        public static Rectangle DetectPadding(this Image image, Color backgroundColor = default(Color))
        {
            if (backgroundColor.IsEmpty)
                backgroundColor = Color.Transparent;

            var top = image.Height;
            var bottom = 0;
            var left = image.Width;
            var right = 0;
            var width = image.Width - 1;
            var height = image.Height - 1;
            using (var context = new UnsafeBitmapContext(image))
            {
                for (int y = 0; y < context.Height; y++)
                    for (int x = 0; x < context.Width; x++)
                    {
                        if (width - right <= x && left <= x && height - bottom <= y)
                            break;
                        if (x < left && !context.GetRawPixel(x, y).EqualsColor(backgroundColor))
                        {
                            if (y < top) { top = y; }
                            left = x;
                        }
                        if (x < width - right && !context.GetRawPixel(width - x, y).EqualsColor(backgroundColor))
                        {
                            if (y < top) { top = y; }
                            right = width - x;
                        }
                        if (y < height - bottom && !context.GetRawPixel(x, height - y).EqualsColor(backgroundColor))
                        {
                            bottom = height - y;
                        }
                    }
            }
            width = Math.Max(0, right - left);
            height = Math.Max(0, bottom - top);
            return new Rectangle(left, top, width, height);
        }

        /// <summary>
        /// Clones this image scaled to fit the specified size.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <param name="size">The size to scale the clone to.</param>
        /// <param name="mode">FitToContent will scale the content to be completely contained in the specified size. <br />
        /// Overflow will maximize the image to completely fill the specified size, clipping excess content.</param>
        /// <returns>A clone of this image scaled to the specified size.</returns>
        public static Image ScaleToFit(this Image image, Size size, ScalingMode mode = ScalingMode.FitContent)
        {
            return image.ScaleToFit(size, default(Color), true, mode);
        }

        /// <summary>
        /// Clones this image scaled to fit the specified size.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <param name="size">The size to scale the clone to.</param>
        /// <param name="backgroundColor">The color to fill unused image space with.</param>
        /// <param name="mode">FitToContent will scale the content to be completely contained in the specified size. <br />
        /// Overflow will maximize the image to completely fill the specified size, clipping excess content.</param>
        /// <returns>A clone of this image scaled to the specified size.</returns>
        public static Image ScaleToFit(this Image image, Size size, Color backgroundColor, ScalingMode mode = ScalingMode.FitContent)
        {
            return image.ScaleToFit(size, backgroundColor, true, mode);
        }

        /// <summary>
        /// Clones this image scaled to fit the specified size.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <param name="size">The size to scale the clone to.</param>
        /// <param name="dispose">If true, disposes this image upon cloning.</param>
        /// <param name="mode">FitToContent will scale the content to be completely contained in the specified size. <br />
        /// Overflow will maximize the image to completely fill the specified size, clipping excess content.</param>
        /// <returns>A clone of this image scaled to the specified size.</returns>
        public static Image ScaleToFit(this Image image, Size size, bool dispose, ScalingMode mode = ScalingMode.FitContent)
        {
            return image.ScaleToFit(size, default(Color), dispose, mode);
        }

        /// <summary>
        /// Clones this image scaled to fit the specified size.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <param name="size">The size to scale the clone to.</param>
        /// <param name="backgroundColor">The color to fill unused image space with.</param>
        /// <param name="dispose">If true, disposes this image upon cloning.</param>
        /// <param name="mode">FitToContent will scale the content to be completely contained in the specified size. <br />
        /// Overflow will maximize the image to completely fill the specified size, clipping excess content.</param>
        /// <returns>A clone of this image scaled to the specified size.</returns>
        public static Image ScaleToFit(this Image image, Size size, Color backgroundColor, bool dispose = true, ScalingMode mode = ScalingMode.FitContent)
        {
            var widthRatio = (double) size.Width/image.Width;
            var heightRatio = (double) size.Height/image.Height;
            var scaleRatio = mode == ScalingMode.Overflow
                                 ? Math.Max(widthRatio, heightRatio)
                                 : Math.Min(widthRatio, heightRatio);
            var width = image.Width*scaleRatio;
            var height = image.Height*scaleRatio;

            var newImage = new Bitmap(size.Width, size.Height);
            using (var gfx = Graphics.FromImage(newImage))
            {
                if (!backgroundColor.IsEmpty)
                    gfx.Clear(backgroundColor);
                gfx.DrawImage(image, 
                    (float)((newImage.Width - width) / 2), (float)((newImage.Height - height) / 2),
                    (float)width, (float)height);
            }
            if (dispose) image.Dispose();
            return newImage;
        }

        /// <summary>
        /// Clones this image stretched to the specified size.
        /// </summary>
        /// <param name="image">The original image.</param>
        /// <param name="size">The size to stretch the clone to.</param>
        /// <param name="dispose">If true, disposes this image upon cloning.</param>
        /// <returns>A clone of this image streched to the specified size.</returns>
        public static Image Stretch(this Image image, Size size, bool dispose = true)
        {
            var newImage = new Bitmap(size.Width, size.Height);
            using (var gfx = Graphics.FromImage(newImage))
            {
                gfx.DrawImage(image, 0, 0, size.Width, size.Height);
            }
            if (dispose) image.Dispose();
            return newImage;
        }

        /// <summary>
        /// Clones this image with the specified rotation.
        /// </summary>
        /// <param name="image">The original image</param>
        /// <param name="angle">The angle to rotate the image</param>
        /// <param name="mode">FitToContent will resize the clone accordingly to fit the rotated content. <br />
        /// Overflow will maintain the original size and clip content.</param>
        /// <returns>A clone of this image with the specified rotation.</returns>
        public static Image Rotate(this Image image, double angle, ScalingMode mode = ScalingMode.Overflow)
        {
            return image.Rotate(angle, true, mode);
        }

        /// <summary>
        /// Clones this image with the specified rotation.
        /// </summary>
        /// <param name="image">The original image</param>
        /// <param name="angle">The angle to rotate the image</param>
        /// <param name="dispose">If true, disposes this image upon cloning.</param>
        /// <param name="mode">FitToContent will resize the clone accordingly to fit the rotated content. <br />
        /// Overflow will maintain the original size and clip content.</param>
        /// <returns>A clone of this image with the specified rotation.</returns>
        public static Image Rotate(this Image image, double angle, bool dispose, ScalingMode mode = ScalingMode.Overflow)
        {
            var width = image.Width;
            var height = image.Height;
            if (mode == ScalingMode.FitContent)
            {
                var o = angle%180;
                var d = Math.Sqrt(Math.Pow(image.Width, 2) + Math.Pow(image.Height, 2));
                var a = (Math.Atan((double) image.Height/image.Width)*180/Math.PI) + (o > 90 ? 180 - o : o);
                height = (int)(Math.Sin(a * Math.PI / 180) * d);
                a = (Math.Atan((double) -image.Height/image.Width)*180/Math.PI) + (o > 90 ? 180 - o : o);
                width = (int)(Math.Cos(a * Math.PI / 180) * d);
            }
            var newImage = new Bitmap(width, height);
            using (var gfx = Graphics.FromImage(newImage))
            {
                gfx.TranslateTransform(-image.Width/(float)2, -image.Height/(float)2, MatrixOrder.Prepend);
                gfx.RotateTransform((float)angle, MatrixOrder.Append);
                gfx.TranslateTransform(newImage.Width/(float)2, newImage.Height/(float)2, MatrixOrder.Append);
                gfx.DrawImage(image, 0, 0);
            }
            if (dispose) image.Dispose();
            return newImage;
        }
    }
}
