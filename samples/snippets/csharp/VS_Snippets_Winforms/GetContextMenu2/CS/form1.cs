using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Data;

namespace Contextmnu2
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
			AddContextmenu();

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
		public void AddContextmenu()
		{
			// Create a shortcut menu.
			ContextMenu m = new ContextMenu();
			this.ContextMenu= m;

			// Create MenuItem objects.
			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
			
			// Set the Text property.
			menuItem1.Text = "New";
			menuItem2.Text = "Open";

			// Add menu items to the MenuItems collection.
			m.MenuItems.Add(menuItem1);
			m.MenuItems.Add(menuItem2);

			// Display the starting message.
			MessageBox.Show("Right-click the form to display the shortcut menu items");


			// Add functionality to the menu items. 
			menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			string textReport =	"You clicked the New menu item. \n" +
				"It is contained in the following shortcut menu: \n\n"; 
		
			// Get information on the shortcut menu in which menuitem1 is contained.
			textReport += ContextMenu.GetContextMenu().ToString();

			// Display the shortcut menu information in a message box.
			MessageBox.Show(textReport,"The ContextMenu Information");		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			string textReport =	"You clicked the Open menu item. \n" +
				"It is contained in the following shortcut menu: \n\n"; 
		
			// Get information on the shortcut menu in which menuitem1 is contained.
			textReport += ContextMenu.GetContextMenu().ToString();

			// Display the shortcut menu information in a message box.
			MessageBox.Show(textReport,"The ContextMenu Information");		
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
