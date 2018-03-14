using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SimpleVisualStyleRendererSample
{
    class Form1 : Form
    {
        public Form1()
        {
            this.Size = new Size(400, 400);
            this.BackColor = Color.WhiteSmoke;
            this.Controls.Add(new CustomControl());
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }

    public class CustomControl : Control
    {
        // <Snippet4>
        private VisualStyleRenderer renderer = null;
        private readonly VisualStyleElement element =
            VisualStyleElement.StartPanel.LogOffButtons.Normal;

        public CustomControl()
        {
            this.Location = new Point(50, 50);
            this.Size = new Size(200, 200);
            this.BackColor = SystemColors.ActiveBorder;

            if (Application.RenderWithVisualStyles &&
                VisualStyleRenderer.IsElementDefined(element))
            {
                renderer = new VisualStyleRenderer(element);
            }
        }
        // </Snippet4>

        // <Snippet6>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw the element if the renderer has been set.
            if (renderer != null)
            {
                renderer.DrawBackground(e.Graphics, this.ClientRectangle);
            }

            // Visual styles are disabled or the element is undefined, 
            // so just draw a message.
            else
            {
                this.Text = "Visual styles are disabled.";
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font,
                    new Point(0, 0), this.ForeColor);
            }
        }
        // </Snippet6>
    }
}