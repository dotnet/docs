using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ContainerProject
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MdiClient mdiClient1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			InitializeComponent();
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
			this.mdiClient1 = new System.Windows.Forms.MdiClient();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// mdiClient1
			// 
			this.mdiClient1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mdiClient1.Name = "mdiClient1";
			this.mdiClient1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(16, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(568, 368);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.mdiClient1});
			this.IsMdiContainer = true;
			this.Name = "Form1";
			this.Text = "Form1";
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
		// <snippet1>
		// The event handler on Form1.
		private void button1_Click(object sender, System.EventArgs e)
		{
			// Create an instance of Form2.
			Form2 f2 = new Form2();
			// Make this form the parent of f2.
			f2.MdiParent = this;
			// Display the form.
			f2.Show();
		}
		// </snippet1>
		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
