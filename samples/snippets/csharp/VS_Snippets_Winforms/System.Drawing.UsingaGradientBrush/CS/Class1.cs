using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Drawing2D;

public class class1
{

    // 1948e834-e104-481c-b71d-d8aa9e4d106e
    // How to: Create a Path Gradient

    public void Method11(PaintEventArgs e)
    {
        // <snippet11>
        // Create a path that consists of a single ellipse.
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, 140, 70);

        // Use the path to construct a brush.
        PathGradientBrush pthGrBrush = new PathGradientBrush(path);

        // Set the color at the center of the path to blue.
        pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255);

        // Set the color along the entire boundary 
        // of the path to aqua.
        Color[] colors = { Color.FromArgb(255, 0, 255, 255) };
        pthGrBrush.SurroundColors = colors;

        e.Graphics.FillEllipse(pthGrBrush, 0, 0, 140, 70);

        // </snippet11>
    }
    public void Method12(PaintEventArgs e)
    {
        // <snippet12>
        // Put the points of a polygon in an array.
        Point[] points = {
           new Point(75, 0),
           new Point(100, 50),
           new Point(150, 50),
           new Point(112, 75),
           new Point(150, 150),
           new Point(75, 100),
           new Point(0, 150),
           new Point(37, 75),
           new Point(0, 50),
           new Point(50, 50)};

        // Use the array of points to construct a path.
        GraphicsPath path = new GraphicsPath();
        path.AddLines(points);

        // Use the path to construct a path gradient brush.
        PathGradientBrush pthGrBrush = new PathGradientBrush(path);

        // Set the color at the center of the path to red.
        pthGrBrush.CenterColor = Color.FromArgb(255, 255, 0, 0);

        // Set the colors of the points in the array.
        Color[] colors = {
           Color.FromArgb(255, 0, 0, 0),
           Color.FromArgb(255, 0, 255, 0),
           Color.FromArgb(255, 0, 0, 255), 
           Color.FromArgb(255, 255, 255, 255),
           Color.FromArgb(255, 0, 0, 0),
           Color.FromArgb(255, 0, 255, 0),
           Color.FromArgb(255, 0, 0, 255),
           Color.FromArgb(255, 255, 255, 255),
           Color.FromArgb(255, 0, 0, 0),  
           Color.FromArgb(255, 0, 255, 0)};

        pthGrBrush.SurroundColors = colors;

        // Fill the path with the path gradient brush.
        e.Graphics.FillPath(pthGrBrush, path);

        // </snippet12>
    }
    public void Method13(PaintEventArgs e)
    {
        // <snippet13>
        // Construct a path gradient brush based on an array of points.
        PointF[] ptsF = {
           new PointF(0, 0), 
           new PointF(160, 0), 
           new PointF(160, 200),
           new PointF(80, 150),
           new PointF(0, 200)};

        PathGradientBrush pBrush = new PathGradientBrush(ptsF);

        // An array of five points was used to construct the path gradient
        // brush. Set the color of each point in that array.
        Color[] colors = {
           Color.FromArgb(255, 255, 0, 0),  // (0, 0) red
           Color.FromArgb(255, 0, 255, 0),  // (160, 0) green
           Color.FromArgb(255, 0, 255, 0),  // (160, 200) green
           Color.FromArgb(255, 0, 0, 255),  // (80, 150) blue
           Color.FromArgb(255, 255, 0, 0)}; // (0, 200) red

        pBrush.SurroundColors = colors;

        // Set the center color to white.
        pBrush.CenterColor = Color.White;

        // Use the path gradient brush to fill a rectangle.
        e.Graphics.FillRectangle(pBrush, new Rectangle(0, 0, 160, 200));
        // </snippet13>
    }
    public void Method14(PaintEventArgs e)
    {
        // <snippet14>
        // Create a path that consists of a single ellipse.
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, 200, 100);

        // Create a path gradient brush based on the elliptical path.
        PathGradientBrush pthGrBrush = new PathGradientBrush(path);

        // Set the color along the entire boundary to blue.
        Color[] color = { Color.Blue };
        pthGrBrush.SurroundColors = color;

        // Set the center color to aqua.
        pthGrBrush.CenterColor = Color.Aqua;

        // Use the path gradient brush to fill the ellipse. 
        e.Graphics.FillPath(pthGrBrush, path);

        // Set the focus scales for the path gradient brush.
        pthGrBrush.FocusScales = new PointF(0.3f, 0.8f);

        // Use the path gradient brush to fill the ellipse again.
        // Show this filled ellipse to the right of the first filled ellipse.
        e.Graphics.TranslateTransform(220.0f, 0.0f);
        e.Graphics.FillPath(pthGrBrush, path);
        // </snippet14>
    }
    public void Method15(PaintEventArgs e)
    {
        // <snippet15>
        // Vertices of the outer triangle
        Point[] points = {
           new Point(100, 0),
           new Point(200, 200),
           new Point(0, 200)};

        // No GraphicsPath object is created. The PathGradientBrush
        // object is constructed directly from the array of points.
        PathGradientBrush pthGrBrush = new PathGradientBrush(points);

        Color[] colors = {
           Color.FromArgb(255, 0, 128, 0),    // dark green
           Color.FromArgb(255, 0, 255, 255),  // aqua
           Color.FromArgb(255, 0, 0, 255)};   // blue

        float[] relativePositions = {
           0f,       // Dark green is at the boundary of the triangle.
           0.4f,     // Aqua is 40 percent of the way from the boundary
                     // to the center point.
           1.0f};    // Blue is at the center point.

        ColorBlend colorBlend = new ColorBlend();
        colorBlend.Colors = colors;
        colorBlend.Positions = relativePositions;
        pthGrBrush.InterpolationColors = colorBlend;

        // Fill a rectangle that is larger than the triangle
        // specified in the Point array. The portion of the
        // rectangle outside the triangle will not be painted.
        e.Graphics.FillRectangle(pthGrBrush, 0, 0, 200, 200);
        // </snippet15>
    }
    public void Method16(PaintEventArgs e)
    {
        // <snippet16>
        // Create a path that consists of a single ellipse.
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, 140, 70);

        // Use the path to construct a brush.
        PathGradientBrush pthGrBrush = new PathGradientBrush(path);

        // Set the center point to a location that is not
        // the centroid of the path.
        pthGrBrush.CenterPoint = new PointF(120, 40);

        // Set the color at the center of the path to blue.
        pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255);

        // Set the color along the entire boundary 
        // of the path to aqua.
        Color[] colors = { Color.FromArgb(255, 0, 255, 255) };
        pthGrBrush.SurroundColors = colors;

        e.Graphics.FillEllipse(pthGrBrush, 0, 0, 140, 70);

        // </snippet16>
        
        // <snippet17>
        pthGrBrush.CenterPoint = new PointF(145, 35);
        // </snippet17>
    }
    // 6c88e1cc-1217-4399-ac12-cb37592b9f01
    // How to: Create a Linear Gradient

    public void Method21(PaintEventArgs e)
    {
        // <snippet21>
        LinearGradientBrush linGrBrush = new LinearGradientBrush(
           new Point(0, 10),
           new Point(200, 10),
           Color.FromArgb(255, 255, 0, 0),   // Opaque red
           Color.FromArgb(255, 0, 0, 255));  // Opaque blue

        Pen pen = new Pen(linGrBrush);

        e.Graphics.DrawLine(pen, 0, 10, 200, 10);
        e.Graphics.FillEllipse(linGrBrush, 0, 30, 200, 100);
        e.Graphics.FillRectangle(linGrBrush, 0, 155, 500, 30);
        // </snippet21>
    }
    public void Method22(PaintEventArgs e)
    {
        // <snippet22>
        LinearGradientBrush linGrBrush = new LinearGradientBrush(
           new Point(0, 10),
           new Point(200, 10),
           Color.FromArgb(255, 0, 0, 0),     // Opaque black 
           Color.FromArgb(255, 255, 0, 0));  // Opaque red

        float[] relativeIntensities = { 0.0f, 0.5f, 1.0f };
        float[] relativePositions = { 0.0f, 0.2f, 1.0f };

        //Create a Blend object and assign it to linGrBrush.
        Blend blend = new Blend();
        blend.Factors = relativeIntensities;
        blend.Positions = relativePositions;
        linGrBrush.Blend = blend;

        e.Graphics.FillEllipse(linGrBrush, 0, 30, 200, 100);
        e.Graphics.FillRectangle(linGrBrush, 0, 155, 500, 30);
        // </snippet22>
    }
    public void Method23(PaintEventArgs e)
    {
        // <snippet23>
        LinearGradientBrush linGrBrush = new LinearGradientBrush(
           new Point(0, 0),
           new Point(200, 100),
           Color.FromArgb(255, 0, 0, 255),   // opaque blue
           Color.FromArgb(255, 0, 255, 0));  // opaque green

        Pen pen = new Pen(linGrBrush, 10);

        e.Graphics.DrawLine(pen, 0, 0, 600, 300);
        e.Graphics.FillEllipse(linGrBrush, 10, 100, 200, 100);
        // </snippet23>
    }
    // da4690e7-5fac-4fd2-b3f0-5cb35c165b92
    // How to: Apply Gamma Correction to a Gradient

    public void Method31(PaintEventArgs e)
    {
        // <snippet31>
        LinearGradientBrush linGrBrush = new LinearGradientBrush(
           new Point(0, 10),
           new Point(200, 10),
           Color.Red,
           Color.Blue);

        e.Graphics.FillRectangle(linGrBrush, 0, 0, 200, 50);
        linGrBrush.GammaCorrection = true;
        e.Graphics.FillRectangle(linGrBrush, 0, 60, 200, 50);
        // </snippet31>
    }
}

