using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace StatusBarEX
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
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
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(152, 96);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(376, 293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

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
		private void CreateMyStatusBar()
		{
			// Create a StatusBar control.
			StatusBar statusBar1 = new StatusBar();
			// Create two StatusBarPanel objects to display in the StatusBar.
			StatusBarPanel panel1 = new StatusBarPanel();
			StatusBarPanel panel2 = new StatusBarPanel();

			// Display the first panel with a sunken border style.
			panel1.BorderStyle = StatusBarPanelBorderStyle.Sunken;
			// Initialize the text of the panel.
			panel1.Text = "Ready...";
			// Set the AutoSize property to use all remaining space on the StatusBar.
			panel1.AutoSize = StatusBarPanelAutoSize.Spring;
			
			// Display the second panel with a raised border style.
			panel2.BorderStyle = StatusBarPanelBorderStyle.Raised;
			
			// Create ToolTip text that displays time the application was 
      			//started.
			panel2.ToolTipText = "Started: " + System.DateTime.Now.ToShortTimeString();
			// Set the text of the panel to the current date.
			panel2.Text = System.DateTime.Today.ToLongDateString();
			// Set the AutoSize property to size the panel to the size of the contents.
			panel2.AutoSize = StatusBarPanelAutoSize.Contents;
						
			// Display panels in the StatusBar control.
			statusBar1.ShowPanels = true;

			// Add both panels to the StatusBarPanelCollection of the StatusBar.			
			statusBar1.Panels.Add(panel1);
			statusBar1.Panels.Add(panel2);

			// Add the StatusBar to the form.
			this.Controls.Add(statusBar1);
		}
		//</snippet1>

		private void button1_Click(object sender, System.EventArgs e)
		{
			CreateMyStatusBar();
		}
	}
}
