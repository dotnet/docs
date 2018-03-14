using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TextRendering
{
    public class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        //<snippet1>
        private void MeasureText1(PaintEventArgs e)
        {
            String text1 = "Measure this text";
            Font arialBold = new Font("Arial", 12.0F);
            Size textSize = TextRenderer.MeasureText(text1, arialBold);
            TextRenderer.DrawText(e.Graphics, text1, arialBold, 
                new Rectangle(new Point(10, 10), textSize), Color.Red);  
        }
        //</snippet1>
        //<snippet10>
        private void MeasureText2(PaintEventArgs e)
        {
            String text1 = "How big is this text?";
            Font arialBold = new Font("Arial", 12.0F);
            
            // Indicate a size taller than it is wide.
            Size proposedSize = new Size(40, 60);

            Size textSize = TextRenderer.MeasureText(text1, arialBold, proposedSize, TextFormatFlags.WordBreak);
            TextRenderer.DrawText(e.Graphics, text1, arialBold,
                new Rectangle(new Point(10, 10), textSize), Color.Red, TextFormatFlags.WordBreak);
        }
        //</snippet10>
        //<snippet2>
        private void RenderText1(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text", this.Font, 
                new Point(10, 10), SystemColors.ControlText);

        }
        //</snippet2>
        //<snippet3>
        private void RenderText2(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text", this.Font,
                new Rectangle(10, 10, 100, 100), SystemColors.ControlText);

        }
        //</snippet3>
        //<snippet4>
        private void RenderText3(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text", this.Font,
                new Point(10, 10), Color.Red, Color.PowderBlue);
        }
        //</snippet4>
        //<snippet5>
        private void RenderText4(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Regular Text.", this.Font,
                new Rectangle(10, 10, 70, 70), SystemColors.ControlText, 
                SystemColors.ControlDark);
        }
        //</snippet5>
        //<snippet6>
        private void RenderText5(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "Some text.",
                this.Font, new Point(10, 10), SystemColors.ControlText, TextFormatFlags.Bottom);
        }
        //</snippet6>
        //<snippet7>
        private void RenderText6(PaintEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Bottom | TextFormatFlags.EndEllipsis;
            TextRenderer.DrawText(e.Graphics, "This is some text that will be clipped at the end.", this.Font,
                new Rectangle(10, 10, 100, 50), SystemColors.ControlText, flags);
        }
        //</snippet7>
        //<snippet8>
        private void RenderText7(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, "This is some text.", this.Font,
                new Point(10, 10), Color.White, Color.SteelBlue, TextFormatFlags.Default);
        }
        //</snippet8>
        //<snippet9>
        private void RenderText8(PaintEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Bottom | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(e.Graphics, "This is some text that will display on multiple lines.", this.Font,
                new Rectangle(10, 10, 100, 50), SystemColors.ControlText, SystemColors.ControlDark, flags);
        }

        //</snippet9>

   //<snippet11>
        private static void DrawALineOfText(PaintEventArgs e)
        {
            // Declare strings to render on the form.
            string[] stringsToPaint = { "Tail", "Spin", " Toys" };

            // Declare fonts for rendering the strings.
            Font[] fonts = { new Font("Arial", 14, FontStyle.Regular), 
                new Font("Arial", 14, FontStyle.Italic), 
                new Font("Arial", 14, FontStyle.Regular) };

            Point startPoint = new Point(10, 10);

            // Set TextFormatFlags to no padding so strings are drawn together.
            TextFormatFlags flags = TextFormatFlags.NoPadding;

            // Declare a proposed size with dimensions set to the maximum integer value.
            Size proposedSize = new Size(int.MaxValue, int.MaxValue);

            // Measure each string with its font and NoPadding value and 
            // draw it to the form.
            for (int i = 0; i < stringsToPaint.Length; i++)
            {
                Size size = TextRenderer.MeasureText(e.Graphics, stringsToPaint[i], 
                    fonts[i], proposedSize, flags);
                Rectangle rect = new Rectangle(startPoint, size);
                TextRenderer.DrawText(e.Graphics, stringsToPaint[i], fonts[i],
                    startPoint, Color.Black, flags);
                startPoint.X += size.Width;
            }
            
        }
	//</snippet11>
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MeasureText2(e);
        }

             
        
       
        
    }
}