using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace test2
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	
	[LicenseProvider(typeof(LicFileLicenseProvider))]
	public class Form1 : System.Windows.Forms.Form
	{
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
		protected override void Dispose(bool disposing)
		{
         if(disposing)
         {
            if (components != null) 
            {
               components.Dispose();
            }
            base.Dispose();
         }		
      }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);

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
		//<snippet1>
		try {
		    License licTest = null;
		    licTest = LicenseManager.Validate(typeof(Form1), this);
		}

		catch(LicenseException licE) {
		    Console.WriteLine(licE.Message);
		    Console.WriteLine(licE.LicensedType);
		    Console.WriteLine(licE.StackTrace);
		    Console.WriteLine(licE.Source);	
		}
		//</snippet1>
		}

	}
}