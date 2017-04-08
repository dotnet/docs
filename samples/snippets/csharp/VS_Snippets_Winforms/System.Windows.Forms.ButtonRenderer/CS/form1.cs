// This entire sample can go in the ButtonRenderer overview. 
//  - Snippet2 can be excerpted in ButtonRenderer.DrawBackground overload
//    and specific ButtonRenderer.DrawBackground that it uses.
//  - Snippet4 can be linked to in ButtonRenderer.DrawParentBackground
//  - Snippet2 could be excerpted in the VisualStyles.PushButtonState enum,
//    if necessary.

// The sample defines a simple custom Control that uses ButtonRenderer to
// simulate a real Button control. When clicked, it draws a smaller button
// and uses DrawParentBackground to erase the remainder of the unpressed
// button.

// Issue: to show using DrawParentBackground, I'm currently setting the BackColor
// of the custom control to something other than the parent form. There might be
// a better way of demonstrating this that makes more sense from a usability standpoint...


//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ButtonRendererSample
{
    class Form1 : Form
    {
        public Form1()
            : base()
        {
            CustomButton Button1 = new CustomButton();
            Controls.Add(Button1);

            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }

        [STAThread]
        static void Main()
        {
            // If you do not call EnableVisualStyles below, then   
            // ButtonRenderer automatically detects this and draws
            // the button without visual styles.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class CustomButton : Control
    {
        private Rectangle clickRectangleValue = new Rectangle();
        private PushButtonState state = PushButtonState.Normal;

        public CustomButton()
            : base()
        {
            this.Size = new Size(100, 40);
            this.Location = new Point(50, 50);
            this.Font = SystemFonts.IconTitleFont;
            this.Text = "Click here";
        }

        // Define the bounds of the smaller pressed button.
        public Rectangle ClickRectangle
        {
            get
            {
                clickRectangleValue.X = ClientRectangle.X +
                    (int)(.2 * ClientRectangle.Width);
                clickRectangleValue.Y = ClientRectangle.Y +
                    (int)(.2 * ClientRectangle.Height);
                clickRectangleValue.Width = ClientRectangle.Width -
                    (int)(.4 * ClientRectangle.Width);
                clickRectangleValue.Height = ClientRectangle.Height -
                    (int)(.4 * ClientRectangle.Height);

                return clickRectangleValue;
            }
        }

        //<Snippet2>
        //<Snippet4>
        // Draw the large or small button, depending on the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the smaller pressed button image
            if (state == PushButtonState.Pressed)
            {
                // Set the background color to the parent if visual styles  
                // are disabled, because DrawParentBackground will only paint  
                // over the control background if visual styles are enabled.
                this.BackColor = Application.RenderWithVisualStyles ?
                    Color.Azure : this.Parent.BackColor;

                // If you comment out the call to DrawParentBackground, 
                // the background of the control will still be visible 
                // outside the pressed button, if visual styles are enabled.
                ButtonRenderer.DrawParentBackground(e.Graphics,
                    ClientRectangle, this);
                ButtonRenderer.DrawButton(e.Graphics, ClickRectangle,
                    this.Text, this.Font, true, state);
            }

            // Draw the bigger unpressed button image.
            else
            {
                ButtonRenderer.DrawButton(e.Graphics, ClientRectangle,
                    this.Text, this.Font, false, state);
            }
        }
        //</Snippet4>

        // Draw the smaller pressed button image.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.Text = "Clicked!";
            state = PushButtonState.Pressed;
            Invalidate();
        }

        // Draw the button in the hot state. 
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Text = "Click here";
            state = PushButtonState.Hot;
            Invalidate();
        }

        // Draw the button in the unpressed state.
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Text = "Click here";
            state = PushButtonState.Normal;
            Invalidate();
        }
        //</Snippet2>

        // Draw the button hot if the mouse is released on the button. 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            OnMouseEnter(e);
        }

        // Detect when the cursor leaves the button area while 
        // it is pressed.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // Detect when the left mouse button is down and   
            // the cursor has left the pressed button area. 
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left &&
                !ClientRectangle.Contains(e.Location) &&
                state == PushButtonState.Pressed)
            {
                OnMouseLeave(e);
            }
        }
    }
}
//</Snippet0>
