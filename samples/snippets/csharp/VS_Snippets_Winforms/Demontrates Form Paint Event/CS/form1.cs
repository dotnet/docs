using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Demo1_CS
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

			RcDraw = new Rectangle(0, 0, 0, 0);

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
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "Form1";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		//<snippet1>

		private Rectangle RcDraw;
		private float PenWidth = 5;

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Determine the initial rectangle coordinates...

			RcDraw.X = e.X;
			RcDraw.Y = e.Y;
		
		}

		private void Form1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			// Determine the width and height of the rectangle...

			if(e.X < RcDraw.X)
			{
				RcDraw.Width = RcDraw.X - e.X;
				RcDraw.X = e.X;
			}
			else
			{
				RcDraw.Width = e.X - RcDraw.X;
			}

			if(e.Y < RcDraw.Y)
			{
				RcDraw.Height = RcDraw.Y - e.Y;
				RcDraw.Y = e.Y;
			}
			else
			{
				RcDraw.Height = e.Y - RcDraw.Y;
			}

			// Force a repaint of the region occupied by the rectangle...

			this.Invalidate(RcDraw);
		
		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

			// Draw the rectangle...

			e.Graphics.DrawRectangle(new Pen(Color.Blue, PenWidth), RcDraw);
			
		}

		//</snippet1>

		
	}
}
