using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

public class Form1 : Form
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    // 0828c331-a438-4bdd-a4d6-3ef1e59e8795
    // How to: Use a Pen to Draw Lines

    public void Method11(PaintEventArgs e)
    {
        // <snippet11>
        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
        e.Graphics.DrawLine(pen, 20, 10, 300, 100);
        // </snippet11>
    }
    // 54a7fa14-3ad8-4d64-b424-2a12005b250c
    // How to: Use a Pen to Draw Rectangles

    public void Method21(PaintEventArgs e)
    {
        // <snippet21>
        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
        e.Graphics.DrawRectangle(blackPen, 10, 10, 100, 50);
        // </snippet21>
    }
    // 9fc480c2-3c75-4fd1-8ab5-296a99e820e2
    // How to: Join Lines

    public void Method31(PaintEventArgs e)
    {
        // <snippet31>
        GraphicsPath path = new GraphicsPath();
        Pen penJoin = new Pen(Color.FromArgb(255, 0, 0, 255), 8);

        path.StartFigure();
        path.AddLine(new Point(50, 200), new Point(100, 200));
        path.AddLine(new Point(100, 200), new Point(100, 250));

        penJoin.LineJoin = LineJoin.Bevel;
        e.Graphics.DrawPath(penJoin, path);

        // </snippet31>
    }
    // a202af36-4d31-4401-a126-b232f51db581
    // How to: Set Pen Width and Alignment

    public void Method41(PaintEventArgs e)
    {
        // <snippet41>
        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
        Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
        greenPen.Alignment = PenAlignment.Center;

        // Draw the line with the wide green pen.
        e.Graphics.DrawLine(greenPen, 10, 100, 100, 50);

        // Draw the line with the thin black pen.
        e.Graphics.DrawLine(blackPen, 10, 100, 100, 50);
        // </snippet41>
    }
    public void Method42(PaintEventArgs e)
    {
        // <snippet42>
        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
        Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
        greenPen.Alignment = PenAlignment.Center;

        // Draw the rectangle with the wide green pen.
        e.Graphics.DrawRectangle(greenPen, 10, 100, 50, 50);

        // Draw the rectangle with the thin black pen.
        e.Graphics.DrawRectangle(blackPen, 10, 100, 50, 50);
        // </snippet42>
    }
    public void Method43(PaintEventArgs e)
    {
        Pen greenPen = new Pen(Color.FromArgb(255, 0, 255, 0), 10);
        // <snippet43>
        greenPen.Alignment = PenAlignment.Inset;
        // </snippet43>
    }
    // cd0ed96a-cce4-47b9-b58a-3bae2e3d1bee
    // How to: Draw a Custom Dashed Line

    public void Method51(PaintEventArgs e)
    {
        // <snippet51>
        float[] dashValues = { 5, 2, 15, 4 };
        Pen blackPen = new Pen(Color.Black, 5);
        blackPen.DashPattern = dashValues;
        e.Graphics.DrawLine(blackPen, new Point(5, 5), new Point(405, 5));
        // </snippet51>
    }
    // dc9118cc-f3c2-42e5-8173-f46d41d18fd5
    // How to: Draw a Line Filled with a Texture

    public void Method61(PaintEventArgs e)
    {
        // <snippet61>
        Bitmap bitmap = new Bitmap("Texture1.jpg");
        TextureBrush tBrush = new TextureBrush(bitmap);
        Pen texturedPen = new Pen(tBrush, 30);

        e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
        e.Graphics.DrawEllipse(texturedPen, 100, 20, 200, 100);
        // </snippet61>
    }
    // eb68c3e1-c400-4886-8a04-76978a429cb6
    // How to: Draw a Line with Line Caps

    public void Method71(PaintEventArgs e)
    {
        // <snippet71>
        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), 8);
        pen.StartCap = LineCap.ArrowAnchor;
        pen.EndCap = LineCap.RoundAnchor;
        e.Graphics.DrawLine(pen, 20, 175, 300, 175);
        // </snippet71>
    }
}

