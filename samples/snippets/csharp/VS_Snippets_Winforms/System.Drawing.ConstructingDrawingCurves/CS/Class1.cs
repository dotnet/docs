using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Drawing2D;

public class SystemDrawingConstructingDrawingCurves
{

    // 37a0bedb-20c2-4cf0-91fa-a5509e826b30
    // How to: Draw a Sequence of Bézier Splines

    private void Method11(PaintEventArgs e)
    {
        // <snippet11>
        Point[] p = {
           new Point(10, 100),   // start point of first spline
           new Point(75, 10),    // first control point of first spline
           new Point(80, 50),    // second control point of first spline

           new Point(100, 150),  // endpoint of first spline and 
                                 // start point of second spline

           new Point(125, 80),   // first control point of second spline
           new Point(175, 200),  // second control point of second spline
           new Point(200, 80)};  // endpoint of second spline

        Pen pen = new Pen(Color.Blue);
        e.Graphics.DrawBeziers(pen, p);

        // </snippet11>
    }
    // a4a41e80-4461-4b47-b6bd-2c5e68881994
    // How to: Draw Cardinal Splines

    private void Method21(PaintEventArgs e)
    {
        // <snippet21>
        Point[] points = {
           new Point(0, 100),
           new Point(50, 80),
           new Point(100, 20),
           new Point(150, 80),
           new Point(200, 100)};

        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255));
        e.Graphics.DrawCurve(pen, points);
        // </snippet21>
    }
    private void Method22(PaintEventArgs e)
    {
        // <snippet22>
        Point[] points = {
           new Point(60, 60),
           new Point(150, 80),
           new Point(200, 40),
           new Point(180, 120),
           new Point(120, 100),
           new Point(80, 160)};

        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255));
        e.Graphics.DrawClosedCurve(pen, points);
        // </snippet22>
    }
    private void Method23(PaintEventArgs e)
    {
        // <snippet23>
        Point[] points = {
           new Point(20, 50),
           new Point(100, 10),
           new Point(200, 100),
           new Point(300, 50),
           new Point(400, 80)};

        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255));
        e.Graphics.DrawCurve(pen, points, 0.0f);
        e.Graphics.DrawCurve(pen, points, 0.6f);
        e.Graphics.DrawCurve(pen, points, 1.0f);
        // </snippet23>
    }
    // f4f3fe30-f0a6-4743-ac91-11310cebea9f
    // How to: Draw a Single Bézier Spline

    private void Method31(PaintEventArgs e)
    {
        // <snippet31>
        Point p1 = new Point(10, 100);   // Start point
        Point c1 = new Point(100, 10);   // First control point
        Point c2 = new Point(150, 150);  // Second control point
        Point p2 = new Point(200, 100);  // Endpoint

        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255));
        e.Graphics.DrawBezier(pen, p1, c1, c2, p2);
        // </snippet31>
    }
}

