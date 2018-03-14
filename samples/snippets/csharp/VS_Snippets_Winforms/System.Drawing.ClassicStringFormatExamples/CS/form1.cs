using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicStringFormatExamplesCS
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


        // Snippet for: M:System.Drawing.StringFormat.GetTabStops(System.Single@)
        // <snippet1>
        public void GetSetTabStopsExample1(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Tools used for drawing, painting.
            Pen          redPen = new Pen(Color.FromArgb(255, 255, 0, 0));
            SolidBrush   blueBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
                     
            // Layout and format for text.
            Font         myFont = new Font("Times New Roman", 12);
            StringFormat myStringFormat = new StringFormat();
            Rectangle    enclosingRectangle = new Rectangle(20, 20, 500, 100);
            float[]      tabStops = {150.0f, 100.0f, 100.0f};
                     
            // Text with tabbed columns.
            string       myString =
                "Name\tTab 1\tTab 2\tTab 3\nGeorge Brown\tOne\tTwo\tThree";
                     
            // Set the tab stops, paint the text specified by myString, and draw the
                     
            // rectangle that encloses the text.
            myStringFormat.SetTabStops(0.0f, tabStops);
            g.DrawString(myString, myFont, blueBrush,
                enclosingRectangle, myStringFormat);
            g.DrawRectangle(redPen, enclosingRectangle);
                     
            // Get the tab stops.
            float   firstTabOffset;
            float[] tabStopsObtained = myStringFormat.GetTabStops(out firstTabOffset);
            for(int j = 0; j < tabStopsObtained.Length; j++)
            {
                     
                // Inspect or use the value in tabStopsObtained[j].
                Console.WriteLine("\n  Tab stop {0} = {1}", j, tabStopsObtained[j]);
            }
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.StringFormat.SetDigitSubstitution(System.Int32,System.Drawing.StringDigitSubstitute)
        // <snippet2>
        public void SetDigitSubExample(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
            SolidBrush   blueBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
            Font         myFont = new Font("Courier New", 12);
            StringFormat myStringFormat = new StringFormat();
            string       myString = "0 1 2 3 4 5 6 7 8 9";
                     
               
            // Arabic (0x0C01) digits.
                     
            // Use National substitution method.
            myStringFormat.SetDigitSubstitution(0x0C01,
                StringDigitSubstitute.National);
            g.DrawString(
                "Arabic:\nMethod of substitution = National:     " + myString,
                myFont, blueBrush, new PointF(10.0f, 20.0f), myStringFormat);
                     
            // Use Traditional substitution method.
            myStringFormat.SetDigitSubstitution(0x0C01,
                StringDigitSubstitute.Traditional);
            g.DrawString(
                "Method of substitution = Traditional:  " + myString,
                myFont, blueBrush, new PointF(10.0f, 55.0f), myStringFormat);
                     
            // Thai (0x041E) digits.
           
            // Use National substitution method.
            myStringFormat.SetDigitSubstitution(0x041E,
                StringDigitSubstitute.National);
            g.DrawString(
                "Thai:\nMethod of substitution = National:     " + myString,
                myFont, blueBrush, new PointF(10.0f, 85.0f), myStringFormat);
                     
            // Use Traditional substitution method.
            myStringFormat.SetDigitSubstitution(0x041E,
                StringDigitSubstitute.Traditional);
            g.DrawString(
                "Method of substitution = Traditional:  " + myString,
                myFont, blueBrush, new PointF(10.0f, 120.0f), myStringFormat);
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.StringFormat.SetMeasurableCharacterRanges(System.Drawing.CharacterRange[])
        // <snippet3>
        public void SetMeasCharRangesExample(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
            SolidBrush   redBrush = new SolidBrush(Color.FromArgb(50, 255, 0, 0));
                     
            // Layout rectangles, font, and string format used for displaying string.
            Rectangle    layoutRectA = new Rectangle(20, 20, 165, 80);
            Rectangle    layoutRectB = new Rectangle(20, 110, 165, 80);
            Rectangle    layoutRectC = new Rectangle(20, 200, 240, 80);
            Font         tnrFont = new Font("Times New Roman", 16);
            StringFormat strFormat = new StringFormat();
                     
            // Ranges of character positions within a string.
            CharacterRange[] charRanges = { new CharacterRange(3, 5),
                new CharacterRange(15, 2), new CharacterRange(30, 15)};
                     
            // Each region specifies the area occupied by the characters within a
            // range of positions. the values are obtained by using a method that
            // measures the character ranges.
            Region[]     charRegions = new Region[charRanges.Length];
                     
            // String to be displayed.
            string  str =
                "The quick, brown fox easily jumps over the lazy dog.";
                     
            // Set the char ranges for the string format.
            strFormat.SetMeasurableCharacterRanges(charRanges);
           
            // loop counter (unsigned 8-bit integer)
            byte  i;    
           
            // Measure the char ranges for a given string and layout rectangle. Each
            // area occupied by the characters in a range is stored as a region. Then
            // draw the string and layout rectangle, and paint the regions.
            charRegions = g.MeasureCharacterRanges(str, tnrFont,
                layoutRectA, strFormat);
           g.DrawString(str, tnrFont, Brushes.Blue, layoutRectA, strFormat);
            g.DrawRectangle(Pens.Black, layoutRectA);
             
            // Paint the regions.
            for (i = 0; i < charRegions.Length; i++)
                g.FillRegion(redBrush, charRegions[i]);   
           
                     
            // Repeat the above steps, but include trailing spaces in the char
            // range measurement by setting the appropriate string format flag.
            strFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
            charRegions = g.MeasureCharacterRanges(str, tnrFont,
                layoutRectB, strFormat);
            g.DrawString(str, tnrFont, Brushes.Blue, layoutRectB, strFormat);
            g.DrawRectangle(Pens.Black, layoutRectB);
             
            
            for (i = 0; i < charRegions.Length; i++)
                g.FillRegion(redBrush, charRegions[i]);   
           
            // Clear all the format flags.
            strFormat.FormatFlags = 0;                   
         
            // Repeat the steps, but use a different layout rectangle. the dimensions
            // of the layout rectangle and the size of the font both affect the
            // character range measurement.
            charRegions = g.MeasureCharacterRanges(str, tnrFont,
                layoutRectC, strFormat);
            g.DrawString(str, tnrFont, Brushes.Blue, layoutRectC, strFormat);
            g.DrawRectangle(Pens.Black, layoutRectC);
            
            // Paint the regions.
            for (i = 0; i < charRegions.Length; i++)
                g.FillRegion(redBrush, charRegions[i]);   
            
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.StringFormat.SetTabStops(System.Single,System.Single[])
        // <snippet4>
        public void GetSetTabStopsExample2(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Tools used for drawing, painting.
            Pen          redPen = new Pen(Color.FromArgb(255, 255, 0, 0));
            SolidBrush   blueBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
                     
            // Layout and format for text.
            Font         myFont = new Font("Times New Roman", 12);
            StringFormat myStringFormat = new StringFormat();
            Rectangle    enclosingRectangle = new Rectangle(20, 20, 500, 100);
            float[]      tabStops = {150.0f, 100.0f, 100.0f};
                     
            // Text with tabbed columns.
            string       myString =
                "Name\tTab 1\tTab 2\tTab 3\nGeorge Brown\tOne\tTwo\tThree";
                     
            // Set the tab stops, paint the text specified by myString, draw the
            // rectangle that encloses the text.
            myStringFormat.SetTabStops(0.0f, tabStops);
            g.DrawString(myString, myFont, blueBrush,
                enclosingRectangle, myStringFormat);
            g.DrawRectangle(redPen, enclosingRectangle);
                     
            // Get the tab stops.
            float   firstTabOffset;
            float[] tabStopsObtained = myStringFormat.GetTabStops(out firstTabOffset);
            for(int j = 0; j < tabStopsObtained.Length; j++)
            {
                     
                // Inspect or use the value in tabStopsObtained[j].
                Console.WriteLine("\n  Tab stop {0} = {1}", j, tabStopsObtained[j]);
            }
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.StringFormat.ToString
        // <snippet5>
        public void ToStringExample(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
            SolidBrush   blueBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
            Font         myFont = new Font("Times New Roman", 14);
            StringFormat myStringFormat = new StringFormat();
                     
            // String variable to hold the values of the StringFormat object.
            string    strFmtString;
                     
            // Convert the string format object to a string (only certain information
            // in the object is converted) and display the string.
            strFmtString = myStringFormat.ToString();
            g.DrawString("Before changing properties:   " + myStringFormat,
                myFont, blueBrush, 20, 40);
                     
            // Change some properties of the string format
            myStringFormat.Trimming = StringTrimming.None;
            myStringFormat.FormatFlags =   StringFormatFlags.NoWrap
                | StringFormatFlags.NoClip;
                     
            // Convert the string format object to a string and display the string.
            // The string will be different because the properties of the string
            // format have changed.
            strFmtString = myStringFormat.ToString();
            g.DrawString("After changing properties:   " + myStringFormat,
                myFont, blueBrush, 20, 70);
        }
        // </snippet5>

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
