using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace System.Drawing.ClassicColorExamplesCS
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


        // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32)
        // <snippet1>
        public void FromArgb4(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Transparent red, green, and blue brushes.
            SolidBrush trnsRedBrush = new SolidBrush(Color.FromArgb(0x78FF0000));
            SolidBrush trnsGreenBrush = new SolidBrush(Color.FromArgb(0x7800FF00));
            SolidBrush trnsBlueBrush = new SolidBrush(Color.FromArgb(0x780000FF));
                     
            // Base and height of the triangle that is used to position the
            // circles. Each vertex of the triangle is at the center of one of the
            // 3 circles. The base is equal to the diameter of the circles.
            float   triBase = 100;
            float   triHeight = (float)Math.Sqrt(3*(triBase*triBase)/4);
                     
            // coordinates of first circle's bounding rectangle.
            float   x1 = 40;
            float   y1 = 40;
                     
            // Fill 3 over-lapping circles. Each circle is a different color.
            g.FillEllipse(trnsRedBrush, x1, y1, 2*triHeight, 2*triHeight);
            g.FillEllipse(trnsGreenBrush, x1 + triBase/2, y1 + triHeight,
                2*triHeight, 2*triHeight);
            g.FillEllipse(trnsBlueBrush, x1 + triBase, y1, 2*triHeight, 2*triHeight);
        }
        // </snippet1>


        // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Drawing.Color)
        // <snippet2>
        public void FromArgb3(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Opaque colors (alpha value defaults to 255 -- max value).
            Color red = Color.FromArgb(255, 0, 0);
            Color green = Color.FromArgb(0, 255, 0);
            Color blue = Color.FromArgb(0, 0, 255);
                     
            // Solid brush initialized to red.
            SolidBrush  myBrush = new SolidBrush(red);
            int alpha;
            
            // x coordinate of first red rectangle
            int x = 50;         
            
            // y coordinate of first red rectangle
            int y = 50;         
            
            // Fill rectangles with red, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, red);
                g.FillRectangle(myBrush, x, y, 50, 100);
                g.FillRectangle(myBrush, x, y + 250, 50, 50);
                x += 50;
            }
            // x coordinate of first green rectangle
            x = 50;             
            
            // y coordinate of first green rectangle
            y += 50;            
            
            // Fill rectangles with green, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, green);
                g.FillRectangle(myBrush, x, y, 50, 150);
                x += 50;
            }
            // x coordinate of first blue rectangle.
            x = 50; 
            
             // y coordinate of first blue rectangle
            y += 100;           
           
                     
            // Fill rectangles with blue, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, blue);
                g.FillRectangle(myBrush, x, y, 50, 150);
                x += 50;
            }
        }
        // </snippet2>


        // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Int32,System.Int32)
        // <snippet3>
        public void FromArgb2(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Opaque colors (alpha value defaults to 255 -- max value).
            Color red = Color.FromArgb(255, 0, 0);
            Color green = Color.FromArgb(0, 255, 0);
            Color blue = Color.FromArgb(0, 0, 255);
                     
            // Solid brush initialized to red.
            SolidBrush  myBrush = new SolidBrush(red);
            int alpha;

            // x coordinate of first red rectangle
            int x = 50;         
            
            // y coordinate of first red rectangle
            int y = 50;         
                           
            // Fill rectangles with red, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, red);
                g.FillRectangle(myBrush, x, y, 50, 100);
                g.FillRectangle(myBrush, x, y + 250, 50, 50);
                x += 50;
            }
            // x coordinate of first green rectangle.
            x = 50;             
            
            // y coordinate of first green rectangle.
            y += 50;            
                              
            // Fill rectangles with green, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, green);
                g.FillRectangle(myBrush, x, y, 50, 150);
                x += 50;
            }
            // x coordinate of first blue rectangle.
            x = 50;             
            
            // y coordinate of first blue rectangle.
            y += 100;           
                     
            // Fill rectangles with blue, varying the alpha value from 25 to 250.
            for (alpha = 25; alpha <= 250; alpha += 25)
            {
                myBrush.Color = Color.FromArgb(alpha, blue);
                g.FillRectangle(myBrush, x, y, 50, 150);
                x += 50;
            }
        }
        // </snippet3>


        // Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Int32,System.Int32,System.Int32)
        // <snippet4>
        public void FromArgb1(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Transparent red, green, and blue brushes.
            SolidBrush trnsRedBrush = new SolidBrush(Color.FromArgb(120, 255, 0, 0));
            SolidBrush trnsGreenBrush = new SolidBrush(Color.FromArgb(120, 0, 255, 0));
            SolidBrush trnsBlueBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 255));
                     
            // Base and height of the triangle that is used to position the
            // circles. Each vertex of the triangle is at the center of one of the
            // 3 circles. The base is equal to the diameter of the circles.
            float   triBase = 100;
            float   triHeight = (float)Math.Sqrt(3*(triBase*triBase)/4);
                     
            // Coordinates of first circle's bounding rectangle.
            float   x1 = 40;
            float   y1 = 40;
                     
            // Fill 3 over-lapping circles. Each circle is a different color.
            g.FillEllipse(trnsRedBrush, x1, y1, 2*triHeight, 2*triHeight);
            g.FillEllipse(trnsGreenBrush, x1 + triBase/2, y1 + triHeight,
                2*triHeight, 2*triHeight);
            g.FillEllipse(trnsBlueBrush, x1 + triBase, y1, 2*triHeight, 2*triHeight);
        }
        // </snippet4>


        // Snippet for: M:System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor)
        // <snippet5>
        public void KnownColorBrightnessExample1(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Color structures. One is a variable used for temporary storage. The other
            // is a constant used for comparisons.
            Color   someColor = Color.FromArgb(0);
            Color   redShade = Color.FromArgb(255, 200, 0, 100);
                     
            // Array to store KnownColor values that match the brightness of the
            // redShade color.
            KnownColor[]  colorMatches = new KnownColor[15];
             
            // Number of matches found.
            int  count = 0;   
                  
            // Iterate through the KnownColor enums until 15 matches are found.
            for (KnownColor enumValue = 0;
                enumValue <= KnownColor.YellowGreen && count < 15; enumValue++)
            {
                someColor = Color.FromKnownColor(enumValue);
                if (someColor.GetBrightness() == redShade.GetBrightness())
                    colorMatches[count++] = enumValue;
            }
                     
            // Display the redShade color and its argb value.
            SolidBrush  myBrush1 = new SolidBrush(redShade);
            Font        myFont = new Font("Arial", 12);
            int         x = 20;
            int         y = 20;
            someColor = redShade;
            g.FillRectangle(myBrush1, x, y, 100, 30);
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
                     
            // Iterate through the matches that were found and display each color that
            // Corresponds with the enum value in the array. also display the name of
            // The KnownColor.
            for (int i = 0; i < count; i++)
            {
                y += 40;
                someColor = Color.FromKnownColor(colorMatches[i]);
                myBrush1.Color = someColor;
                g.FillRectangle(myBrush1, x, y, 100, 30);
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
            }
        }
        // </snippet5>


        // Snippet for: M:System.Drawing.Color.GetBrightness
        // <snippet6>
        public void KnownColorBrightnessExample2(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Color structures. One is a variable used for temporary storage. The other
            // is a constant used for comparisons.
            Color   someColor = Color.FromArgb(0);
            Color   redShade = Color.FromArgb(255, 200, 0, 100);
                     
            // Array to store KnownColor values that match the brightness of the
            // redShade color.
            KnownColor[]  colorMatches = new KnownColor[15];
            
            // Number of matches found.
            int  count = 0;   
                                 
            // Iterate through the KnownColor enums until 15 matches are found.
            for (KnownColor enumValue = 0;
                enumValue <= KnownColor.YellowGreen && count < 15; enumValue++)
            {
                someColor = Color.FromKnownColor(enumValue);
                if (someColor.GetBrightness() == redShade.GetBrightness())
                    colorMatches[count++] = enumValue;
            }
                     
            // display the redShade color and its argb value.
            SolidBrush  myBrush1 = new SolidBrush(redShade);
            Font        myFont = new Font("Arial", 12);
            int         x = 20;
            int         y = 20;
            someColor = redShade;
            g.FillRectangle(myBrush1, x, y, 100, 30);
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
                     
            // Iterate through the matches that were found and display each color that
            // corresponds with the enum value in the array. also display the name of
            // The KnownColor.
            for (int i = 0; i < count; i++)
            {
                y += 40;
                someColor = Color.FromKnownColor(colorMatches[i]);
                myBrush1.Color = someColor;
                g.FillRectangle(myBrush1, x, y, 100, 30);
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
            }
        }
        // </snippet6>


        // Snippet for: M:System.Drawing.Color.GetHue
        // <snippet7>
        public void GetHueExample(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Color structures. One is a variable used for temporary storage. The other
            // is a constant used for comparisons.
            Color   someColor = Color.FromArgb(0);
            Color   redShade = Color.FromArgb(255, 200, 0, 100);
                     
            // Array to store KnownColor values that match the hue of the redShade
            // color.
            KnownColor[]  colorMatches = new KnownColor[15];

            // Number of matches found.
            int  count = 0;   
            
            // Iterate through the KnownColor enums until 15 matches are found.
            for (KnownColor enumValue = 0;
                enumValue <= KnownColor.YellowGreen && count < 15; enumValue++)
            {
                someColor = Color.FromKnownColor(enumValue);
                if (someColor.GetHue() == redShade.GetHue())
                    colorMatches[count++] = enumValue;
            }
                     
            // Display the redShade color and its argb value.
            SolidBrush  myBrush1 = new SolidBrush(redShade);
            Font        myFont = new Font("Arial", 12);
            int         x = 20;
            int         y = 20;
            someColor = redShade;
            g.FillRectangle(myBrush1, x, y, 100, 30);
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
                     
            // Iterate through the matches that were found and display each color that
            // corresponds with the enum value in the array. also display the name of
            // the KnownColor.
            for (int i = 0; i < count; i++)
            {
                y += 40;
                someColor = Color.FromKnownColor(colorMatches[i]);
                myBrush1.Color = someColor;
                g.FillRectangle(myBrush1, x, y, 100, 30);
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
            }
        }
        // </snippet7>


        // Snippet for: M:System.Drawing.Color.GetSaturation
        // <snippet8>
        public void GetSatExample(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Color structures. One is a variable used for temporary storage. The other
            // is a constant used for comparisons.
            Color   someColor = Color.FromArgb(0);
            Color   redShade = Color.FromArgb(255, 200, 0, 100);
                     
            // Array to store KnownColor values that match the saturation of the
            // redShade color.
            KnownColor[]  colorMatches = new KnownColor[15];
             
            // Number of matches found.
            int  count = 0;   
           
            // Iterate through the KnownColor enums until 15 matches are found.
            for (KnownColor enumValue = 0;
                enumValue <= KnownColor.YellowGreen && count < 15; enumValue++)
            {
                someColor = Color.FromKnownColor(enumValue);
                if (someColor.GetSaturation() == redShade.GetSaturation())
                    colorMatches[count++] = enumValue;
            }
                     
            // Display the redShade color and its argb value.
            SolidBrush  myBrush1 = new SolidBrush(redShade);
            Font        myFont = new Font("Arial", 12);
            int         x = 20;
            int         y = 20;
            someColor = redShade;
            g.FillRectangle(myBrush1, x, y, 100, 30);
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
                     
            // Iterate through the matches that were found and display each color that
            // corresponds with the enum value in the array. also display the name of
            // the KnownColor.
            for (int i = 0; i < count; i++)
            {
                y += 40;
                someColor = Color.FromKnownColor(colorMatches[i]);
                myBrush1.Color = someColor;
                g.FillRectangle(myBrush1, x, y, 100, 30);
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 120, y);
            }
        }
        // </snippet8>


        // Snippet for: M:System.Drawing.Color.ToArgb
        // <snippet9>
        public void ToArgbToStringExample1(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Color structure used for temporary storage.
            Color   someColor = Color.FromArgb(0);
                     
            // Array to store KnownColor values that match the criteria.
            KnownColor[]  colorMatches = new KnownColor[167];
            
            // Number of matches found.
            int  count = 0; 
  
            // Iterate through the KnownColor enums to find all corresponding colors
            // that have a nonzero green component and zero-value red component and
            // that are not system colors.
            for (KnownColor enumValue = 0;
                enumValue <= KnownColor.YellowGreen; enumValue++)
            {
                someColor = Color.FromKnownColor(enumValue);
                if (someColor.G != 0 && someColor.R == 0 && !someColor.IsSystemColor)
                    colorMatches[count++] = enumValue;
            }
            SolidBrush  myBrush1 = new SolidBrush(someColor);
            Font        myFont = new Font("Arial", 9);
            int         x = 40;
            int         y = 40;
                     
            // Iterate through the matches that were found and display each color that
            // corresponds with the enum value in the array. also display the name of
            // the KnownColor and the ARGB components.
            for (int i = 0; i < count; i++)
            {
                     
                // Display the color.
                someColor = Color.FromKnownColor(colorMatches[i]);
                myBrush1.Color = someColor;
                g.FillRectangle(myBrush1, x, y, 50, 30);
                     
                // Display KnownColor name and the four component values. To display the
                // component values:  Use the ToArgb method to get the 32-bit ARGB value
                // of someColor, which was created from a KnownColor. Then create a
                // Color structure from the 32-bit ARGB value and set someColor equal to
                // this new Color structure. Then use the ToString method to convert it to
                // a string.
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 55, y);
                someColor = Color.FromArgb(someColor.ToArgb());
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 55, y + 15);
                y += 40;
            }
        }
        // </snippet9>


        // Snippet for: M:System.Drawing.Color.ToString
        // <snippet10>
        public void ToArgbToStringExample2(PaintEventArgs e)
        {
            Graphics     g = e.Graphics;
                     
            // Color structure used for temporary storage.
            Color   someColor = Color.FromArgb(0);
                     
            // Array to store KnownColor values that match the criteria.
            KnownColor[]  colorMatches = new KnownColor[167];
            
            // Number of matches found.
            int  count = 0;   
                     
            // Iterate through the KnownColor enums to find all corresponding colors
            // that have a nonzero green component and zero-value red component and
            // that are not system colors.
            for (KnownColor enumValue = 0;
                enumValue <= KnownColor.YellowGreen; enumValue++)
            {
                someColor = Color.FromKnownColor(enumValue);
                if (someColor.G != 0 && someColor.R == 0 && !someColor.IsSystemColor)
                    colorMatches[count++] = enumValue;
            }
            SolidBrush  myBrush1 = new SolidBrush(someColor);
            Font        myFont = new Font("Arial", 9);
            int         x = 40;
            int         y = 40;
                     
            // Iterate through the matches that were found and display each color that
            // corresponds with the enum value in the array. also display the name of
            // the KnownColor and the ARGB components.
            for (int i = 0; i < count; i++)
            {
                // Display the color.
                someColor = Color.FromKnownColor(colorMatches[i]);
                myBrush1.Color = someColor;
                g.FillRectangle(myBrush1, x, y, 50, 30);
                     
                // Display KnownColor name and the four component values. To display the
                // component values:  Use the ToArgb method to get the 32-bit ARGB value
                // of someColor, which was created from a KnownColor. Then create a
                // Color structure from the 32-bit ARGB value and set someColor equal to
                // this new Color structure. Then use the ToString method to convert it to
                // a string.
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 55, y);
                someColor = Color.FromArgb(someColor.ToArgb());
                g.DrawString(someColor.ToString(), myFont, Brushes.Black, x + 55, y + 15);
                y += 40;
            }
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
