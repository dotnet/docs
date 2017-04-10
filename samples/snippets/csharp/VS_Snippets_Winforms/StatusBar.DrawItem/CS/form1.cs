using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace OwnerDrawnStatusBarPanel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.StatusBarPanel statusBarPanel1;
      private System.Windows.Forms.StatusBarPanel statusBarPanel2;
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

         StatusBarPanel sbp = new StatusBarPanel();
         sbp.Width = 100;

         sbp.Style = StatusBarPanelStyle.OwnerDraw;

         statusBar1.Panels.Add(sbp);
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
         this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
         this.button1 = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
         this.SuspendLayout();
         // 
         // statusBar1
         // 
         this.statusBar1.Location = new System.Drawing.Point(0, 384);
         this.statusBar1.Name = "statusBar1";
         this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                      this.statusBarPanel1,
                                                                                      this.statusBarPanel2});
         this.statusBar1.ShowPanels = true;
         this.statusBar1.Size = new System.Drawing.Size(536, 22);
         this.statusBar1.TabIndex = 0;
         this.statusBar1.Text = "statusBar1";
         this.statusBar1.DrawItem += new System.Windows.Forms.StatusBarDrawItemEventHandler(this.DrawMyPanel);
         // 
         // statusBarPanel1
         // 
         this.statusBarPanel1.Text = "statusBarPanel1";
         // 
         // statusBarPanel2
         // 
         this.statusBarPanel2.Text = "statusBarPanel2";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(336, 112);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(104, 32);
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(536, 406);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button1,
                                                                      this.statusBar1});
         this.Name = "Form1";
         this.Text = "Form1";
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
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
      private void DrawMyPanel(object sender, System.Windows.Forms.StatusBarDrawItemEventArgs sbdevent)
      {
         // Create a StringFormat object to align text in the panel.
         StringFormat sf = new StringFormat();
         // Format the String of the StatusBarPanel to be centered.
         sf.Alignment = StringAlignment.Center;
         sf.LineAlignment = StringAlignment.Center;

         // Draw a black background in owner-drawn panel.
         sbdevent.Graphics.FillRectangle(Brushes.Black, sbdevent.Bounds);
         // Draw the current date (short date format) with white text in the control's font.
         sbdevent.Graphics.DrawString(DateTime.Today.ToShortDateString(), 
            statusBar1.Font,Brushes.White,sbdevent.Bounds,sf);
      }
      //</Snippet1>
	}
}
