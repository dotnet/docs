
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
        this.Paint += new PaintEventHandler(Form1_Paint);

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
        components = new System.ComponentModel.Container();
        this.Text = "Form1";
    }

    #endregion

    // The following method demonstrates the effects of setting
    // the LineJoin property on a Pen object.

    // This example is designed to be used with Windows Forms.
    // Paste the code into a form and call the ShowLineJoin method when
    // handling the form's Paint event, passing e as PaintEventArgs.
    //<snippet1>
    private void ShowLineJoin(PaintEventArgs e)
    {

        // Create a new pen.
        Pen skyBluePen = new Pen(Brushes.DeepSkyBlue);

        // Set the pen's width.
        skyBluePen.Width = 8.0F;

        // Set the LineJoin property.
        skyBluePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;

        // Draw a rectangle.
        e.Graphics.DrawRectangle(skyBluePen, 
            new Rectangle(40, 40, 150, 200));

        //Dispose of the pen.
        skyBluePen.Dispose();

    }
    //</snippet1>

    // The following method demonstrates the effects of setting
    // the StartCap and EndCap properties on a Pen object.

    // This example is designed to be used with Windows Forms.
    // Paste the code into a form and call the ShowStartAndEndCaps
    // method when handling the form's Paint event, passing e 
    // as PaintEventArgs.
    //<snippet2>
    private void ShowStartAndEndCaps(PaintEventArgs e)
    {

        // Create a new custom pen.
        Pen redPen = new Pen(Brushes.Red, 6.0F);

        // Set the StartCap property.
        redPen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

        // Set the EndCap property.
        redPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

        // Draw a line.
        e.Graphics.DrawLine(redPen, 40.0F, 40.0F, 145.0F, 185.0F);

        // Dispose of the custom pen.
        redPen.Dispose();

    }
    //</snippet2>

    // The following method demonstrates the effects of setting
    // the DashCap, DashPattern and SmoothingMode properties 
    // of a Pen object.

    // This example is designed to be used with Windows Forms. 
    // Paste the code into a form and call the ShowPensAndSmoothingMode
    // method when handling the form's Paint event, passing e as
    // PaintEventArgs.
    //<snippet3>
    private void ShowPensAndSmoothingMode(PaintEventArgs e)
    {

        // Set the SmoothingMode property to smooth the line.
        e.Graphics.SmoothingMode = 
            System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Create a new Pen object.
        Pen greenPen = new Pen(Color.Green);

        // Set the width to 6.
        greenPen.Width = 6.0F;

        // Set the DashCap to round.
        greenPen.DashCap = System.Drawing.Drawing2D.DashCap.Round;

        // Create a custom dash pattern.
        greenPen.DashPattern = new float[]{4.0F, 2.0F, 1.0F, 3.0F};

        // Draw a line.
        e.Graphics.DrawLine(greenPen, 20.0F, 20.0F, 100.0F, 240.0F);

        // Change the SmoothingMode to none.
        e.Graphics.SmoothingMode = 
            System.Drawing.Drawing2D.SmoothingMode.None;

        // Draw another line.
        e.Graphics.DrawLine(greenPen, 100.0F, 240.0F, 160.0F, 20.0F);

        // Dispose of the custom pen.
        greenPen.Dispose();
    }
    //</snippet3>
    // The following method demonstrates how to use the Pens class.

    // This example is designed to be used with Windows Forms.
    // Paste the code into a form and call the UsePensClass method
    // when handling the form's Paint event, passing e as PaintEventArgs.
    //<snippet4>
    private void UsePensClass(PaintEventArgs e)
    {
        e.Graphics.DrawEllipse(Pens.SlateBlue, 
            new Rectangle(40, 40, 140, 140));
    }
    //</snippet4>

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        UsePensClass(e);
        ShowPensAndSmoothingMode(e);
        ShowStartAndEndCaps(e);
        ShowLineJoin(e);
    }
}




