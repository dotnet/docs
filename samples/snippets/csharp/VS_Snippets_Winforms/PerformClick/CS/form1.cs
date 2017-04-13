using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PerformClick
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
			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();

			// Set the caption of the menu items.
			menuItem1.Text = "&File";
			menuItem2.Text = "&Edit";

			// Add the menu items to the main menu.
			mainMenu1.MenuItems.Add(menuItem1);
			mainMenu1.MenuItems.Add(menuItem2);
			
			// Add functionality to the menu items. 
			menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			
			// Assign mainMenu1 to the form.
			this.Menu=mainMenu1;

			// Perform a click on the File menu item.
			menuItem1.PerformClick();
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{	
			MessageBox.Show("You clicked the File menu.","The Event Information");		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("You clicked the Edit menu.","The Event Information");		
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
