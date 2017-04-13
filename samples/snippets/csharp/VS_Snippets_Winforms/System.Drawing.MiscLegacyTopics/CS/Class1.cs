using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

public class SystemDrawingMiscLegacyTopics
{

    // 1e717711-1361-448e-aa49-0f3ec43110c9
    // Using the World Transformation

    private void Method11(PaintEventArgs e)
    {
        // <snippet11>
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        Pen pen = new Pen(Color.FromArgb(128, 200, 0, 200), 2);
        e.Graphics.DrawRectangle(pen, rect);
        // </snippet11>
    }
    private void Method12(PaintEventArgs e)
    {
        Pen pen = new Pen(Color.FromArgb(128, 200, 0, 200), 2);
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        // <snippet12>
        e.Graphics.ScaleTransform(1.75f, 0.5f);
        e.Graphics.DrawRectangle(pen, rect); 
        // </snippet12>
    }
    private void Method13(PaintEventArgs e)
    {
        Pen pen = new Pen(Color.FromArgb(128, 200, 0, 200), 2);
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        // <snippet13>
        e.Graphics.ResetTransform();
        e.Graphics.RotateTransform(28); // 28 degrees
        e.Graphics.DrawRectangle(pen, rect);
        // </snippet13>
    }
    private void Method14(PaintEventArgs e)
    {
        Pen pen = new Pen(Color.FromArgb(128, 200, 0, 200), 2);
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        // <snippet14>
        e.Graphics.ResetTransform();
        e.Graphics.TranslateTransform(150, 150);
        e.Graphics.DrawRectangle(pen, rect);
        // </snippet14>
    }
    // 37d5f9dc-a5cf-4475-aa5d-34d714e808a9
    // Why Transformation Order Is Significant

    private void Method21(PaintEventArgs e)
    {
        // <snippet21>
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        Pen pen = new Pen(Color.FromArgb(128, 200, 0, 200), 2);
        e.Graphics.ResetTransform();
        e.Graphics.ScaleTransform(1.75f, 0.5f);
        e.Graphics.RotateTransform(28, MatrixOrder.Append);
        e.Graphics.TranslateTransform(150, 150, MatrixOrder.Append);
        e.Graphics.DrawRectangle(pen, rect);
        // </snippet21>
    }
    private void Method22(PaintEventArgs e)
    {
        // <snippet22>
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        Pen pen = new Pen(Color.FromArgb(128, 200, 0, 200), 2);
        e.Graphics.ResetTransform();
        e.Graphics.TranslateTransform(150, 150, MatrixOrder.Append);
        e.Graphics.RotateTransform(28, MatrixOrder.Append);
        e.Graphics.ScaleTransform(1.75f, 0.5f);
        e.Graphics.DrawRectangle(pen, rect);
        // </snippet22>
    }
    private void Method23(PaintEventArgs e)
    {
        // <snippet23>
        Rectangle rect = new Rectangle(0, 0, 50, 50);
        Pen pen = new Pen(Color.FromArgb(128, 200, 0, 200), 2);
        e.Graphics.ResetTransform();
        e.Graphics.TranslateTransform(150, 150, MatrixOrder.Prepend);
        e.Graphics.RotateTransform(28, MatrixOrder.Prepend);
        e.Graphics.ScaleTransform(1.75f, 0.5f);
        e.Graphics.DrawRectangle(pen, rect);
        // </snippet23>
    }
    // 3a4c07cb-a40a-4d14-ad35-008f531910a8
    // How to: Use Hit Testing with a Region

    private void Method31(PaintEventArgs e)
    {
        // <snippet31>
        Point point = new Point(60, 10);

        // Assume that the variable "point" contains the location of the
        // most recent mouse click.
        // To simulate a hit, assign (60, 10) to point.
        // To simulate a miss, assign (0, 0) to point.

        SolidBrush solidBrush = new SolidBrush(Color.Black);
        Region region1 = new Region(new Rectangle(50, 0, 50, 150));
        Region region2 = new Region(new Rectangle(0, 50, 150, 50));

        // Create a plus-shaped region by forming the union of region1 and 
        // region2.
        // The union replaces region1.
        region1.Union(region2);

        if (region1.IsVisible(point, e.Graphics))
        {
            // The point is in the region. Use an opaque brush.
            solidBrush.Color = Color.FromArgb(255, 255, 0, 0);
        }
        else
        {
            // The point is not in the region. Use a semitransparent brush.
            solidBrush.Color = Color.FromArgb(64, 255, 0, 0);
        }

        e.Graphics.FillRegion(solidBrush, region1);
        // </snippet31>
    }
    // 43d121b4-e14c-4901-b25c-2d6c25ba4e29
    // How to: Use Clipping with a Region

