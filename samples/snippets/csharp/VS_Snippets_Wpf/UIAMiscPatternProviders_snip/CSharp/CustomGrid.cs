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
    class CustomGrid : Control, IRawElementProviderFragmentRoot, IGridProvider  
        
    {
        ListBox ChildControl = new ListBox();
        Rectangle myRectangle;
        Color myColor;
        //Form ownerForm;
        //IntPtr ownerFormHandle;
//        InvokePatternProvider myInvokePatternProvider = null;
        IntPtr myHWND;

        CustomGridItem[,] gridItems = new CustomGridItem[5, 2];

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainForm">Host form.</param>
        /// <param name="rect">Position and size of control.</param>
        public CustomGrid(Form mainForm, Rectangle rect)
        {
            // Create an object that implements IInvokeProvider; see Invoker.cs.
            //myInvokePatternProvider = new InvokePatternProvider(this, this);  

            // Initialize painting area and color.
            myRectangle = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
            myColor = Color.Green;
            myHWND = this.Handle;

            // Give the control a Control.Location and Size so that it will trap mouse clicks
            // and will be repainted as necessary.

            Size = new System.Drawing.Size(myRectangle.Width, myRectangle.Height);
            Location = new System.Drawing.Point(myRectangle.X, myRectangle.Y);

            // Add MouseDown event handler.
            //this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RootButtonControl_MouseDown);
            gridItems[0,0] = new CustomGridItem("Apple", 0, 0, (IRawElementProviderSimple)this);
            gridItems[0, 1] = new CustomGridItem("10 cents", 0, 1, (IRawElementProviderSimple)this);
            gridItems[1, 0] = new CustomGridItem("Orange", 1, 0, (IRawElementProviderSimple)this);
            gridItems[1, 1] = new CustomGridItem("15 cents", 1, 1, (IRawElementProviderSimple)this);
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


        
        #region IRawElementProviderSimple


        /// <summary>
        /// Returns the object that supports the specified pattern.
        /// </summary>
        /// <param name="patternId">ID of the pattern.</param>
        /// <returns>Object that implements IInvokeProvider.</returns>
        object IRawElementProviderSimple.GetPatternProvider(int patternId)
        {
            if (patternId == GridPatternIdentifiers.Pattern.Id)
            {
                
                return (IGridProvider)this;
            }
            return null;
        }

        object IRawElementProviderSimple.GetPropertyValue(int propertyId)
        {
            if (propertyId == AutomationElementIdentifiers.NameProperty.Id)
            {
                return "CustomGridControl";
            }
            else if (propertyId == AutomationElementIdentifiers.ClassNameProperty.Id)
            {
                return "CustomGridControlClass";
            }
            else if (propertyId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.Custom.Id;  
            }
            else if (propertyId == AutomationElementIdentifiers.IsContentElementProperty.Id)
            {
                return true;
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
        IRawElementProviderSimple IRawElementProviderSimple.HostRawElementProvider  
        {
            get 
            {
                // myHWND is the handle of the window that contains this control.
                return AutomationInteropProvider.HostProviderFromHandle(myHWND);
            }
        }

        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get 
            {
                return ProviderOptions.ServerSideProvider;
            }
        }

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

        IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
        {
            if (direction == NavigateDirection.FirstChild)
            {
                // Return the provider that is the sole child of this one.
                return (IRawElementProviderFragment)gridItems[0,0];
            }
            else
            {
                return null;
            };
        }

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




        #region IGridProvider Members
// <Snippet101> 
        IRawElementProviderSimple IGridProvider.GetItem(int row, int column)
        {
            return (IRawElementProviderSimple)gridItems[row, column];
        }
// </Snippet101>

// <Snippet102> 
        /// <summary>
        /// Gets the count of columns in the grid.
        /// </summary>
        /// <remarks>
        /// gridItems is a two-dimensional array containing columns
        /// in the second dimension.
        /// </remarks>
        int IGridProvider.ColumnCount
        {
            get 
            {
                return gridItems.GetUpperBound(1) + 1; ;  
            }
        }
// </Snippet102>

// <Snippet103> 
        /// <summary>
        /// Gets the count of rows in the grid.
        /// </summary>
        /// <remarks>
        /// gridItems is a two-dimensional array containing rows in
        /// the first dimension.
        /// </remarks>
        int IGridProvider.RowCount
        {
            get 
            {
                return gridItems.GetUpperBound(0) + 1;  
            }
        }
// </Snippet103>

        #endregion
    }
}
