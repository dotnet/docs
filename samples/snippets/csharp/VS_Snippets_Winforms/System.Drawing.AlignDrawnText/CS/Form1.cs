using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AlignText
{
    public class Form1 : Form
    {
        public Form1()
        {
            this.Paint +=new PaintEventHandler(Form1_Paint);
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private void AlignTextWithTextRenderer(PaintEventArgs e)
        {
            //<snippet20>
            string text2 = "Use TextFormatFlags and Rectangle objects to"
             + " center text in a rectangle.";

            using (Font font2 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                Rectangle rect2 = new Rectangle(150, 10, 130, 140);

                // Create a TextFormatFlags with word wrapping, horizontal center and
                // vertical center specified.
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

                // Draw the text and the surrounding rectangle.
                TextRenderer.DrawText(e.Graphics, text2, font2, rect2, Color.Blue, flags);
                e.Graphics.DrawRectangle(Pens.Black, rect2);
            }
            //</snippet20>
        }



        private void AlignTextWithDrawString(PaintEventArgs e)
        {
            //<snippet10>
            string text1 = "Use StringFormat and Rectangle objects to" 
                + " center text in a rectangle.";
            using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                Rectangle rect1 = new Rectangle(10, 10, 130, 140);

                // Create a StringFormat object with the each line of text, and the block
                // of text centered on the page.
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                // Draw the text and the surrounding rectangle.
                e.Graphics.DrawString(text1, font1, Brushes.Blue, rect1, stringFormat);
                e.Graphics.DrawRectangle(Pens.Black, rect1);
            }
            //</snippet10>
        }
        private void DrawTextAtLocation1(PaintEventArgs e)
        {
            //<snippet30>
            using (Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel)){
            PointF pointF1 = new PointF(30, 10);
            e.Graphics.DrawString("Hello", font1, Brushes.Blue, pointF1);
            }
            //</snippet30>
        }
        
        private void DrawTextAtLocation2(PaintEventArgs e)
        {
            //<snippet40>
            using (Font font = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                Point point1 = new Point(30, 10);
                TextRenderer.DrawText(e.Graphics, "Hello", font, point1, Color.Blue);
            }
            //</snippet40>
        }

        private void DrawTextInARectangle1(PaintEventArgs e)
        {
            //<snippet50>
            string text1 = "Draw text in a rectangle by passing a RectF to the DrawString method.";
            using (Font font1 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(30, 10, 100, 122);
                e.Graphics.DrawString(text1, font1, Brushes.Blue, rectF1);
                e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));
            }
            //</snippet50>
        }

        private void DrawTextInARectangle2(PaintEventArgs e)
        {
            //<snippet60>
            string text2 = "Draw text in a rectangle by passing a RectF to the DrawString method.";
            using (Font font2 = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point))
            {
                Rectangle rect2 = new Rectangle(30, 10, 100, 122);

                // Specify the text is wrapped.
                TextFormatFlags flags = TextFormatFlags.WordBreak;
                TextRenderer.DrawText(e.Graphics, text2, font2, rect2, Color.Blue, flags);
                e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rect2));

            }
            //</snippet60>
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //AlignTextWithDrawString(e);
            //AlignTextWithTextRenderer(e);
            //DrawTextAtLocation1(e);
            //DrawTextAtLocation2(e);
            DrawTextInARectangle1(e);
        }
    }
}