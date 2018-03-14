using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MenuItemClass
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
			this.ClientSize = new System.Drawing.Size(292, 276);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		// <snippet1>
		public void CreateMyMenu()
		{
			// Create a main menu object.
			MainMenu mainMenu1 = new MainMenu();

			// Create empty menu item objects.
			MenuItem topMenuItem = new MenuItem();
			MenuItem menuItem1 = new MenuItem();
                  
			// Set the caption of the menu items.
			topMenuItem.Text = "&File";
			menuItem1.Text = "&Open";

			// Add the menu items to the main menu.
         		topMenuItem.MenuItems.Add(menuItem1);
			mainMenu1.MenuItems.Add(topMenuItem);
						
			// Add functionality to the menu items using the Click event. 
			menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

			// Assign mainMenu1 to the form.
			this.Menu=mainMenu1;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{	
                   // Create a new OpenFileDialog and display it.
		   OpenFileDialog fd = new OpenFileDialog();
         	   fd.DefaultExt = "*.*";
		   fd.ShowDialog();
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
