using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public class SystemDrawingAlphaBlending
{

    // 8f2508af-f495-4223-b5cc-646cbbb520eb
    // How to: Draw Opaque and Semitransparent Lines

    public void Method11(PaintEventArgs e)
    {
        // <snippet11>
        Bitmap bitmap = new Bitmap("Texture1.jpg");
        e.Graphics.DrawImage(bitmap, 10, 5, bitmap.Width, bitmap.Height);

        Pen opaquePen = new Pen(Color.FromArgb(255, 0, 0, 255), 15);
        Pen semiTransPen = new Pen(Color.FromArgb(128, 0, 0, 255), 15);

        e.Graphics.DrawLine(opaquePen, 0, 20, 100, 20);
        e.Graphics.DrawLine(semiTransPen, 0, 40, 100, 40);

        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
        e.Graphics.DrawLine(semiTransPen, 0, 60, 100, 60);
        // </snippet11>
    }
    // a27121e6-f7e9-4c09-84e2-f05aa9d2a1bb
    // How to: Use a Color Matrix to Set Alpha Values in Images

    public void Method21(PaintEventArgs e)
    {
        // <snippet21>
        // Create the Bitmap object and load it with the texture image.
        Bitmap bitmap = new Bitmap("Texture.jpg");

        // Initialize the color matrix.
        // Note the value 0.8 in row 4, column 4.
        float[][] matrixItems ={ 
           new float[] {1, 0, 0, 0, 0},
           new float[] {0, 1, 0, 0, 0},
           new float[] {0, 0, 1, 0, 0},
           new float[] {0, 0, 0, 0.8f, 0}, 
           new float[] {0, 0, 0, 0, 1}};
        ColorMatrix colorMatrix = new ColorMatrix(matrixItems);

        // Create an ImageAttributes object and set its color matrix.
        ImageAttributes imageAtt = new ImageAttributes();
        imageAtt.SetColorMatrix(
           colorMatrix,
           ColorMatrixFlag.Default,
           ColorAdjustType.Bitmap);

        // First draw a wide black line.
        e.Graphics.DrawLine(
           new Pen(Color.Black, 25),
           new Point(10, 35),
           new Point(200, 35));

        // Now draw the semitransparent bitmap image.
        int iWidth = bitmap.Width;
        int iHeight = bitmap.Height;
        e.Graphics.DrawImage(
           bitmap,
           new Rectangle(30, 0, iWidth, iHeight),  // destination rectangle
           0.0f,                          // source rectangle x 
           0.0f,                          // source rectangle y
           iWidth,                        // source rectangle width
           iHeight,                       // source rectangle height
           GraphicsUnit.Pixel,
           imageAtt);
        // </snippet21>
    }
    // a4f6f6b8-3bc8-440a-84af-d62ef0f8ff40
    // How to: Draw with Opaque and Semitransparent Brushes

    public void Method31(PaintEventArgs e)
    {
        // <snippet31>
        Bitmap bitmap = new Bitmap("Texture1.jpg");
        e.Graphics.DrawImage(bitmap, 50, 50, bitmap.Width, bitmap.Height);

        SolidBrush opaqueBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
        SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 255));

        e.Graphics.FillEllipse(opaqueBrush, 35, 45, 45, 30);
        e.Graphics.FillEllipse(semiTransBrush, 86, 45, 45, 30);

        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
        e.Graphics.FillEllipse(semiTransBrush, 40, 90, 86, 30);
        // </snippet31>
    }
    // f331df2d-b395-4b0a-95be-24fec8c9bbb5
    // How to: Use Compositing Mode to Control Alpha Blending

    public void Method41()
    {
        Bitmap myBitmap = new Bitmap(180, 100);

        // Create a Graphics object that we can use to draw on the bitmap.
        Graphics bitmapGraphics = Graphics.FromImage(myBitmap);

        // <snippet41>
        bitmapGraphics.CompositingMode = CompositingMode.SourceCopy;
        // </snippet41>
    }
    public void Method42()
    {
        Bitmap myBitmap = new Bitmap(180, 100);

        // Create a Graphics object that we can use to draw on the bitmap.
        Graphics bitmapGraphics = Graphics.FromImage(myBitmap);

        // <snippet42>
        bitmapGraphics.CompositingMode = CompositingMode.SourceOver;
        // </snippet42>
    }
    public void Method43(PaintEventArgs e)
    {
        // <snippet43>
        // Create a blank bitmap.
        Bitmap myBitmap = new Bitmap(180, 100);

        // Create a Graphics object that we can use to draw on the bitmap.
        Graphics bitmapGraphics = Graphics.FromImage(myBitmap);

        // Create a red brush and a green brush, each with an alpha value of 160.
        SolidBrush redBrush = new SolidBrush(Color.FromArgb(160, 255, 0, 0));
        SolidBrush greenBrush = new SolidBrush(Color.FromArgb(160, 0, 255, 0));

        // Set the compositing mode so that when we draw overlapping ellipses,
        // the colors of the ellipses are not blended.
        bitmapGraphics.CompositingMode = CompositingMode.SourceCopy;

        // Fill an ellipse using a red brush that has an alpha value of 160.
        bitmapGraphics.FillEllipse(redBrush, 0, 0, 150, 70);

        // Fill a second ellipse using a green brush that has an alpha value of 160. 
        // The green ellipse overlaps the red ellipse, but the green is not 
        // blended with the red.
        bitmapGraphics.FillEllipse(greenBrush, 30, 30, 150, 70);

        // Set the compositing quality of the form's Graphics object. 
        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;

        // Draw a multicolored background.
        SolidBrush colorBrush = new SolidBrush(Color.Aqua);
        e.Graphics.FillRectangle(colorBrush, 200, 0, 60, 100);
        colorBrush.Color = Color.Yellow;
        e.Graphics.FillRectangle(colorBrush, 260, 0, 60, 100);
        colorBrush.Color = Color.Fuchsia;
        e.Graphics.FillRectangle(colorBrush, 320, 0, 60, 100);

        // Display the bitmap on a white background.
        e.Graphics.DrawImage(myBitmap, 0, 0);

        // Display the bitmap on a multicolored background.
        e.Graphics.DrawImage(myBitmap, 200, 0);
        // </snippet43>
    }
}

