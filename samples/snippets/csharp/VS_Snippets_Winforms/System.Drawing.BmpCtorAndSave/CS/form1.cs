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
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        // 
        // Form1
        // 
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Name = "Form1";
        this.Text = "Form1";
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

    }

    #endregion

    //<snippet1>
    private void ConstructFromResourceSaveAsGif(PaintEventArgs e)
    {

        // Construct a bitmap from the button image resource.
        Bitmap bmp1 = new Bitmap(typeof(Button), "Button.bmp");

        // Save the image as a GIF.
        bmp1.Save("c:\\button.gif", System.Drawing.Imaging.ImageFormat.Gif);

        // Construct a new image from the GIF file.
        Bitmap bmp2 = new Bitmap("c:\\button.gif");

        // Draw the two images.
        e.Graphics.DrawImage(bmp1, new Point(10, 10));
        e.Graphics.DrawImage(bmp2, new Point(10, 40));

        // Dispose of the image files.
        bmp1.Dispose();
        bmp2.Dispose();
    }
    //</snippet1>

    public static void Main()
    {
        Application.Run(new Form1());
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        ConstructFromResourceSaveAsGif(e);
    }
}



