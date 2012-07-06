using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace BumpKit
{
    /// <summary>
    /// Provides quick but unsafe access to a bitmap's bits. <br />
    /// ALWAYS ALWAYS ALWAYS wire this in a using block. <br />
    /// DO NOT EVER access the bitmap directly while in this unsafe context. <br />
    /// </summary>
    public sealed unsafe class UnsafeBitmapContext : IDisposable
    {
        private Stream _originalStream;
        private Bitmap _bitmap;
        private BitmapData _lockData;
        private Byte* _ptrBase;
        private int _pixelWidth;

        public int Width { get; private set; }
        public int Height { get; private set; }

        /// <summary>
        /// Provides quick but unsafe access to a bitmap's bits. <br />
        /// ALWAYS ALWAYS ALWAYS wire this in a using block. <br />
        /// DO NOT EVER access the bitmap directly while in this unsafe context. <br />
        /// </summary>
        /// <param name="bitmap">The bitmap to access</param>
        public UnsafeBitmapContext(Bitmap bitmap)
        {
            _bitmap = bitmap;
            LockBits();
        }

        /// <summary>
        /// Provides quick but unsafe access to a bitmap's bits. <br />
        /// ALWAYS ALWAYS ALWAYS wire this in a using block. <br />
        /// DO NOT EVER access the bitmap directly while in this unsafe context. <br />
        /// </summary>
        /// <param name="image">The bitmap to access</param>
        public UnsafeBitmapContext(Image image)
        {
            if (!(image is Bitmap))
            {
                throw new ArgumentException("Image must be convertable to a bitmap.");
            }
            _bitmap = (Bitmap) image;
            LockBits();
        }

        /// <summary>
        /// Provides quick but unsafe access to a bitmap's bits. <br />
        /// The stream will be updated upon disposal. <br />
        /// ALWAYS ALWAYS ALWAYS wire this in a using block. <br />
        /// DO NOT EVER access the bitmap directly while in this unsafe context. <br />
        /// </summary>
        /// <param name="stream">The stream to read and write to.</param>
        public UnsafeBitmapContext(Stream stream)
        {
            try
            {
                _originalStream = stream;
                stream.Position = 0;
                _bitmap = (Bitmap)Image.FromStream(stream);
            }
            catch { throw new ArgumentException("Stream did not contain a valid image format."); }
            LockBits();
        }

        private void LockBits()
        {
            Width = _bitmap.Width;
            Height = _bitmap.Height;
            _pixelWidth = sizeof (Pixel);
            _lockData = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            _ptrBase = (Byte*)_lockData.Scan0.ToPointer();
        }

        public void Dispose()
        {
            _bitmap.UnlockBits(_lockData);
            _lockData = null;
            if (_originalStream != null)
            {
                _originalStream.SetLength(0);
                _originalStream.Position = 0;
                _bitmap.Save(_originalStream, _bitmap.RawFormat);
                _bitmap.Dispose();
                _originalStream.Position = 0;
            }
            _originalStream = null;
            _bitmap = null;
        }

        /// <summary>
        /// Access a pixel from the bitmap's memory (slower than GetRawPixel)
        /// </summary>
        public Color GetPixel(int x, int y)
        {
            var pixel = GetRawPixel(x, y);
            return Color.FromArgb(pixel.Alpha, pixel.Red, pixel.Green, pixel.Blue);
        }

        /// <summary>
        /// Access a pixel from the bitmap's memory (faster than GetPixel) <br />
        /// </summary>
        public Pixel GetRawPixel(int x, int y)
        {
            return *Pointer(x, y);
        }

        /// <summary>
        /// Replace a pixel in the bitmap's memory (slower than by bytes)
        /// </summary>
        public void SetPixel(int x, int y, Color color)
        {
            SetPixel(x, y, color.A, color.R, color.G, color.B);
        }

        /// <summary>
        /// Replace a pixel in the bitmap's memory (faster than by Color)
        /// </summary>
        public void SetPixel(int x, int y, byte alpha, byte red, byte green, byte blue)
        {
            var pixel = Pointer(x, y);
            (*pixel).Alpha = alpha;
            (*pixel).Red = red;
            (*pixel).Green = green;
            (*pixel).Blue = blue;
        }

        private Pixel* Pointer(int x, int y)
        {
            if (x >= Width || x < 0 || y >= Height || y < 0)
            {
                Dispose();
                throw new ArgumentException("The X and Y parameters must be within the scope of the image pixel ranges.");
            }
            return (Pixel*) (_ptrBase + y*_lockData.Stride + x*_pixelWidth);
        }

        /// <summary>
        /// Represents raw pixel data.
        /// </summary>
        public struct Pixel
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }
    }
}
