using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicGraphicsExamples2CS
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(300,300);
            this.Text = "Form1";
        }
        #endregion

        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.IntPtr)
        // <snippet55>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback8(IntPtr callBackData)
        {
                     
            // Test for call that passes callBackData parameter.
            if(callBackData==IntPtr.Zero)
            {
                     
                // If no callBackData passed, abort DrawImage method.
                return true;
            }
            else
            {
                     
                // If callBackData passed, continue DrawImage method.
                return false;
            }
        }
        public void DrawImageRect4FloatAttribAbortData(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback8);
            IntPtr imageCallbackData = new IntPtr(1);
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying original image.
            Rectangle destRect1 = new Rectangle(100, 25, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            float x = 50.0F;
            float y = 50.0F;
            float width = 150.0F;
            float height = 150.0F;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, units);
                     
            // Create rectangle for adjusted image.
            Rectangle destRect2 = new Rectangle(100, 175, 450, 150);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
                     
            // Draw adjusted image to screen.
            try
            {
                checked
                {
                     
                    // Draw adjusted image to screen.
                    e.Graphics.DrawImage(
                        newImage,
                        destRect2,
                        x, y,
                        width, height,
                        units,
                        imageAttr,
                        imageCallback,
                        imageCallbackData);
                }
            }
            catch (Exception ex)
            {
                e.Graphics.DrawString(
                    ex.ToString(),
                    new Font("Arial", 8),
                    Brushes.Black,
                    new PointF(0, 0));
            }
        }
        // </snippet55>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.RectangleF)
        // <snippet56>
        public void DrawImageRectF(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying image.
            RectangleF rect = new RectangleF(100.0F, 100.0F, 450.0F, 150.0F);
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, rect);
        }
        // </snippet56>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.RectangleF,System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
        // <snippet57>
        public void DrawImageRectFRectF(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying image.
            RectangleF destRect = new RectangleF(100.0F, 100.0F, 450.0F, 150.0F);
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, srcRect, units);
        }
        // </snippet57>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Int32,System.Int32)
        // <snippet58>
        public void DrawImage2Int(PaintEventArgs e)
        {
                        
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                        
            // Create coordinates for upper-left corner of image.
            int x = 100;
            int y = 100;
                        
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y);
        }
        // </snippet58>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Int32,System.Int32,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
        // <snippet59>
        public void DrawImage2IntRect(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner of image.
            int x = 100;
            int y = 100;
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y, srcRect, units);
        }
        // </snippet59>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet60>
        public void DrawImage4Int(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner.
                     
            // of image and for size of image.
            int x = 100;
            int y = 100;
            int width = 450;
            int height = 150;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y, width, height);
        }
        // </snippet60>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Single,System.Single)
        // <snippet61>
        public void DrawImage2Float(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner of image.
            float x = 100.0F;
            float y = 100.0F;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y);
        }
        // </snippet61>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Single,System.Single,System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
        // <snippet62>
        public void DrawImage2FloatRectF(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner of image.
            float x = 100.0F;
            float y = 100.0F;
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y, srcRect, units);
        }
        // </snippet62>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Single,System.Single,System.Single,System.Single)
        // <snippet63>
        public void DrawImage4Float(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner.
                     
            // of image and for size of image.
            float x = 100.0F;
            float y = 100.0F;
            float width = 450.0F;
            float height = 150.0F;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, x, y, width, height);
        }
        // </snippet63>


        // Snippet for: M:System.Drawing.Graphics.DrawImageUnscaled(System.Drawing.Image,System.Drawing.Point)
        // <snippet64>
        public void DrawImageUnscaledPoint(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create point for upper-left corner of image.
            Point ulCorner = new Point(100, 100);
                     
            // Draw image to screen.
            e.Graphics.DrawImageUnscaled(newImage, ulCorner);
        }
        // </snippet64>


        // Snippet for: M:System.Drawing.Graphics.DrawImageUnscaled(System.Drawing.Image,System.Int32,System.Int32)
        // <snippet65>
        public void DrawImageUnscaledInt(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create coordinates for upper-left corner of image.
            int x = 100;
            int y = 100;
                     
            // Draw image to screen.
            e.Graphics.DrawImageUnscaled(newImage, x, y);
        }
        // </snippet65>


        // Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Drawing.Point,System.Drawing.Point)
        // <snippet66>
        public void DrawLinePoint(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points that define line.
            Point point1 = new Point(100, 100);
            Point point2 = new Point(500, 100);
                     
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2);
        }
        // </snippet66>


        // Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Drawing.PointF,System.Drawing.PointF)
        // <snippet67>
        public void DrawLinePointF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points that define line.
            PointF point1 = new PointF(100.0F, 100.0F);
            PointF point2 = new PointF(500.0F, 100.0F);
                     
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, point1, point2);
        }
        // </snippet67>


        // Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet68>
        public void DrawLineInt(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create coordinates of points that define line.
            int x1 = 100;
            int y1 = 100;
            int x2 = 500;
            int y2 = 100;
                     
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }
        // </snippet68>


        // Snippet for: M:System.Drawing.Graphics.DrawLine(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single)
        // <snippet69>
        public void DrawLineFloat(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create coordinates of points that define line.
            float x1 = 100.0F;
            float y1 = 100.0F;
            float x2 = 500.0F;
            float y2 = 100.0F;
                     
            // Draw line to screen.
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
        }
        // </snippet69>


        // Snippet for: M:System.Drawing.Graphics.DrawLines(System.Drawing.Pen,System.Drawing.Point[])
        // <snippet70>
        public void DrawLinesPoint(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen pen = new Pen(Color.Black, 3);
                     
            // Create array of points that define lines to draw.
            Point[] points =
                     {
                         new Point(10,  10),
                         new Point(10, 100),
                         new Point(200,  50),
                         new Point(250, 300)
                     };
                     
            //Draw lines to screen.
            e.Graphics.DrawLines(pen, points);
        }
        // </snippet70>


        // Snippet for: M:System.Drawing.Graphics.DrawLines(System.Drawing.Pen,System.Drawing.PointF[])
        // <snippet71>
        public void DrawLinesPointF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen pen = new Pen(Color.Black, 3);
                     
            // Create array of points that define lines to draw.
            PointF[] points =
                     {
                         new PointF(10.0F,  10.0F),
                         new PointF(10.0F, 100.0F),
                         new PointF(200.0F,  50.0F),
                         new PointF(250.0F, 300.0F)
                     };
                     
            //Draw lines to screen.
            e.Graphics.DrawLines(pen, points);
        }
        // </snippet71>


        // Snippet for: M:System.Drawing.Graphics.DrawPath(System.Drawing.Pen,System.Drawing.Drawing2D.GraphicsPath)
        // <snippet72>
        public void DrawPathEllipse(PaintEventArgs e)
        {
                     
            // Create graphics path object and add ellipse.
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddEllipse(0, 0, 200, 100);
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Draw graphics path to screen.
            e.Graphics.DrawPath(blackPen, graphPath);
        }
        // </snippet72>


        // Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Drawing.Rectangle,System.Single,System.Single)
        // <snippet73>
        public void DrawPieRectangle(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle for ellipse.
            Rectangle rect = new Rectangle(0, 0, 200, 100);
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Draw pie to screen.
            e.Graphics.DrawPie(blackPen, rect, startAngle, sweepAngle);
        }
        // </snippet73>


        // Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Drawing.RectangleF,System.Single,System.Single)
        // <snippet74>
        public void DrawPieRectangleF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle for ellipse.
            RectangleF rect = new RectangleF(0.0F, 0.0F, 200.0F, 100.0F);
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Draw pie to screen.
            e.Graphics.DrawPie(blackPen, rect, startAngle, sweepAngle);
        }
        // </snippet74>


        // Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet75>
        public void DrawPieInt(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
                     
            // Create start and sweep angles.
            int startAngle =  0;
            int sweepAngle = 45;
                     
            // Draw pie to screen.
            e.Graphics.DrawPie(blackPen, x, y, width, height, startAngle, sweepAngle);
        }
        // </snippet75>


        // Snippet for: M:System.Drawing.Graphics.DrawPie(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
        // <snippet76>
        public void DrawPieFloat(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 100.0F;
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Draw pie to screen.
            e.Graphics.DrawPie(blackPen, x, y, width, height, startAngle, sweepAngle);
        }
        // </snippet76>


        // Snippet for: M:System.Drawing.Graphics.DrawPolygon(System.Drawing.Pen,System.Drawing.Point[])
        // <snippet77>
        public void DrawPolygonPointF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points that define polygon.
            PointF point1 = new PointF(50.0F,  50.0F);
            PointF point2 = new PointF(100.0F,  25.0F);
            PointF point3 = new PointF(200.0F,   5.0F);
            PointF point4 = new PointF(250.0F,  50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints =
                     {
                         point1,
                         point2,
                         point3,
                         point4,
                         point5,
                         point6,
                         point7
                     };
                     
            // Draw polygon curve to screen.
            e.Graphics.DrawPolygon(blackPen, curvePoints);
        }
        // </snippet77>


        // Snippet for: M:System.Drawing.Graphics.DrawPolygon(System.Drawing.Pen,System.Drawing.PointF[])
        // <snippet78>
        public void DrawPolygonPoint(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points that define polygon.
            Point point1 = new Point(50,  50);
            Point point2 = new Point(100,  25);
            Point point3 = new Point(200,   5);
            Point point4 = new Point(250,  50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints =
                     {
                         point1,
                         point2,
                         point3,
                         point4,
                         point5,
                         point6,
                         point7
                     };
                     
            // Draw polygon to screen.
            e.Graphics.DrawPolygon(blackPen, curvePoints);
        }
        // </snippet78>


        // Snippet for: M:System.Drawing.Graphics.DrawRectangle(System.Drawing.Pen,System.Drawing.Rectangle)
        // <snippet79>
        public void DrawRectangleRectangle(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);
                     
            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
        }
        // </snippet79>


        // Snippet for: M:System.Drawing.Graphics.DrawRectangle(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet80>
        public void DrawRectangleInt(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of rectangle.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 200;
                     
            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
        }
        // </snippet80>


        // Snippet for: M:System.Drawing.Graphics.DrawRectangle(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single)
        // <snippet81>
        public void DrawRectangleFloat(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of rectangle.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 200.0F;
                     
            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
        }
        // </snippet81>


        // Snippet for: M:System.Drawing.Graphics.DrawRectangles(System.Drawing.Pen,System.Drawing.Rectangle[])
        // <snippet82>
        public void DrawRectanglesRectangle(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create array of rectangles.
            Rectangle[] rects =
                     {
                         new Rectangle( 0,   0, 100, 200),
                         new Rectangle(100, 200, 250,  50),
                         new Rectangle(300,   0,  50, 100)
                     };
                     
            // Draw rectangles to screen.
            e.Graphics.DrawRectangles(blackPen, rects);
        }
        // </snippet82>


        // Snippet for: M:System.Drawing.Graphics.DrawRectangles(System.Drawing.Pen,System.Drawing.RectangleF[])
        // <snippet83>
        public void DrawRectanglesRectangleF(PaintEventArgs e)
        {
                     
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create array of rectangles.
            RectangleF[] rects =
                     {
                         new RectangleF( 0.0F,   0.0F, 100.0F, 200.0F),
                         new RectangleF(100.0F, 200.0F, 250.0F,  50.0F),
                         new RectangleF(300.0F,   0.0F,  50.0F, 100.0F)
                     };
                     
            // Draw rectangles to screen.
            e.Graphics.DrawRectangles(blackPen, rects);
        }
        // </snippet83>


        // Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.PointF)
        // <snippet84>
        public void DrawStringPointF(PaintEventArgs e)
        {
                     
            // Create string to draw.
            String drawString = "Sample Text";
                     
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
                     
            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(150.0F, 150.0F);
                     
            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
        }
        // </snippet84>


        // Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.PointF,System.Drawing.StringFormat)
        // <snippet85>
        public void DrawStringPointFFormat(PaintEventArgs e)
        {
                     
            // Create string to draw.
            String drawString = "Sample Text";
                     
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
                     
            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(150.0F, 50.0F);
                     
            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                     
            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint, drawFormat);
        }
        // </snippet85>


        // Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.RectangleF)
        // <snippet86>
        public void DrawStringRectangleF(PaintEventArgs e)
        {
                     
            // Create string to draw.
            String drawString = "Sample Text";
                     
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
                     
            // Create rectangle for drawing.
            float x = 150.0F;
            float y = 150.0F;
            float width = 200.0F;
            float height = 50.0F;
            RectangleF drawRect = new RectangleF(x, y, width, height);
                     
            // Draw rectangle to screen.
            Pen blackPen = new Pen(Color.Black);
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
                     
            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect);
        }
        // </snippet86>


        // Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Drawing.RectangleF,System.Drawing.StringFormat)
        // <snippet87>
        public void DrawStringRectangleFFormat(PaintEventArgs e)
        {
                     
            // Create string to draw.
            String drawString = "Sample Text";
                     
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
                     
            // Create rectangle for drawing.
            float x = 150.0F;
            float y = 150.0F;
            float width = 200.0F;
            float height = 50.0F;
            RectangleF drawRect = new RectangleF(x, y, width, height);
                     
            // Draw rectangle to screen.
            Pen blackPen = new Pen(Color.Black);
            e.Graphics.DrawRectangle(blackPen, x, y, width, height);
                     
            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
                     
            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, drawRect, drawFormat);
        }
        // </snippet87>


        // Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Single,System.Single)
        // <snippet88>
        public void DrawStringFloat(PaintEventArgs e)
        {
                     
            // Create string to draw.
            String drawString = "Sample Text";
                     
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
                     
            // Create point for upper-left corner of drawing.
            float x = 150.0F;
            float y = 150.0F;
                     
            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y);
        }
        // </snippet88>


        // Snippet for: M:System.Drawing.Graphics.DrawString(System.String,System.Drawing.Font,System.Drawing.Brush,System.Single,System.Single,System.Drawing.StringFormat)
        // <snippet89>
        public void DrawStringFloatFormat(PaintEventArgs e)
        {
                     
            // Create string to draw.
            String drawString = "Sample Text";
                     
            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
                     
            // Create point for upper-left corner of drawing.
            float x = 150.0F;
            float y =  50.0F;
                     
            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                     
            // Draw string to screen.
            e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
        }
        // </snippet89>


        // Snippet for: M:System.Drawing.Graphics.EndContainer(System.Drawing.Drawing2D.GraphicsContainer)
        // <snippet90>
        public void EndContainerState(PaintEventArgs e)
        {
                     
            // Begin graphics container.
            GraphicsContainer containerState = e.Graphics.BeginContainer();
                     
            // Translate world transformation.
            e.Graphics.TranslateTransform(100.0F, 100.0F);
                     
            // Fill translated rectangle in container with red.
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0, 0, 200, 200);
                     
            // End graphics container.
            e.Graphics.EndContainer(containerState);
                     
            // Fill untransformed rectangle with green.
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 0, 0, 200, 200);
        }
        // </snippet90>


        

        // Snippet for: M:System.Drawing.Graphics.ExcludeClip(System.Drawing.Region)
        // <snippet91>
        public void ExcludeClipRegion(PaintEventArgs e)
        {
                     
            // Create rectangle for region.
            Rectangle excludeRect = new Rectangle(100, 100, 200, 200);
                     
            // Create region for exclusion.
            Region excludeRegion = new Region(excludeRect);
                     
            // Set clipping region to exclude region.
            e.Graphics.ExcludeClip(excludeRegion);
                     
            // Fill large rectangle to show clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 300, 300);
        }
        // </snippet91>


        // Snippet for: M:System.Drawing.Graphics.ExcludeClip(System.Drawing.Rectangle)
        // <snippet92>
        public void ExcludeClipRectangle(PaintEventArgs e)
        {
                     
            // Create rectangle for exclusion.
            Rectangle excludeRect = new Rectangle(100, 100, 200, 200);
                     
            // Set clipping region to exclude rectangle.
            e.Graphics.ExcludeClip(excludeRect);
                     
            // Fill large rectangle to show clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 300, 300);
        }
        // </snippet92>


        // Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.Point[])
        // <snippet93>
        public void FillClosedCurvePoint(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            //Create array of points for curve.
            Point point1 = new Point(100, 100);
            Point point2 = new Point(200,  50);
            Point point3 = new Point(250, 200);
            Point point4 = new Point(50, 150);
            Point[] points = {point1, point2, point3, point4};
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points);
        }
        // </snippet93>


        // Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.Point[],System.Drawing.Drawing2D.FillMode)
        // <snippet94>
        public void FillClosedCurvePointFillMode(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            //Create array of points for curve.
            Point point1 = new Point(100, 100);
            Point point2 = new Point(200,  50);
            Point point3 = new Point(250, 200);
            Point point4 = new Point(50, 150);
            Point[] points = {point1, point2, point3, point4};
                     
            // Set fill mode.
            FillMode newFillMode = FillMode.Winding;
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points, newFillMode);
        }
        // </snippet94>


        // Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.Point[],System.Drawing.Drawing2D.FillMode,System.Single)
        // <snippet95>
        public void FillClosedCurvePointFillModeTension(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create array of points for curve.
            Point point1 = new Point(100, 100);
            Point point2 = new Point(200,  50);
            Point point3 = new Point(250, 200);
            Point point4 = new Point(50, 150);
            Point[] points = {point1, point2, point3, point4};
                     
            // Set fill mode.
            FillMode newFillMode = FillMode.Winding;
                     
            // Set tension.
            float tension = 1.0F;
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points, newFillMode, tension);
        }
        // </snippet95>


        // Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.PointF[])
        // <snippet96>
        public void FillClosedCurvePointF(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            //Create array of points for curve.
            PointF point1 = new PointF(100.0F, 100.0F);
            PointF point2 = new PointF(200.0F,  50.0F);
            PointF point3 = new PointF(250.0F, 200.0F);
            PointF point4 = new PointF(50.0F, 150.0F);
            PointF[] points = {point1, point2, point3, point4};
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points);
        }
        // </snippet96>


        // Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.PointF[],System.Drawing.Drawing2D.FillMode)
        // <snippet97>
        public void FillClosedCurvePointFFillMode(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create array of points for curve.
            PointF point1 = new PointF(100.0F, 100.0F);
            PointF point2 = new PointF(200.0F,  50.0F);
            PointF point3 = new PointF(250.0F, 200.0F);
            PointF point4 = new PointF(50.0F, 150.0F);
            PointF[] points = {point1, point2, point3, point4};
                     
            // Set fill mode.
            FillMode newFillMode = FillMode.Winding;
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points, newFillMode);
        }
        // </snippet97>


        // Snippet for: M:System.Drawing.Graphics.FillClosedCurve(System.Drawing.Brush,System.Drawing.PointF[],System.Drawing.Drawing2D.FillMode,System.Single)
        // <snippet98>
        public void FillClosedCurvePointFFillModeTension(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create array of points for curve.
            PointF point1 = new PointF(100.0F, 100.0F);
            PointF point2 = new PointF(200.0F,  50.0F);
            PointF point3 = new PointF(250.0F, 200.0F);
            PointF point4 = new PointF(50.0F, 150.0F);
            PointF[] points = {point1, point2, point3, point4};
                     
            // Set fill mode.
            FillMode newFillMode = FillMode.Winding;
                     
            // Set tension.
            float tension = 1.0F;
                     
            // Fill curve on screen.
            e.Graphics.FillClosedCurve(redBrush, points, newFillMode, tension);
        }
        // </snippet98>


        // Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Drawing.Rectangle)
        // <snippet99>
        public void FillEllipseRectangle(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create rectangle for ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
            Rectangle rect = new Rectangle(x, y, width, height);
                     
            // Fill ellipse on screen.
            e.Graphics.FillEllipse(redBrush, rect);
        }
        // </snippet99>


        // Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Drawing.RectangleF)
        // <snippet100>
        public void FillEllipseRectangleF(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create rectangle for ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 100.0F;
            RectangleF rect = new RectangleF(x, y, width, height);
                     
            // Fill ellipse on screen.
            e.Graphics.FillEllipse(redBrush, rect);
        }
        // </snippet100>


        // Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet101>
        public void FillEllipseInt(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create location and size of ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
                     
            // Fill ellipse on screen.
            e.Graphics.FillEllipse(redBrush, x, y, width, height);
        }
        // </snippet101>


        // Snippet for: M:System.Drawing.Graphics.FillEllipse(System.Drawing.Brush,System.Single,System.Single,System.Single,System.Single)
        // <snippet102>
        public void FillEllipseFloat(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create location and size of ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 100.0F;
                     
            // Fill ellipse on screen.
            e.Graphics.FillEllipse(redBrush, x, y, width, height);
        }
        // </snippet102>


        // Snippet for: M:System.Drawing.Graphics.FillPath(System.Drawing.Brush,System.Drawing.Drawing2D.GraphicsPath)
        // <snippet103>
        public void FillPathEllipse(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create graphics path object and add ellipse.
            GraphicsPath graphPath = new GraphicsPath();
            graphPath.AddEllipse(0, 0, 200, 100);
                     
            // Fill graphics path to screen.
            e.Graphics.FillPath(redBrush, graphPath);
        }
        // </snippet103>


        // Snippet for: M:System.Drawing.Graphics.FillPie(System.Drawing.Brush,System.Drawing.Rectangle,System.Single,System.Single)
        // <snippet104>
        public void FillPieRectangle(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create rectangle for ellipse.
            Rectangle rect = new Rectangle(0, 0, 200, 100);
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Fill pie to screen.
            e.Graphics.FillPie(redBrush, rect, startAngle, sweepAngle);
        }
        // </snippet104>


        // Snippet for: M:System.Drawing.Graphics.FillPie(System.Drawing.Brush,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet105>
        public void FillPieInt(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create location and size of ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
                     
            // Create start and sweep angles.
            int startAngle =  0;
            int sweepAngle = 45;
                     
            // Fill pie to screen.
            e.Graphics.FillPie(redBrush, x, y, width, height, startAngle, sweepAngle);
        }
        // </snippet105>


        // Snippet for: M:System.Drawing.Graphics.FillPie(System.Drawing.Brush,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
        // <snippet106>
        public void FillPieFloat(PaintEventArgs e)
        {
                     
            // Create solid brush.
            SolidBrush redBrush = new SolidBrush(Color.Red);
                     
            // Create location and size of ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 100.0F;
                     
            // Create start and sweep angles.
            float startAngle =  0.0F;
            float sweepAngle = 45.0F;
                     
            // Fill pie to screen.
            e.Graphics.FillPie(redBrush, x, y, width, height, startAngle, sweepAngle);
        }
        // </snippet106>


        // Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.Point[])
        // <snippet107>
        public void FillPolygonPoint(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create points that define polygon.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw polygon to screen.
            e.Graphics.FillPolygon(blueBrush, curvePoints);
        }
        // </snippet107>


        // Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.Point[],System.Drawing.Drawing2D.FillMode)
        // <snippet108>
        public void FillPolygonPointFillMode(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create points that define polygon.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Define fill mode.
            FillMode newFillMode = FillMode.Winding;

            // Draw polygon to screen.
            e.Graphics.FillPolygon(blueBrush, curvePoints, newFillMode);
        }
        // </snippet108>


        // Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.PointF[])
        // <snippet109>
        public void FillPolygonPointF(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create points that define polygon.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Fill polygon to screen.
            e.Graphics.FillPolygon(blueBrush, curvePoints);
        }
        // </snippet109>


        // Snippet for: M:System.Drawing.Graphics.FillPolygon(System.Drawing.Brush,System.Drawing.PointF[],System.Drawing.Drawing2D.FillMode)
        // <snippet110>
        public void FillPolygonPointFFillMode(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create points that define polygon.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Define fill mode.
            FillMode newFillMode = FillMode.Winding;

            // Fill polygon to screen.
            e.Graphics.FillPolygon(blueBrush, curvePoints, newFillMode);
        }
        // </snippet110>

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }
    }
}
