
using System.Drawing;
using System;
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

    // The following code example demonstrates how to use the 
    // PointConverter.ConvertFromString and the Point.op_Subtraction
    // methods. This example is designed to be used with Windows
    // Forms. Paste this code into a form and call the 
    // ShowPointConverter method when handling the form's Paint 
    // event, passing e as PaintEventArgs.
    //<snippet1>
    private void ShowPointConverter(PaintEventArgs e)
    {

        // Create the PointConverter.
        System.ComponentModel.TypeConverter converter = 
            System.ComponentModel.TypeDescriptor.GetConverter(typeof(Point));

        Point point1 = (Point) converter.ConvertFromString("200, 200");

        // Use the subtraction operator to get a second point.
        Point point2 = point1 - new Size(190, 190);

        // Draw a line between the two points.
        e.Graphics.DrawLine(Pens.Black, point1, point2);
    }
    //</snippet1>

    // The following code example demonstrates how to use the 
    // ColorConverter.ConvertToString method. This example
    // is designed to be used with Windows Forms. Paste this code
    // into a form and call the ShowColorConverter method when
    // handling the form's Paint event, passing e as PaintEventArgs.
    //<snippet2>
    
    private void ShowColorConverter(PaintEventArgs e)
    {

        Color myColor = Color.PaleVioletRed;

        // Create the ColorConverter.
        System.ComponentModel.TypeConverter converter = 
            System.ComponentModel.TypeDescriptor.GetConverter(myColor);

        string colorAsString = converter.ConvertToString(Color.PaleVioletRed);
        e.Graphics.DrawString(colorAsString, this.Font,
            Brushes.PaleVioletRed, 50.0F, 50.0F);
    }
    //</snippet2>

    // The following code example demonstrates how to use the 
    // ConvertToInvariantString and ConvertToString methods.  
    // This example is designed to be used with Windows Forms. 
    // Paste this code into a form and call the ShowFontStringConversion
    // method when handling the form's Paint event, passing e
    // as PaintEventArgs.
    //<snippet3>
    private void ShowFontStringConversion(PaintEventArgs e)
    {

        // Create the FontConverter.
        System.ComponentModel.TypeConverter converter = 
            System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));

        Font font1 = (Font) converter.ConvertFromString("Arial, 12pt");

        string fontName1 = converter.ConvertToInvariantString(font1);
        string fontName2 = converter.ConvertToString(font1);

        e.Graphics.DrawString(fontName1, font1, Brushes.Red, 10, 10);
        e.Graphics.DrawString(fontName2, font1, Brushes.Blue, 10, 30);
    }
    //</snippet3>

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        ShowFontStringConversion(e);
        ShowPointConverter(e);
        ShowColorConverter(e);
    }

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }

}



