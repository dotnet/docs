using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Security.Permissions;


namespace UIAITransformProvider_snip
{
    public class CustomControl : Control
    {
        // The UI Automation provider for this instance of the control.
        private TransformProvider myTransformProvider;

        // The control dimensions.
        private int controlWidth = 50;
        private int controlHeight = 100;

        // The form dimensions.
        public int formWidth = ProviderForm.ActiveForm.Width;
        public int formHeight = ProviderForm.ActiveForm.Height;

        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomControl()
        {
            this.Size = new Size(controlWidth, controlHeight);
        }

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


            // Calling the base class OnPaint
            base.OnPaint(e);
        }

        #region UI Automation related methods

        /// <summary>
        /// Gets the UI Automation provider for the control.
        /// </summary>
        public TransformProvider Provider
        {
            get
            {
                return myTransformProvider;
            }
        }

        /// <summary>
        /// Gets a value that specifies whether the UI Automation provider is attached.
        /// </summary>
        protected bool AutomationIsActive
        {
            get
            {
                return (myTransformProvider != null);
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
                    myTransformProvider = new TransformProvider(this);
                }

                m.Result =
                    AutomationInteropProvider.ReturnRawElementProvider(
                        Handle, m.WParam, m.LParam, myTransformProvider);
                return;
            }
            base.WndProc(ref m);
        }

        #endregion UI Automation related methods
    }
}
