Bumpkit (1.0.1 Documentation)
=============================

by Mark Nelson

This is a .NET library that extends the System.Drawing GDI libraries.
Useful for on-the-fly image generation in .NET-based web applications.

Features:
---------
* Image sizing/scaling extensions
* Image rotation extensions
* Lightning-fast pixel manipulation
* Animated GIF generation (utilizes native gif encoding)
* Font bordering and glow effects (DrawString on steroids)
* Other extensions (Point, Color, etc)

Scaling:
--------
`System.Drawing.Image.ScaleToFit(...)`
* Resize images with a single extension method
* Maintain image aspect ratio sizing to a height or width or confine to a boundary

Rotation:
---------
`System.Drawing.Image.Rotate(...)`
* Rotate images with a single extension method
* Maintain image centering to boundaries and scale to fit or maintain sizing ratio

Fast Pixel Access:
------------------
`System.Drawing.Image.CreateUnsafeContext()`
* Provides access to an Image's pixels in a locked session
* Allows lightning-fast custom image manipulation
* Provides direct memory access wrapped in a light-weight disposable context

Animated GIF Generation:
------------------------
`BumpKit.GifEncoder`
* Formats multiple images/frames into a single animated GIF file
* Utilizes native .NET GIF encoding (simply adds missing animation file-headers)
* Fast (relative to other GIF libraries)

Font Effects:
-------------
`System.Drawing.Graphics.DrawString(text, font, brush, x, y, border, borderColors, colorOffsets)`
* Utilizes native .NET font processing
* Fast effect generation
* Flexible API implementation

Samples:
--------
**Scaling an image to fit a specified size maintaining scale ratio**
<pre>var scaledImage = Image.FromFile("").ScaleToFit(new Size(100, 100));</pre>

**Scaling an image to "overflow" or "cover" a specified size maintaining scale ratio**
<pre>var scaledImage = Image.FromFile("").ScaleToFit(new Size(100, 100), ScalingMode.Overflow);</pre>

**Scaling an image without disposing the original image**
<pre>var img = Image.FromFile("");
var scaledImage = img.ScaleToFit(new Size(100, 100), false);
var scaledImage2 = img.ScaleToFit(new Size(100, 100), false, ScalingMode.Overflow);</pre>

**Stretching an image to fit a specified size**
<pre>var stretchedImage = Image.FromFile("").Stretch(new Size(100, 100));</pre>

**Rotating an image**
<pre>var rotationOverflow = Image.FromFile("").Rotate(45);
var rotationFit = Image.FromFile("").Rotate(45, ScalingMode.FitContent); // scales down to fit corner content</pre>

**Detecting Image Edges (finding the crop points)**
<pre>var pixelBoundary = Image.FromFile("").DetectPadding(); // you can also specify the background color if it is not transparent</pre>

**Direct Memory Access (reading/writing pixels quickly)**
<pre>// NOTE: This locks and accesses the bitmap's unmanaged memory. This is NOT thread-safe.
var image = Image.FromFile("");
using (var context = image.CreateUnsafeContext())
{
	for (var x = 0; x &lt; context.Width; x++)
		for (var y = 0; y &lt; context.Height; y++)
		{
			var pixel = context.GetRawPixel(x, y);
			var average = Convert.ToByte((pixel.Red + pixel.Green + pixel.Blue)/3d);
			context.SetPixel(x, y, pixel.Alpha, average, average, average);
		}
}</pre>

**Animated Gif Encoding**
<pre>using (var image = Image.FromFile(""))
using (var gif = File.OpenWrite(""))
using (var encoder = new GifEncoder(gif))
	for (var i = 0; i &lt; 360; i += 10)
		using (var frame = image.Rotate(i, false))
		{
			encoder.AddFrame(frame);
		}</pre>
		
**Font Borders**
<pre>var img = new Bitmap(600, 200);
using (var gfx = Graphics.FromImage(img))
using (var font = new Font(SystemFonts.DefaultFont.FontFamily, 50))
{
	gfx.SmoothingMode = SmoothingMode.AntiAlias;
	gfx.DrawString("ABCabc123", font, Brushes.Black, 0, 0, 50,
		new[] {Color.Red, Color.Green, Color.Blue},
		new[] {0f, 0.5f, 1f});
}</pre>