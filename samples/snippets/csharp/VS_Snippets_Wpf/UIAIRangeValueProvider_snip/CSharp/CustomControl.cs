using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation.Provider;
using System.Security.Permissions;

namespace UIAIRangeValueProvider_snip
{
    public partial class CustomControl : Control
    {
        // The UI Automation provider for this instance of the control.
        private RangeValueProvider myRangeValueProvider;

        // The control dimensions.
        private int controlWidth;
        private int controlHeight;
        public Color controlColor;
        public int colorAlpha;
        
        public CustomControl()
        {
            controlWidth = 100;
            controlHeight = 100;
            colorAlpha = 255;
            controlColor = Color.FromArgb(colorAlpha,Color.Blue);
            this.Size = new Size(controlWidth, controlHeight);
            this.Enabled = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Use SystemBrushes for colors of a control.
            System.Drawing.Brush backgroundBrush = new SolidBrush(controlColor);

            e.Graphics.FillRectangle(backgroundBrush, DisplayRectangle);

            // Calling the base class OnPaint
            base.OnPaint(e);
        }


        #region UI Automation related methods
        
        /// <summary>
        /// Gets the UI Automation provider for the control.
        /// </summary>
        private RangeValueProvider Provider
        {
            get
            {
                return myRangeValueProvider;
            }
        }

        /// <summary>
        /// Gets a value that specifies whether the UI Automation provider is attached.
        /// </summary>
        protected bool AutomationIsActive
        {
            get
            {
                return (myRangeValueProvider != null);
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
                    myRangeValueProvider = new RangeValueProvider(this);
                }

                m.Result =
                    AutomationInteropProvider.ReturnRawElementProvider(
                        Handle, m.WParam, m.LParam, myRangeValueProvider);
                return;
            }
            base.WndProc(ref m);
        }

        #endregion UI Automation related methods
    }
}
