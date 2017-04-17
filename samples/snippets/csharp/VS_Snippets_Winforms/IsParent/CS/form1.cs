using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace menuIsParent
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
			CreateMyMainMenu();
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
		public void CreateMyMainMenu()
		{
			// Create two MenuItem objects and assign to array.
			MenuItem menuItem1 = new MenuItem();
			MenuItem menuItem2 = new MenuItem();
 
			menuItem1.Text = "&File";
			menuItem2.Text = "&Edit";
 
			// Create a MainMenu and assign MenuItem objects.
			MainMenu mainMenu1 = new MainMenu(new MenuItem[] {
						menuItem1,
						menuItem2});
    
			// Determine whether mainMenu1 contains menu items.  
			if (mainMenu1.IsParent) 
			{
				// Set the RightToLeft property for mainMenu1.
				mainMenu1.RightToLeft = RightToLeft.Yes;
				// Bind the MainMenu to Form1.
				Menu = mainMenu1;
			}	
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
