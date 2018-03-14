// This sample can go in TextBoxRenderer class overview.
// - Snippet2 can go in IsSupported and DrawTextBox
// - Snippet4 could go in TextFormatFlags

// This sample is a custom control that displays a static string and allows
// the user to select the TextFormatFlag to apply to the text.
// For simplicity, this sample does not handle run-time switching of visual styles.


//<Snippet0>
using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TextBoxRendererSample
{
    class Form1 : Form
    {
        public Form1()
            : base()
        {
            this.Size = new Size(350, 200);
            CustomTextBox TextBox1 = new CustomTextBox();
            Controls.Add(TextBox1);
        }

        [STAThread]
        static void Main()
        {
            // The call to EnableVisualStyles below does not affect whether 
            // TextBoxRenderer draws the text box; as long as visual styles 
            // are enabled by the operating system, TextBoxRenderer will 
            // draw the text box.
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class CustomTextBox : Control
    {
        private TextFormatFlags textFlags = TextFormatFlags.Default;
        ComboBox comboBox1 = new ComboBox();
        Rectangle textBorder = new Rectangle();
        Rectangle textRectangle = new Rectangle();
        StringBuilder textMeasurements = new StringBuilder();

        public CustomTextBox()
            : base()
        {
            this.Location = new Point(10, 10);
            this.Size = new Size(300, 200);
            this.Font = SystemFonts.IconTitleFont;
            this.Text = "This is a long sentence that will exceed " +
                "the text box bounds";

            textBorder.Location = new Point(10, 10);
            textBorder.Size = new Size(200, 50);
            textRectangle.Location = new Point(textBorder.X + 2,
                textBorder.Y + 2);
            textRectangle.Size = new Size(textBorder.Size.Width - 4,
                textBorder.Height - 4);

            comboBox1.Location = new Point(10, 100);
            comboBox1.Size = new Size(150, 20);
            comboBox1.SelectedIndexChanged +=
                new EventHandler(comboBox1_SelectedIndexChanged);

            // Populate the combo box with the TextFormatFlags value names.
            foreach (string name in Enum.GetNames(typeof(TextFormatFlags)))
            {
                comboBox1.Items.Add(name);
            }

            comboBox1.SelectedIndex = 0;
            this.Controls.Add(comboBox1);
        }

        //<Snippet2>
        //<Snippet4>
        // Use DrawText with the current TextFormatFlags.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (TextBoxRenderer.IsSupported)
            {
                TextBoxRenderer.DrawTextBox(e.Graphics, textBorder, this.Text,
                    this.Font, textRectangle, textFlags, TextBoxState.Normal);

                this.Parent.Text = "CustomTextBox Enabled";
            }
            else
            {
                this.Parent.Text = "CustomTextBox Disabled";
            }
        }
        //</Snippet2>

        // Assign the combo box selection to the display text.
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textFlags = (TextFormatFlags)Enum.Parse(
                typeof(TextFormatFlags),
                (string)comboBox1.Items[comboBox1.SelectedIndex]);
            Invalidate();
        }
        //</Snippet4>
    }
}
//</Snippet0>