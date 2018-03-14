using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Imaging;

public class Form1 : Form
{
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    // 09f0c07a-19c0-43b4-90a2-862a10545ce8
    // Drawing, Positioning, and Cloning Images in GDI+
   
    public void Method11()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet11>
        Bitmap myBitmap = new Bitmap("Climber.jpg");
        myGraphics.DrawImage(myBitmap, 10, 10);
        // </snippet11>
    }
    public void Method12()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet12>
        Bitmap myBMP = new Bitmap("SpaceCadet.bmp");
        Bitmap myGIF = new Bitmap("Soda.gif");
        Bitmap myJPEG = new Bitmap("Mango.jpg");
        Bitmap myPNG = new Bitmap("Flowers.png");
        Bitmap myTIFF = new Bitmap("MS.tif");

        myGraphics.DrawImage(myBMP, 10, 10);
        myGraphics.DrawImage(myGIF, 220, 10);
        myGraphics.DrawImage(myJPEG, 280, 10);
        myGraphics.DrawImage(myPNG, 150, 200);
        myGraphics.DrawImage(myTIFF, 300, 200);
        // </snippet12>
    }
    public void Method13()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet13>
        Bitmap originalBitmap = new Bitmap("Spiral.png");
        Rectangle sourceRectangle = new Rectangle(0, 0, originalBitmap.Width,
           originalBitmap.Height / 2);

        Bitmap secondBitmap = originalBitmap.Clone(sourceRectangle,
           PixelFormat.DontCare);

        myGraphics.DrawImage(originalBitmap, 10, 10);
        myGraphics.DrawImage(secondBitmap, 150, 10);
        // </snippet13>
    }
    // 51da872c-c783-440f-8bf6-1e580a966c31
    // Metafiles in GDI+

    // <snippet21>
    public void Example_DisplayMetafile(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        Metafile myMetafile = new Metafile("SampleMetafile.emf");
        myGraphics.DrawImage(myMetafile, 100, 100);
    }
    // </snippet21>
    // ad5daf26-005f-45bc-a2af-e0e97777a21a
    // Cropping and Scaling Images in GDI+

    public void Method31()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet31>
        Bitmap myBitmap = new Bitmap("Spiral.png");

        Rectangle expansionRectangle = new Rectangle(135, 10,
           myBitmap.Width, myBitmap.Height);

        Rectangle compressionRectangle = new Rectangle(300, 10,
           myBitmap.Width / 2, myBitmap.Height / 2);

        myGraphics.DrawImage(myBitmap, 10, 10);
        myGraphics.DrawImage(myBitmap, expansionRectangle);
        myGraphics.DrawImage(myBitmap, compressionRectangle);
        // </snippet31>
    }
    public void Method32()
    {
        Graphics myGraphics = this.CreateGraphics();
        // <snippet32>
        Bitmap myBitmap = new Bitmap("Runner.jpg");

        // One hand of the runner
        Rectangle sourceRectangle = new Rectangle(80, 70, 80, 45);

        // Compressed hand
        Rectangle destRectangle1 = new Rectangle(200, 10, 20, 16);

        // Expanded hand
        Rectangle destRectangle2 = new Rectangle(200, 40, 200, 160);

        // Draw the original image at (0, 0).
        myGraphics.DrawImage(myBitmap, 0, 0);

        // Draw the compressed hand.
        myGraphics.DrawImage(
           myBitmap, destRectangle1, sourceRectangle, GraphicsUnit.Pixel);

        // Draw the expanded hand. 
        myGraphics.DrawImage(
           myBitmap, destRectangle2, sourceRectangle, GraphicsUnit.Pixel);
        // </snippet32>
    }
}

