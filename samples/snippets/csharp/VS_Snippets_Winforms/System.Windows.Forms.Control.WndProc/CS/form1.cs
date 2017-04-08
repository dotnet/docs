//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace csTempWindowsApplication1
{
    public class Form1 : System.Windows.Forms.Form
    {
        // Constant value was found in the "windows.h" header file.
        private const int WM_ACTIVATEAPP = 0x001C;
        private bool appActive = true;

        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }
        
        public Form1()
        {
            this.Size = new System.Drawing.Size(300,300);
            this.Text = "Form1";
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
        }

        protected override void OnPaint(PaintEventArgs e) 
        {
            // Paint a string in different styles depending on whether the
            // application is active.
            if (appActive) 
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption,20,20,260,50);
                e.Graphics.DrawString("Application is active", this.Font, SystemBrushes.ActiveCaptionText, 20,20);
            }
            else 
            {
                e.Graphics.FillRectangle(SystemBrushes.InactiveCaption,20,20,260,50);
                e.Graphics.DrawString("Application is Inactive", this.Font, SystemBrushes.ActiveCaptionText, 20,20);
            }
        }

	[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
        protected override void WndProc(ref Message m) 
        {
            // Listen for operating system messages.
            switch (m.Msg)
            {
                // The WM_ACTIVATEAPP message occurs when the application
                // becomes the active application or becomes inactive.
                case WM_ACTIVATEAPP:

                    // The WParam value identifies what is occurring.
                    appActive = (((int)m.WParam != 0));

                    // Invalidate to get new text painted.
                    this.Invalidate();

                    break;                
            }
            base.WndProc(ref m);
        }
    }
}
//</Snippet1>
