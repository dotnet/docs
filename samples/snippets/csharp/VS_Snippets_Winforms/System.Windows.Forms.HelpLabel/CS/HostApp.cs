// <snippet10>
namespace Microsoft.Samples.WinForms.Cs.HostApp 
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Windows.Forms;
	using Microsoft.Samples.WinForms.Cs.HelpLabel;

	public class HostApp : System.Windows.Forms.Form 
	{
		/// <summary>
		///    Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private Microsoft.Samples.WinForms.Cs.HelpLabel.HelpLabel helpLabel1;

		public HostApp() 
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		/// <summary>
		///    Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) 
		{
			if (disposing) 
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		/// <summary>
		///    Required method for Designer support - do not modify
		///    the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.helpLabel1 = new Microsoft.Samples.WinForms.Cs.HelpLabel.HelpLabel();

			label1.Location = new System.Drawing.Point(16, 16);
			label1.Text = "Name:";
			label1.Size = new System.Drawing.Size(56, 24);
			label1.TabIndex = 3;

			helpLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			helpLabel1.Size = new System.Drawing.Size(448, 40);
			helpLabel1.TabIndex = 0;
			helpLabel1.Location = new System.Drawing.Point(0, 117);

			button1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			button1.Size = new System.Drawing.Size(104, 40);
			button1.TabIndex = 1;
			helpLabel1.SetHelpText(button1, "This is the Save Button. Press the Save Button to save your work.");
			button1.Text = "&Save";
			button1.Location = new System.Drawing.Point(336, 56);

			this.Text = "Control Example";
			this.ClientSize = new System.Drawing.Size(448, 157);

			textBox1.Anchor = AnchorStyles.Left| AnchorStyles.Right | AnchorStyles.Top;
			textBox1.Location = new System.Drawing.Point(80, 16);
			textBox1.Text = "<Name>";
			helpLabel1.SetHelpText(textBox1, "This is the name field. Please enter your name here.");
			textBox1.TabIndex = 2;
			textBox1.Size = new System.Drawing.Size(360, 20);

			this.Controls.Add(label1);
			this.Controls.Add(textBox1);
			this.Controls.Add(button1);
			this.Controls.Add(helpLabel1);
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args) 
		{
			Application.Run(new HostApp());
		}

	}
}

// </snippet10>