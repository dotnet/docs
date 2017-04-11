using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D; 

namespace System.Drawing.ClassicRegionExamplesCS
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


        // Snippet for: M:System.Drawing.Region.Complement(System.Drawing.Drawing2D.GraphicsPath)
        // <snippet1>
        public void Complement_Path_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // Create the second rectangle and draw it to the screen in red.
            Rectangle complementRect = new Rectangle(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red, complementRect);
                     
            // Create a graphics path and add the second rectangle to it.
            GraphicsPath complementPath = new GraphicsPath();
            complementPath.AddRectangle(complementRect);
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the complement of myRegion when combined with
                     
            // complementPath.
            myRegion.Complement(complementPath);
                     
            // Fill the complement area with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Region.Complement(System.Drawing.RectangleF)
        // <snippet2>
        public void Complement_RectF_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // Create the second rectangle and draw it to the screen in red.
            RectangleF complementRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red,
                Rectangle.Round(complementRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the complement of the region combined with the second
                     
            // rectangle.
            myRegion.Complement(complementRect);
                     
            // Fill the complement area with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Region.Complement(System.Drawing.Region)
        // <snippet3>
        public void Complement_Region_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // Create the second rectangle and draw it to the screen in red.
            Rectangle complementRect = new Rectangle(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red, complementRect);
                     
            // Create a region from the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Create a complement region.
            Region complementRegion = new Region(complementRect);
                     
            // Get the complement of myRegion when combined with
                     
            // complementRegion.
            myRegion.Complement(complementRegion);
                     
            // Fill the complement area with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Region.Exclude(System.Drawing.RectangleF)
        // <snippet4>
        public void Exclude_RectF_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // Create the second rectangle and draw it to the screen in red.
            RectangleF complementRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red,
                Rectangle.Round(complementRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the nonexcluded area of myRegion when combined with
                     
            // complementRect.
            myRegion.Exclude(complementRect);
                     
            // Fill the nonexcluded area of myRegion with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Region.GetBounds(System.Drawing.Graphics)
        // <snippet5>
        public void GetBoundsExample(PaintEventArgs e)
        {
                     
            // Create a GraphicsPath and add an ellipse to it.
            GraphicsPath myPath = new GraphicsPath();
            Rectangle ellipseRect = new Rectangle(20, 20, 100, 100);
            myPath.AddEllipse(ellipseRect);
                     
            // Fill the path with blue and draw it to the screen.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillPath(myBrush, myPath);
                     
            // Create a region using the GraphicsPath.
            Region myRegion = new Region(myPath);
                     
            // Get the bounding rectangle for myRegion and draw it to the
                     
            // screen in Red.
            RectangleF boundsRect = myRegion.GetBounds(e.Graphics);
            e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(boundsRect));
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Region.GetRegionData
        // <snippet6>
        public void GetRegionDataExample(PaintEventArgs e)
        {
                     
            // Create a rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the RegionData for this region.
            RegionData myRegionData = myRegion.GetRegionData();
            int myRegionDataLength = myRegionData.Data.Length;
            DisplayRegionData(e, myRegionDataLength, myRegionData);
        }
                     
        // THIS IS A HELPER FUNCTION FOR GetRegionData.
        public void DisplayRegionData(PaintEventArgs e,
            int len,
            RegionData dat)
        {
                     
            // Display the result.
            int i;
            float x = 20, y = 140;
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString("myRegionData = ",
                myFont,
                myBrush,
                new PointF(x, y));
            y = 160;
            for(i = 0; i < len; i++)
            {
                if(x > 300)
                {
                    y += 20;
                    x = 20;
                }
                e.Graphics.DrawString(dat.Data[i].ToString(),
                    myFont,
                    myBrush,
                    new PointF(x, y));
                x += 30;
            }
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.Region.Intersect(System.Drawing.RectangleF)
        // <snippet7>
        public void Intersect_RectF_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // create the second rectangle and draw it to the screen in red.
            RectangleF complementRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red,
                Rectangle.Round(complementRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the area of intersection for myRegion when combined with
                     
            // complementRect.
            myRegion.Intersect(complementRect);
                     
            // Fill the intersection area of myRegion with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.Region.IsVisible(System.Drawing.RectangleF)
        // <snippet8>
        public void IsVisible_RectF_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in blue.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Blue, regionRect);
                     
            // Create the second rectangle and draw it to the screen in red.
            RectangleF myRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red, Rectangle.Round(myRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Determine if myRect is contained in the region.
            bool contained = myRegion.IsVisible(myRect);
                     
            // Display the result.
            Font myFont = new Font("Arial", 8);
            SolidBrush myBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString("contained = " + contained.ToString(),
                myFont,
                myBrush,
                new PointF(20, 140));
        }
        // </snippet8>


        // Snippet for: M:System.Drawing.Region.Transform(System.Drawing.Drawing2D.Matrix)
        // <snippet9>
        public void TransformExample(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in blue.
            Rectangle regionRect = new Rectangle(100, 50, 100, 100);
            e.Graphics.DrawRectangle(Pens.Blue, regionRect);
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Create a transform matrix and set it to have a 45 degree
                     
            // rotation.
            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(45, new Point(100, 50));
                     
            // Apply the transform to the region.
            myRegion.Transform(transformMatrix);
                     
            // Fill the transformed region with red and draw it to the screen
                     
            // in red.
            SolidBrush myBrush = new SolidBrush(Color.Red);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet9>


        // Snippet for: M:System.Drawing.Region.Translate(System.Int32,System.Int32)
        // <snippet10>
        public void TranslateExample(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in blue.
            Rectangle regionRect = new Rectangle(100, 50, 100, 100);
            e.Graphics.DrawRectangle(Pens.Blue, regionRect);
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Apply the translation to the region.
            myRegion.Translate(150, 100);
                     
            // Fill the transformed region with red and draw it to the screen in red.
            SolidBrush myBrush = new SolidBrush(Color.Red);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet10>


        // Snippet for: M:System.Drawing.Region.Union(System.Drawing.RectangleF)
        // <snippet11>
        public void Union_RectF_Example(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // create the second rectangle and draw it to the screen in red.
            RectangleF unionRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red,
                Rectangle.Round(unionRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the area of union for myRegion when combined with
                     
            // complementRect.
            myRegion.Union(unionRect);
                     
            // Fill the union area of myRegion with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet11>


        // Snippet for: M:System.Drawing.Region.Xor(System.Drawing.RectangleF)
        // <snippet12>
        public void XorExample(PaintEventArgs e)
        {
                     
            // Create the first rectangle and draw it to the screen in black.
            Rectangle regionRect = new Rectangle(20, 20, 100, 100);
            e.Graphics.DrawRectangle(Pens.Black, regionRect);
                     
            // create the second rectangle and draw it to the screen in red.
            RectangleF xorRect = new RectangleF(90, 30, 100, 100);
            e.Graphics.DrawRectangle(Pens.Red,
                Rectangle.Round(xorRect));
                     
            // Create a region using the first rectangle.
            Region myRegion = new Region(regionRect);
                     
            // Get the area of overlap for myRegion when combined with
                     
            // complementRect.
            myRegion.Xor(xorRect);
                     
            // Fill the Xor area of myRegion with blue.
            SolidBrush myBrush = new SolidBrush(Color.Blue);
            e.Graphics.FillRegion(myBrush, myRegion);
        }
        // </snippet12>

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
