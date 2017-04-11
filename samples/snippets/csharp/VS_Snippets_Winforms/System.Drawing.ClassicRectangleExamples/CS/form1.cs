using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicRectangleExamplesCS
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


        // Snippet for: M:System.Drawing.Rectangle.Inflate(System.Drawing.Rectangle,System.Int32,System.Int32)
        // <snippet1>
        public void RectangleInflateTest(PaintEventArgs e)
        {
                     
            // Create a rectangle.
            Rectangle rect = new Rectangle(100, 100, 50, 50);
                     
            // Draw the uninflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Black, rect);
                     
            // Call Inflate.
            Rectangle rect2 = Rectangle.Inflate(rect, 50, 50);
                     
            // Draw the inflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Red, rect2);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Rectangle.Inflate(System.Drawing.Size)
        // <snippet2>
        public void RectangleInflateTest2(PaintEventArgs e)
        {
                     
            // Create a rectangle.
            Rectangle rect = new Rectangle(100, 100, 50, 50);
                     
            // Draw the uninflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Black, rect);
                     
            // Set up the inflate size.
            Size inflateSize = new Size(50, 50);
                     
            // Call Inflate.
            rect.Inflate(inflateSize);
                     
            // Draw the inflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Red, rect);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Rectangle.Inflate(System.Int32,System.Int32)
        // <snippet3>
        public void RectangleInflateTest3(PaintEventArgs e)
        {
                     
            // Create a rectangle.
            Rectangle rect = new Rectangle(100, 100, 50, 50);
                     
            // Draw the uninflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Black, rect);
                     
            // Call Inflate.
            rect.Inflate(50, 50);
                     
            // Draw the inflated rectangle to screen.
            e.Graphics.DrawRectangle(Pens.Red, rect);
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