    private void Method41(PaintEventArgs e)
    {
        // <snippet41>
        // Create a path that consists of a single polygon.
        Point[] polyPoints = {
   new Point(10, 10),
   new Point(150, 10), 
   new Point(100, 75),
   new Point(100, 150)};
        GraphicsPath path = new GraphicsPath();
        path.AddPolygon(polyPoints);

        // Construct a region based on the path.
        Region region = new Region(path);

        // Draw the outline of the region.
        Pen pen = Pens.Black;
        e.Graphics.DrawPath(pen, path);

        // Set the clipping region of the Graphics object.
        e.Graphics.SetClip(region, CombineMode.Replace);

        // Draw some clipped strings.
        FontFamily fontFamily = new FontFamily("Arial");
        Font font = new Font(
           fontFamily,
           36, FontStyle.Bold,
           GraphicsUnit.Pixel);
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));

        e.Graphics.DrawString(
           "A Clipping Region",
           font, solidBrush,
           new PointF(15, 25));

        e.Graphics.DrawString(
           "A Clipping Region",
           font,
           solidBrush,
           new PointF(15, 68));
        // </snippet41>
    }

    // a0d9f178-43a4-4323-bb5a-d3e3f77ae6c1
    // Using Nested Graphics Containers

    private void Method61(PaintEventArgs e)
    {
        // <snippet61>
        Graphics graphics = e.Graphics;
        Pen pen = new Pen(Color.Red);
        GraphicsContainer graphicsContainer;
        graphics.FillRectangle(Brushes.Black, 100, 80, 3, 3);

        graphics.TranslateTransform(100, 80);

        graphicsContainer = graphics.BeginContainer();
        graphics.RotateTransform(30);
        graphics.DrawRectangle(pen, -60, -30, 120, 60);
        graphics.EndContainer(graphicsContainer);

        graphics.DrawRectangle(pen, -60, -30, 120, 60);
        // </snippet61>
    }
    private void Method62(PaintEventArgs e)
    {
        // <snippet62>
        Graphics graphics = e.Graphics;
        GraphicsContainer graphicsContainer;
        Pen redPen = new Pen(Color.Red, 2);
        Pen bluePen = new Pen(Color.Blue, 2);
        SolidBrush aquaBrush = new SolidBrush(Color.FromArgb(255, 180, 255, 255));
        SolidBrush greenBrush = new SolidBrush(Color.FromArgb(255, 150, 250, 130));

        graphics.SetClip(new Rectangle(50, 65, 150, 120));
        graphics.FillRectangle(aquaBrush, 50, 65, 150, 120);

        graphicsContainer = graphics.BeginContainer();
        // Create a path that consists of a single ellipse.
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(75, 50, 100, 150);

        // Construct a region based on the path.
        Region region = new Region(path);
        graphics.FillRegion(greenBrush, region);

        graphics.SetClip(region, CombineMode.Replace);
        graphics.DrawLine(redPen, 50, 0, 350, 300);
        graphics.EndContainer(graphicsContainer);

        graphics.DrawLine(bluePen, 70, 0, 370, 300);
        // </snippet62>
    }
    private void Method63(PaintEventArgs e)
    {
        // <snippet63>
        Graphics graphics = e.Graphics;
        GraphicsContainer innerContainer;
        GraphicsContainer outerContainer;
        SolidBrush brush = new SolidBrush(Color.Blue);
        FontFamily fontFamily = new FontFamily("Times New Roman");
        Font font = new Font(fontFamily, 36, FontStyle.Regular, GraphicsUnit.Pixel);

        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

        outerContainer = graphics.BeginContainer();

        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;

        innerContainer = graphics.BeginContainer();
        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        graphics.DrawString(
           "Inner Container",
           font,
           brush,
           new PointF(20, 10));
        graphics.EndContainer(innerContainer);

        graphics.DrawString(
           "Outer Container",
           font,
           brush,
           new PointF(20, 50));

        graphics.EndContainer(outerContainer);

        graphics.DrawString(
           "Graphics Object",
           font,
           brush,
           new PointF(20, 90));
        // </snippet63>
    }
}

