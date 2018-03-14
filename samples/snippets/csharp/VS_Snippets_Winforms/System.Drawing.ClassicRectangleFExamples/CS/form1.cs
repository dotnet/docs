using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicRectangleFExamplesCS
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


        // Snippet for: M:System.Drawing.RectangleF.Inflate(System.Drawing.SizeF)
        // <snippet1>
        public void RectangleFInflateExample(PaintEventArgs e)
        {
                     
            // Create a RectangleF structure.
            RectangleF myRectF = new RectangleF(100, 20, 100, 100);
                     
            // Draw myRect to the screen.
            Rectangle myRect = Rectangle.Truncate(myRectF);
            e.Graphics.DrawRectangle(Pens.Black, myRect);
                     
            // Create a Size structure.
            SizeF inflateSize = new SizeF(100, 0);
                     
            // Inflate myRect.
            myRectF.Inflate(inflateSize);
                     
            // Draw the inflated rectangle to the screen.
            myRect = Rectangle.Truncate(myRectF);
            e.Graphics.DrawRectangle(Pens.Red, myRect);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.RectangleF.Intersect(System.Drawing.RectangleF,System.Drawing.RectangleF)
        // <snippet2>
        public void RectangleFIntersectExample(PaintEventArgs e)
        {
                     
            // Create two rectangles.
            RectangleF firstRectangleF = new RectangleF(0, 0, 75, 50);
            RectangleF secondRectangleF = new RectangleF(50, 20, 50, 50);
                     
            // Convert the RectangleF structures to Rectangle structures and draw them to the
                     
            // screen.
            Rectangle firstRect = Rectangle.Truncate(firstRectangleF);
            Rectangle secondRect = Rectangle.Truncate(secondRectangleF);
            e.Graphics.DrawRectangle(Pens.Black, firstRect);
            e.Graphics.DrawRectangle(Pens.Red, secondRect);
                     
            // Get the intersection.
            RectangleF intersectRectangleF =
                RectangleF.Intersect(firstRectangleF,
                secondRectangleF);
                     
            // Draw the intersectRectangleF to the screen.
            Rectangle intersectRect =
                Rectangle.Truncate(intersectRectangleF);
            e.Graphics.DrawRectangle(Pens.Blue, intersectRect);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.RectangleF.Union(System.Drawing.RectangleF,System.Drawing.RectangleF)
        // <snippet3>
        public void RectangleFUnionExample(PaintEventArgs e)
        {
                     
            // Create two rectangles and draw them to the screen.
            RectangleF firstRectangleF = new RectangleF(0, 0, 75, 50);
            RectangleF secondRectangleF = new RectangleF(100, 100, 20, 20);
                     
            // Convert the RectangleF structures to Rectangle structures and draw them to the
                     
            // screen.
            Rectangle firstRect = Rectangle.Truncate(firstRectangleF);
            Rectangle secondRect = Rectangle.Truncate(secondRectangleF);
            e.Graphics.DrawRectangle(Pens.Black, firstRect);
            e.Graphics.DrawRectangle(Pens.Red, secondRect);
                     
            // Get the union rectangle.
            RectangleF unionRectangleF = RectangleF.Union(firstRectangleF,
                secondRectangleF);
                     
            // Draw the unionRectangleF to the screen.
            Rectangle unionRect = Rectangle.Truncate(unionRectangleF);
            e.Graphics.DrawRectangle(Pens.Blue, unionRect);
        }
        // </snippet3>

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
