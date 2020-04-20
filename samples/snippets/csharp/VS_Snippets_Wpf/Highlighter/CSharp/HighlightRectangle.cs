/*******************************************************************************
 * File: HighlightRectangle.cs
 *
 * Description:
 * Contains a class that represents the highlight rectangle, which is made up
 * of four Form objects. Windows takes care of properly drawing and erasing
 * these forms.
 *
 * See ClientForm.cs for a full description of the sample.
 *
 *  This file is part of the Microsoft Windows SDK Code Samples.
 *
 *  Copyright (C) Microsoft Corporation.  All rights reserved.
 *
 * This source code is intended only as a supplement to Microsoft
 * Development Tools and/or on-line documentation.  See these other
 * materials for detailed information regarding Microsoft code samples.
 *
 * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
 * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
 * PARTICULAR PURPOSE.
 *
 ******************************************************************************/

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Highlighter
{
    internal class HighlightRectangle
    {
        #region Private Fields

        private bool highlightShown;
        private int highlightLineWidth;
        private Rectangle highlightLocation;

        private Form leftForm;
        private Form topForm;
        private Form rightForm;
        private Form bottomForm;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <remarks>
        /// Creates each side of the highlight rectangle as a form, so that
        /// drawing and erasing are handled automatically.
        /// </remarks>
        public HighlightRectangle()
        {
            // Construct the rectangle and set some values.
            highlightShown = false;
            highlightLineWidth = 3;
            leftForm = new Form();
            topForm = new Form();
            rightForm = new Form();
            bottomForm = new Form();
            Form[] forms = { leftForm, topForm, rightForm, bottomForm };
            foreach (Form form in forms)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.ShowInTaskbar = false;
                form.TopMost = true;
                form.Visible = false;
                form.Left = 0;
                form.Top = 0;
                form.Width = 1;
                form.Height = 1;
                form.BackColor = Color.Red;

                // Make it a tool window so it doesn't show up with Alt+Tab.
                int style = NativeMethods.GetWindowLong(
                    form.Handle, NativeMethods.GWL_EXSTYLE);
                NativeMethods.SetWindowLong(
                    form.Handle, NativeMethods.GWL_EXSTYLE,
                    (int)(style | NativeMethods.WS_EX_TOOLWINDOW));
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Sets the visible state of the rectangle.
        /// </summary>
        /// <remarks>
        /// The Layout method is called by using BeginInvoke, to prevent
        /// cross-thread updates to the UI. This method can be called on
        /// any form that belongs to the UI thread.
        /// </remarks>
        public bool Visible
        {
            set
            {
                if (highlightShown != value)
                {
                    highlightShown = value;
                    if (highlightShown)
                    {
                        MethodInvoker mi = new MethodInvoker(Layout);
                        leftForm.BeginInvoke(mi);
                        mi = new MethodInvoker(ShowRectangle);
                        leftForm.BeginInvoke(mi);
                    }
                    else
                    {
                        MethodInvoker mi = new MethodInvoker(HideRectangle);
                        leftForm.BeginInvoke(mi);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the location of the highlight.
        /// </summary>
        public Rectangle Location
        {
            set
            {
                highlightLocation = value;
                MethodInvoker mi = new MethodInvoker(Layout);
                leftForm.BeginInvoke(mi);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Shows or hides the rectangle.
        /// </summary>
        /// <param name="show">true to show, false to hide.</param>
        private void Show(bool show)
        {
            if (show)
            {
                NativeMethods.ShowWindow(leftForm.Handle, NativeMethods.SW_SHOWNA);
                NativeMethods.ShowWindow(topForm.Handle, NativeMethods.SW_SHOWNA);
                NativeMethods.ShowWindow(rightForm.Handle, NativeMethods.SW_SHOWNA);
                NativeMethods.ShowWindow(bottomForm.Handle, NativeMethods.SW_SHOWNA);
            }
            else
            {
                leftForm.Hide();
                topForm.Hide();
                rightForm.Hide();
                bottomForm.Hide();
            }
        }

        /// <summary>
        /// Shows the highlight.
        /// </summary>
        /// <remarks> Parameterless method for MethodInvoker.</remarks>
        void ShowRectangle()
        {
            Show(true);
        }

        /// <summary>
        /// Hides the highlight.
        /// </summary>
        /// <remarks> Parameterless method for MethodInvoker.</remarks>
        void HideRectangle()
        {
            Show(false);
        }

        /// <summary>
        /// Sets the position and size of the four forms that make up the rectangle.
        /// </summary>
        /// <remarks>
        /// Use the Win32 SetWindowPosfunction so that SWP_NOACTIVATE can be set.
        /// This ensures that the windows are shown without receiving the focus.
        /// </remarks>
        private void Layout()
        {
            // Use SetWindowPos instead of changing the location via form properties:
            // this allows us to also specify HWND_TOPMOST.
            // Using Form.TopMost = true to do this has the side-effect
            // of activating the rectangle windows, causing them to gain the focus.
            NativeMethods.SetWindowPos(leftForm.Handle, NativeMethods.HWND_TOPMOST,
                        highlightLocation.Left - highlightLineWidth,
                        highlightLocation.Top,
                        highlightLineWidth, highlightLocation.Height,
                        NativeMethods.SWP_NOACTIVATE);
            NativeMethods.SetWindowPos(topForm.Handle, NativeMethods.HWND_TOPMOST,
                        highlightLocation.Left - highlightLineWidth,
                        highlightLocation.Top - highlightLineWidth,
                        highlightLocation.Width + 2 * highlightLineWidth,
                        highlightLineWidth,
                        NativeMethods.SWP_NOACTIVATE);
            NativeMethods.SetWindowPos(rightForm.Handle, NativeMethods.HWND_TOPMOST,
                        highlightLocation.Left + highlightLocation.Width,
                        highlightLocation.Top, highlightLineWidth,
                        highlightLocation.Height,
                        NativeMethods.SWP_NOACTIVATE);
            NativeMethods.SetWindowPos(bottomForm.Handle, NativeMethods.HWND_TOPMOST,
                        highlightLocation.Left - highlightLineWidth,
                        highlightLocation.Top + highlightLocation.Height,
                        highlightLocation.Width + 2 * highlightLineWidth,
                        highlightLineWidth,
                        NativeMethods.SWP_NOACTIVATE);
        }

        #endregion

    }  // class
}  // namespace
