using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Security.Permissions;

namespace UIAIToggleProvider_snip
{
    public partial class CustomControl : Control
    {
        // The UI Automation provider for this instance of the control.
        private ToggleProvider myToggleProvider;

        // The control dimensions.
        private int controlWidth;
        private int controlHeight;
        private Rectangle controlRectangle;
        private IntPtr controlHWND;
        //public ArrayList togglestateColor = new ArrayList(3);
        public Color controlColor;
        public Dictionary<Color, ToggleState> toggleStateColor = new Dictionary<Color, ToggleState>();

        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomControl(Form mainForm, Rectangle rect)
        {
            // Initialize painting area and color.
            controlWidth = 50;
            controlHeight = 100;
            controlRectangle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            this.Size = new Size(controlWidth, controlHeight);
            controlHWND = this.Handle;

            // Give the control a Control.Location and Size so that it will trap mouse clicks
            // and will be repainted as necessary.
            Size = new System.Drawing.Size(controlRectangle.Width, controlRectangle.Height);
            Location = new System.Drawing.Point(controlRectangle.X, controlRectangle.Y);
            //togglestateColor[(int)ToggleState.On] = Color.Red;
            //togglestateColor[(int)ToggleState.Off] = Color.Green;
            //togglestateColor[(int)ToggleState.Indeterminate] = Color.Yellow;
            toggleStateColor[Color.Green] = ToggleState.On;
            toggleStateColor[Color.Red] = ToggleState.Off;
            toggleStateColor[Color.Yellow] = ToggleState.Indeterminate;
            controlColor = Color.Yellow;
            //KeyCollection k = toggleColor.Keys;
            //ToggleState[] v = toggleColor.Values;
            //int c = toggleColor.Values.Count;
            //for (int loop = 0; loop <= c; loop++)
            //{

            //}


        }

        #region Private/Internal methods

        /// <summary>
        /// Handles Paint event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(controlColor);
            e.Graphics.FillRectangle(brush, controlRectangle);
        }

        #endregion Private/Internal methods

        #region UI Automation related methods
        /// <summary>
        /// Gets the UI Automation provider for the control.
        /// </summary>
        public ToggleProvider Provider
        {
            get
            {
                return myToggleProvider;
            }
        }

        /// <summary>
        /// Gets a value that specifies whether the UI Automation provider is attached.
        /// </summary>
        protected bool AutomationIsActive
        {
            get
            {
                return (myToggleProvider != null);
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
                    myToggleProvider = new ToggleProvider(this);
                }

                m.Result =
                    AutomationInteropProvider.ReturnRawElementProvider(
                        Handle, m.WParam, m.LParam, myToggleProvider);
                return;
            }
            base.WndProc(ref m);
        }

        #endregion UI Automation related methods
    }
}
