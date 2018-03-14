using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicFontExamplesCS
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


        // Snippet for: M:System.Drawing.Font.Clone
        // <snippet1>
        public void Clone_Example(PaintEventArgs e)
        {
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Create a copy of myFont.
            Font cloneFont = (Font)myFont.Clone();
                     
            // Use cloneFont to draw text to the screen.
            e.Graphics.DrawString("This is a cloned font", cloneFont,
                Brushes.Black, 0, 0);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Font.Equals(System.Object)
        // <snippet2>
        public void Equals_Example(PaintEventArgs e)
        {
            // Create a Font object.
            Font firstFont = new Font("Arial", 16);
                     
            // Create a second Font object.
            Font secondFont = new Font(new FontFamily("Arial"), 16);
                     
            // Test to see if firstFont is identical to secondFont.
            bool fontTest = firstFont.Equals(secondFont);
                     
            // Display a message box with the result of the test.
            MessageBox.Show(fontTest.ToString());
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Font.FromHfont(System.IntPtr)
        // <snippet3>
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr GetStockObject(int fnObject);
        public void FromHfont_Example(PaintEventArgs e)
        {
                     
            // Get a handle for a GDI font.
            IntPtr hFont = GetStockObject(0);
                     
            // Create a Font object from hFont.
            Font hfontFont = Font.FromHfont(hFont);
                     
            // Use hfontFont to draw text to the screen.
            e.Graphics.DrawString(
                "This font is from a GDI HFONT", hfontFont,Brushes.Black, 
                0, 0);
               
                
                
                
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Font.GetHashCode
        // <snippet4>
        public void GetHashCode_Example(PaintEventArgs e)
        {
                     
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Get the hash code for myFont.
            int hashCode = myFont.GetHashCode();
                     
            // Display the hash code in a message box.
            MessageBox.Show(hashCode.ToString());
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Font.GetHeight(System.Drawing.Graphics)
        // <snippet5>
        public void GetHeight_Example(PaintEventArgs e)
        {
                     
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            //Draw text to the screen with myFont.
            e.Graphics.DrawString("This is the first line",myFont,
                Brushes.Black, new PointF(0, 0));
                     
            //Get the height of myFont.
            float height = myFont.GetHeight(e.Graphics);
                     
            //Draw text immediately below the first line of text.
            e.Graphics.DrawString(
                "This is the second line",
                myFont,
                Brushes.Black,
                new PointF(0, height));
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Font.ToHfont
        // <snippet6>

	//Reference the GDI DeleteObject method.
        [System.Runtime.InteropServices.DllImport("GDI32.dll")]
        public static extern bool DeleteObject(IntPtr objectHandle); 

        public void ToHfont_Example(PaintEventArgs e)
        {
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Get a handle to the Font object.
            IntPtr hFont = myFont.ToHfont();
                     
            // Display a message box with the value of hFont.
            MessageBox.Show(hFont.ToString());
            
            //Dispose of the hFont.
            DeleteObject(hFont);
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.Font.ToString
        // <snippet7>
        public void ToString_Example(PaintEventArgs e)
        {
            // Create a Font object.
            Font myFont = new Font("Arial", 16);
                     
            // Get a string that represents myFont.
            string fontString = myFont.ToString();
                     
            // Display a message box with fontString.
            MessageBox.Show(fontString);
        }
        // </snippet7>

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
