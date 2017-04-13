using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public class SystemDrawingWorkingWithImages : Form
{

	[STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SystemDrawingWorkingWithImages());
        }

    // 053e3360-bca0-4b25-9afa-0e77a6f17b03
    // How to: Crop and Scale Images

    private void Method11(PaintEventArgs e)
    {
        // <snippet11>
        Image image = new Bitmap("Apple.gif");

        // Draw the image unaltered with its upper-left corner at (0, 0).
        e.Graphics.DrawImage(image, 0, 0);

        // Make the destination rectangle 30 percent wider and
        // 30 percent taller than the original image.
        // Put the upper-left corner of the destination
        // rectangle at (150, 20).
        int width = image.Width;
        int height = image.Height;
        RectangleF destinationRect = new RectangleF(
            150,
            20,
            1.3f * width,
            1.3f * height);

        // Draw a portion of the image. Scale that portion of the image
        // so that it fills the destination rectangle.
        RectangleF sourceRect = new RectangleF(0, 0, .75f * width, .75f * height);
        e.Graphics.DrawImage(
            image,
            destinationRect,
            sourceRect,
            GraphicsUnit.Pixel);
        // </snippet11>
    }
    // 5bc558d7-b326-4050-a834-b8600da0de95
    // How to: Load and Display Bitmaps

    private void Method21(PaintEventArgs e)
    {
        // <snippet21>
        Bitmap bitmap = new Bitmap("Grapes.jpg");
        e.Graphics.DrawImage(bitmap, 60, 10);
        // </snippet21>
    }
    // 5fe2c95d-8653-4d55-bf0d-e5afa28f223b
    // How to: Improve Performance by Avoiding Automatic Scaling

    private void Method31(PaintEventArgs e)
    {
        Image image = new Bitmap("Texture.jpg");
        // <snippet31>
        e.Graphics.DrawImage(image, 50, 30);  // upper-left corner at (50, 30)
        // </snippet31>
    }
    private void Method32(PaintEventArgs e)
    {
        // <snippet32>
        Image image = new Bitmap("Texture.jpg");

        e.Graphics.DrawImage(image, 10, 10);
        e.Graphics.DrawImage(image, 120, 10, image.Width, image.Height);
        // </snippet32>
    }
    // 60af1714-f148-4d85-a739-0557965ffa73
    // How to: Load and Display Metafiles

    private void Method41(PaintEventArgs e)
    {
        // <snippet41>
        Metafile metafile = new Metafile("SampleMetafile.emf");
        e.Graphics.DrawImage(metafile, 60, 10);
        // </snippet41>
    }
    // 72ec0b31-0be7-444a-9575-1dbcb864e0be
    // How to: Read Image Metadata

    private void Method51(PaintEventArgs e)
    {
        // <snippet51>
        // Create an Image object. 
        Image image = new Bitmap(@"c:\FakePhoto.jpg");

        // Get the PropertyItems property from image.
        PropertyItem[] propItems = image.PropertyItems;

        // Set up the display.
        Font font = new Font("Arial", 12);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        int X = 0;
        int Y = 0;

        // For each PropertyItem in the array, display the ID, type, and 
        // length.
        int count = 0;
        foreach (PropertyItem propItem in propItems)
        {
            e.Graphics.DrawString(
            "Property Item " + count.ToString(),
            font,
            blackBrush,
            X, Y);

            Y += font.Height;

            e.Graphics.DrawString(
               "   iD: 0x" + propItem.Id.ToString("x"),
               font,
               blackBrush,
               X, Y);

            Y += font.Height;

            e.Graphics.DrawString(
               "   type: " + propItem.Type.ToString(),
               font,
               blackBrush,
               X, Y);

            Y += font.Height;

            e.Graphics.DrawString(
               "   length: " + propItem.Len.ToString() + " bytes",
               font,
               blackBrush,
               X, Y);

            Y += font.Height;

            count++;
        }
        // Convert the value of the second property to a string, and display 
        // it.
        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
        string manufacturer = encoding.GetString(propItems[1].Value);

        e.Graphics.DrawString(
           "The equipment make is " + manufacturer + ".",
           font,
           blackBrush,
           X, Y);
        // </snippet51>
    }
    // a3bf97eb-63ed-425a-ba07-dcc65efb567c
    // How to: Rotate, Reflect, and Skew Images

    private void Method61(PaintEventArgs e)
    {
        // <snippet61>
        Point[] destinationPoints = {
    new Point(200, 20),   // destination for upper-left point of 
                          // original
    new Point(110, 100),  // destination for upper-right point of 
                          // original
    new Point(250, 30)};  // destination for lower-left point of 
        // original

        Image image = new Bitmap("Stripes.bmp");

        // Draw the image unaltered with its upper-left corner at (0, 0).
        e.Graphics.DrawImage(image, 0, 0);

        // Draw the image mapped to the parallelogram.
        e.Graphics.DrawImage(image, destinationPoints);
        // </snippet61>
    }
    // e956242a-1e5b-4217-a3cf-5f3fb45d00ba
    // How to: Create Thumbnail Images

   
        // <snippet71>
	public bool ThumbnailCallback() {
            return true;
        }
       
        private void GetThumbnail(PaintEventArgs e)
        {

            Image.GetThumbnailImageAbort callback = 
                new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image image = new Bitmap(@"c:\FakePhoto.jpg");
            Image pThumbnail = image.GetThumbnailImage(100, 100, callback, new
               IntPtr());
            e.Graphics.DrawImage(
               pThumbnail,
               10,
               10,
               pThumbnail.Width,
               pThumbnail.Height);
        }
      
        // </snippet71>
    
    // fde9bccf-8aa5-4b0d-ba4b-788740627b02
    // How to: Use Interpolation Mode to Control Image Quality During Scaling

    private void Method81(PaintEventArgs e)
    {
        // <snippet81>
        Image image = new Bitmap("GrapeBunch.bmp");
        int width = image.Width;
        int height = image.Height;

        // Draw the image with no shrinking or stretching.
        e.Graphics.DrawImage(
            image,
            new Rectangle(10, 10, width, height),  // destination rectangle  
            0,
            0,           // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel,
            null);

        // Shrink the image using low-quality interpolation. 
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.DrawImage(
           image,
            new Rectangle(10, 250, (int)(0.6 * width), (int)(0.6 * height)),
            // destination rectangle 
            0,
            0,           // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel);

        // Shrink the image using medium-quality interpolation.
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
        e.Graphics.DrawImage(
            image,
            new Rectangle(150, 250, (int)(0.6 * width), (int)(0.6 * height)),
            // destination rectangle 
            0,
            0,           // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel);

        // Shrink the image using high-quality interpolation.
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        e.Graphics.DrawImage(
            image,
            new Rectangle(290, 250, (int)(0.6 * width), (int)(0.6 * height)),
            // destination rectangle 
            0,
            0,           // upper-left corner of source rectangle
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel);
        // </snippet81>
    }
}

