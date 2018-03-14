using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace System.Drawing.ClassicGraphicsExamples3CS
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    class Form1 : System.Windows.Forms.Form
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Size = new System.Drawing.Size(300, 300);
            this.Text = "Form1";
        }
        #endregion


        // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Drawing.Rectangle)
        // <snippet111>
        private void FillRectangleRectangle(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, rect);
        }
        // </snippet111>


        // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Drawing.RectangleF)
        // <snippet112>
        private void FillRectangleRectangleF(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create rectangle.
            RectangleF rect = new RectangleF(0.0F, 0.0F, 200.0F, 200.0F);

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, rect);
        }
        // </snippet112>


        // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet113>
        private void FillRectangleInt(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create location and size of rectangle.
            int x = 0;
            int y = 0;
            int width = 200;
            int height = 200;

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, x, y, width, height);
        }
        // </snippet113>


        // Snippet for: M:System.Drawing.Graphics.FillRectangle(System.Drawing.Brush,System.Single,System.Single,System.Single,System.Single)
        // <snippet114>
        private void FillRectangleFloat(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create location and size of rectangle.
            float x = 0.0F;
            float y = 0.0F;
            float width = 200.0F;
            float height = 200.0F;

            // Fill rectangle to screen.
            e.Graphics.FillRectangle(blueBrush, x, y, width, height);
        }
        // </snippet114>


        // Snippet for: M:System.Drawing.Graphics.FillRectangles(System.Drawing.Brush,System.Drawing.Rectangle[])
        // <snippet115>
        private void FillRectanglesRectangle(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create array of rectangles.
            Rectangle[] rects = { new Rectangle(0, 0, 100, 200), new Rectangle(100, 200, 250, 50), new Rectangle(300, 0, 50, 100) };

            // Fill rectangles to screen.
            e.Graphics.FillRectangles(blueBrush, rects);
        }
        // </snippet115>


        // Snippet for: M:System.Drawing.Graphics.FillRectangles(System.Drawing.Brush,System.Drawing.RectangleF[])
        // <snippet116>
        private void FillRectanglesRectangleF(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create array of rectangles.
            RectangleF[] rects = { new RectangleF(0.0F, 0.0F, 100.0F, 200.0F), new RectangleF(100.0F, 200.0F, 250.0F, 50.0F), new RectangleF(300.0F, 0.0F, 50.0F, 100.0F) };

            // Fill rectangles to screen.
            e.Graphics.FillRectangles(blueBrush, rects);
        }
        // </snippet116>


        // Snippet for: M:System.Drawing.Graphics.FillRegion(System.Drawing.Brush,System.Drawing.Region)
        // <snippet117>
        private void FillRegionRectangle(PaintEventArgs e)
        {

            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create rectangle for region.
            Rectangle fillRect = new Rectangle(100, 100, 200, 200);

            // Create region for fill.
            Region fillRegion = new Region(fillRect);

            // Fill region to screen.
            e.Graphics.FillRegion(blueBrush, fillRegion);
        }
        // </snippet117>


        // Snippet for: M:System.Drawing.Graphics.FromHdc(System.IntPtr)
        // <snippet118>
        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand, Flags = 
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]            
        private void FromHdcHdc(PaintEventArgs e)
        {

            // Get handle to device context.
            IntPtr hdc = e.Graphics.GetHdc();

            // Create new graphics object using handle to device context.
            Graphics newGraphics = Graphics.FromHdc(hdc);

            // Draw rectangle to screen.
            newGraphics.DrawRectangle(new Pen(Color.Red, 3), 0, 0, 200, 100);

            // Release handle to device context and dispose of the      // Graphics object
            e.Graphics.ReleaseHdc(hdc);
            newGraphics.Dispose();
        }
        // </snippet118>


        // Snippet for: M:System.Drawing.Graphics.FromHwnd(System.IntPtr)
        // <snippet119>
        private void FromHwndHwnd(PaintEventArgs e)
        {

            // Get handle to form.
            IntPtr hwnd = this.Handle;

            // Create new graphics object using handle to window.
            Graphics newGraphics = Graphics.FromHwnd(hwnd);

            // Draw rectangle to screen.
            newGraphics.DrawRectangle(new Pen(Color.Red, 3), 0, 0, 200, 100);

            // Dispose of new graphics.
            newGraphics.Dispose();
        }
        // </snippet119>


        // Snippet for: M:System.Drawing.Graphics.FromImage(System.Drawing.Image)
        // <snippet120>
        private void FromImageImage(PaintEventArgs e)
        {

            // Create image.
            Image imageFile = Image.FromFile("SampImag.jpg");

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            // Alter image.
            newGraphics.FillRectangle(new SolidBrush(Color.Black), 100, 50, 100, 100);

            // Draw image to screen.
            e.Graphics.DrawImage(imageFile, new PointF(0.0F, 0.0F));

            // Dispose of graphics object.
            newGraphics.Dispose();
        }
        // </snippet120>


        // Snippet for: M:System.Drawing.Graphics.GetHalftonePalette
        // <snippet121>
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr SelectPalette(
            IntPtr hdc,
            IntPtr htPalette,
            bool bForceBackground);
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern int RealizePalette(IntPtr hdc);

        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand, Flags = 
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]            
        private void GetHalftonePaletteVoid(PaintEventArgs e)
        {

            // Create and draw image.
            Image imageFile = Image.FromFile("SampImag.jpg");
            e.Graphics.DrawImage(imageFile, new Point(0, 0));

            // Get handle to device context.
            IntPtr hdc = e.Graphics.GetHdc();

            // Get handle to halftone palette.
            IntPtr htPalette = Graphics.GetHalftonePalette();

            // Select and realize new palette.
            SelectPalette(hdc, htPalette, true);
            RealizePalette(hdc);

            // Create new graphics object.
            Graphics newGraphics = Graphics.FromHdc(hdc);

            // Draw image with new palette.
            newGraphics.DrawImage(imageFile, 300, 0);

            // Release handle to device context.
            e.Graphics.ReleaseHdc(hdc);
        }
        // </snippet121>


        // Snippet for: M:System.Drawing.Graphics.GetHdc
        // <snippet122>
        public class GDI
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            internal static extern bool Rectangle(
               IntPtr hdc,
               int ulCornerX, int ulCornerY,
               int lrCornerX, int lrCornerY);
        }

        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand, Flags = 
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]            
        private void GetHdcForGDI1(PaintEventArgs e)
        {

            // Create pen.
            Pen redPen = new Pen(Color.Red, 1);

            // Draw rectangle with GDI+.
            e.Graphics.DrawRectangle(redPen, 10, 10, 100, 50);

            // Get handle to device context.
            IntPtr hdc = e.Graphics.GetHdc();

            // Draw rectangle with GDI using default pen.
            GDI.Rectangle(hdc, 10, 70, 110, 120);

            // Release handle to device context.
            e.Graphics.ReleaseHdc(hdc);
        }
        // </snippet122>


        // Snippet for: M:System.Drawing.Graphics.GetNearestColor(System.Drawing.Color)
        // <snippet123>
        private void GetNearestColorColor(PaintEventArgs e)
        {
            // Create solid brush with arbitrary color.
            Color arbColor = Color.FromArgb(255, 165, 63, 136);
            SolidBrush arbBrush = new SolidBrush(arbColor);

            // Fill ellipse on screen.
            e.Graphics.FillEllipse(arbBrush, 0, 0, 200, 100);

            // Get nearest color.
            Color realColor = e.Graphics.GetNearestColor(arbColor);
            SolidBrush realBrush = new SolidBrush(realColor);

            // Fill ellipse on screen.
            e.Graphics.FillEllipse(realBrush, 0, 100, 200, 100);
        }
        // </snippet123>


        // Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.Rectangle)
        // <snippet124>
        private void IntersectClipRectangle(PaintEventArgs e)
        {

            // Set clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 200, 200);
            e.Graphics.SetClip(clipRect);

            // Update clipping region to intersection of

            // existing region with specified rectangle.
            Rectangle intersectRect = new Rectangle(100, 100, 200, 200);
            e.Graphics.IntersectClip(intersectRect);

            // Fill rectangle to demonstrate effective clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 500, 500);

            // Reset clipping region to infinite.
            e.Graphics.ResetClip();

            // Draw clipRect and intersectRect to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Black), clipRect);
            e.Graphics.DrawRectangle(new Pen(Color.Red), intersectRect);
        }
        // </snippet124>


        // Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.RectangleF)
        // <snippet125>
        private void IntersectClipRectangleF1(PaintEventArgs e)
        {

            // Set clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 200, 200);
            e.Graphics.SetClip(clipRect);

            // Update clipping region to intersection of

            // existing region with specified rectangle.
            RectangleF intersectRectF = new RectangleF(100.0F, 100.0F, 200.0F, 200.0F);
            e.Graphics.IntersectClip(intersectRectF);

            // Fill rectangle to demonstrate effective clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 500, 500);

            // Reset clipping region to infinite.
            e.Graphics.ResetClip();

            // Draw clipRect and intersectRect to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Black), clipRect);
            e.Graphics.DrawRectangle(new Pen(Color.Red), Rectangle.Round(intersectRectF));
        }
        // </snippet125>


        // Snippet for: M:System.Drawing.Graphics.IntersectClip(System.Drawing.Region)
        // <snippet126>
        private void IntersectClipRegion(PaintEventArgs e)
        {

            // Set clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 200, 200);
            Region clipRegion = new Region(clipRect);
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Update clipping region to intersection of

            // existing region with specified rectangle.
            Rectangle intersectRect = new Rectangle(100, 100, 200, 200);
            Region intersectRegion = new Region(intersectRect);
            e.Graphics.IntersectClip(intersectRegion);

            // Fill rectangle to demonstrate effective clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 500, 500);

            // Reset clipping region to infinite.
            e.Graphics.ResetClip();

            // Draw clipRect and intersectRect to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Black), clipRect);
            e.Graphics.DrawRectangle(new Pen(Color.Red), intersectRect);
        }
        // </snippet126>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.Point)
        // <snippet127>
        private void IsVisiblePoint(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of points.
            int x1 = 100;
            int y1 = 100;
            int x2 = 200;
            int y2 = 200;
            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);

            // If point is visible, fill ellipse that represents it.
            if (e.Graphics.IsVisible(point1))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), x1, y1, 10, 10);
            }
            if (e.Graphics.IsVisible(point2))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), x2, y2, 10, 10);
            }
        }
        // </snippet127>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.PointF)
        // <snippet128>
        private void IsVisiblePointF(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of points.
            float x1 = 100.0F;
            float y1 = 100.0F;
            float x2 = 200.0F;
            float y2 = 200.0F;
            PointF point1 = new PointF(x1, y1);
            PointF point2 = new PointF(x2, y2);

            // If point is visible, fill ellipse that represents it.
            if (e.Graphics.IsVisible(point1))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), x1, y1, 10.0F, 10.0F);
            }
            if (e.Graphics.IsVisible(point2))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), x2, y2, 10.0F, 10.0F);
            }
        }
        // </snippet128>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.Rectangle)
        // <snippet129>
        private void IsVisibleRectangle(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of rectangles.
            Rectangle rect1 = new Rectangle(100, 100, 20, 20);
            Rectangle rect2 = new Rectangle(200, 200, 20, 20);

            // If rectangle is visible, fill it.
            if (e.Graphics.IsVisible(rect1))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), rect1);
            }
            if (e.Graphics.IsVisible(rect2))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), rect2);
            }
        }
        // </snippet129>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Drawing.RectangleF)
        // <snippet130>
        private void IsVisibleRectangleF(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of rectangles.
            RectangleF rect1 = new RectangleF(100.0F, 100.0F, 20.0F, 20.0F);
            RectangleF rect2 = new RectangleF(200.0F, 200.0F, 20.0F, 20.0F);

            // If rectangle is visible, fill it.
            if (e.Graphics.IsVisible(rect1))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), rect1);
            }
            if (e.Graphics.IsVisible(rect2))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), rect2);
            }
        }
        // </snippet130>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Int32,System.Int32)
        // <snippet131>
        private void IsVisibleInt(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of points.
            int x1 = 100;
            int y1 = 100;
            int x2 = 200;
            int y2 = 200;

            // If point is visible, fill ellipse that represents it.
            if (e.Graphics.IsVisible(x1, y1))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), x1, y1, 10, 10);
            }
            if (e.Graphics.IsVisible(x2, y2))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), x2, y2, 10, 10);
            }
        }
        // </snippet131>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet132>
        private void IsVisible4Int(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of rectangles.
            int x1 = 100;
            int y1 = 100;
            int width1 = 20;
            int height1 = 20;
            int x2 = 200;
            int y2 = 200;
            int width2 = 20;
            int height2 = 20;

            // If rectangle is visible, fill it.
            if (e.Graphics.IsVisible(x1, y1, width1, height1))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), x1, y1, width1, height1);
            }
            if (e.Graphics.IsVisible(x2, y2, width2, height2))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), x2, y2, width2, height2);
            }
        }
        // </snippet132>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Single,System.Single)
        // <snippet133>
        private void IsVisibleFloat(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of points.
            float x1 = 100.0F;
            float y1 = 100.0F;
            float x2 = 200.0F;
            float y2 = 200.0F;

            // If point is visible, fill ellipse that represents it.
            if (e.Graphics.IsVisible(x1, y1))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), x1, y1, 10.0F, 10.0F);
            }
            if (e.Graphics.IsVisible(x2, y2))
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.Blue), x2, y2, 10.0F, 10.0F);
            }
        }
        // </snippet133>


        // Snippet for: M:System.Drawing.Graphics.IsVisible(System.Single,System.Single,System.Single,System.Single)
        // <snippet134>
        private void IsVisible4Float(PaintEventArgs e)
        {

            // Set clip region.
            Region clipRegion = new Region(new Rectangle(50, 50, 100, 100));
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Set up coordinates of rectangles.
            float x1 = 100.0F;
            float y1 = 100.0F;
            float width1 = 20.0F;
            float height1 = 20.0F;
            float x2 = 200.0F;
            float y2 = 200.0F;
            float width2 = 20.0F;
            float height2 = 20.0F;

            // If rectangle is visible, fill it.
            if (e.Graphics.IsVisible(x1, y1, width1, height1))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Red), x1, y1, width1, height1);
            }
            if (e.Graphics.IsVisible(x2, y2, width2, height2))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), x2, y2, width2, height2);
            }
        }
        // </snippet134>


        // Snippet for: M:System.Drawing.Graphics.MeasureCharacterRanges(System.String,System.Drawing.Font,System.Drawing.RectangleF,System.Drawing.StringFormat)
        // <snippet135>
        private void MeasureCharacterRangesRegions(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "First and Second ranges";
            Font stringFont = new Font("Times New Roman", 16.0F);

            // Set character ranges to "First" and "Second".
            CharacterRange[] characterRanges = { new CharacterRange(0, 5), new CharacterRange(10, 6) };

            // Create rectangle for layout.
            float x = 50.0F;
            float y = 50.0F;
            float width = 35.0F;
            float height = 200.0F;
            RectangleF layoutRect = new RectangleF(x, y, width, height);

            // Set string format.
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
            stringFormat.SetMeasurableCharacterRanges(characterRanges);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, x, y, stringFormat);

            // Measure two ranges in string.
            Region[] stringRegions = e.Graphics.MeasureCharacterRanges(measureString, 
		stringFont, layoutRect, stringFormat);

            // Draw rectangle for first measured range.
            RectangleF measureRect1 = stringRegions[0].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), Rectangle.Round(measureRect1));

            // Draw rectangle for second measured range.
            RectangleF measureRect2 = stringRegions[1].GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 1), Rectangle.Round(measureRect2));
        }
        // </snippet135>


        // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font)
        // <snippet136>
        private void MeasureStringMin(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0));
        }
        // </snippet136>


        // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.PointF,System.Drawing.StringFormat)
        // <snippet137>
        private void MeasureStringPointFFormat(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set point for upper-left corner of string.
            float x = 50.0F;
            float y = 50.0F;
            PointF ulCorner = new PointF(x, y);

            // Set string format.
            StringFormat newStringFormat = new StringFormat();
            newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, ulCorner, newStringFormat);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), x, y, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, ulCorner, newStringFormat);
        }
        // </snippet137>


        // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF)
        // <snippet138>
        private void MeasureStringSizeF(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set maximum layout size.
            SizeF layoutSize = new SizeF(200.0F, 50.0F);

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, layoutSize);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0));
        }
        // </snippet138>


        // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF,System.Drawing.StringFormat)
        // <snippet139>
        private void MeasureStringSizeFFormat(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set maximum layout size.
            SizeF layoutSize = new SizeF(100.0F, 200.0F);

            // Set string format.
            StringFormat newStringFormat = new StringFormat();
            newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, layoutSize, newStringFormat);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0), newStringFormat);
        }
        // </snippet139>


        // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Drawing.SizeF,System.Drawing.StringFormat,System.Int32@,System.Int32@)
        // <snippet140>
        private void MeasureStringSizeFFormatInts(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set maximum layout size.
            SizeF layoutSize = new SizeF(100.0F, 200.0F);

            // Set string format.
            StringFormat newStringFormat = new StringFormat();
            newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Measure string.
            int charactersFitted;
            int linesFilled;
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, layoutSize, newStringFormat, out charactersFitted, out linesFilled);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0), newStringFormat);

            // Draw output parameters to screen.
            string outString = "chars " + charactersFitted + ", lines " + linesFilled;
            e.Graphics.DrawString(outString, stringFont, Brushes.Black, new PointF(100, 0));
        }
        // </snippet140>


        // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Int32)
        // <snippet141>
        private void MeasureStringWidth(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set maximum width of string.
            int stringWidth = 200;

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, stringWidth);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0));
        }
        // </snippet141>


        // Snippet for: M:System.Drawing.Graphics.MeasureString(System.String,System.Drawing.Font,System.Int32,System.Drawing.StringFormat)
        // <snippet142>
        private void MeasureStringWidthFormat(PaintEventArgs e)
        {

            // Set up string.
            string measureString = "Measure String";
            Font stringFont = new Font("Arial", 16);

            // Set maximum width of string.
            int stringWidth = 100;

            // Set string format.
            StringFormat newStringFormat = new StringFormat();
            newStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

            // Measure string.
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(measureString, stringFont, stringWidth, newStringFormat);

            // Draw rectangle representing size of string.
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), 0.0F, 0.0F, stringSize.Width, stringSize.Height);

            // Draw string to screen.
            e.Graphics.DrawString(measureString, stringFont, Brushes.Black, new PointF(0, 0), newStringFormat);
        }
        // </snippet142>


        // Snippet for: M:System.Drawing.Graphics.MultiplyTransform(System.Drawing.Drawing2D.Matrix)
        // <snippet143>
        private void MultiplyTransformMatrix(PaintEventArgs e)
        {

            // Create transform matrix.
            Matrix transformMatrix = new Matrix();

            // Translate matrix, prepending translation vector.
            transformMatrix.Translate(200.0F, 100.0F);

            // Rotate transformation matrix of graphics object,

            // prepending rotation matrix.
            e.Graphics.RotateTransform(30.0F);

            // Multiply (prepend to) transformation matrix of

            // graphics object to translate graphics transformation.
            e.Graphics.MultiplyTransform(transformMatrix);

            // Draw rotated, translated ellipse.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), -80, -40, 160, 80);
        }
        // </snippet143>


        // Snippet for: M:System.Drawing.Graphics.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet144>
        private void MultiplyTransformMatrixOrder(PaintEventArgs e)
        {

            // Create transform matrix.
            Matrix transformMatrix = new Matrix();

            // Translate matrix, prepending translation vector.
            transformMatrix.Translate(200.0F, 100.0F);

            // Rotate transformation matrix of graphics object,

            // prepending rotation matrix.
            e.Graphics.RotateTransform(30.0F);

            // Multiply (append to) transformation matrix of

            // graphics object to translate graphics transformation.
            e.Graphics.MultiplyTransform(transformMatrix, MatrixOrder.Append);

            // Draw rotated, translated ellipse.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), -80, -40, 160, 80);
        }
        // </snippet144>


        // Snippet for: M:System.Drawing.Graphics.ReleaseHdc(System.IntPtr)
        // <snippet145>
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool Rectangle2(
            IntPtr hdc,
            int ulCornerX, int ulCornerY,
            int lrCornerX, int lrCornerY);

        [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.LinkDemand, Flags = 
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]            
        private void GetHdcForGDI2(PaintEventArgs e)
        {

            // Create pen.
            Pen redPen = new Pen(Color.Red, 1);

            // Draw rectangle with GDI+.
            e.Graphics.DrawRectangle(redPen, 10, 10, 100, 50);

            // Get handle to device context.
            IntPtr hdc = e.Graphics.GetHdc();

            // Draw rectangle with GDI using default pen.
            Rectangle2(hdc, 10, 70, 110, 120);

            // Release handle to device context.
            e.Graphics.ReleaseHdc(hdc);
        }
        // </snippet145>


        // Snippet for: M:System.Drawing.Graphics.ResetClip
        // <snippet146>
        private void IntersectClipRectangleF2(PaintEventArgs e)
        {

            // Set clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 200, 200);
            e.Graphics.SetClip(clipRect);

            // Update clipping region to intersection of

            // existing region with specified rectangle.
            RectangleF intersectRectF = new RectangleF(100.0F, 100.0F, 200.0F, 200.0F);
            e.Graphics.IntersectClip(intersectRectF);

            // Fill rectangle to demonstrate effective clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 500, 500);

            // Reset clipping region to infinite.
            e.Graphics.ResetClip();

            // Draw clipRect and intersectRect to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Black), clipRect);
            e.Graphics.DrawRectangle(new Pen(Color.Red), Rectangle.Round(intersectRectF));
        }
        // </snippet146>


        // Snippet for: M:System.Drawing.Graphics.ResetTransform
        // <snippet147>
        private void SaveRestore1(PaintEventArgs e)
        {

            // Translate transformation matrix.
            e.Graphics.TranslateTransform(100, 0);

            // Save translated graphics state.
            GraphicsState transState = e.Graphics.Save();

            // Reset transformation matrix to identity and fill rectangle.
            e.Graphics.ResetTransform();
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0, 0, 100, 100);

            // Restore graphics state to translated state and fill second

            // rectangle.
            e.Graphics.Restore(transState);
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 100, 100);
        }
        // </snippet147>


        // Snippet for: M:System.Drawing.Graphics.Restore(System.Drawing.Drawing2D.GraphicsState)
        // <snippet148>
        private void SaveRestore2(PaintEventArgs e)
        {

            // Translate transformation matrix.
            e.Graphics.TranslateTransform(100, 0);

            // Save translated graphics state.
            GraphicsState transState = e.Graphics.Save();

            // Reset transformation matrix to identity and fill rectangle.
            e.Graphics.ResetTransform();
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0, 0, 100, 100);

            // Restore graphics state to translated state and fill second

            // rectangle.
            e.Graphics.Restore(transState);
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 100, 100);
        }
        // </snippet148>


        // Snippet for: M:System.Drawing.Graphics.RotateTransform(System.Single)
        // <snippet149>
        private void RotateTransformAngle(PaintEventArgs e)
        {

            // Set world transform of graphics object to translate.
            e.Graphics.TranslateTransform(100.0F, 0.0F);

            // Then to rotate, prepending rotation matrix.
            e.Graphics.RotateTransform(30.0F);

            // Draw rotated, translated ellipse to screen.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);
        }
        // </snippet149>


        // Snippet for: M:System.Drawing.Graphics.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet150>
        private void RotateTransformAngleMatrixOrder(PaintEventArgs e)
        {

            // Set world transform of graphics object to translate.
            e.Graphics.TranslateTransform(100.0F, 0.0F);

            // Then to rotate, appending rotation matrix.
            e.Graphics.RotateTransform(30.0F, MatrixOrder.Append);

            // Draw translated, rotated ellipse to screen.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);
        }
        // </snippet150>


        // Snippet for: M:System.Drawing.Graphics.Save
        // <snippet151>
        private void SaveRestore3(PaintEventArgs e)
        {

            // Translate transformation matrix.
            e.Graphics.TranslateTransform(100, 0);

            // Save translated graphics state.
            GraphicsState transState = e.Graphics.Save();

            // Reset transformation matrix to identity and fill rectangle.
            e.Graphics.ResetTransform();
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 0, 0, 100, 100);

            // Restore graphics state to translated state and fill second

            // rectangle.
            e.Graphics.Restore(transState);
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 0, 0, 100, 100);
        }
        // </snippet151>


        // Snippet for: M:System.Drawing.Graphics.ScaleTransform(System.Single,System.Single)
        // <snippet152>
        private void ScaleTransformFloat(PaintEventArgs e)
        {

            // Set world transform of graphics object to rotate.
            e.Graphics.RotateTransform(30.0F);

            // Then to scale, prepending to world transform.
            e.Graphics.ScaleTransform(3.0F, 1.0F);

            // Draw scaled, rotated rectangle to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 3), 50, 0, 100, 40);
        }
        // </snippet152>


        // Snippet for: M:System.Drawing.Graphics.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet153>
        private void ScaleTransformFloatMatrixOrder(PaintEventArgs e)
        {

            // Set world transform of graphics object to rotate.
            e.Graphics.RotateTransform(30.0F);

            // Then to scale, appending to world transform.
            e.Graphics.ScaleTransform(3.0F, 1.0F, MatrixOrder.Append);

            // Draw rotated, scaled rectangle to screen.
            e.Graphics.DrawRectangle(new Pen(Color.Blue, 3), 50, 0, 100, 40);
        }
        // </snippet153>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Drawing2D.GraphicsPath)
        // <snippet154>
        private void SetClipPath(PaintEventArgs e)
        {

            // Create graphics path.
            GraphicsPath clipPath = new GraphicsPath();
            clipPath.AddEllipse(0, 0, 200, 100);

            // Set clipping region to path.
            e.Graphics.SetClip(clipPath);

            // Fill rectangle to demonstrate clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet154>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Drawing2D.GraphicsPath,System.Drawing.Drawing2D.CombineMode)
        // <snippet155>
        private void SetClipPathCombine(PaintEventArgs e)
        {

            // Create graphics path.
            GraphicsPath clipPath = new GraphicsPath();
            clipPath.AddEllipse(0, 0, 200, 100);

            // Set clipping region to path.
            e.Graphics.SetClip(clipPath, CombineMode.Replace);

            // Fill rectangle to demonstrate clipping region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet155>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Graphics)
        // <snippet156>
        private void SetClipGraphics(PaintEventArgs e)
        {

            // Create temporary graphics object and set its clipping region.
            Graphics newGraphics = this.CreateGraphics();
            newGraphics.SetClip(new Rectangle(0, 0, 100, 100));

            // Update clipping region of graphics to clipping region of new

            // graphics.
            e.Graphics.SetClip(newGraphics);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);

            // Release new graphics.
            newGraphics.Dispose();
        }
        // </snippet156>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Graphics,System.Drawing.Drawing2D.CombineMode)
        // <snippet157>
        private void SetClipGraphicsCombine(PaintEventArgs e)
        {

            // Create temporary graphics object and set its clipping region.
            Graphics newGraphics = this.CreateGraphics();
            newGraphics.SetClip(new Rectangle(0, 0, 100, 100));

            // Update clipping region of graphics to clipping region of new

            // graphics.
            e.Graphics.SetClip(newGraphics, CombineMode.Replace);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);

            // Release new graphics.
            newGraphics.Dispose();
        }
        // </snippet157>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Rectangle)
        // <snippet158>
        private void SetClipRectangle(PaintEventArgs e)
        {

            // Create rectangle for clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 100, 100);

            // Set clipping region of graphics to rectangle.
            e.Graphics.SetClip(clipRect);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet158>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Rectangle,System.Drawing.Drawing2D.CombineMode)
        // <snippet159>
        private void SetClipRectangleCombine(PaintEventArgs e)
        {

            // Create rectangle for clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 100, 100);

            // Set clipping region of graphics to rectangle.
            e.Graphics.SetClip(clipRect, CombineMode.Replace);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet159>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.RectangleF)
        // <snippet160>
        private void SetClipRectangleF(PaintEventArgs e)
        {

            // Create rectangle for clipping region.
            RectangleF clipRect = new RectangleF(0.0F, 0.0F, 100.0F, 100.0F);

            // Set clipping region of graphics to rectangle.
            e.Graphics.SetClip(clipRect);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet160>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.RectangleF,System.Drawing.Drawing2D.CombineMode)
        // <snippet161>
        private void SetClipRectangleFCombine(PaintEventArgs e)
        {

            // Create rectangle for clipping region.
            RectangleF clipRect = new RectangleF(0.0F, 0.0F, 100.0F, 100.0F);

            // Set clipping region of graphics to rectangle.
            e.Graphics.SetClip(clipRect, CombineMode.Replace);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet161>


        // Snippet for: M:System.Drawing.Graphics.SetClip(System.Drawing.Region,System.Drawing.Drawing2D.CombineMode)
        // <snippet162>
        private void SetClipRegionCombine(PaintEventArgs e)
        {

            // Create region for clipping.
            Region clipRegion = new Region(new Rectangle(0, 0, 100, 100));

            // Set clipping region of graphics to region.
            e.Graphics.SetClip(clipRegion, CombineMode.Replace);

            // Fill rectangle to demonstrate clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet162>


        // Snippet for: M:System.Drawing.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Point[])
        // <snippet163>
        private void TransformPointsPoint(PaintEventArgs e)
        {

            // Create array of two points.
            Point[] points = { new Point(0, 0), new Point(100, 50) };

            // Draw line connecting two untransformed points.
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), points[0], points[1]);

            // Set world transformation of Graphics object to translate.
            e.Graphics.TranslateTransform(40, 30);

            // Transform points in array from world to page coordinates.
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points);

            // Reset world transformation.
            e.Graphics.ResetTransform();

            // Draw line that connects transformed points.
            e.Graphics.DrawLine(new Pen(Color.Red, 3), points[0], points[1]);
        }
        // </snippet163>


        // Snippet for: M:System.Drawing.Graphics.TransformPoints(System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.Drawing2D.CoordinateSpace,System.Drawing.PointF[])
        // <snippet164>
        private void TransformPointsPointF(PaintEventArgs e)
        {

            // Create array of two points.
            PointF[] points = { new PointF(0.0F, 0.0F), new PointF(100.0F, 50.0F) };

            // Draw line connecting two untransformed points.
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), points[0], points[1]);

            // Set world transformation of Graphics object to translate.
            e.Graphics.TranslateTransform(40.0F, 30.0F);

            // Transform points in array from world to page coordinates.
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points);

            // Reset world transformation.
            e.Graphics.ResetTransform();

            // Draw line that connects transformed points.
            e.Graphics.DrawLine(new Pen(Color.Red, 3), points[0], points[1]);
        }
        // </snippet164>


        // Snippet for: M:System.Drawing.Graphics.TranslateClip(System.Int32,System.Int32)
        // <snippet165>
        private void TranslateClipInt(PaintEventArgs e)
        {

            // Create rectangle for clipping region.
            Rectangle clipRect = new Rectangle(0, 0, 100, 100);

            // Set clipping region of graphics to rectangle.
            e.Graphics.SetClip(clipRect);

            // Translate clipping region.
            int dx = 50;
            int dy = 50;
            e.Graphics.TranslateClip(dx, dy);

            // Fill rectangle to demonstrate translated clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet165>


        // Snippet for: M:System.Drawing.Graphics.TranslateClip(System.Single,System.Single)
        // <snippet166>
        private void TranslateClipFloat(PaintEventArgs e)
        {

            // Create rectangle for clipping region.
            RectangleF clipRect = new RectangleF(0.0F, 0.0F, 100.0F, 100.0F);

            // Set clipping region of graphics to rectangle.
            e.Graphics.SetClip(clipRect);

            // Translate clipping region.
            float dx = 50.0F;
            float dy = 50.0F;
            e.Graphics.TranslateClip(dx, dy);

            // Fill rectangle to demonstrate translated clip region.
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, 500, 300);
        }
        // </snippet166>


        // Snippet for: M:System.Drawing.Graphics.TranslateTransform(System.Single,System.Single)
        // <snippet167>
        private void TranslateTransformAngle(PaintEventArgs e)
        {

            // Set world transform of graphics object to rotate.
            e.Graphics.RotateTransform(30.0F);

            // Then to translate, prepending to world transform.
            e.Graphics.TranslateTransform(100.0F, 0.0F);

            // Draw translated, rotated ellipse to screen.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);
        }
        // </snippet167>


        // Snippet for: M:System.Drawing.Graphics.TranslateTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
        // <snippet168>
        private void TranslateTransformAngleMatrixOrder(PaintEventArgs e)
        {

            // Set world transform of graphics object to rotate.
            e.Graphics.RotateTransform(30.0F);

            // Then to translate, appending to world transform.
            e.Graphics.TranslateTransform(100.0F, 0.0F, MatrixOrder.Append);

            // Draw rotated, translated ellipse to screen.
            e.Graphics.DrawEllipse(new Pen(Color.Blue, 3), 0, 0, 200, 80);
        }
        // </snippet168>


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
