using System;
using System.Windows.Forms;
using System.Drawing;


public class Form1:
    System.Windows.Forms.Form

{
    private void DoSomething1()
    {
        // Snippet for: \vbtskcodeexampledrawingfilledellipseonform.xml
        // <snippet1>
        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.FillEllipse(myBrush, new Rectangle(0, 0, 200, 300));
        myBrush.Dispose();
        formGraphics.Dispose();
        // </snippet1>
    }

    private void DoSomething2()
    {
        // Snippet for: \vbtskcodeexampledrawingfilledrectangleonform.xml
        // <snippet2>
        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));
        myBrush.Dispose();
        formGraphics.Dispose();
        // </snippet2>
    }

    private void DoSomething3()
    {
        // Snippet for: \vbtskcodeexamplecreatingpen.xml
        // <snippet3>
        System.Drawing.Pen myPen;
        myPen = new System.Drawing.Pen(System.Drawing.Color.Tomato);
        // </snippet3>
    }

    private void DoSomething4()
    {
        // Snippet for: \vbtskcodeexamplecreatingsolidbrush.xml
        // <snippet4>
        System.Drawing.SolidBrush myBrush;
        myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.PeachPuff);
        // </snippet4>
    }

    private void DoSomething5()
    {
        // Snippet for: \vbtskcodeexampledrawinglineonform.xml
        // <snippet5>
        System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.DrawLine(myPen, 0, 0, 200, 200);
        myPen.Dispose();
        formGraphics.Dispose();
        // </snippet5>
    }

    // Snippet for: \vbtskcodeexampledrawingoutlinedshapes.xml
    // <snippet6>
    private void DrawEllipse()
    {
        System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.DrawEllipse(myPen, new Rectangle(0, 0, 200, 300));
        myPen.Dispose();
        formGraphics.Dispose();
    }

    private void DrawRectangle()
    {
        System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Red);
        System.Drawing.Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.DrawRectangle(myPen, new Rectangle(0, 0, 200, 300));
        myPen.Dispose();
        formGraphics.Dispose();
    }

    // </snippet6>
    // Snippet for: \vbtskcodeexampledrawingtextonform2.xml
    // <snippet7>
    public void DrawString()
    {
        System.Drawing.Graphics formGraphics = this.CreateGraphics();
        string drawString = "Sample Text";
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        float x = 150.0F;
        float y = 50.0F;
        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
        formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        drawFont.Dispose();
        drawBrush.Dispose();
        formGraphics.Dispose();
    }

    // </snippet7>
    // Snippet for: \vbtskcodeexampledrawingtextonform.xml
    // <snippet8>
    public void DrawVerticalString()
    {
        System.Drawing.Graphics formGraphics = this.CreateGraphics();
        string drawString = "Sample Text";
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        float x = 150.0F;
        float y = 50.0F;
        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
        drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
        formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        drawFont.Dispose();
        drawBrush.Dispose();
        formGraphics.Dispose();
    }

    // </snippet8>
    private void DoSomething9()
    {
        Pen myPen = new Pen(Color.Red);
        // Snippet for: \vbtskcodeexamplesetcolorofpen.xml
        // <snippet9>
        myPen.Color = System.Drawing.Color.PeachPuff;
        // </snippet9>
    }
    // Snippet for: \vbtskcreateashapedwindowsform.xml
    // <snippet10>
    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        System.Drawing.Drawing2D.GraphicsPath shape = new System.Drawing.Drawing2D.GraphicsPath();
        shape.AddEllipse(0, 0, this.Width, this.Height);
        this.Region = new System.Drawing.Region(shape);
    }
    // </snippet10>

    [STAThread]
    public static void Main()
    {
        Application.Run(new Form1());
    }
}



