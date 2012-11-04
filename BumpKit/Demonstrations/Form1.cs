using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BumpKit;

namespace Demonstrations
{
    public partial class Demonstrations : Form
    {
        public Demonstrations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog { Title = "Please select an image to open:", Filter = "Jpeg|*.jpg|Jpeg|*.jpeg|Png|*.png|Bitmap|*.bmp" };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var img = Image.FromFile(dlg.FileName);

            // Scale to fit
            _scaleToFit.BackgroundImage = img.ScaleToFit(_scaleToFit.Size, false);

            // Scale to fit (overflow)
            _scaleToOverflow.BackgroundImage = img.ScaleToFit(_scaleToOverflow.Size, false, ScalingMode.Overflow);

            // Stretch to fit
            _stretch.BackgroundImage = img.Stretch(_stretch.Size, false);

            // Rotate and fit
            _rotateFit.BackgroundImage = img.ScaleToFit(_rotateFit.Size, false).Rotate(45, ScalingMode.FitContent).ScaleToFit(_rotateOverflow.Size);
            
            // Rotate and overflow
            _rotateOverflow.BackgroundImage = img.ScaleToFit(_rotateOverflow.Size, false).Rotate(45);

            // Fast pixel manipulation (UnsafeContext)
            _pixelManipulation.BackgroundImage = img.ScaleToFit(_pixelManipulation.Size, false);
            using (var context = _pixelManipulation.BackgroundImage.CreateUnsafeContext())
            {
                for (var y = 0; y < context.Height; y++)
                    for (var x = 0; x < context.Width; x++)
                    {
                        var pixel = context.GetRawPixel(x, y);
                        var level = Math.Max(pixel.Red, Math.Max(pixel.Green, pixel.Blue));
                        context.SetPixel(x, y, pixel.Alpha, level, level, level);
                    }
            }
            _pixelManipulation.Refresh();

            // Detect Edges
            var edge = new Bitmap(_edgeDetection.Width, _edgeDetection.Height);
            using (var gfx = Graphics.FromImage(edge))
            {
                gfx.DrawEllipse(Pens.Black, 25, 25, 50, 50);
                var bounds = edge.DetectPadding();
                gfx.DrawLine(Pens.Red, bounds.Left, 0, bounds.Left, edge.Height);
                gfx.DrawLine(Pens.Red, bounds.Right, 0, bounds.Right, edge.Height);
                gfx.DrawLine(Pens.Red, 0, bounds.Top, edge.Width, bounds.Top);
                gfx.DrawLine(Pens.Red, 0, bounds.Bottom, edge.Width, bounds.Bottom);
            }
            _edgeDetection.BackgroundImage = edge;

            // Create animated Gif
            var gifImage = img.ScaleToFit(_gifGeneration.Size, false);
            var gifStream = new MemoryStream(); // NOTE: Disposing this stream will break this demo - I don't know why.
            using (var encoder = new GifEncoder(gifStream))
                for (var angle = 0; angle < 360; angle += 10)
                    using (var frame = gifImage.Rotate(angle, false))
                    {
                        encoder.AddFrame(frame, 0, 0, TimeSpan.FromSeconds(0));
                    }
            gifStream.Position = 0;
            _gifGeneration.Image = Image.FromStream(gifStream);

            // Draw text with effects
            _textGen.BackgroundImage = img.ScaleToFit(_textGen.Size, false, ScalingMode.Overflow);
            using (var gfx = Graphics.FromImage(_textGen.BackgroundImage))
            {
                gfx.DrawString("A B C 1 2 3", new Font(FontFamily.Families.First(f => f.Name.Contains("Times")), 15), Brushes.Green, 15, 25, 10,
                    new[] {Color.Yellow, Color.Blue, Color.Red, Color.Green, Color.Purple, Color.Black},
                    new[] { 0, (float).20, (float).40, (float).60, (float).80, 1 });
            }
        }
    }
}
