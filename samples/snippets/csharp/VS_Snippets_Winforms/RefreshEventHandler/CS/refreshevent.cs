using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace PropertyChanged
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox1;
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 0;
			this.textBox1.Text = "textBox1";
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(488, 301);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBox1});
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

//<snippet1>
private void Form1_Load(object sender, System.EventArgs e)
{
    textBox1.Text = "changed";
    System.ComponentModel.TypeDescriptor.Refreshed += new
    System.ComponentModel.RefreshEventHandler(OnRefresh);
    System.ComponentModel.TypeDescriptor.GetProperties(textBox1);
    System.ComponentModel.TypeDescriptor.Refresh(textBox1);
}

protected static void OnRefresh(System.ComponentModel.RefreshEventArgs e)
{
    Console.WriteLine(e.ComponentChanged.ToString());
}
//</snippet1>


	}

	class Control : Component 
	{
		int position;
    
		public int Position 
		{ 
			get { return position; }
			set 
			{
				if (!position.Equals(value)) 
				{
					position = value;
					//RaisePropertyChangedEvent(position);
				}
			}
		}
	}




}
