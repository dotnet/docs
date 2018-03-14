using System.Drawing.Drawing2D;
using System.Drawing;
using System;
using System.Windows.Forms;

[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
public class Form1:
    System.Windows.Forms.Form

{
    #region " Windows Form Designer generated code "

    public Form1() : base()
    {        

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        this.Paint += new PaintEventHandler(Form1_Paint);
        Button1.Click += new EventHandler(Button1_Click);
        DrawFirstRectangle();

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
    [System.Diagnostics.DebuggerStepThrough]
    private void InitializeComponent()
    {
        this.Button1 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        //Button1
        //
        this.Button1.Location = new System.Drawing.Point(208, 16);
        this.Button1.Name = "Button1";
        this.Button1.TabIndex = 0;
        this.Button1.Text = "Button1";
        //
        //Form1
        //
        this.ClientSize = new System.Drawing.Size(292, 266);
        this.Controls.Add(this.Button1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);

    }

    #endregion
    // The following code example demonstrates creating a rectangle
    // using the FromLTRB method. This example is designed to
    // be used with a Windows Form. Paste this code into a form
    // and call the CreateARectangleFromLTRB method when handling
    // the form's Paint event, passing e as PaintEventArgs.
    //<snippet7>
    private void CreateARectangleFromLTRB(PaintEventArgs e)
    {
        Rectangle myRectangle = Rectangle.FromLTRB(40, 40, 140, 240);
        e.Graphics.DrawRectangle(SystemPens.ControlText, myRectangle);
    }
    //</snippet7>

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
       
        //ConvertRectangleToRectangleF(e)
        //RoundingAndTruncatingRectangles(e);
    }

    // The following code example demonstrates the static (Shared in
    // Visual Basic) Intersects method.  This example should be used 
    // with a Windows form.  Paste this code into a form
    // and call this method when handling the form's Paint event,
    // passing e as PaintEventArgs.
    //<snippet1>
    private void StaticRectangleIntersection(PaintEventArgs e)
    {
        Rectangle rectangle1 = new Rectangle(50, 50, 200, 100);
        Rectangle rectangle2 = new Rectangle(70, 20, 100, 200);
        Rectangle rectangle3 = new Rectangle();

        e.Graphics.DrawRectangle(Pens.Black, rectangle1);
        e.Graphics.DrawRectangle(Pens.Red, rectangle2);

        if (rectangle1.IntersectsWith(rectangle2))
        {
            rectangle3 = Rectangle.Intersect(rectangle1, rectangle2);
            if (!rectangle3.IsEmpty)
            {
                e.Graphics.FillRectangle(Brushes.Green, rectangle3);
            }
        }
    }
    //</snippet1>

    // The following code example demonstrates the instance
    // version of the Intersects method.  This example should be used 
    // with a Windows form.  Paste this code into a form
    // and call this method when handling the form's Paint event,
    // passing e as PaintEventArgs.
    //<snippet2>
    private void InstanceRectangleIntersection(PaintEventArgs e)
    {

        Rectangle rectangle1 = new Rectangle(50, 50, 200, 100);
        Rectangle rectangle2 = new Rectangle(70, 20, 100, 200);
    
        e.Graphics.DrawRectangle(Pens.Black, rectangle1);
        e.Graphics.DrawRectangle(Pens.Red, rectangle2);

        if (rectangle1.IntersectsWith(rectangle2))
        {
            rectangle1.Intersect(rectangle2);
            if (!rectangle1.IsEmpty)
            {
                e.Graphics.FillRectangle(Brushes.Green, rectangle1);
            }
        }
    }
    //</snippet2>

    // The following code example demonstrates the Contains method 
    // and the SystemPens class.
    // This example is designed for use with a Windows Form.  Paste 
    // this code into a form that contains a Button named Button1, 
    // call DrawFirstRectangle from the form's constructor 
    // or Load method and associate the Button1_Click method with 
    // the button's Click event.
    //<snippet3>
    Rectangle rectangle1 = new Rectangle(70, 70, 100, 150);

    private void DrawFirstRectangle()
    {
        ControlPaint.DrawReversibleFrame(rectangle1, 
            SystemColors.Highlight, FrameStyle.Thick);
    }

    private void Button1_Click(object sender, EventArgs e)
    {

        // Get the bounds of the screen.
        Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;

        // Check to see if the rectangle is within the bounds of the screen.
        if (screenRectangle.Contains(rectangle1))

            // If so, erase the previous rectangle.
        {
            ControlPaint.DrawReversibleFrame(rectangle1, 
                SystemColors.Highlight, FrameStyle.Thick);

            // Call the Offset method to move the rectangle.
            rectangle1.Offset(20, 20);

            // Draw the new, offset rectangle.
            ControlPaint.DrawReversibleFrame(rectangle1, 
                SystemColors.Highlight, FrameStyle.Thick);
        }
    }
    //</snippet3>

    // The following code example demonstrates the Union method. This
    // example is designed for use with a Windows Form.  Paste this code 
    // into a form and call this method when handling the form's 
    // Paint event, passing e as PaintEventArgs.
    //<snippet4>
    private void ShowRectangleUnion(PaintEventArgs e)
    {

        // Declare two rectangles and draw them.
        Rectangle rectangle1 = new Rectangle(30, 40, 50, 100);
        Rectangle rectangle2 = new Rectangle(50, 60, 100, 60);
        e.Graphics.DrawRectangle(Pens.Sienna, rectangle1);
        e.Graphics.DrawRectangle(Pens.BlueViolet, rectangle2);

        // Declare a third rectangle as a union of the first two.
        Rectangle rectangle3 = Rectangle.Union(rectangle1, rectangle2);

        // Fill in the third rectangle in a semi-transparent color.
        Color transparentColor = Color.FromArgb(40, 135, 135, 255);
        e.Graphics.FillRectangle(new SolidBrush(transparentColor), rectangle3);
    }
    //</snippet4>


    // The following code example demonstrates how to use the Round
    // and Truncate methods.
    // This example is designed for use with a Windows Form.  Paste this code 
    // into a form and call the RoundingAndTruncatingRectangles method  
    // when handling the form's Paint event, passing e as PaintEventArgs.
    //<snippet5>
    private void RoundingAndTruncatingRectangles(PaintEventArgs e)
    {

        // Construct a new RectangleF.
        RectangleF myRectangleF = 
            new RectangleF(30.6F, 30.7F, 40.8F, 100.9F);

        // Call the Round method.
        Rectangle roundedRectangle = Rectangle.Round(myRectangleF);

        // Draw the rounded rectangle in red.
        Pen redPen = new Pen(Color.Red, 4);
        e.Graphics.DrawRectangle(redPen, roundedRectangle);

        // Call the Truncate method.
        Rectangle truncatedRectangle = Rectangle.Truncate(myRectangleF);

        // Draw the truncated rectangle in white.
        Pen whitePen = new Pen(Color.White, 4);
        e.Graphics.DrawRectangle(whitePen, truncatedRectangle);

        // Dispose of the custom pens.
        redPen.Dispose();
        whitePen.Dispose();
    }
    //</snippet5>

    // The following code example demonstrates how to convert
    // a Rectangle object to a RectangleF using the Implicit operator.

    // This example is designed for use with a Windows Form.  Paste 
    // this code into a form and call the ConvertRectangleToRectangleF
    // method when handling the form's Paint event, passing e as 
    // PaintEventArgs.
    //<snippet6>
    private void ConvertRectangleToRectangleF(PaintEventArgs e)
    {

        // Create a rectangle.
        Rectangle rectangle1 = new Rectangle(30, 40, 50, 100);

        // Convert it to a RectangleF.
        RectangleF convertedRectangle = rectangle1;

        // Create a new RectangleF.
        RectangleF rectangle2 = new RectangleF(new PointF(30.0F, 40.0F),
            new SizeF(50.0F, 100.0F));

        // Create a custom, partially transparent brush.
        SolidBrush redBrush = new SolidBrush(Color.FromArgb(40, Color.Red));

        // Compare the converted rectangle with the new one.  If they 
        // are equal draw and fill the rectangles on the form.
        if (convertedRectangle == rectangle2)
        {
            e.Graphics.FillRectangle(redBrush, rectangle2);
        }

        // Dispose of the custom brush.
        redBrush.Dispose();
    }

    //</snippet6>
    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}





