using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Owner_Draw_CS2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;

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

			// Create the menu.

			CreateMyMenu();
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

		private void CreateMyMenu()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			// 

			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItem1});
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItem2});
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.menuItem3});

			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.OwnerDraw = true;
			this.menuItem1.Text = "";
			this.menuItem1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.menuItem1_DrawItem);

																					  																
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.OwnerDraw = true;
			this.menuItem2.Text = "";
			this.menuItem2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.menuItem2_DrawItem);
	
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.OwnerDraw = true;
			this.menuItem3.Text = "";
			this.menuItem3.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.menuItem3_DrawItem);

			this.Menu = this.mainMenu1;

		}

//<snippet1>

// The DrawItem event handler.
private void menuItem1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
{

	string myCaption = "Owner Draw Item1";

	// Create a Brush and a Font with which to draw the item.
	Brush myBrush = System.Drawing.Brushes.AliceBlue;
	Font myFont = new Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel);
	SizeF mySizeF = e.Graphics.MeasureString(myCaption, myFont);

	// Draw the item, and then draw a Rectangle around it.
	e.Graphics.DrawString(myCaption, myFont, myBrush, e.Bounds.X, e.Bounds.Y);
	e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.X, e.Bounds.Y, Convert.ToInt32(mySizeF.Width), Convert.ToInt32(mySizeF.Height)));

}
//</snippet1>


		private void menuItem2_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			string myCaption = "Owner Draw Item2";
			Brush myBrush = System.Drawing.Brushes.AliceBlue;
			Font myFont = new Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel);
			SizeF mySizeF = e.Graphics.MeasureString(myCaption, myFont);

			e.Graphics.DrawString(myCaption, myFont, myBrush, e.Bounds.X, e.Bounds.Y+20);
			e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.X, e.Bounds.Y+20, Convert.ToInt32(mySizeF.Width), Convert.ToInt32(mySizeF.Height)));

		}

		private void menuItem3_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			string myCaption = "Owner Draw Item3";
			Brush myBrush = System.Drawing.Brushes.AliceBlue;
			Font myFont = new Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel);
			SizeF mySizeF = e.Graphics.MeasureString(myCaption, myFont);

			e.Graphics.DrawString(myCaption, myFont, myBrush, e.Bounds.X, e.Bounds.Y+40);
			e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.X, e.Bounds.Y+40,  Convert.ToInt32(mySizeF.Width), Convert.ToInt32(mySizeF.Height)));

		}
	}
}
