using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;


namespace System.Drawing.ClassicGraphicsExamplesCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
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

        

        // Snippet for: M:System.Drawing.Graphics.AddMetafileComment(System.Byte[])
        // <snippet1>
        private void AddMetafileCommentBytes(PaintEventArgs e)
        {
            // Create temporary Graphics object for metafile
            //  creation and get handle to its device context.
            Graphics newGraphics = this.CreateGraphics();
            IntPtr hdc = newGraphics.GetHdc();
                     
            // Create metafile object to record.
            Metafile metaFile1 = new Metafile("SampMeta.emf", hdc);
                     
            // Create graphics object to record metaFile.
            Graphics metaGraphics = Graphics.FromImage(metaFile1);
                     
            // Draw rectangle in metaFile.
            metaGraphics.DrawRectangle(new Pen(Color.Black, 5), 0, 0, 100, 100);
                     
            // Create comment and add to metaFile.
            byte[] metaComment = {(byte)'T', (byte)'e', (byte)'s', (byte)'t'};
            metaGraphics.AddMetafileComment(metaComment);
                     
            // Dispose of graphics object.
            metaGraphics.Dispose();
                     
            // Dispose of metafile.
            metaFile1.Dispose();
                     
            // Release handle to temporary device context.
            newGraphics.ReleaseHdc(hdc);
                     
            // Dispose of scratch graphics object.
            newGraphics.Dispose();
                     
            // Create existing metafile object to draw.
            Metafile metaFile2 = new Metafile("SampMeta.emf");
                     
            // Draw metaFile to screen.
            e.Graphics.DrawImage(metaFile2, new Point(0, 0));
                     
            // Dispose of metafile.
            metaFile2.Dispose();
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Graphics.BeginContainer
        // <snippet2>
        private void BeginContainerVoid(PaintEventArgs e)
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
        // </snippet2>


        // Snippet for: M:System.Drawing.Graphics.BeginContainer(System.Drawing.Rectangle,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
        // <snippet3>
        private void BeginContainerRectangle(PaintEventArgs e)
        {
            // Define transformation for container.
            Rectangle srcRect = new Rectangle(0, 0, 200, 200);
            Rectangle destRect = new Rectangle(100, 100, 150, 150);
                     
            // Begin graphics container.
            GraphicsContainer containerState = e.Graphics.BeginContainer(
                destRect, srcRect,
                GraphicsUnit.Pixel);
                     
            // Fill red rectangle in container.
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0, 0, 200, 200);
                     
            // End graphics container.
            e.Graphics.EndContainer(containerState);
                     
            // Fill untransformed rectangle with green.
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 0, 0, 200, 200);
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Graphics.BeginContainer(System.Drawing.RectangleF,System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
        // <snippet4>
        private void BeginContainerRectangleF(PaintEventArgs e)
        {
            // Define transformation for container.
            RectangleF srcRect = new RectangleF(0.0F, 0.0F, 200.0F, 200.0F);
            RectangleF destRect = new RectangleF(100.0F, 100.0F, 150.0F, 150.0F);
                     
            // Begin graphics container.
            GraphicsContainer containerState = e.Graphics.BeginContainer(
                destRect, srcRect,
                GraphicsUnit.Pixel);
                     
            // Fill red rectangle in container.
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0.0F, 0.0F, 200.0F, 200.0F);
                     
            // End graphics container.
            e.Graphics.EndContainer(containerState);
                     
            // Fill untransformed rectangle with green.
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), 0.0F, 0.0F, 200.0F, 200.0F);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Graphics.Clear(System.Drawing.Color)
        // <snippet5>
        private void ClearColor(PaintEventArgs e)
        {
            // Clear screen with teal background.
            e.Graphics.Clear(Color.Teal);
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Graphics.Dispose
        // <snippet6>
        private void FromImageImage1(PaintEventArgs e)
        {
            // Create image.
            Image imageFile = Image.FromFile("SampImag.jpg");
                     
            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);
                     
            // Alter image.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 100, 50, 100, 100);
                     
            // Draw image to screen.
            e.Graphics.DrawImage(imageFile, new PointF(0.0F, 0.0F));
                     
            // Release graphics object.
            newGraphics.Dispose();
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Drawing.Rectangle,System.Single,System.Single)
        // <snippet7>
        private void DrawArcRectangle(PaintEventArgs e)
        {
           // Create pen.
            Pen blackPen= new Pen(Color.Black, 3);
                     
            // Create rectangle to bound ellipse.
            Rectangle rect = new Rectangle(0, 0, 100, 200);
                     
            // Create start and sweep angles on ellipse.
            float startAngle =  45.0F;
            float sweepAngle = 270.0F;
                     
            // Draw arc to screen.
            e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Drawing.RectangleF,System.Single,System.Single)
        // <snippet8>
        private void DrawArcRectangleF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen= new Pen(Color.Black, 3);
                     
            // Create rectangle to bound ellipse.
            RectangleF rect = new RectangleF(0.0F, 0.0F, 100.0F, 200.0F);
                     
            // Create start and sweep angles on ellipse.
            float startAngle =  45.0F;
            float sweepAngle = 270.0F;
                     
            // Draw arc to screen.
            e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);
        }
        // </snippet8>


        // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet9>
        private void DrawArcInt(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen= new Pen(Color.Black, 3);
                     
            // Create coordinates of rectangle to bound ellipse.
            int x = 0;
            int y = 0;
            int width = 100;
            int height = 200;
                     
            // Create start and sweep angles on ellipse.
            int startAngle =  45;
            int sweepAngle = 270;
                     
            // Draw arc to screen.
            e.Graphics.DrawArc(blackPen, x, y, width, height, startAngle, sweepAngle);
        }
        // </snippet9>


        // Snippet for: M:System.Drawing.Graphics.DrawArc(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
        // <snippet10>
        private void DrawArcFloat(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen= new Pen(Color.Black, 3);
                     
            // Create coordinates of rectangle to bound ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 100.0F;
            float height = 200.0F;
                     
            // Create start and sweep angles on ellipse.
            float startAngle =  45.0F;
            float sweepAngle = 270.0F;
                     
            // Draw arc to screen.
            e.Graphics.DrawArc(blackPen, x, y, width, height, startAngle, sweepAngle);
        }
        // </snippet10>


        // Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Drawing.Point,System.Drawing.Point,System.Drawing.Point,System.Drawing.Point)
        // <snippet11>
        private void DrawBezierPoint(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points for curve.
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end = new Point(500, 100);
                     
            // Draw arc to screen.
            e.Graphics.DrawBezier(blackPen, start, control1, control2, end);
        }
        // </snippet11>


        // Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Drawing.PointF,System.Drawing.PointF,System.Drawing.PointF,System.Drawing.PointF)
        // <snippet12>
        private void DrawBezierPointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points for curve.
            PointF start = new PointF(100.0F, 100.0F);
            PointF control1 = new PointF(200.0F, 10.0F);
            PointF control2 = new PointF(350.0F, 50.0F);
            PointF end = new PointF(500.0F, 100.0F);
                     
            // Draw arc to screen.
            e.Graphics.DrawBezier(blackPen, start, control1, control2, end);
        }
        // </snippet12>


        // Snippet for: M:System.Drawing.Graphics.DrawBezier(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single)
        // <snippet13>
        private void DrawBezierFloat(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create coordinates of points for curve.
            float startX = 100.0F;
            float startY = 100.0F;
            float controlX1 = 200.0F;
            float controlY1 =  10.0F;
            float controlX2 = 350.0F;
            float controlY2 =  50.0F;
            float endX = 500.0F;
            float endY = 100.0F;
                     
            // Draw arc to screen.
            e.Graphics.DrawBezier(blackPen, startX, startY,
                controlX1, controlY1,
                controlX2, controlY2,
                endX, endY);
        }
        // </snippet13>


        // Snippet for: M:System.Drawing.Graphics.DrawBeziers(System.Drawing.Pen,System.Drawing.Point[])
        // <snippet14>
        private void DrawBeziersPoint(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points for curve.
            Point start = new Point(100, 100);
            Point control1 = new Point(200, 10);
            Point control2 = new Point(350, 50);
            Point end1 = new Point(500, 100);
            Point control3 = new Point(600, 150);
            Point control4 = new Point(650, 250);
            Point end2 = new Point(500, 300);
            Point[] bezierPoints =
                     {
                         start, control1, control2, end1,
                         control3, control4, end2
                     };
                     
            // Draw arc to screen.
            e.Graphics.DrawBeziers(blackPen, bezierPoints);
        }
        // </snippet14>


        // Snippet for: M:System.Drawing.Graphics.DrawBeziers(System.Drawing.Pen,System.Drawing.PointF[])
        // <snippet15>
        private void DrawBeziersPointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points for curve.
            PointF start = new PointF(100.0F, 100.0F);
            PointF control1 = new PointF(200.0F, 10.0F);
            PointF control2 = new PointF(350.0F, 50.0F);
            PointF end1 = new PointF(500.0F, 100.0F);
            PointF control3 = new PointF(600.0F, 150.0F);
            PointF control4 = new PointF(650.0F, 250.0F);
            PointF end2 = new PointF(500.0F, 300.0F);
            PointF[] bezierPoints = { start, control1, control2, end1,
                 control3, control4, end2 };      
                         
            // Draw arc to screen.
            e.Graphics.DrawBeziers(blackPen, bezierPoints);
        }
        // </snippet15>


        // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.Point[])
        // <snippet16>
        private void DrawClosedCurvePoint(PaintEventArgs e)
        {
            // Create pens.
            Pen redPen   = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);
                     
            // Create points that define curve.
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
                     
            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);
                     
            // Draw closed curve to screen.
            e.Graphics.DrawClosedCurve(greenPen, curvePoints);
        }
        // </snippet16>


        // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.Point[],System.Single,System.Drawing.Drawing2D.FillMode)
        // <snippet17>
        private void DrawClosedCurvePointTension(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create tension and fill mode.
            float tension = 1.0F;
            FillMode aFillMode = FillMode.Alternate;

            // Draw closed curve to screen.
            e.Graphics.DrawClosedCurve(greenPen, curvePoints, tension, aFillMode);
        }
        // </snippet17>


        // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.PointF[])
        // <snippet18>
        private void DrawClosedCurvePointF(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Draw closed curve to screen.
            e.Graphics.DrawClosedCurve(greenPen, curvePoints);
        }
        // </snippet18>


        // Snippet for: M:System.Drawing.Graphics.DrawClosedCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Single,System.Drawing.Drawing2D.FillMode)
        // <snippet19>
        private void DrawClosedCurvePointFTension(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create tension and fill mode.
            float tension = 1.0F;
            FillMode aFillMode = FillMode.Alternate;

            // Draw closed curve to screen.
            e.Graphics.DrawClosedCurve(greenPen, curvePoints, tension, aFillMode);
        }
        // </snippet19>


        // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[])
        // <snippet20>
        private void DrawCurvePoint(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints);
        }
        // </snippet20>


        // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[],System.Int32,System.Int32,System.Single)
        // <snippet21>
        private void DrawCurvePointSegmentTension(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create offset, number of segments, and tension.
            int offset = 2;
            int numSegments = 4;
            float tension = 1.0F;

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints, offset, numSegments, tension);
        }
        // </snippet21>


        // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.Point[],System.Single)
        // <snippet22>
        private void DrawCurvePointTension(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            Point point1 = new Point(50, 50);
            Point point2 = new Point(100, 25);
            Point point3 = new Point(200, 5);
            Point point4 = new Point(250, 50);
            Point point5 = new Point(300, 100);
            Point point6 = new Point(350, 200);
            Point point7 = new Point(250, 250);
            Point[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create tension.
            float tension = 1.0F;

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints, tension);
        }
        // </snippet22>


        // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[])
        // <snippet23>
        private void DrawCurvePointF(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints);
        }
        // </snippet23>


        // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Int32,System.Int32)
        // <snippet24>
        private void DrawCurvePointFSegments(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create offset and number of segments.
            int offset = 2;
            int numSegments = 4;

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints, offset, numSegments);
        }
        // </snippet24>


        // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Int32,System.Int32,System.Single)
        // <snippet25>
        private void DrawCurvePointFSegmentTension(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create offset, number of segments, and tension.
            int offset = 2;
            int numSegments = 4;
            float tension = 1.0F;

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints, offset, numSegments, tension);
        }
        // </snippet25>


        // Snippet for: M:System.Drawing.Graphics.DrawCurve(System.Drawing.Pen,System.Drawing.PointF[],System.Single)
        // <snippet26>
        private void DrawCurvePointFTension(PaintEventArgs e)
        {

            // Create pens.
            Pen redPen = new Pen(Color.Red, 3);
            Pen greenPen = new Pen(Color.Green, 3);

            // Create points that define curve.
            PointF point1 = new PointF(50.0F, 50.0F);
            PointF point2 = new PointF(100.0F, 25.0F);
            PointF point3 = new PointF(200.0F, 5.0F);
            PointF point4 = new PointF(250.0F, 50.0F);
            PointF point5 = new PointF(300.0F, 100.0F);
            PointF point6 = new PointF(350.0F, 200.0F);
            PointF point7 = new PointF(250.0F, 250.0F);
            PointF[] curvePoints = {point1, point2, point3, point4, point5, point6, point7};

            // Draw lines between original points to screen.
            e.Graphics.DrawLines(redPen, curvePoints);

            // Create tension.
            float tension = 1.0F;

            // Draw curve to screen.
            e.Graphics.DrawCurve(greenPen, curvePoints, tension);
        }
        // </snippet26>


        // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Drawing.Rectangle)
        // <snippet27>
        private void DrawEllipseRectangle(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle for ellipse.
            Rectangle rect = new Rectangle(0, 0, 200, 100);
                     
            // Draw ellipse to screen.
            e.Graphics.DrawEllipse(blackPen, rect);
        }
        // </snippet27>


        // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Drawing.RectangleF)
        // <snippet28>
        private void DrawEllipseRectangleF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create rectangle for ellipse.
            RectangleF rect = new RectangleF(0.0F, 0.0F, 200.0F, 100.0F);
                     
            // Draw ellipse to screen.
            e.Graphics.DrawEllipse(blackPen, rect);
        }
        // </snippet28>


        // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet29>
        private void DrawEllipseInt(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of ellipse.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 100;
                     
            // Draw ellipse to screen.
            e.Graphics.DrawEllipse(blackPen, x, y, width, height);
        }
        // </snippet29>


        // Snippet for: M:System.Drawing.Graphics.DrawEllipse(System.Drawing.Pen,System.Single,System.Single,System.Single,System.Single)
        // <snippet30>
        private void DrawEllipseFloat(PaintEventArgs e)
        {         
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create location and size of ellipse.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 100.0F;
                     
            // Draw ellipse to screen.
            e.Graphics.DrawEllipse(blackPen, x, y, width, height);
        }
        // </snippet30>


        // Snippet for: M:System.Drawing.Graphics.DrawIcon(System.Drawing.Icon,System.Drawing.Rectangle)
        // <snippet31>
        private void DrawIconRectangle(PaintEventArgs e)
        {        
            // Create icon.
            Icon newIcon = new Icon("SampIcon.ico");
                     
            // Create rectangle for icon.
            Rectangle rect = new Rectangle(100, 100, 200, 200);
                     
            // Draw icon to screen.
            e.Graphics.DrawIcon(newIcon, rect);
        }
        // </snippet31>


        // Snippet for: M:System.Drawing.Graphics.DrawIcon(System.Drawing.Icon,System.Int32,System.Int32)
        // <snippet32>
        private void DrawIconInt(PaintEventArgs e)
        {
            // Create icon.
            Icon newIcon = new Icon("SampIcon.ico");
                     
            // Create coordinates for upper-left corner of icon.
            int x = 100;
            int y = 100;
                     
            // Draw icon to screen.
            e.Graphics.DrawIcon(newIcon, x, y);
        }
        // </snippet32>


        // Snippet for: M:System.Drawing.Graphics.DrawIconUnstretched(System.Drawing.Icon,System.Drawing.Rectangle)
        // <snippet33>
        private void DrawIconUnstretchedRectangle(PaintEventArgs e)
        {
            // Create icon.
            Icon newIcon = new Icon("SampIcon.ico");
                     
            // Create rectangle for icon.
            Rectangle rect = new Rectangle(100, 100, 200, 200);
                     
            // Draw icon to screen.
            e.Graphics.DrawIconUnstretched(newIcon, rect);
        }
        // </snippet33>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point)
        // <snippet34>
        private void DrawImagePoint(PaintEventArgs e)
        {         
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create Point for upper-left corner of image.
            Point ulCorner = new Point(100, 100);
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, ulCorner);
        }
        // </snippet34>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[])
        // <snippet35>
        private void DrawImagePara(PaintEventArgs e)
        {
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(550, 100);
            Point llCorner = new Point(150, 250);
            Point[] destPara = {ulCorner, urCorner, llCorner};
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara);
        }
        // </snippet35>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
        // <snippet36>
        private void DrawImageParaRect(PaintEventArgs e)
        {
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(325, 100);
            Point llCorner = new Point(150, 250);
            Point[] destPara = {ulCorner, urCorner, llCorner};
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara, srcRect, units);
        }
        // </snippet36>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
        // <snippet37>
        private void DrawImageParaRectAttrib(PaintEventArgs e)
        {
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            Point ulCorner1 = new Point(100, 100);
            Point urCorner1 = new Point(325, 100);
            Point llCorner1 = new Point(150, 250);
            Point[] destPara1 = {ulCorner1, urCorner1, llCorner1};
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create parallelogram for drawing adjusted image.
            Point ulCorner2 = new Point(325, 100);
            Point urCorner2 = new Point(550, 100);
            Point llCorner2 = new Point(375, 250);
            Point[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
                     
            // Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, imageAttr);
        }
        // </snippet37>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        // <snippet38>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback1(IntPtr callBackData)
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
        private void DrawImageParaRectAttribAbort(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback1);
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing original image.
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(550, 100);
            Point llCorner = new Point(150, 250);
            Point[] destPara1 = {ulCorner, urCorner, llCorner};
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create parallelogram for drawing adjusted image.
            Point ulCorner2 = new Point(325, 100);
            Point urCorner2 = new Point(550, 100);
            Point llCorner2 = new Point(375, 250);
            Point[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
            try
            {
                checked
                {
                     
                    // Draw image to screen.
                    e.Graphics.DrawImage(
                        newImage,
                        destPara2,
                        srcRect,
                        units,
                        imageAttr,
                        imageCallback);
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
        // </snippet38>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Point[],System.Drawing.Rectangle,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
        // <snippet39>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback2(IntPtr callBackData)
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
        private void DrawImageParaRectAttribAbortData(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback2);
            int imageCallbackData = 1;
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing original image.
            Point ulCorner = new Point(100, 100);
            Point urCorner = new Point(550, 100);
            Point llCorner = new Point(150, 250);
            Point[] destPara1 = {ulCorner, urCorner, llCorner};
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create parallelogram for drawing adjusted image.
            Point ulCorner2 = new Point(325, 100);
            Point urCorner2 = new Point(550, 100);
            Point llCorner2 = new Point(375, 250);
            Point[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
            try
            {
                checked
                {
                     
                    // Draw image to screen.
                    e.Graphics.DrawImage(
                        newImage,
                        destPara2,
                        srcRect,
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
        // </snippet39>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF)
        // <snippet40>
        private void DrawImagePointF(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create point for upper-left corner of image.
            PointF ulCorner = new PointF(100.0F, 100.0F);
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, ulCorner);
        }
        // </snippet40>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[])
        // <snippet41>
        private void DrawImageParaF(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            PointF ulCorner = new PointF(100.0F, 100.0F);
            PointF urCorner = new PointF(550.0F, 100.0F);
            PointF llCorner = new PointF(150.0F, 250.0F);
            PointF[] destPara = {ulCorner, urCorner, llCorner};
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara);
        }
        // </snippet41>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit)
        // <snippet42>
        private void DrawImageParaFRectF(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing image.
            PointF ulCorner = new PointF(100.0F, 100.0F);
            PointF urCorner = new PointF(550.0F, 100.0F);
            PointF llCorner = new PointF(150.0F, 250.0F);
            PointF[] destPara = {ulCorner, urCorner, llCorner};
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destPara, srcRect, units);
        }
        // </snippet42>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
        // <snippet43>
        private void DrawImageParaFRectFAttrib(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing original image.
            PointF ulCorner1 = new PointF(100.0F, 100.0F);
            PointF urCorner1 = new PointF(325.0F, 100.0F);
            PointF llCorner1 = new PointF(150.0F, 250.0F);
            PointF[] destPara1 = {ulCorner1, urCorner1, llCorner1};
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Create parallelogram for drawing adjusted image.
            PointF ulCorner2 = new PointF(325.0F, 100.0F);
            PointF urCorner2 = new PointF(550.0F, 100.0F);
            PointF llCorner2 = new PointF(375.0F, 250.0F);
            PointF[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
                     
            // Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destPara2, srcRect, units, imageAttr);
        }
        // </snippet43>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        // <snippet44>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback3(IntPtr callBackData)
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
        private void DrawImageParaFRectAttribAbort(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback3);
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing original image.
            PointF ulCorner1 = new PointF(100.0F, 100.0F);
            PointF urCorner1 = new PointF(325.0F, 100.0F);
            PointF llCorner1 = new PointF(150.0F, 250.0F);
            PointF[] destPara1 = {ulCorner1, urCorner1, llCorner1};
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Create parallelogram for drawing adjusted image.
            PointF ulCorner2 = new PointF(325.0F, 100.0F);
            PointF urCorner2 = new PointF(550.0F, 100.0F);
            PointF llCorner2 = new PointF(375.0F, 250.0F);
            PointF[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
            try
            {
                checked
                {
                     
                    // Draw adjusted image to screen.
                    e.Graphics.DrawImage(
                        newImage,
                        destPara2,
                        srcRect,
                        units,
                        imageAttr,
                        imageCallback);
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
        // </snippet44>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.PointF[],System.Drawing.RectangleF,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.Int32)
        // <snippet45>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback4(IntPtr callBackData)
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
        private void DrawImageParaFRectAttribAbortData(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback4);
            int imageCallbackData = 1;
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create parallelogram for drawing original image.
            PointF ulCorner1 = new PointF(100.0F, 100.0F);
            PointF urCorner1 = new PointF(325.0F, 100.0F);
            PointF llCorner1 = new PointF(150.0F, 250.0F);
            PointF[] destPara1 = {ulCorner1, urCorner1, llCorner1};
                     
            // Create rectangle for source image.
            RectangleF srcRect = new RectangleF(50.0F, 50.0F, 150.0F, 150.0F);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Create parallelogram for drawing adjusted image.
            PointF ulCorner2 = new PointF(325.0F, 100.0F);
            PointF urCorner2 = new PointF(550.0F, 100.0F);
            PointF llCorner2 = new PointF(375.0F, 250.0F);
            PointF[] destPara2 = {ulCorner2, urCorner2, llCorner2};
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destPara1, srcRect, units);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
            try
            {
                checked
                {
                     
                    // Draw adjusted image to screen.
                    e.Graphics.DrawImage(
                        newImage,
                        destPara2,
                        srcRect,
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
        // </snippet45>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle)
        // <snippet46>
        private void DrawImageRect(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(100, 100, 450, 150);
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect);
        }
        // </snippet46>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Drawing.Rectangle,System.Drawing.GraphicsUnit)
        // <snippet47>
        private void DrawImageRectRect(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(100, 100, 450, 150);
                     
            // Create rectangle for source image.
            Rectangle srcRect = new Rectangle(50, 50, 150, 150);
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, srcRect, units);
        }
        // </snippet47>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit)
        // <snippet48>
        private void DrawImageRect4Int(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(100, 100, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            int x = 50;
            int y = 50;
            int width = 150;
            int height = 150;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, x, y, width, height, units);
        }
        // </snippet48>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
        // <snippet49>
        private void DrawImageRect4IntAtrrib(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying original image.
            Rectangle destRect1 = new Rectangle(100, 25, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            int x = 50;
            int y = 50;
            int width = 150;
            int height = 150;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, units);
                     
            // Create rectangle for adjusted image.
            Rectangle destRect2 = new Rectangle(100, 175, 450, 150);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
                     
            // Draw adjusted image to screen.
            e.Graphics.DrawImage(newImage, destRect2, x, y, width, height, units, imageAttr);
        }
        // </snippet49>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        // <snippet50>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback5(IntPtr callBackData)
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
        private void DrawImageRect4IntAtrribAbort(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback5);
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying original image.
            Rectangle destRect1 = new Rectangle(100, 25, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            int x = 50;
            int y = 50;
            int width = 150;
            int height = 150;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, units);
                     
            // Create rectangle for adjusted image.
            Rectangle destRect2 = new Rectangle(100, 175, 450, 150);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
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
                        imageCallback);
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
        // </snippet50>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Int32,System.Int32,System.Int32,System.Int32,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort,System.IntPtr)
        // <snippet51>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback6(IntPtr callBackData)
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
        private void DrawImageRect4IntAtrribAbortData(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback6);
            IntPtr imageCallbackData = new IntPtr(1);
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying original image.
            Rectangle destRect1 = new Rectangle(100, 25, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            int x = 50;
            int y = 50;
            int width = 150;
            int height = 150;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw original image to screen.
            e.Graphics.DrawImage(newImage, destRect1, x, y, width, height, units);
                     
            // Create rectangle for adjusted image.
            Rectangle destRect2 = new Rectangle(100, 175, 450, 150);
                     
            // Create image attributes and set large gamma.
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetGamma(4.0F);
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
        // </snippet51>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit)
        // <snippet52>
        private void DrawImageRect4Float(PaintEventArgs e)
        {
                     
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create rectangle for displaying image.
            Rectangle destRect = new Rectangle(100, 100, 450, 150);
                     
            // Create coordinates of rectangle for source image.
            float x = 50.0F;
            float y = 50.0F;
            float width = 150.0F;
            float height = 150.0F;
            GraphicsUnit units = GraphicsUnit.Pixel;
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, destRect, x, y, width, height, units);
        }
        // </snippet52>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes)
        // <snippet53>
        private void DrawImageRect4FloatAttrib(PaintEventArgs e)
        {
                     
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
            e.Graphics.DrawImage(newImage, destRect2, x, y, width, height, units, imageAttr);
        }
        // </snippet53>


        // Snippet for: M:System.Drawing.Graphics.DrawImage(System.Drawing.Image,System.Drawing.Rectangle,System.Single,System.Single,System.Single,System.Single,System.Drawing.GraphicsUnit,System.Drawing.Imaging.ImageAttributes,System.Drawing.Graphics.DrawImageAbort)
        // <snippet54>

        // Define DrawImageAbort callback method.
        private bool DrawImageCallback7(IntPtr callBackData)
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
        private void DrawImageRect4FloatAttribAbort(PaintEventArgs e)
        {
                     
            // Create callback method.
            Graphics.DrawImageAbort imageCallback
                = new Graphics.DrawImageAbort(DrawImageCallback7);
                     
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
                        imageCallback);
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
        // </snippet54>


        // Snippet for: T:System.Drawing.Image
        // <snippet55>
        private void ImageExampleForm_Paint(object sender, PaintEventArgs e)
        {         
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");
                     
            // Create Point for upper-left corner of image.
            Point ulCorner = new Point(100, 100);
                     
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, ulCorner);
        }
        // </snippet55>


       
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
