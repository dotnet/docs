using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DocRefreshSnippets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           // InitializeComponent();
            CharacterRangeInequality();
            this.Paint += new PaintEventHandler(Form1_Paint);
          
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            //DrawImageUnscaled(e);
            //OffsetPoint(e);
            //SubtractSizes(e);
            DrawWithAppWorkspacePen(e);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        //<snippet1>
        private void CharacterRangeEquality1()
        {

            // Declare the string to draw.
            string message = "Strings or strings; that is the question.";

            // Compare the ranges for equality. The should not be equal.
            CharacterRange range1 = 
                new CharacterRange(message.IndexOf("Strings"), "Strings".Length);
            CharacterRange range2 = 
                new CharacterRange(message.IndexOf("strings"), "strings".Length);

            if (range1 == range2)
                MessageBox.Show("The ranges are equal.");
            else
                MessageBox.Show("The ranges are not equal.");
    
        }
        //</snippet1>

        //<snippet2>
        private void CharacterRangeEquality2()
        {

            // Declare the string to draw.
            string message = "Strings or strings; that is the question.";

            // Compare the ranges for equality. The should not be equal.
            CharacterRange range1 =
                new CharacterRange(message.IndexOf("Strings"), "Strings".Length);
            CharacterRange range2 =
                new CharacterRange(message.IndexOf("strings"), "strings".Length);

            if (range1.Equals(range2))
                MessageBox.Show("The ranges are equal.");
            else
                MessageBox.Show("The ranges are not equal.");

        }
        //</snippet2>

        //<snippet3>
        private void CharacterRangeInequality()
        {

            // Declare the string to draw.
            string message = "Strings or strings; that is the question.";

            // Compare the ranges for equality. The should not be equal.
            CharacterRange range1 =
                new CharacterRange(message.IndexOf("Strings"), "Strings".Length);
            CharacterRange range2 =
                new CharacterRange(message.IndexOf("string"), "strings".Length);

            if (range1 != range2)
                MessageBox.Show("The ranges are not equal.");
            else
                MessageBox.Show("The ranges are equal.");
        }
        //</snippet3>

        //<snippet4>
        private void CopyPixels1(PaintEventArgs e)
        {
            e.Graphics.CopyFromScreen(this.Location, 
                new Point(40, 40), new Size(100, 100));
        }
        //</snippet4>

        //<snippet5>
        private void CopyPixels2(PaintEventArgs e)
        {
            e.Graphics.CopyFromScreen(this.Location, new Point(40, 40), 
                new Size(100, 100), CopyPixelOperation.MergePaint); 
        }
        //</snippet5>
        //<snippet6>
        private void CopyPixels3(PaintEventArgs e)
        {
            e.Graphics.CopyFromScreen(0, 0, 20, 20, new Size(160, 160));
        }
        //</snippet6>

        //<snippet7>
        private void CopyPixels4(PaintEventArgs e)
        {
            e.Graphics.CopyFromScreen(0, 0, 20, 20, new Size(160, 160), 
                CopyPixelOperation.SourceInvert);
        }
        //</snippet7>


        //<snippet8>
        private void DrawImageUnscaled(PaintEventArgs e)
        {
            string filepath = @"C:\Documents and Settings\All Users\Documents\" + 
                @"My Pictures\Sample Pictures\Water Lilies.jpg";
            Bitmap bitmap1 = new Bitmap(filepath);
            e.Graphics.DrawImageUnscaledAndClipped(bitmap1, new Rectangle(10,10,250,250));
        }
        //</snippet8>

        //<snippet9>
        private void AddPoint(PaintEventArgs e)
        {
            Point point1 = new Point(10, 10);
            Point point2 = Point.Add(point1, new Size(250,0));
            e.Graphics.DrawLine(Pens.Red, point1, point2);
        }
        //</snippet9>

        //<snippet10>
        private void OffsetPoint(PaintEventArgs e)
        {
            Point point1 = new Point(10, 10);
            point1.Offset(50, 0);
            Point point2 = new Point(250, 10);
            e.Graphics.DrawLine(Pens.Red, point1, point2);
        }
        //</snippet10>

        //<snippet11>
        private void AddSizes(PaintEventArgs e)
        {
            Size size1 = new Size(100, 100);
            Size size2 = new Size(50,50);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(10,10), size1));
            size1 = Size.Add(size1, size2);
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(new Point(10, 10), size1));
        }
        //</snippet11>

        //<snippet12>
        private void SubtractSizes(PaintEventArgs e)
        {
            Size size1 = new Size(100, 100);
            Size size2 = new Size(50, 50);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(new Point(10, 10), size1));
            size1 = Size.Subtract(size1, size2);
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(new Point(10, 10), size1));
        }
        //</snippet12>

        //<snippet13>
        private void DrawWithActiveBorderPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ActiveBorder, rectangle1);
        }
        //</snippet13>

        //<snippet14>
        private void DrawWithActiveCaptionPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ActiveCaption, rectangle1);
        }
        //</snippet14>

        //<snippet15>
        private void DrawWithAppWorkspacePen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.AppWorkspace, rectangle1);
        }
        //</snippet15>

        //<snippet16>
        private void DrawWithButtonFacePen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ButtonFace, rectangle1);
        }
        //</snippet16>

        //<snippet17>
        private void DrawWithButtonHighlightPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ButtonHighlight, rectangle1);
        }
        //</snippet17>

        //<snippet18>
        private void DrawWithButtonShadowPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ButtonShadow, rectangle1);
        }
        //</snippet18>

        //<snippet19>
        private void DrawWithControlPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.Control, rectangle1);
        }
        //</snippet19>

        //<snippet20>
        private void DrawWithControlDarkPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ControlDark, rectangle1);
        }
        //</snippet20>

        //<snippet21>
        private void DrawWithControlDarkDarkPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, rectangle1);
        }
        //</snippet21>

        //<snippet22>
        private void DrawWithControlLightPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ControlLight, rectangle1);
        }
        //</snippet22>

        //<snippet23>
        private void DrawWithControlLightLightPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ControlLightLight, rectangle1);
        }
        //</snippet23>

        //<snippet24>
        private void DrawWithControlTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ControlText, rectangle1);
        }
        //</snippet24>

        //<snippet25>
        private void DrawWithControlDesktopPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.Desktop, rectangle1);
        }
        //</snippet25>

        //<snippet26>
        private void DrawWithGradientActiveCaptionPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.GradientActiveCaption, rectangle1);
        }
        //</snippet26>

        //<snippet27>
        private void DrawWithGradientInactiveCaptionPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, rectangle1);
        }
        //</snippet27>

        //<snippet28>
        private void DrawWithGrayTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.GrayText, rectangle1);
        }
        //</snippet28>
        //<snippet29>
        private void DrawWithHighlightPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.Highlight, rectangle1);
        }
        //</snippet29>
        //<snippet30>
        private void DrawWithHighlightTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.HighlightText, rectangle1);
        }
        //</snippet30>
        //<snippet31>
        private void DrawWithHotTrackPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.HotTrack, rectangle1);
        }
        //</snippet31>
        //<snippet32>
        private void DrawWithInactiveBorderPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.InactiveBorder, rectangle1);
        }
        //</snippet32>
        //<snippet33>
        private void DrawWithInactiveCaptionPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.InactiveCaption, rectangle1);
        }
        //</snippet33>
        //<snippet34>
        private void DrawWithInactiveCaptionTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.InactiveCaptionText, rectangle1);
        }
        //</snippet34>
        //<snippet35>
        private void DrawWithInfoPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.Info, rectangle1);
        }
        //</snippet35>

        //<snippet36>
        private void DrawWithInfoTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.InfoText, rectangle1);
        }
        //</snippet36>

        //<snippet37>
        private void DrawWithMenuPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.Menu, rectangle1);
        }
        //</snippet37>

        //<snippet38>
        private void DrawWithMenuBarPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.MenuBar, rectangle1);
        }
        //</snippet38>

        //<snippet39>
        private void DrawWithMenuHighlightPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.MenuHighlight, rectangle1);
        }
        //</snippet39>

        //<snippet40>
        private void DrawWithMenuTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.MenuText, rectangle1);
        }
        //</snippet40>
        //<snippet41>
        private void DrawWithScrollBarPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.ScrollBar, rectangle1);
        }
        //</snippet41>

        //<snippet42>
        private void DrawWithWindowPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.Window, rectangle1);
        }
        //</snippet42>

        //<snippet44>
        private void DrawWithWindowFramePen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.WindowFrame, rectangle1);
        }
        //</snippet44>

        //<snippet45>
        private void DrawWithWindowTextPen(PaintEventArgs e)
        {
            Rectangle rectangle1 = new Rectangle(10, 10, 100, 100);
            e.Graphics.DrawRectangle(SystemPens.WindowText, rectangle1);
        }
        //</snippet45>

    }


}