using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1:
    System.Windows.Forms.Form

{
    #region " Windows Form Designer generated code "

    public Form1() : base()
    {        

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        this.Button1.Click += new EventHandler(Button1_Click);
        this.Button2.Click += new EventHandler(Button2_Click);
        InitializeBitmap();
        InitializeStreamBitmap();

        //Add any initialization after the InitializeComponent() call

    }

    //Form overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    //Required by the Windows Form Designer
    private System.ComponentModel.IContainer components;

    //NOTE: The following procedure is required by the Windows Form Designer
    //It can be modified using the Windows Form Designer.  
    //Do not modify it using the code editor.
    internal System.Windows.Forms.Button Button1;
    internal System.Windows.Forms.PictureBox PictureBox1;
    internal System.Windows.Forms.Button Button2;

    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        this.Button1 = new System.Windows.Forms.Button();
        this.PictureBox1 = new System.Windows.Forms.PictureBox();
        this.Button2 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // Button1
        // 
        this.Button1.Location = new System.Drawing.Point(24, 192);
        this.Button1.Name = "Button1";
        this.Button1.Size = new System.Drawing.Size(96, 23);
        this.Button1.TabIndex = 2;
        this.Button1.Text = "Rotate and Flip";
        // 
        // PictureBox1
        // 
        this.PictureBox1.Location = new System.Drawing.Point(48, 40);
        this.PictureBox1.Name = "PictureBox1";
        this.PictureBox1.Size = new System.Drawing.Size(168, 72);
        this.PictureBox1.TabIndex = 3;
        this.PictureBox1.TabStop = false;
        // 
        // Button2
        // 
        this.Button2.Location = new System.Drawing.Point(152, 192);
        this.Button2.Name = "Button2";
        this.Button2.TabIndex = 4;
        this.Button2.Text = "Button2";
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.Add(this.Button2);
        this.Controls.Add(this.PictureBox1);
        this.Controls.Add(this.Button1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);

    }

    #endregion


    // <snippet3Intro>
    // The following code example demonstrates constructing how to construct 
    // a new Bitmap from a file.

    // This example is designed to be used with a Windows Forms that contains
    // a PictureBox named PictureBox1. 
    // 
    // Paste the code into a form and call InitializeBitmap from the form's
    // constructor or Load method.

    // </snippet3Intro>

    // <snippet4Intro>
    // The following code example demonstrates how to set the RotateFlip 
    // property of a Bitmap.  

    // This example is designed to be used with a Windows form that contains
    // a PictureBox named PictureBox1 and a button named Button1. 
    // Paste the code to a form, call InitializeBitmap from the form's
    // constructor or Load method and associate Button1_Click with the button's
    // click event. Ensure the filepath to the bitmap is valid on 
    // your system.
    // </snippet4Intro>

    //<snippet3>
    //<snippet4>
    Bitmap bitmap1;

    private void InitializeBitmap()
    {
        try
        {
            bitmap1 = (Bitmap)Bitmap.FromFile(@"C:\Documents and Settings\" + 
                @"All Users\Documents\My Music\music.bmp");
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox1.Image = bitmap1;
        }
        catch(System.IO.FileNotFoundException)
        {
            MessageBox.Show("There was an error." + 
                "Check the path to the bitmap.");
        }


    }
    //</snippet4>

    private void Button1_Click(System.Object sender, System.EventArgs e)
    {

        if (bitmap1 != null)
        {
            bitmap1.RotateFlip(RotateFlipType.Rotate180FlipY);
            PictureBox1.Image = bitmap1;
        }

    }
    //</snippet3>

    // The following code example demonstrates how to load a bitmap 
    // from an Icon handle, using the GraphicsUnit enumeration, and the  
    // the use of the RectangleF.Round method to draw the rectangle 
    // bounds of an icon.

    // This example is designed to be used with Windows Forms. Create
    // a form that contains a button named Button2. Paste the code into the
    // form and associate this method with the button's Click event.
    //<snippet1>
    private void Button2_Click(System.Object sender, System.EventArgs e)
    {

        Bitmap bitmap1 = Bitmap.FromHicon(SystemIcons.Hand.Handle);
        Graphics formGraphics = this.CreateGraphics();
        GraphicsUnit units = GraphicsUnit.Point;

        RectangleF bmpRectangleF = bitmap1.GetBounds(ref units);
        Rectangle bmpRectangle = Rectangle.Round(bmpRectangleF);
        formGraphics.DrawRectangle(Pens.Blue, bmpRectangle);
        formGraphics.Dispose();
    }
    //</snippet1>

    // The following code example demonstrates how to load a bitmap 
    // from a stream.

    // This example is designed to be used with Windows Forms. Create
    // a form that contains a PictureBox named PictureBox1. Paste the code 
    // into the form and call InitializeStreamBitmap from the form's
    // constructor or Load method.
    //<snippet2>
    private void InitializeStreamBitmap()
    {
        try
        {
            System.Net.WebRequest request = 
                System.Net.WebRequest.Create(
                "http://www.microsoft.com//h/en-us/r/ms_masthead_ltr.gif");
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = 
                response.GetResponseStream();
            Bitmap bitmap2 = new Bitmap(responseStream);
            PictureBox1.Image = bitmap2;

        }
        catch(System.Net.WebException)
        {
            MessageBox.Show("There was an error opening the image file."
               + "Check the URL");
        }
    }
    //</snippet2>
 // The following code example demonstrates how to use the Image.PixelFormat,
    // Image.Height, Image.Width, and BitmapData.Scan0 properties; the Bitmap.LockBits 
    // and Bitmap.UnlockBits methods; and the ImageLockMode enumeration. 
    // This example is designed to be used with Windows
    // Forms. To run this example, paste it into a form and handle the form's Paint event by
    // calling the LockUnlockBitsExample method, passing e as PaintEventArgs. 
    // This example assumes the existence of an 24bpp image file named fakePhoto.jpg at c:\.
    //<snippet5>
    private void LockUnlockBitsExample(PaintEventArgs e)
        {

            // Create a new bitmap.
            Bitmap bmp = new Bitmap("c:\\fakePhoto.jpg");

            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                bmp.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = bmpData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];

            // Copy the RGB values into the array.
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Set every third value to 255. A 24bpp bitmap will look red.  
            for (int counter = 2; counter < rgbValues.Length; counter += 3)
                rgbValues[counter] = 255;

            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            // Unlock the bits.
            bmp.UnlockBits(bmpData);

            // Draw the modified image.
            e.Graphics.DrawImage(bmp, 0, 150);

        }
    
    //</snippet5>


    public static void Main()
    {
        Application.Run(new Form1());
    }

}





