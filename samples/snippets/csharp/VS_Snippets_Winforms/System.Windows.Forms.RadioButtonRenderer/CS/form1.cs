// This sample can go in RadioButtonRenderer class overview
// - Snippet2 can go in GetGlyphSize
// - Snippet4 can go in DrawRadioButton.
// - Snippet4 can also go in RadioButtonState enum, if necessary.
//   Snippet3 is for RenderMatchingApplicationState

// This sample mimics the RadioButton control. Might want to come up with a better
// customization sample that actually does something different from the RadioButton.


//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RadioButtonRendererSample
{
    class Form1 : Form
    {
        Button button1 = new Button();
        public Form1()
            : base()
        {
            CustomRadioButton RadioButton1 = new CustomRadioButton();
          
            button1.Location = new System.Drawing.Point(175, 231);
            button1.Size = new System.Drawing.Size(105, 23);
            button1.Text = "Toggle Style";
            button1.Click += new System.EventHandler(this.button1_Click);
            Controls.Add(RadioButton1);
            Controls.Add(button1);

            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }

        [STAThread]
        static void Main()
        {
            // If you do not call EnableVisualStyles below, then 
            // RadioButtonRenderer.DrawRadioButton automatically detects 
            // this and draws the radio button without visual styles.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        //<snippet3>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.VisualStyleState =
                Application.VisualStyleState ^
                VisualStyleState.ClientAndNonClientAreasEnabled;

            GroupBoxRenderer.RenderMatchingApplicationState = true;
            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }
        //</snippet3>
    }

    public class CustomRadioButton : Control
    {
        private Rectangle textRectangleValue = new Rectangle();
        private bool clicked = false;
        private RadioButtonState state = RadioButtonState.UncheckedNormal;

        public CustomRadioButton()
            : base()
        {
            this.Location = new Point(50, 50);
            this.Size = new Size(100, 20);
            this.Text = "Click here";
            this.Font = SystemFonts.IconTitleFont;
        }

        //<Snippet2>
        // Define the text bounds so that the text rectangle 
        // does not include the radio button.
        public Rectangle TextRectangle
        {
            get
            {
                using (Graphics g = this.CreateGraphics())
                {
                    textRectangleValue.X = ClientRectangle.X +
                        RadioButtonRenderer.GetGlyphSize(g,
                        RadioButtonState.UncheckedNormal).Width;
                    textRectangleValue.Y = ClientRectangle.Y;
                    textRectangleValue.Width = ClientRectangle.Width -
                        RadioButtonRenderer.GetGlyphSize(g,
                        RadioButtonState.UncheckedNormal).Width;
                    textRectangleValue.Height = ClientRectangle.Height;
                }

                return textRectangleValue;
            }
        }
        //</Snippet2>

        //<Snippet4>
        // Draw the radio button in the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RadioButtonRenderer.DrawRadioButton(e.Graphics,
                ClientRectangle.Location, TextRectangle, this.Text,
                this.Font, clicked, state);
        }

        // Draw the radio button in the checked or unchecked state.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!clicked)
            {
                clicked = true;
                this.Text = "Clicked!";
                state = RadioButtonState.CheckedPressed;
                Invalidate();
            }
            else
            {
                clicked = false;
                this.Text = "Click here";
                state = RadioButtonState.UncheckedNormal;
                Invalidate();
            }
        }
        //</Snippet4>

        // Draw the radio button in the hot state.
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            state = clicked ? RadioButtonState.CheckedHot :
                RadioButtonState.UncheckedHot;
            Invalidate();
        }

        // Draw the radio button in the hot state.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.OnMouseHover(e);
        }

        // Draw the radio button in the unpressed state.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            state = clicked ? RadioButtonState.CheckedNormal :
                RadioButtonState.UncheckedNormal;
            Invalidate();
        }
    }
}
//</Snippet0>


