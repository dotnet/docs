/*************************************************************************************************
 *
 * File: MyControl.cs
 *
 * Description: Implements a custom control that supports UI Automation.
 *
 * See ProviderForm.cs for a full description of this sample.
 *
 *
 *  This file is part of the Microsoft WinfFX SDK Code Samples.
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
 *************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ElementProvider
{
    class RootButton : Control, IRawElementProviderFragmentRoot

    {
        ListBox ChildControl = new ListBox();
        Rectangle myRectangle;
        Color myColor;
        //Form ownerForm;
        //IntPtr ownerFormHandle;
        InvokePatternProvider myInvokePatternProvider = null;
        IntPtr myHWND;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainForm">Host form.</param>
        /// <param name="rect">Position and size of control.</param>
        public RootButton(Form mainForm, Rectangle rect)
        {
            // Create an object that implements IInvokeProvider; see Invoker.cs.
            myInvokePatternProvider = new InvokePatternProvider(this, this);

            // Initialize painting area and color.
            myRectangle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            myColor = Color.Green;
            myHWND = this.Handle;

            // Give the control a Control.Location and Size so that it will trap mouse clicks
            // and will be repainted as necessary.

            Size = new System.Drawing.Size(myRectangle.Width, myRectangle.Height);
            Location = new System.Drawing.Point(myRectangle.X, myRectangle.Y);

            // Add MouseDown event handler.
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RootButtonControl_MouseDown);
        }

        /// <summary>
        /// Handles WM_GETOBJECT message; others are passed to base handler.
        /// </summary>
        /// <param name="m">Windows message.</param>

        protected override void WndProc(ref Message m)
        {
            const int WM_GETOBJECT = 0x003D;

            if ((m.Msg == WM_GETOBJECT) && (m.LParam.ToInt32() == AutomationInteropProvider.RootObjectId))
            {
                m.Result =
                    AutomationInteropProvider.ReturnRawElementProvider(
                        this.Handle, m.WParam, m.LParam, (IRawElementProviderSimple)this);
                return;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Handles Paint event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(myColor);
            e.Graphics.FillRectangle(brush, DisplayRectangle);
        }

        /// <summary>
        /// Handles MouseDown event.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        public void RootButtonControl_MouseDown(object sender, MouseEventArgs e)
        {
            OnCustomButtonClicked();
            return;
        }

// <Snippet150>
        /// <summary>
        /// Responds to a button click, regardless of whether it was caused by a mouse or
        /// keyboard click or by InvokePattern.Invoke.
        /// </summary>
        private void OnCustomButtonClicked()
        {
            // TODO  Perform program actions invoked by the control.

            // Raise an event.
            if (AutomationInteropProvider.ClientsAreListening)
            {
                AutomationEventArgs args = new AutomationEventArgs(InvokePatternIdentifiers.InvokedEvent);
                AutomationInteropProvider.RaiseAutomationEvent(InvokePatternIdentifiers.InvokedEvent, this, args);
            }
        }
// </Snippet150>

        #region IRawElementProviderSimple

        // <Snippet101>
        /// <summary>
        /// Returns the object that supports the specified pattern.
        /// </summary>
        /// <param name="patternId">ID of the pattern.</param>
        /// <returns>Object that implements IInvokeProvider.</returns>
        object IRawElementProviderSimple.GetPatternProvider(int patternId)
        {
            if (patternId == InvokePatternIdentifiers.Pattern.Id)
            {
                // Return an object that implements IInvokeProvider.
                return myInvokePatternProvider;
            }
            else
            {
                return null;
            }
        }
        // </Snippet101>

        // <Snippet102>
        object IRawElementProviderSimple.GetPropertyValue(int propertyId)
        {
            if (propertyId == AutomationElementIdentifiers.NameProperty.Id)
            {
                return "RootButtonControl";
            }
            else if (propertyId == AutomationElementIdentifiers.ClassNameProperty.Id)
            {
                return "RootButtonControlClass";
            }
            else if (propertyId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.Button.Id;
            }
            else if (propertyId == AutomationElementIdentifiers.IsContentElementProperty.Id)
            {
                return false;
            }
            else if (propertyId == AutomationElementIdentifiers.IsControlElementProperty.Id)
            {
                return true;
            }
            else
            {
                return null;
            }
        }
        // </Snippet102>

        // <Snippet103>
        IRawElementProviderSimple IRawElementProviderSimple.HostRawElementProvider
        {
            get
            {
                // myHWND is the handle of the window that contains this control.
                return AutomationInteropProvider.HostProviderFromHandle(myHWND);
            }
        }
        // </Snippet103>

        // <Snippet104>
        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get
            {
                return ProviderOptions.ServerSideProvider;
            }
        }
        // </Snippet104>

        #endregion IRawElementProviderSimple

        #region IRawElementProviderFragment Members

        System.Windows.Rect IRawElementProviderFragment.BoundingRectangle
        {
            get
            {
                Console.WriteLine("RootButton:  Got BoundingRectangle property.");
                return System.Windows.Rect.Empty;   // per Brendan's doc  -- roots return empty.
            }
        }

        IRawElementProviderFragmentRoot IRawElementProviderFragment.FragmentRoot
        {
            get
            {
                Console.WriteLine("RootButton:  Got FragmentRoot property.");
                return this;
            }
        }

        IRawElementProviderSimple[] IRawElementProviderFragment.GetEmbeddedFragmentRoots()
        {
            return null;
        }

        int[] IRawElementProviderFragment.GetRuntimeId()
        {
            return null;
            //return new int[] { AutomationInteropProvider.AppendRuntimeId, 1 };
                  // not implemented by root, says Brendan's sample
        }

        // <Snippet105>
        IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
        {
            if ((direction == NavigateDirection.FirstChild)
                || (direction == NavigateDirection.LastChild))
            {
                // Return the provider that is the sole child of this one.
                return (IRawElementProviderFragment)ChildControl;
            }
            else
            {
                return null;
            };
        }
        // </Snippet105>

        void IRawElementProviderFragment.SetFocus()
        {
            //  TODO  See spec for requirements

            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IRawElementProviderFragmentRoot Members

        IRawElementProviderFragment IRawElementProviderFragmentRoot.ElementProviderFromPoint(double x, double y)
        {
            throw new Exception("The method or operation is not implemented.");
            //Console.WriteLine("RootButton:  ElementProviderFromPoint");

            //Point pt = new Point((int)x, (int)y);
            //if (myRectangle.Contains(pt))
            //{
            //    return this;
            //}
            ////  TODO  Return child element if it contains p.
            //return null;
        }

        IRawElementProviderFragment IRawElementProviderFragmentRoot.GetFocus()
        {
            // TODO  Unsure of the idea here -- it returns the element within this tree that has
            //  focus, but only if the focus is actually on an element in this tree? Or is it the element
            //  that gains focus when the user navigates to the root element?
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

    }
}
