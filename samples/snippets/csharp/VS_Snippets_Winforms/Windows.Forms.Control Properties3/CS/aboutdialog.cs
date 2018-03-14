using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.CompilerServices;


[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("Test")]
[assembly: AssemblyVersion("1.0.*")]
namespace CodeExamples
{
	public class AboutDialog : System.Windows.Forms.Form
	{
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.Label labelVersionInfo;
		private System.ComponentModel.Container components = null;

		public AboutDialog()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
         this.labelVersionInfo = new System.Windows.Forms.Label();
         this.buttonOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // labelVersionInfo
         // 
         this.labelVersionInfo.Location = new System.Drawing.Point(8, 8);
         this.labelVersionInfo.Name = "labelVersionInfo";
         this.labelVersionInfo.Size = new System.Drawing.Size(360, 23);
         this.labelVersionInfo.TabIndex = 0;
         this.labelVersionInfo.Text = "label1";
         // 
         // buttonOK
         // 
         this.buttonOK.Location = new System.Drawing.Point(296, 64);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.TabIndex = 3;
         this.buttonOK.Text = "&OK";
         // 
         // AboutDialog
         // 
         this.ClientSize = new System.Drawing.Size(392, 109);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.buttonOK,
                                                                      this.labelVersionInfo});
         this.Name = "AboutDialog";
         this.Text = "About";
         this.Load += new System.EventHandler(this.AboutDialog_Load);
         this.ResumeLayout(false);

      }
		#endregion


      [STAThread]
      static void Main() 
      {
         Application.Run(new AboutDialog());
      }

// <snippet1>
private void AboutDialog_Load(object sender, EventArgs e)
{
   // Display the application information in the label.
   this.labelVersionInfo.Text = 
      this.CompanyName + "  " + 
      this.ProductName + "  Version: " +
      this.ProductVersion;  
}
// </snippet1>




	}
}
