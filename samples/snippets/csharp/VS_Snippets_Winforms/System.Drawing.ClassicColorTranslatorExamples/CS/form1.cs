using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicColorTranslatorCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
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
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "Form1";
		}
		#endregion


        // Snippet for: M:System.Drawing.ColorTranslator.FromHtml(System.String)
        // <snippet1>
        public void FromHtml_Example(PaintEventArgs e)
        {
            // Create a string representation of an HTML color.
            string htmlColor = "Blue";
                     
            // Translate htmlColor to a GDI+ Color structure.
            Color myColor = ColorTranslator.FromHtml(htmlColor);
                     
            // Fill a rectangle with myColor.
            e.Graphics.FillRectangle( new SolidBrush(myColor), 0, 0, 
                100, 100);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.ColorTranslator.FromOle(System.Int32)
        // <snippet2>
        public void FromOle_Example(PaintEventArgs e)
        {
            // Create an integer representation of an OLE color.
            int oleColor = 0xFF00;
                     
            // Translate oleColor to a GDI+ Color structure.
            Color myColor = ColorTranslator.FromOle(oleColor);
                     
            // Fill a rectangle with myColor.
            e.Graphics.FillRectangle( new SolidBrush(myColor), 0, 0, 
                100, 100);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.ColorTranslator.FromWin32(System.Int32)
        // <snippet3>
        public void FromWin32_Example(PaintEventArgs e)
        {
            // Create an integer representation of a Windows color.
            int winColor = 0xA000;
                     
            // Translate winColor to a GDI+ Color structure.
            Color myColor = ColorTranslator.FromWin32(winColor);
                     
            // Fill a rectangle with myColor.
            e.Graphics.FillRectangle( new SolidBrush(myColor), 0, 0, 
                100, 100);
                
                
                
                
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color)
        // <snippet4>
        public void ToHtml_Example(PaintEventArgs e)
        {
            // Create an instance of a Color structure.
            Color myColor = Color.Red;
                     
            // Translate myColor to an HTML color.
            string htmlColor = ColorTranslator.ToHtml(myColor);
                     
            // Show a message box with the value of htmlColor.
            MessageBox.Show(htmlColor);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.ColorTranslator.ToOle(System.Drawing.Color)
        // <snippet5>
        public void ToOle_Example(PaintEventArgs e)
        {
           // Create an instance of a Color structure.
            Color myColor = Color.Red;
                     
            // Translate myColor to an OLE color.
            int oleColor = ColorTranslator.ToOle(myColor);
                     
            // Show a message box with the value of oleColor.
            MessageBox.Show(oleColor.ToString());
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.ColorTranslator.ToWin32(System.Drawing.Color)
        // <snippet6>
        public void ToWin32_Example(PaintEventArgs e)
        {
            // Create an instance of a Color structure.
            Color myColor = Color.Red;
                     
            // Translate myColor to an OLE color.
            int winColor = ColorTranslator.ToWin32(myColor);
                     
            // Show a message box with the value of winColor.
            MessageBox.Show(winColor.ToString());
        }
        // </snippet6>

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
