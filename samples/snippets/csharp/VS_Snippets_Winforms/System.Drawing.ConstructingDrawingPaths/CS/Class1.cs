using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Drawing2D;

public class SystemDrawingConstructingDrawingPaths
{

    // 5a36b0e4-f1f4-46c0-a85a-22ae98491950
    // How to: Fill Open Figures

    private void Method11(PaintEventArgs e)
    {
        // <snippet11>
        GraphicsPath path = new GraphicsPath();

        // Add an open figure.
        path.AddArc(0, 0, 150, 120, 30, 120);

        // Add an intrinsically closed figure.
        path.AddEllipse(50, 50, 50, 100);

        Pen pen = new Pen(Color.FromArgb(128, 0, 0, 255), 5);
        SolidBrush brush = new SolidBrush(Color.Red);

        // The fill mode is FillMode.Alternate by default.
        e.Graphics.FillPath(brush, path);
        e.Graphics.DrawPath(pen, path);
        // </snippet11>
    }
    // 82fd56c7-b443-4765-9b7c-62ce030656ec
    // How to: Create Figures from Lines, Curves, and Shapes

    private void Method21(PaintEventArgs e)
    {
        // <snippet21>
        GraphicsPath path = new GraphicsPath();
        path.AddArc(175, 50, 50, 50, 0, -180);
        e.Graphics.DrawPath(new Pen(Color.FromArgb(128, 255, 0, 0), 4), path);
        // </snippet21>
    }
    private void Method22(PaintEventArgs e)
    {
        // <snippet22>
        // Create an array of points for the curve in the second figure.
        Point[] points = {
   new Point(40, 60),
   new Point(50, 70),
   new Point(30, 90)};

        GraphicsPath path = new GraphicsPath();

        path.StartFigure(); // Start the first figure.
        path.AddArc(175, 50, 50, 50, 0, -180);
        path.AddLine(100, 0, 250, 20);
        // First figure is not closed.

        path.StartFigure(); // Start the second figure.
        path.AddLine(50, 20, 5, 90);
        path.AddCurve(points, 3);
        path.AddLine(50, 150, 150, 180);
        path.CloseFigure(); // Second figure is closed.

        e.Graphics.DrawPath(new Pen(Color.FromArgb(255, 255, 0, 0), 2), path);
        // </snippet22>
    }
}

