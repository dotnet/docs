using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HtmlElementEventHandlerCSharp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
        [System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.WebBrowser WebBrowser1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.WebBrowser1 = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();

// 
// WebBrowser1
// 
			this.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.WebBrowser1.Location = new System.Drawing.Point(0, 0);
			this.WebBrowser1.Name = "WebBrowser1";
			this.WebBrowser1.Size = new System.Drawing.Size(824, 440);
			this.WebBrowser1.TabIndex = 0;
			this.WebBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);

// 
// Form1
// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(824, 440);
			this.Controls.Add(this.WebBrowser1);
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
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		//<SNIPPET1>
		private void webBrowser1_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
		{
			WebBrowser1.Document.MouseDown += new HtmlElementEventHandler(Document_MouseDown);
			WebBrowser1.Document.MouseMove += new HtmlElementEventHandler(Document_MouseMove);
			WebBrowser1.Document.MouseUp += new HtmlElementEventHandler(Document_MouseUp);
		}

		private void Document_MouseDown(object sender, HtmlElementEventArgs e)
		{
			// Insert your code here.
		}

		private void Document_MouseMove(object sender, HtmlElementEventArgs e)
		{
			// Insert your code here.
		}

		private void Document_MouseUp(object sender, HtmlElementEventArgs e)
		{
			// Insert your code here.
		}
		//</SNIPPET1>
	}
}
