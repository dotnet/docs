
//<Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SimpleControlRenderingSample
{
    class Form1 : Form
    {
        public Form1()
            : base()
        {
            this.Size = new Size(300, 300);
            CustomComboBoxArrow ComboBox1 = new CustomComboBoxArrow();
            Controls.Add(ComboBox1);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class CustomComboBoxArrow : Control
    {
        public CustomComboBoxArrow()
            : base()
        {
            this.Location = new Point(50, 50);
            this.Size = new Size(40, 40);
        }

        //<Snippet10>
        // Render the drop-down arrow with or without visual styles.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!ComboBoxRenderer.IsSupported)
            {
                ControlPaint.DrawComboButton(e.Graphics,
                    this.ClientRectangle, ButtonState.Normal);
            }
            else
            {
                ComboBoxRenderer.DrawDropDownButton(e.Graphics,
                    this.ClientRectangle, ComboBoxState.Normal);
            }
        }
        //</Snippet10>
    }
}
//</Snippet0>