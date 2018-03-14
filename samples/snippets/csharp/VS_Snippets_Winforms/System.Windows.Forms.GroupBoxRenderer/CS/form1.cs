// This sample can go in GroupBoxRenderer class overview.
// - Snippet2 can go in DrawGroupBox

// This is a custom GroupBox-like control that has a double border
// and uses an internal FlowLayoutPanel to contain added controls.

// TODO: see if you can work DrawParentBackground into here somehow.


//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GroupBoxRendererSample
{
    class Form1 : Form
    {
        private Button button1;
    
        public Form1()
            : base()
        {
            CustomGroupBox GroupBox1 = new CustomGroupBox();
            button1 = new Button();
             
            GroupBox1.Text = "Radio Button Display";
            this.button1.Location = new System.Drawing.Point(205, 231);
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.Text = "Toggle Visual Styles";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            Controls.Add(GroupBox1);
            this.Controls.Add(this.button1);

            // Add some radio buttons to test the CustomGroupBox.
            int count = 8;
            RadioButton[] ButtonArray = new RadioButton[count];
            for (int i = 0; i < count; i++)
            {
                ButtonArray[i] = new RadioButton();
                ButtonArray[i].Text = "Button " + (i + 1).ToString();
                GroupBox1.Controls.Add(ButtonArray[i]);
            }

            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }

        [STAThread]
        static void Main()
        {
            // If you do not call EnableVisualStyles below, then 
            // GroupBoxRenderer automatically detects this and draws
            // the group box without visual styles.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        //<snippet3>

	// Match application style and toggle visual styles off
	// and on for the application.
        private void button1_Click(object sender, EventArgs e)
        {
            GroupBoxRenderer.RenderMatchingApplicationState = true;
            Application.VisualStyleState = 
                Application.VisualStyleState ^ 
                VisualStyleState.ClientAndNonClientAreasEnabled;

          
            if (Application.RenderWithVisualStyles)
                this.Text = "Visual Styles Enabled";
            else
                this.Text = "Visual Styles Disabled";
        }
        //</snippet3>
    }

    public class CustomGroupBox : Control
    {
        private Rectangle innerRectangle = new Rectangle();
        private GroupBoxState state = GroupBoxState.Normal;
        private FlowLayoutPanel panel = new FlowLayoutPanel();

        public CustomGroupBox()
            : base()
        {
            this.Size = new Size(200, 200);
            this.Location = new Point(10, 10);
            this.Controls.Add(panel);
            this.Text = "CustomGroupBox";
            this.Font = SystemFonts.IconTitleFont;

            innerRectangle.X = ClientRectangle.X + 5;
            innerRectangle.Y = ClientRectangle.Y + 15;
            innerRectangle.Width = ClientRectangle.Width - 10;
            innerRectangle.Height = ClientRectangle.Height - 20;

            panel.FlowDirection = FlowDirection.TopDown;
            panel.Location = new Point(innerRectangle.X + 5,
                innerRectangle.Y + 5);
            panel.Size = new Size(innerRectangle.Width - 10,
                innerRectangle.Height - 10);
        }

        //<Snippet2>
        // Draw the group box in the current state.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GroupBoxRenderer.DrawGroupBox(e.Graphics, ClientRectangle,
                this.Text, this.Font, state);

            // Draw an additional inner border if visual styles are enabled.
            if (Application.RenderWithVisualStyles)
            {
                GroupBoxRenderer.DrawGroupBox(e.Graphics, innerRectangle, state);
            }
        }
        //</Snippet2>

        // Pass added controls to the internal FlowLayoutPanel.
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            // Ensure that you do not add the panel itself.
            if (e.Control != this.panel)
            {
                this.Controls.Remove(e.Control);
                panel.Controls.Add(e.Control);
            }
        }
    }
}
//</Snippet0>
