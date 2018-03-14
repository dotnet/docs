using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ParentMenu
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
			CreateMyMenuItems();
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
		public void CreateMyMenuItems()
		{
			// Craete a main menu object.
			MainMenu mainMenu1 = new MainMenu();

			// Create three top-level menu items.
			MenuItem menuItem1 = new MenuItem("&File");
			MenuItem menuItem2 = new MenuItem("&New");
			MenuItem menuItem3 = new MenuItem("&Open");

			// Add menuItem1 to the main menu.
			mainMenu1.MenuItems.Add(menuItem1);	

			// Add menuItem2 and menuItem3 to menuItem1.
			menuItem1.MenuItems.Add(menuItem2);
			menuItem1.MenuItems.Add(menuItem3);

			// Check to see if menuItem3 has a parent menu.
			if (menuItem3.Parent != null)
				MessageBox.Show(menuItem3.Parent.ToString()+
						".", "Parent Menu Information of menuItem3"); 
			else
				MessageBox.Show("No parent menu."); 

			// Assign mainMenu1 to the form.
			this.Menu = mainMenu1;			
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
