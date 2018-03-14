using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;

public class LinesCurvesAndShapes : Form
{
    // 0195df81-66be-452d-bb53-5a582ebfdc09
    // Vector Graphics Overview

    Pen myPen = Pens.Black;
    SolidBrush mySolidBrush = (SolidBrush)Brushes.Red;
    GraphicsPath myGraphicsPath = new GraphicsPath();

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new LinesCurvesAndShapes());
    }
    public void Method11(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet11>
        myGraphics.DrawRectangle(myPen, 20, 10, 100, 50);
        // </snippet11>
    }
    // 08d2cc9a-dc9d-4eed-bcbb-2c8e2ca5d3ae
    // Open and Closed Curves in GDI+

    public void Method21(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet21>
        myGraphics.FillPie(mySolidBrush, 0, 0, 140, 70, 0, 120);
        myGraphics.DrawArc(myPen, 0, 0, 140, 70, 0, 120);
        // </snippet21>
    }
    public void Method22(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet22>
        Point[] myPointArray =
   { new Point(0, 0), new Point(60, 20), new Point(40, 50) };
        myGraphics.DrawClosedCurve(myPen, myPointArray);
        myGraphics.FillClosedCurve(mySolidBrush, myPointArray);
        // </snippet22>
    }
    public void Method23(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet23>
        SolidBrush mySolidBrush = new SolidBrush(Color.Aqua);
        GraphicsPath myGraphicsPath = new GraphicsPath();

        Point[] myPointArray = {
   new Point(15, 20), 
   new Point(20, 40), 
   new Point(50, 30)};

        FontFamily myFontFamily = new FontFamily("Times New Roman");
        PointF myPointF = new PointF(50, 20);
        StringFormat myStringFormat = new StringFormat();

        myGraphicsPath.AddArc(0, 0, 30, 20, -90, 180);
        myGraphicsPath.AddCurve(myPointArray);
        myGraphicsPath.AddString("a string in a path", myFontFamily,
           0, 24, myPointF, myStringFormat);
        myGraphicsPath.AddPie(230, 10, 40, 40, 40, 110);

        myGraphics.FillPath(mySolidBrush, myGraphicsPath);
        myGraphics.DrawPath(myPen, myGraphicsPath);
        // </snippet23>
    }
    // 09b3797a-6294-422d-9adf-a5a0a7695c0c
    // Cardinal Splines in GDI+

    public void Method31(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        Point[] myPointArray = new Point[] { new Point(10, 10), 
            new Point(50, 40), new Point(123, 200) };
        // <snippet31>
        myGraphics.DrawCurve(myPen, myPointArray, 1.5f);
        // </snippet31>
    }
    // 30b25aae-e3eb-4479-bdb8-187cf651fc84
    // Pens, Lines, and Rectangles in GDI+

    public void Method41(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet41>
        myGraphics.DrawLine(myPen, 4, 2, 12, 6);
        // </snippet41>
    }
    public void Method42(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet42>
        Point myStartPoint = new Point(4, 2);
        Point myEndPoint = new Point(12, 6);
        myGraphics.DrawLine(myPen, myStartPoint, myEndPoint);
        // </snippet42>
    }
    public void Method43(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet43>
        Pen myPen = new Pen(Color.Blue, 2);
        myGraphics.DrawLine(myPen, 0, 0, 60, 30);
        // </snippet43>
    }
    public void Method44(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet44>
        myPen.DashStyle = DashStyle.Dash;
        myGraphics.DrawLine(myPen, 100, 50, 300, 80);
        // </snippet44>
    }
    public void Method45(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet45>
        myGraphics.DrawRectangle(myPen, 100, 50, 80, 40);
        // </snippet45>
    }
    public void Method46(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet46>
        Rectangle myRectangle = new Rectangle(100, 50, 80, 40);
        myGraphics.DrawRectangle(myPen, myRectangle);
        // </snippet46>
    }
    // 34f35133-a835-4ca4-81f6-0dfedee8b683
    // Ellipses and Arcs in GDI+

    public void Method51(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet51>
        myGraphics.DrawEllipse(myPen, 100, 50, 80, 40);
        // </snippet51>
    }
    public void Method52(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet52>
        Rectangle myRectangle = new Rectangle(100, 50, 80, 40);
        myGraphics.DrawEllipse(myPen, myRectangle);
        // </snippet52>
    }
    public void Method53(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet53>
        myGraphics.DrawArc(myPen, 100, 50, 140, 70, 30, 180);
        // </snippet53>
    }
    // 52184f9b-16dd-4bbd-85be-029112644ceb
    // Regions in GDI+

    public void Method61(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        Region myRegion = new Region(this.ClientRectangle);
        // <snippet61>
        myGraphics.FillRegion(mySolidBrush, myRegion);
        // </snippet61>
    }
    // 5774ce1e-87d4-4bc7-88c4-4862052781b8
    // Bézier Splines in GDI+

    public void Method71(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet71>
        myGraphics.DrawBezier(myPen, 0, 0, 40, 20, 80, 150, 100, 10);
        // </snippet71>
    }
    // 810da1a4-c136-4abf-88df-68e49efdd8d4
    // Antialiasing with Lines and Curves

    public void Method81(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet81>
        myGraphics.SmoothingMode = SmoothingMode.AntiAlias;
        myGraphics.DrawLine(myPen, 0, 0, 12, 8);
        // </snippet81>
    }
    // 8b5f71d9-d2f0-4540-9c41-740f90fd4c26
    // Restricting the Drawing Surface in GDI+

    public void Method91(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        Region myRegion = new Region(this.ClientRectangle);
        // <snippet91>
        myGraphics.Clip = myRegion;
        myGraphics.DrawLine(myPen, 0, 0, 200, 200);
        // </snippet91>
    }
    // a5500dec-666c-41fd-9da3-2169dd89c5eb
    // Graphics Paths in GDI+

    public void Method101(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet101>
        myGraphicsPath.AddLine(0, 0, 30, 20);
        myGraphicsPath.AddEllipse(20, 20, 20, 40);
        myGraphicsPath.AddBezier(30, 60, 70, 60, 50, 30, 100, 10);
        myGraphics.DrawPath(myPen, myGraphicsPath);
        // </snippet101>
    }
    public void Method102()
    {
        GraphicsPath graphicsPath1 = new GraphicsPath();
        GraphicsPath graphicsPath2 = new GraphicsPath();
        // <snippet102>
        myGraphicsPath.AddPath(graphicsPath1, false);
        myGraphicsPath.AddPath(graphicsPath2, false);
        // </snippet102>
    }
    public void Method103(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet103>
        GraphicsPath myGraphicsPath = new GraphicsPath();

        Point[] myPointArray = {
   new Point(5, 30), 
   new Point(20, 40), 
   new Point(50, 30)};

        FontFamily myFontFamily = new FontFamily("Times New Roman");
        PointF myPointF = new PointF(50, 20);
        StringFormat myStringFormat = new StringFormat();

        myGraphicsPath.AddArc(0, 0, 30, 20, -90, 180);
        myGraphicsPath.StartFigure();
        myGraphicsPath.AddCurve(myPointArray);
        myGraphicsPath.AddString("a string in a path", myFontFamily,
           0, 24, myPointF, myStringFormat);
        myGraphicsPath.AddPie(230, 10, 40, 40, 40, 110);
        myGraphics.DrawPath(myPen, myGraphicsPath);
        // </snippet103>
    }
    // a72213d2-d69a-4c2b-a75c-be7b20390c13
    // Polygons in GDI+

    public void Method111(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet111>
        Point[] myPointArray = 
   { new Point(0, 0), new Point(50, 30), new Point(30, 60) };
        myGraphics.DrawPolygon(myPen, myPointArray);
        // </snippet111>
    }
    // e863e2a7-0294-4130-99b6-f1ea3201e7cd
    // Brushes and Filled Shapes in GDI+

    public void Method121(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet121>
        SolidBrush mySolidBrush = new SolidBrush(Color.Red);
        myGraphics.FillEllipse(mySolidBrush, 0, 0, 60, 40);
        // </snippet121>
    }
    public void Method122()
    {
        // <snippet122>
        HatchBrush myHatchBrush =
           new HatchBrush(HatchStyle.Vertical, Color.Blue, Color.Green);
        // </snippet122>
    }
    public void Method123(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        // <snippet123>
        Image myImage = Image.FromFile("MyTexture.bmp");
        TextureBrush myTextureBrush = new TextureBrush(myImage);
        myGraphics.FillEllipse(myTextureBrush, 0, 0, 100, 50);
        // </snippet123>
    }
    public void Method124(PaintEventArgs e)
    {
        Graphics myGraphics = e.Graphics;
        Rectangle myRectangle = new Rectangle(new Point(10, 10), new Size(40, 50));
        // <snippet124>
        LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush(
           myRectangle,
           Color.Blue,
           Color.Green,
           LinearGradientMode.Horizontal);
        myGraphics.FillEllipse(myLinearGradientBrush, myRectangle);
        // </snippet124>
    }
}

