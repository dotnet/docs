//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ToolTipExample
{
    // Form for the ToolTip example.
    public class ToolTipExampleForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

        public ToolTipExampleForm()
        {
            // Create the ToolTip and set initial values.
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.Draw += new DrawToolTipEventHandler(this.toolTip1_Draw);
            this.toolTip1.Popup += new PopupEventHandler(toolTip1_Popup);

            // Create button1 and set initial values.
            this.button1 = new System.Windows.Forms.Button();
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Text = "Button 1";
            this.toolTip1.SetToolTip(this.button1, "Button1 tip text");

            // Create button2 and set initial values.
            this.button2 = new System.Windows.Forms.Button();
            this.button2.Location = new System.Drawing.Point(8, 32);
            this.button2.Text = "Button 2";
            this.toolTip1.SetToolTip(this.button2, "Button2 tip text");

            // Create button3 and set initial values.
            this.button3 = new System.Windows.Forms.Button();
            this.button3.Location = new System.Drawing.Point(8, 56);
            this.button3.Text = "Button 3";
            this.toolTip1.SetToolTip(this.button3, "Button3 tip text");

            // Set up the Form.
            this.Controls.AddRange(new Control[] {
                this.button1, this.button2, this.button3
            });
            this.Text = "owner drawn ToolTip example";
        }

        // Clean up any resources being used.        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                toolTip1.Dispose();
            }

            base.Dispose(disposing);
        }

        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.Run(new ToolTipExampleForm());
        }

        // Determines the correct size for the button2 ToolTip.
        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl == button2)
            {
                using (Font f = new Font("Tahoma", 9))
                {
                    e.ToolTipSize = TextRenderer.MeasureText(
                        toolTip1.GetToolTip(e.AssociatedControl), f);
                }
            }
        }

        //<Snippet5>
        // Handles drawing the ToolTip.
        private void toolTip1_Draw(System.Object sender, 
            System.Windows.Forms.DrawToolTipEventArgs e)
        {
            // Draw the ToolTip differently depending on which 
            // control this ToolTip is for.
            //<Snippet2>
            // Draw a custom 3D border if the ToolTip is for button1.
            if (e.AssociatedControl == button1)
            {
                // Draw the standard background.
                e.DrawBackground();

                // Draw the custom border to appear 3-dimensional.
                e.Graphics.DrawLines(SystemPens.ControlLightLight, new Point[] {
                    new Point (0, e.Bounds.Height - 1), 
                    new Point (0, 0), 
                    new Point (e.Bounds.Width - 1, 0)
                });
                e.Graphics.DrawLines(SystemPens.ControlDarkDark, new Point[] {
                    new Point (0, e.Bounds.Height - 1), 
                    new Point (e.Bounds.Width - 1, e.Bounds.Height - 1), 
                    new Point (e.Bounds.Width - 1, 0)
                });

                // Specify custom text formatting flags.
                TextFormatFlags sf = TextFormatFlags.VerticalCenter |
                                     TextFormatFlags.HorizontalCenter |
                                     TextFormatFlags.NoFullWidthCharacterBreak;

                // Draw the standard text with customized formatting options.
                e.DrawText(sf);
            }
            //</Snippet2>
            //<Snippet3>
            // Draw a custom background and text if the ToolTip is for button2.
            else if (e.AssociatedControl == button2)
            {
                // Draw the custom background.
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);

                // Draw the standard border.
                e.DrawBorder();

                // Draw the custom text.
                // The using block will dispose the StringFormat automatically.
                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    sf.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
                    sf.FormatFlags = StringFormatFlags.NoWrap;
                    using (Font f = new Font("Tahoma", 9))
                    {
                        e.Graphics.DrawString(e.ToolTipText, f, 
                            SystemBrushes.ActiveCaptionText, e.Bounds, sf);
                    }
                }
            }
            //</Snippet3>
            //<Snippet4>
            // Draw the ToolTip using default values if the ToolTip is for button3.
            else if (e.AssociatedControl == button3)
            {
                e.DrawBackground();
                e.DrawBorder();
                e.DrawText();
            }
            //</Snippet4>
        }
        //</Snippet5>
    }
}
//</Snippet1>