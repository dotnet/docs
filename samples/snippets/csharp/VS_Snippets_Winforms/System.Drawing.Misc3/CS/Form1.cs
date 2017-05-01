using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Drawing.Text;
using System;

public class Form1 :
    System.Windows.Forms.Form
{
    #region " Windows Form Designer generated code "

    public Form1() : base()
    {

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        ExtractAssociatedIconEx();

    }






    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.

    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
       
// Form1
// 
        this.ClientSize = new System.Drawing.Size(292, 266);

        this.Name = "Form1";
        this.Text = "Form1";
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
        this.ResumeLayout(false);

    }

    #endregion


    [System.STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }


    //<snippet1>    

    protected void DrawCaps(PaintEventArgs e)
    {
        GraphicsPath hPath = new GraphicsPath();

        // Create the outline for our custom end cap.
        hPath.AddLine(new Point(0, 0), new Point(0, 5));
        hPath.AddLine(new Point(0, 5), new Point(5, 1));
        hPath.AddLine(new Point(5, 1), new Point(3, 1));

        // Construct the hook-shaped end cap.
        CustomLineCap HookCap = new CustomLineCap(null, hPath);

        // Set the start cap and end cap of the HookCap to be rounded.
        HookCap.SetStrokeCaps(LineCap.Round, LineCap.Round);

        // Create a pen and set end custom start and end
        // caps to the hook cap.
        Pen customCapPen = new Pen(Color.Black, 5);
        customCapPen.CustomStartCap = HookCap;
        customCapPen.CustomEndCap = HookCap;

        // Create a second pen using the start and end caps from
        // the hook cap.
        Pen capPen = new Pen(Color.Red, 10);
        LineCap startCap;
        LineCap endCap;
        HookCap.GetStrokeCaps(out startCap, out endCap);
        capPen.StartCap = startCap;
        capPen.EndCap = endCap;

        // Create a line to draw.
        Point[] points = { new Point(100, 100), new Point(200, 50), 
            new Point(250, 300) };

        // Draw the lines.
        e.Graphics.DrawLines(capPen, points);
        e.Graphics.DrawLines(customCapPen, points);

    }
    //</snippet1>  

    //<snippet2>  
    private void ExtractAssociatedIconEx()
    {
        Icon ico =
            Icon.ExtractAssociatedIcon(@"C:\WINDOWS\system32\notepad.exe");
        this.Icon = ico;

    }
    //</snippet2> 

    //<snippet3> 
    private void ConstructAnIconFromAType(PaintEventArgs e)
    {

        Icon icon1 = new Icon(typeof(Control), "Error.ico");
        e.Graphics.DrawIcon(icon1, new Rectangle(10, 10, 50, 50));

    }
    //</snippet3>
    // <snippet4>
    private void ShowOutputChannels(PaintEventArgs e)
    {
        //Create a bitmap from a file.
        Bitmap bmp1 = new Bitmap("c:\\fakePhoto.jpg");

        // Create a new bitmap from the original, resizing it for this example.
        Bitmap bmp2 = new Bitmap(bmp1, new Size(80, 80));

        bmp1.Dispose();

        // Create an ImageAttributes object.
        ImageAttributes imgAttributes = new ImageAttributes();

        // Draw the image unaltered.
        e.Graphics.DrawImage(bmp2, 10, 10);

        // Draw the image, showing the intensity of the cyan channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelC,
            System.Drawing.Imaging.ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(bmp2, new Rectangle(100, 10, bmp2.Width, bmp2.Height),
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        // Draw the image, showing the intensity of the magenta channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelM,
            ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(bmp2, new Rectangle(10, 100, bmp2.Width, bmp2.Height),
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        // Draw the image, showing the intensity of the yellow channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelY,
            ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(bmp2, new Rectangle(100, 100, bmp2.Width, bmp2.Height), 0, 0,
            bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        // Draw the image, showing the intensity of the black channel.
        imgAttributes.SetOutputChannel(ColorChannelFlag.ColorChannelK,

            System.Drawing.Imaging.ColorAdjustType.Bitmap);
        e.Graphics.DrawImage(bmp2, new Rectangle(10, 190, bmp2.Width, bmp2.Height),
            0, 0, bmp2.Width, bmp2.Height, GraphicsUnit.Pixel, imgAttributes);

        //Dispose of the bitmap.
        bmp2.Dispose();

    }
    // </snippet4>
//<snippet5>
    private void OpAdditionExample(PaintEventArgs e)
    {
        PointF point1 = new PointF(120.5F, 120F);
        SizeF size1 = new SizeF(120.5F, 30.5F);
        RectangleF rect1 = new RectangleF(point1, size1);
        if (new PointF(rect1.Right, rect1.Bottom) == point1 + size1)
            e.Graphics.DrawString("They are equal", this.Font, Brushes.Black, rect1);
        else
            e.Graphics.DrawString("They are not equal", this.Font, Brushes.Red, rect1);

    }
    //</snippet5>

    //<snippet6>
    private void AddExample(PaintEventArgs e)
    {
        PointF point1 = new PointF(120.5F, 120F);
        SizeF size1 = new SizeF(20.5F, 20.5F);
        RectangleF rect1 = new RectangleF(point1, size1);
        PointF point2 = new PointF(rect1.Right, rect1.Bottom);
        if (point2 != PointF.Add(point1, size1))
            e.Graphics.DrawString("They are not equal", this.Font, Brushes.Red, rect1);
        else
            e.Graphics.DrawString("They are equal", this.Font, Brushes.Black, rect1);

    }
    //</snippet6>

    //<snippet7>
    private void SubtractExample(PaintEventArgs e)
    {
        PointF point1 = new PointF(120.5F, 120F);
        SizeF size1 = new SizeF(120.5F, 30.5F);
        PointF point2 = PointF.Subtract(point1, size1);
        e.Graphics.DrawLine(Pens.Blue, point1, point2);
    }
    //</snippet7>

    //<snippet8>
    private void OpSubtractionExample(PaintEventArgs e)
    {
        PointF point1 = new PointF(120.5F, 120F);
        SizeF size1 = new SizeF(20.5F, 20.5F);
        PointF point2 = point1 - size1;
        e.Graphics.DrawLine(Pens.Blue, point1, point2);
    }
    //</snippet8>


    private void ShearColors(PaintEventArgs e)
    {
        //<snippet9>
        Image image = new Bitmap("ColorBars.bmp");
        ImageAttributes imageAttributes = new ImageAttributes();
        int width = image.Width;
        int height = image.Height;

        float[][] colorMatrixElements = { 
                new float[] {1,  0,  0,  0, 0},
                new float[] {0,  1,  0,  0, 0},
                new float[] {0.5f,  0,  1,  0, 0},
                new float[] {0,  0,  0,  1, 0},
                new float[] {0, 0, 0, 0, 1}};

        ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

        imageAttributes.SetColorMatrix(
           colorMatrix,
           ColorMatrixFlag.Default,
           ColorAdjustType.Bitmap);

        e.Graphics.DrawImage(image, 10, 10, width, height);

        e.Graphics.DrawImage(
           image,
           new Rectangle(150, 10, width, height),  // destination rectangle 
            0, 0,        // upper-left corner of source rectangle 
            width,       // width of source rectangle
            height,      // height of source rectangle
            GraphicsUnit.Pixel,
           imageAttributes);
        //</snippet9>

    }
        //<snippetInstalledFonts>
        InstalledFontCollection ifc = new InstalledFontCollection();
        private void EnumerateInstalledFonts(PaintEventArgs e)
        {
            FontFamily[] families = ifc.Families;
            float x = 0.0F;
            float y = 0.0F;
            for (int i = 0; i < ifc.Families.Length; i++)
            {
                if (ifc.Families[i].IsStyleAvailable(FontStyle.Regular))
                {
                    e.Graphics.DrawString(ifc.Families[i].Name, new Font(ifc.Families[i], 12), 
			            Brushes.Black, x, y);
                    y += 20;
                    if (y % 700 == 0)
                    {
                        x += 140;
                        y = 0;
                    }
                }
            }
        }
        //</snippetInstalledFonts>

        //<snippetConstructFontWithString>
        private void ConstructFontWithString(PaintEventArgs e)
        {
            Font font1 = new Font("Arial", 20);
            e.Graphics.DrawString("Arial Font", font1, Brushes.Red, new PointF(10, 10));
        }
        //</snippetConstructFontWithString>
 	public static Bitmap ResizeImage(System.Drawing.Image image)
        {
            //<snippetSetResolution>
            Bitmap bitmap = new Bitmap(100, 100);
            bitmap.SetResolution(96.0F, 96.0F);
            //</snippetSetResolution>

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
               graphics.DrawImage(image,
                    new Rectangle(0, 0, 100, 100),
                    new Rectangle(0, 0, image.Width, image.Height),
                    GraphicsUnit.Pixel);
            }
            
            return bitmap;
        }
    //<snippetGetThumbnail>
    public bool ThumbnailCallback()
    {
        return false;
    }
    public void Example_GetThumb(PaintEventArgs e)
    {
        Image.GetThumbnailImageAbort myCallback =
        new Image.GetThumbnailImageAbort(ThumbnailCallback);
        Bitmap myBitmap = new Bitmap("Climber.jpg");
        Image myThumbnail = myBitmap.GetThumbnailImage(
        40, 40, myCallback, IntPtr.Zero);
        e.Graphics.DrawImage(myThumbnail, 150, 75);
    }
    //</snippetGetThumbnail>
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        DrawCaps(e);
        //ConstructAnIconFromAType(e);
        ShowOutputChannels(e);
    }



}

