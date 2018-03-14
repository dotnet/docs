using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ProgressBarValueEx
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.ProgressBar progressBar1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.StatusBar statusBar1;
      private System.Windows.Forms.StatusBarPanel statusBarPanel1;
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
         this.progressBar1 = new System.Windows.Forms.ProgressBar();
         this.button1 = new System.Windows.Forms.Button();
         this.statusBar1 = new System.Windows.Forms.StatusBar();
         this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
         ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
         this.SuspendLayout();
         // 
         // progressBar1
         // 
         this.progressBar1.Location = new System.Drawing.Point(24, 24);
         this.progressBar1.Name = "progressBar1";
         this.progressBar1.Size = new System.Drawing.Size(192, 24);
         this.progressBar1.Step = 1;
         this.progressBar1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(224, 24);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // statusBar1
         // 
         this.statusBar1.Location = new System.Drawing.Point(0, 272);
         this.statusBar1.Name = "statusBar1";
         this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                      this.statusBarPanel1});
         this.statusBar1.ShowPanels = true;
         this.statusBar1.Size = new System.Drawing.Size(368, 22);
         this.statusBar1.TabIndex = 2;
         this.statusBar1.Text = "statusBar1";
         // 
         // statusBarPanel1
         // 
         this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
         this.statusBarPanel1.Text = "Ready";
         this.statusBarPanel1.Width = 352;
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(368, 294);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.statusBar1,
                                                                      this.button1,
                                                                      this.progressBar1});
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

      private void button1_Click(object sender, System.EventArgs e)
      {
         InitializeMyTimer();
      }

      //<Snippet1>
      private Timer time = new Timer();

      // Call this method from the constructor of the form.
      private void InitializeMyTimer()
      {
         // Set the interval for the timer.
         time.Interval = 250;
         // Connect the Tick event of the timer to its event handler.
         time.Tick += new EventHandler(IncreaseProgressBar);
         // Start the timer.
         time.Start();
      }

      private void IncreaseProgressBar(object sender, EventArgs e)
      {
         // Increment the value of the ProgressBar a value of one each time.
         progressBar1.Increment(1);
         // Display the textual value of the ProgressBar in the StatusBar control's first panel.
         statusBarPanel1.Text = progressBar1.Value.ToString() + "% Completed";
         // Determine if we have completed by comparing the value of the Value property to the Maximum value.
         if (progressBar1.Value == progressBar1.Maximum)
            // Stop the timer.
            time.Stop();
      }
      //</Snippet1>
   }
}
