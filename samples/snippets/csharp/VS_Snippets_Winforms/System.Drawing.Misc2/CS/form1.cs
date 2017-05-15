using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Form1:
    System.Windows.Forms.Form

{
    #region " Windows Form Designer generated code "

    public Form1() : base()
    {        

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        Button1.Click += new EventHandler(Button1_Click);
        Button2.Click += new EventHandler(Button2_Click);
        //UseTransparentProperty()

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
        //Button1
        //
        this.Button1.Location = new System.Drawing.Point(184, 40);
        this.Button1.Name = "Button1";
        this.Button1.TabIndex = 0;
        this.Button1.Text = "Button1";
        //
        //PictureBox1
        //
        this.PictureBox1.Location = new System.Drawing.Point(112, 160);
        this.PictureBox1.Name = "PictureBox1";
        this.PictureBox1.Size = new System.Drawing.Size(128, 88);
        this.PictureBox1.TabIndex = 3;
        this.PictureBox1.TabStop = false;
        //
        //Button2
        //
        this.Button2.Location = new System.Drawing.Point(184, 88);
        this.Button2.Name = "Button2";
        this.Button2.TabIndex = 2;
        this.Button2.Text = "Button2";
        //
        //Form1
        //
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.Add(this.PictureBox1);
        this.Controls.Add(this.Button2);
        this.Controls.Add(this.Button1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);

    }

    #endregion

    // The following code example demonstrates the following members:
    //   Rectangle.#ctor(PointF, SizeF)
    //   StringFormat#ctor(StringFormatFlags)
    //   StringFormat.#ctor(StringFormat)
    //   StringFormat.Alignment
    //   StringAlignment
    //   StringFormatFlags
    // This example is designed to be used with 
    // Windows Forms. Paste the code into a form and call the
    // ShowLineAndAlignment method when handling the form's Paint event,
    // passing e as PaintEventArgs.

    //<snippet1>
    private void ShowLineAndAlignment(PaintEventArgs e)
    {

        // Construct a new Rectangle .
        Rectangle  displayRectangle = 
            new Rectangle (new Point(40, 40), new Size (80, 80));

        // Construct 2 new StringFormat objects
        StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
        StringFormat format2 = new StringFormat(format1);

        // Set the LineAlignment and Alignment properties for
        // both StringFormat objects to different values.
        format1.LineAlignment = StringAlignment.Near;
        format1.Alignment = StringAlignment.Center;
        format2.LineAlignment = StringAlignment.Center;
        format2.Alignment = StringAlignment.Far;

        // Draw the bounding rectangle and a string for each
        // StringFormat object.
        e.Graphics.DrawRectangle(Pens.Black, displayRectangle);
        e.Graphics.DrawString("Showing Format1", this.Font, 
            Brushes.Red, (RectangleF)displayRectangle, format1);
        e.Graphics.DrawString("Showing Format2", this.Font, 
            Brushes.Red, (RectangleF)displayRectangle, format2);
    }
    //</snippet1>


    // The following example shows how to set the Trimming property
    // and how to use the StringTrimming enumeration. This example
    // is designed to be used with a Windows Form. Paste this code
    // into a form and call the ShowStringTrimming method when
    // handling the form's Paint event, passing e as PaintEventArgs.
    //<snippet6>
    private void ShowStringTrimming(PaintEventArgs e)
    {

        StringFormat format1 = new StringFormat();
        string quote = "Not everything that can be counted counts," +
            " and not everything that counts can be counted.";
        format1.Trimming = StringTrimming.EllipsisWord;
        e.Graphics.DrawString(quote, this.Font, Brushes.Black, 
            new RectangleF(10.0F, 10.0F, 90.0F, 50.0F), format1);
    }
    //</snippet6>
    
    private void Form1_Paint(object sender, PaintEventArgs e)
    {

        //ShowLineAndAlignment(e)
        //DemonstrateBlend(e)
        //ShowStringTrimming(e)

    }

    // The following code example demonstrates how to use the 
    // Transparent property. 
    // This example is designed to be used with Windows Forms.  
    // Paste the code into a form that contains two buttons named Button1
    // and Button2. Call the UseTransparentProperty method in the 
    // form's constructor.
    //<snippet2>
    private void UseTransparentProperty()
    {

        // Set up the PictureBox to display the entire image, and
        // to cover the entire client area.
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        PictureBox1.Dock = DockStyle.Fill;

        try
        {
            // Set the Image property of the PictureBox to an image retrieved
            // from the file system.
            PictureBox1.Image = 
                Image.FromFile("C:\\Documents and Settings\\All Users\\" +
                "Documents\\My Pictures\\Sample Pictures\\sunset.jpg");

            // Set the Parent property of Button1 and Button2 to the 
            // PictureBox.
            Button1.Parent = PictureBox1;
            Button2.Parent = PictureBox1;

            // Set the Color property of both buttons to transparent. 
            // With this setting the buttons assume the color of their
            // parent.
            Button1.BackColor = Color.Transparent;
            Button2.BackColor = Color.Transparent;

        }
        catch(System.IO.FileNotFoundException)
        {
            MessageBox.Show("There was an error." +
                "Make sure the image file path is valid.");
        }


    }
    //</snippet2>

    // The following code example demonstrates how to use the equality
    // operator and construct a Point from a Size. It also 
    // demonstrates the use of the X and Y properties.
    // This example is designed to be used with Windows Forms.  
    // Paste the code into a form that contains a button named Button1
    // and associate the Button1_Click method with the button's Click event.
    //<snippet3>
    private void Button1_Click(System.Object sender, System.EventArgs e)
    {

        // Construct a new Point with integers.
        Point Point1 = new Point(100, 100);

        // Create a Graphics object.
        Graphics formGraphics = this.CreateGraphics();

        // Construct another Point, this time using a Size.
        Point Point2 = new Point(new Size(100, 100));

        // Call the equality operator to see if the points are equal,  
        // and if so print out their x and y values.
        if (Point1 == Point2)
        {
            formGraphics.DrawString(String.Format("Point1.X: " +
                "{0},Point2.X: {1}, Point1.Y: {2}, Point2.Y {3}",
                new object[]{Point1.X, Point2.X, Point1.Y, Point2.Y}),
                this.Font, Brushes.Black, new PointF(10, 70));
        }

    }
    //</snippet3>

    // The following code example demonstrates how to use the Name
    // property of a Color.
    // This example is designed to be used with Windows Forms.  
    // Paste the code into a form that contains a button named Button2
    // and associate the Button2_Click method with the button's 
    // Click event.
    //<snippet4>
    private void Button2_Click(System.Object sender, System.EventArgs e)
    {

        Button2.Width = 100;
        Button2.Text = "Color: "+Button2.BackColor.Name;
    }
    //</snippet4>

    // The following code example demonstrates how to use the Blend
    // class by setting the Factors and Positions properties.
    // This example is designed to be used with Windows Forms.  
    // Paste the code into a form that imports the 
    // System.Drawing.Drawing2D namespace. Handle the form's Paint
    // event and call the DemonstrateBlend method, passing e as 
    // PaintEventArgs.
    //<snippet5>
    private void DemonstrateBlend(PaintEventArgs e)
    {
        Blend blend1 = new Blend(9);

        // Set the values in the Factors array to be all green, 
        // go to all blue, and then go back to green.
        blend1.Factors = new float[]{0.0F, 0.2F, 0.5F, 0.7F, 1.0F, 
                                        0.7F, 0.5F, 0.2F, 0.0F};

        // Set the positions.
        blend1.Positions = 
            new float[]{0.0F, 0.1F, 0.3F, 0.4F, 0.5F, 0.6F, 
            0.7F, 0.8F, 1.0F};

        // Declare a rectangle to draw the Blend in.
        Rectangle rectangle1 = new Rectangle(10, 10, 120, 100);

        // Create a new LinearGradientBrush using the rectangle, 
        // green and blue. and 90-degree angle.
        LinearGradientBrush brush1 = 
            new LinearGradientBrush(rectangle1, Color.LightGreen, 
            Color.Blue, 90, true);

        // Set the Blend property on the brush to the custom blend.
        brush1.Blend = blend1;

        // Fill in an ellipse with the brush.
        e.Graphics.FillEllipse(brush1, rectangle1);

        // Dispose of the custom brush.
        brush1.Dispose();
    }
    //</snippet5>



    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}






