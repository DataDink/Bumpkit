Bumpkit (1.0.0 Documentation)
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

-- Full documentation comming soon --