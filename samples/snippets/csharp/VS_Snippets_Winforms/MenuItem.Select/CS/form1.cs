using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MenuItemSelectEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.StatusBarPanel statusBarPanel1;
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItem4;
      private System.Windows.Forms.MenuItem menuOpen;
      private System.Windows.Forms.MenuItem menuSave;
      private System.Windows.Forms.MenuItem menuExit;
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
         this.statusBar1 = new System.Windows.Forms.StatusBar();
         this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
         this.mainMenu1 = new System.Windows.Forms.MainMenu();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.menuOpen = new System.Windows.Forms.MenuItem();
         this.menuSave = new System.Windows.Forms.MenuItem();
         this.menuItem4 = new System.Windows.Forms.MenuItem();
         this.menuExit = new System.Windows.Forms.MenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
         this.SuspendLayout();
         // 
         // statusBar1
         // 
         this.statusBar1.Location = new System.Drawing.Point(0, 496);
         this.statusBar1.Name = "statusBar1";
         this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                      this.statusBarPanel1});
         this.statusBar1.ShowPanels = true;
         this.statusBar1.Size = new System.Drawing.Size(536, 22);
         this.statusBar1.TabIndex = 0;
         this.statusBar1.Text = "statusBar1";
         // 
         // statusBarPanel1
         // 
         this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
         this.statusBarPanel1.Text = "statusBarPanel1";
         this.statusBarPanel1.Width = 520;
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuItem1});
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 0;
         this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                  this.menuOpen,
                                                                                  this.menuSave,
                                                                                  this.menuItem4,
                                                                                  this.menuExit});
         this.menuItem1.Text = "&File";
         // 
         // menuOpen
         // 
         this.menuOpen.Index = 0;
         this.menuOpen.Text = "&Open";
         this.menuOpen.Select += new System.EventHandler(this.MenuSelected);
         // 
         // menuSave
         // 
         this.menuSave.Index = 1;
         this.menuSave.Text = "&Save";
         this.menuSave.Select += new System.EventHandler(this.MenuSelected);
         // 
         // menuItem4
         // 
         this.menuItem4.Index = 2;
         this.menuItem4.Text = "-";
         // 
         // menuExit
         // 
         this.menuExit.Index = 3;
         this.menuExit.Text = "E&xit";
         this.menuExit.Select += new System.EventHandler(this.MenuSelected);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(536, 518);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.statusBar1});
         this.Menu = this.mainMenu1;
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
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

      //<Snippet1>
      private void MenuSelected(object sender, System.EventArgs e)
      {
         if (sender == menuOpen)
            statusBar1.Panels[0].Text = "Opens a file to edit";
         else if(sender == menuSave)
            statusBar1.Panels[0].Text = "Saves the current file";
         else if(sender == menuExit)
            statusBar1.Panels[0].Text = "Exits the application";
         else
            statusBar1.Panels[0].Text = "Ready";
      }
      //</Snippet1>
	}
}
