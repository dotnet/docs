using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace GetMainMenu
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
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
			InitializeMyMainMenu();

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
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(240, 88);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 276);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1});
			this.Name = "Form1";
			this.Text = "My Form";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		// <snippet1>
		private void InitializeMyMainMenu()
		{
			// Create the MainMenu and the menu items to add.
			MainMenu mainMenu1 = new MainMenu();

			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
			MenuItem menuItem3 = new MenuItem();
			MenuItem menuItem4 = new MenuItem();

   
			// Set the caption for the menu items.
			menuItem1.Text = "File";
			menuItem2.Text = "Edit";
			menuItem3.Text = "View";

			// Add 3 menu items to the MainMenu for displaying.
			mainMenu1.MenuItems.Add(menuItem1);
			mainMenu1.MenuItems.Add(menuItem2);
			mainMenu1.MenuItems.Add(menuItem3);

			// Assign mainMenu1 to the form.
			Menu = mainMenu1;

			// Determine whether menuItem3 is currently being used.
			if(menuItem3.GetMainMenu() != null)
				// Display the name of the form in which it is located.
				label1.Text= menuItem3.GetMainMenu().GetForm().ToString();
		}
		// </snippet1>
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

		}
	}
}
