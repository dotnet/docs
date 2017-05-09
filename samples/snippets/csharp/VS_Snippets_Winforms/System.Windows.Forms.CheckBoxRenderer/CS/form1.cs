// This sample can go in CheckBoxRenderer class overview. 
// - Snippet2 can go in GetGlyphSize
// - Snippet4 can go in DrawCheckBox
// - Snippet4 can also go in the VisualStyles.CheckBoxState enum, if necessary.

// The sample defines a simple custom Control that uses CheckBoxRenderer to
// simulate a CheckBox control. 

// Might want to think of a better, more realistic/solution-oriented example. 


//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace CheckBoxRendererSample
{
    class Form1 : Form
    {
        public Form1()
            : base()
        {
            CustomCheckBox CheckBox1 = new CustomCheckBox();
            Controls.Add(CheckBox1);

            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }

        [STAThread]
        static void Main()
        {
            // If you do not call EnableVisualStyles below, then 
            // CheckBoxRenderer.DrawCheckBox automatically detects 
            // this and draws the check box without visual styles.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class CustomCheckBox : Control
    {
        private Rectangle textRectangleValue = new Rectangle();
        private Point clickedLocationValue = new Point();
        private bool clicked = false;
        private CheckBoxState state = CheckBoxState.UncheckedNormal;

        public CustomCheckBox()
            : base()
        {
            this.Location = new Point(50, 50);
            this.Size = new Size(100, 20);
            this.Text = "Click here";
            this.Font = SystemFonts.IconTitleFont;
        }

        //<Snippet2>
        // Calculate the text bounds, exluding the check box.
        public Rectangle TextRectangle
        {
            get
            {
                using (Graphics g = this.CreateGraphics())
                {
                    textRectangleValue.X = ClientRectangle.X +
                        CheckBoxRenderer.GetGlyphSize(g,
                        CheckBoxState.UncheckedNormal).Width;
                    textRectangleValue.Y = ClientRectangle.Y;
                    textRectangleValue.Width = ClientRectangle.Width -
                        CheckBoxRenderer.GetGlyphSize(g,
                        CheckBoxState.UncheckedNormal).Width;
                    textRectangleValue.Height = ClientRectangle.Height;
                }

                return textRectangleValue;
            }
        }
        //</Snippet2>

        //<Snippet4>
        // Draw the check box in the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            CheckBoxRenderer.DrawCheckBox(e.Graphics,
                ClientRectangle.Location, TextRectangle, this.Text,
                this.Font, TextFormatFlags.HorizontalCenter,
                clicked, state);
        }

        // Draw the check box in the checked or unchecked state, alternately.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!clicked)
            {
                clicked = true;
                this.Text = "Clicked!";
                state = CheckBoxState.CheckedPressed;
                Invalidate();
            }
            else
            {
                clicked = false;
                this.Text = "Click here";
                state = CheckBoxState.UncheckedNormal;
                Invalidate();
            }
        }
        //</Snippet4>

        // Draw the check box in the hot state. 
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            state = clicked ? CheckBoxState.CheckedHot :
                CheckBoxState.UncheckedHot;
            Invalidate();
        }

        // Draw the check box in the hot state. 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.OnMouseHover(e);
        }

        // Draw the check box in the unpressed state.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            state = clicked ? CheckBoxState.CheckedNormal :
                CheckBoxState.UncheckedNormal;
            Invalidate();
        }
    }
}
//</Snippet0>