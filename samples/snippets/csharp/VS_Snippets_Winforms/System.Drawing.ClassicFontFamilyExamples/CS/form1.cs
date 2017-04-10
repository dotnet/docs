using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicFontFamilyCS
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


        // Snippet for: M:System.Drawing.FontFamily.Equals(System.Object)
        // <snippet1>
        public void Equals_Example(PaintEventArgs e)
        {
            // Create two FontFamily objects.
            FontFamily firstFontFamily = new FontFamily("Arial");
            FontFamily secondFontFamily = new FontFamily("Times New Roman");
                     
            // Check to see if the two font families are equivalent.
            bool equalFonts = firstFontFamily.Equals(secondFontFamily);
                     
            // Display the result of the test in a message box.
            MessageBox.Show(equalFonts.ToString());
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.FontFamily.GetCellAscent(System.Drawing.FontStyle)
        // <snippet2>
        public void GetCellAscent_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily ascentFontFamily = new FontFamily("arial");
                     
            // Get the cell ascent of the font family in design units.
            int cellAscent = ascentFontFamily.GetCellAscent(FontStyle.Regular);
                     
            // Draw the result as a string to the screen.
            e.Graphics.DrawString(
                "ascentFontFamily.GetCellAscent() returns " + cellAscent.ToString() + ".",
                new Font(ascentFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.FontFamily.GetCellDescent(System.Drawing.FontStyle)
        // <snippet3>
        public void GetCellDescent_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily descentFontFamily = new FontFamily("arial");
                     
            // Get the cell descent of the font family in design units.
            int cellDescent = descentFontFamily.GetCellDescent(FontStyle.Regular);
                     
            // Draw the result as a string to the screen.
            e.Graphics.DrawString(
                "descentFontFamily.GetCellDescent() returns " + cellDescent.ToString() + ".",
                new Font(descentFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.FontFamily.GetEmHeight(System.Drawing.FontStyle)
        // <snippet4>
        public void GetEmHeight_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily emFontFamily = new FontFamily("arial");
                     
            // Get the em height of the font family in design units.
            int emHeight = emFontFamily.GetEmHeight(FontStyle.Regular);
                     
            // Draw the result as a string to the screen.
            e.Graphics.DrawString(
                "emFontFamily.GetEmHeight() returns " + emHeight.ToString() + ".",
                new Font(emFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }
            // </snippet4>

// Snippet for: M:System.Drawing.FontFamily.GetFamilies(System.Drawing.Graphics)
            // <snippet5>
            public void GetFamilies_Example(PaintEventArgs e)
            {
                // Get an array of the available font families.
                FontFamily[] families = FontFamily.GetFamilies(e.Graphics);
                     
                // Draw text using each of the font families.
                Font familiesFont;
                string familyString;
                float spacing = 0;
                
                foreach (FontFamily family in families)
                {
                   if (family.IsStyleAvailable(FontStyle.Regular)) 
                    {
                        familiesFont = new Font(family, 16);
                        familyString = "This is the " + family.Name + " family.";
                        e.Graphics.DrawString(
                            familyString,
                            familiesFont,
                            Brushes.Black,
                            new PointF(0, spacing));
                        spacing += familiesFont.Height;
                    }
                }
            }
        // </snippet5>



        // Snippet for: M:System.Drawing.FontFamily.GetHashCode
        // <snippet6>
        public void GetHashCode_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Get the hash code for myFontFamily.
            int hashCode = myFontFamily.GetHashCode();
                     
            // Draw the value of hashCode to the screen as a string.
            e.Graphics.DrawString(
                "hashCode = " + hashCode.ToString(),
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.FontFamily.GetLineSpacing(System.Drawing.FontStyle)
        // <snippet7>
        public void GetLineSpacing_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Get the line spacing for myFontFamily.
            int lineSpacing = myFontFamily.GetLineSpacing(FontStyle.Regular);
                     
            // Draw the value of lineSpacing to the screen as a string.
            e.Graphics.DrawString(
                "lineSpacing = " + lineSpacing.ToString(),
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.FontFamily.GetName(System.Int32)
        // <snippet8>
        public void GetName_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Get the name of myFontFamily.
            string familyName = myFontFamily.GetName(0);
                     
            // Draw the name of the myFontFamily to the screen as a string.
            e.Graphics.DrawString(
                "The family name is " + familyName,
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }
        // </snippet8>


        // Snippet for: M:System.Drawing.FontFamily.IsStyleAvailable(System.Drawing.FontStyle)
        // <snippet9>
        public void IsStyleAvailable_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Test whether myFontFamily is available in Italic.
            if(myFontFamily.IsStyleAvailable(FontStyle.Italic))
            {
                     
                // Create a Font object using myFontFamily.
                Font familyFont = new Font(myFontFamily, 16, FontStyle.Italic);
                     
                // Use familyFont to draw text to the screen.
                e.Graphics.DrawString(
                    myFontFamily.Name + " is available in Italic",
                    familyFont,
                    Brushes.Black,
                    new PointF(0, 0));
            }
        }
        // </snippet9>


        // Snippet for: M:System.Drawing.FontFamily.ToString
        // <snippet10>
        public void ToString_Example(PaintEventArgs e)
        {
            // Create a FontFamily object.
            FontFamily myFontFamily = new FontFamily("Arial");
                     
            // Draw a string representation of myFontFamily to the screen.
            e.Graphics.DrawString(
                myFontFamily.ToString(),
                new Font(myFontFamily, 16),
                Brushes.Black,
                new PointF(0, 0));
        }
        // </snippet10>

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
