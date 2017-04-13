using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Automation.Provider;
using System.Security.Permissions;

namespace UIAIValueProvider_snip
{
    public partial class CustomControl : Control
    {
        // The UI Automation provider for this instance of the control.
        private ValueProvider myValueProvider;

        // The control dimensions.
        private int controlWidth = 100;
        private int controlHeight = 25;

        public CustomControl()
        {
            this.Size = new Size(controlWidth, controlHeight);
        }

        /// <summary>
        /// Responds to Paint event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Use SystemBrushes for colors of a control.
            System.Drawing.Brush backgroundBrush = SystemBrushes.Window;
            System.Drawing.Brush focusedBrush;
            if (this.Focused)
            {
                focusedBrush = SystemBrushes.Highlight;
            }
            else
            {
                focusedBrush = new SolidBrush(Color.DarkGray);
            }
            e.Graphics.FillRectangle(backgroundBrush, DisplayRectangle);

            System.Drawing.Font itemTextFont = SystemFonts.DefaultFont;

            System.Drawing.Brush itemInk = SystemBrushes.ControlText;

            // draw text onto screen
            Point pt = new Point(DisplayRectangle.Left + 2, DisplayRectangle.Top + controlHeight);
            Rectangle rc = new Rectangle(DisplayRectangle.X, DisplayRectangle.Top + controlHeight + 1, DisplayRectangle.Width, controlHeight);
            rc = new Rectangle(rc.X, rc.Y + 2, controlWidth, controlHeight);

            e.Graphics.DrawString(this.Text, itemTextFont, itemInk, rc);

            e.Dispose();
        }

        #region UI Automation related methods

        /// <summary>
        /// Gets the UI Automation provider for the control.
        /// </summary>
        public ValueProvider Provider
        {
            get
            {
                return myValueProvider;
            }
        }

        /// <summary>
        /// Gets a value that specifies whether the UI Automation provider is attached.
        /// </summary>
        protected bool AutomationIsActive
        {
            get
            {
                return (myValueProvider != null);
            }
        }

        /// <summary>
        /// Handles WM_GETOBJECT message; others are passed to base handler.
        /// </summary>
        /// <param name="winMessage">Windows message.</param>
        /// <remarks>This method enables UI Automation to find the control.</remarks>
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)] 
        protected override void WndProc(ref Message m)
        {
            const int WM_GETOBJECT = 0x003D;

            if (m.Msg == WM_GETOBJECT)
            {
                if (!AutomationIsActive)
                {
                    // If no provider has been created, then create one.
                    myValueProvider = new ValueProvider(this);
                }

                m.Result =
                    AutomationInteropProvider.ReturnRawElementProvider(
                        Handle, m.WParam, m.LParam, myValueProvider);
                return;
            }
            base.WndProc(ref m);
        }

        #endregion UI Automation related methods
    }
}
