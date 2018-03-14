using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SelectionRangew
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
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
		/// Required method for Designer support; do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Location = new System.Drawing.Point(10, 8);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 0;
			this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(96, 176);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(104, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(96, 208);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(104, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Start";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 208);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "End";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(72, 248);
			this.button1.Name = "button1";
			this.button1.TabIndex = 5;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(216, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.button1,
																							 this.label2,
																							 this.label1,
																							 this.textBox2,
																							 this.textBox1,
																							 this.monthCalendar1});
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
private void button1_Click(object sender, System.EventArgs e)
{
   // Create a SelectionRange object and set its Start and End properties.
   SelectionRange sr = new SelectionRange();
   sr.Start = DateTime.Parse(this.textBox1.Text);
   sr.End = DateTime.Parse(this.textBox2.Text);
   /* Assign the SelectionRange object to the 
      SelectionRange property of the MonthCalendar control. */
   this.monthCalendar1.SelectionRange = sr;
}

private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
{
   /* Display the Start and End property values of 
      the SelectionRange object in the text boxes. */
   this.textBox1.Text = 
     monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
   this.textBox2.Text = 
     monthCalendar1.SelectionRange.End.Date.ToShortDateString();
}
//</snippet1>



	}
}
