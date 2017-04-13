//<Snippet1>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TrackBar
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		public Form1()
		{
                        //
                        // Required for Windows Form Designer support
                        //
                        InitializeComponent();

                        //
                        // TODO: Add any constructor code after InitializeComponent call
                        //
                        //<Snippet2>
                        trackBar2.Orientation = Orientation.Vertical;
                        trackBar3.Orientation = Orientation.Vertical;
                        trackBar1.Maximum = trackBar2.Maximum = trackBar3.Maximum = 255;
                        trackBar1.Width = 400;
                        trackBar2.Height = trackBar3.Height = trackBar1.Width;
                        trackBar1.LargeChange = trackBar2.LargeChange = trackBar3.LargeChange = 16;
                        //</Snippet2>
		}       

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
 
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
			//<Snippet4>
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(160, 400);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(608, 40);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.TabIndex = 2;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(56, 40);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.TabIndex = 3;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar_Scroll);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			//</Snippet4>
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(128, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 352);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(288, 448);
            this.label1.Name = "label1";
            this.label1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(600, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 6;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(728, 477);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {this.label3,
                                                                          this.label2,
                                                                          this.label1,
                                                                          this.trackBar3,
                                                                          this.trackBar2,
                                                                          this.trackBar1,
                                                                          this.panel1});
            this.Name = "Form1";
            this.Text = "Color builder";
            this.Load += new System.EventHandler(this.Form1_Load);
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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            showColorValueLabels();
        }
        //<Snippet3>
        private void showColorValueLabels()
        {
            label1.Text = "Red value is : " + trackBar1.Value.ToString();
            label3.Text = "Green Value is : " + trackBar2.Value.ToString();
            label2.Text = "Blue Value is : " + trackBar3.Value.ToString();
        }
        private void trackBar_Scroll(object sender, System.EventArgs e)
        {
            System.Windows.Forms.TrackBar myTB;
            myTB = (System.Windows.Forms.TrackBar) sender ;
            panel1.BackColor = Color.FromArgb(trackBar1.Value,trackBar2.Value,trackBar3.Value);
            myTB.Text = "Value is " + myTB.Value.ToString();
            showColorValueLabels();
        }
        //</Snippet3>
	}
}
//</Snippet1>
