/*************************************************************************************************
 *
 * File: ListFragment.cs
 *
 * Description: Implements a custom control that supports UI Automation.
 *
 * The control is a simple list box that manages its own items. Its primary purpose is to demonstrate how to
 * implement a root fragment (the list box itself) and child fragments (the list items) for UI Automation.
 * The functionality of the control itself is very limited: it will display a small number of text items
 * and manage the selection by processing mouse clicks and arrow keys. The only control patterns it supports
 * are SelectionPattern and SelectionItemPattern. A list box in a real application would support more patterns
 * such as ValuePattern and ScrollPattern.
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
using System.Collections;

namespace ElementProvider
{
    class ParentList : Control, IRawElementProviderFragmentRoot, IRawElementProviderAdviseEvents
    {
        IntPtr myHandle;
        ArrayList myItems;
        int mySelection;
        const int itemHeight = 15;

        #region Public methods
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainForm">Host form.</param>
        /// <param name="rect">Position and size of control.</param>
        public ParentList(Form mainForm, int x, int y)
        {
            // Create an object that implements IInvokeProvider; see Invoker.cs.
            //myInvokePatternProvider = new InvokePatternProvider(this, this);

            this.Location = new Point(x, y);
            this.Size = new Size(70, itemHeight + 2);

            // Create an instance of the child control.
            Rectangle controlRect1 = new Rectangle(this.Left, this.Bottom+1, 100, 50);

            // Save the handle in a member, because we're not allowed to access the UI thread
            // to get the property when we need it.
            myHandle = this.Handle;

            TabStop = true;

            // Initialize list item collection.
            myItems = new ArrayList();
            Select(-1);
        }

 // <Snippet122>
        /// <summary>
        /// Raises an event when a control is invoked.
        /// </summary>
        /// <param name="provider">The UI Automation provider for the control.</param>
        private void RaiseInvokeEvent(IRawElementProviderSimple provider)
        {
            if (AutomationInteropProvider.ClientsAreListening)
            {
                AutomationEventArgs args =
                    new AutomationEventArgs(InvokePatternIdentifiers.InvokedEvent);
                AutomationInteropProvider.RaiseAutomationEvent(InvokePatternIdentifiers.InvokedEvent,
                    provider, args);
            }
        }
// </Snippet122>

// <Snippet123>
        /// <summary>
        /// Raises an event when the IsEnabled property on a control is changed.
        /// </summary>
        /// <param name="provider">The UI Automation provider for the control.</param>
        /// <param name="newValue">The current enabled state.</param>
        private void RaiseEnabledEvent(IRawElementProviderSimple provider, bool newValue)
        {
            if (AutomationInteropProvider.ClientsAreListening)
            {
                AutomationPropertyChangedEventArgs args =
                    new AutomationPropertyChangedEventArgs(AutomationElement.IsEnabledProperty,
                        !newValue, newValue);
                AutomationInteropProvider.RaiseAutomationPropertyChangedEvent(provider, args);
            }
        }
// </Snippet123>

        /// <summary>
        /// Add an item to the list.
        /// </summary>
        /// <param name="text">Item to add.</param>
        /// <returns>Index of the added item.</returns>
        public int Add(String text)
        {
            // Dynamically resize the control. To keep things simple for this example,
            // it is assumed that there will be no need for scrolling.
            if (myItems.Count > 0)
            {
                this.Height += itemHeight;
            }

            // Initialize the selection.
            if (mySelection < 0)
            {
                mySelection = 0;
            }

            // Create the item and add it.
            int itemTop = DisplayRectangle.Top + (itemHeight * myItems.Count) + 1;
            int itemLeft = DisplayRectangle.Left + 1;
            int itemWidth = DisplayRectangle.Width - 2;

            MyListItem listItem = new MyListItem(this, myItems, text, new Rectangle(itemTop, itemLeft, itemWidth, itemHeight));
            return myItems.Add(listItem);
        }

        // DON'T USE THIS SNIPPET -- PROBABLY NOT RAISING CORRECT EVENTS

        // <Snippet118>
        /// <summary>
        /// Selects an item in the myItems collection.
        /// </summary>
        /// <param name="index">Index of the selected item.</param>
        /// <remarks>
        /// This is a single-selection list whose current selection is stored
        /// internally in mySelection.
        /// MyListItem is the provider class for list items.
        /// </remarks>
        public void Select(int index)
        {

            if (index >= myItems.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (index < 0)
            {
                mySelection = -1;
                return;
            }
            else
            // If within range, clear the Selected property on the current item
            // and set it on the new item.
            {
                MyListItem newItem;
                MyListItem oldItem = null;

                // Deselect old item, if there is one; list might not be initialized.
                if (mySelection >= 0)
                {
                    oldItem = myItems[mySelection] as MyListItem;
                    oldItem.Selected = false;
                }
                mySelection = index;
                newItem = myItems[mySelection] as MyListItem;
                newItem.Selected = true;
                // Raise events that clients can receive.
                if (AutomationInteropProvider.ClientsAreListening)
                {
                    // Generic event for selection made.
                    AutomationEventArgs args = new AutomationEventArgs(SelectionItemPatternIdentifiers.ElementSelectedEvent);
                    AutomationInteropProvider.RaiseAutomationEvent(SelectionItemPattern.ElementSelectedEvent,
                        (IRawElementProviderSimple)myItems[mySelection], args);

                    // Property-changed event for old item's Selection property.
                    AutomationPropertyChangedEventArgs propArgs;
                    if (oldItem != null)
                    {
                         propArgs = new AutomationPropertyChangedEventArgs(
                            SelectionItemPatternIdentifiers.IsSelectedProperty, true, false);
                        AutomationInteropProvider.RaiseAutomationPropertyChangedEvent(oldItem, propArgs);
                    }

                    // Property-changed event for new item's Selection property.
                    propArgs = new AutomationPropertyChangedEventArgs(
                        SelectionItemPatternIdentifiers.IsSelectedProperty, false, true);
                    AutomationInteropProvider.RaiseAutomationPropertyChangedEvent(newItem, propArgs);
                }
            }
        }
         // </Snippet118>

        #endregion Public methods

        #region Control method overrides

        // <Snippet116>
        /// <summary>
        /// Handles WM_GETOBJECT message; others are passed to base handler.
        /// </summary>
        /// <param name="m">Windows message.</param>
        /// <remarks>
        /// This method enables UI Automation to find the control.
        /// In this example, the implementation of IRawElementProvider is in the same class
        /// as this method.
        /// </remarks>
        protected override void WndProc(ref Message m)
        {
            const int WM_GETOBJECT = 0x003D;

            if ((m.Msg == WM_GETOBJECT) && ((int)(long)m.LParam ==
                AutomationInteropProvider.RootObjectId))
            {
                m.Result = AutomationInteropProvider.ReturnRawElementProvider(
                        this.Handle, m.WParam, m.LParam,
                        (IRawElementProviderSimple)this);
                return;
            }
            base.WndProc(ref m);
        }
        // </Snippet116>

        /// <summary>
        /// Responds to GotFocus event by repainting the list.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            OnPaint(new PaintEventArgs(CreateGraphics(), this.DisplayRectangle));
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Responds to LostFocus event by repainting the list.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnLostFocus(EventArgs e)
        {
            OnPaint(new PaintEventArgs(CreateGraphics(), this.DisplayRectangle));
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Delegate event handler that can be invoked from another thread.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="args">Event arguments.</param>
        public void PaintMe(Object sender, PaintEventArgs args)
        {
            OnPaint(args);
        }

        /// <summary>
        /// Handles Paint event.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Background.
            SolidBrush brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, DisplayRectangle);

            // Border.
            int borderWidth = 2;
            Pen pen = new Pen(Color.Black, borderWidth);
            e.Graphics.DrawRectangle(pen, DisplayRectangle);

            // Items.
            Font textFont = new Font(FontFamily.GenericSansSerif, 10);
            SolidBrush ink = new SolidBrush(Color.Black);
            int count = 0;

            foreach (MyListItem item in myItems)
            {
                Point upperLeft = new Point(DisplayRectangle.Left, DisplayRectangle.Top + (count * itemHeight));
                if (count == SelectedIndex)
                {
                    ink.Color = Color.Red;
                    // If the listbox has focus, paint the item background.
                    if (this.Focused)
                    {
                        brush.Color = Color.LightGray;
                        int itemTop = DisplayRectangle.Top + (itemHeight * count) + 1;
                        e.Graphics.FillRectangle(brush, DisplayRectangle.X + 1, itemTop,
                            DisplayRectangle.Width - 2, itemHeight);
                    }
                }
                else
                {
                    ink.Color = Color.Black;
                }
                e.Graphics.DrawString(item.Text, textFont, ink, upperLeft);
                count++;
            }
            e.Dispose();
        }

        /// <summary>
        /// Handles MouseDown event by selecting the item under the cursor.
        /// </summary>
        /// <param name="e">Event arguments.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            Point targetPoint = new Point(e.X, e.Y);
            int index = (int)((this.DisplayRectangle.Y + e.Y) / itemHeight);
            if (index < myItems.Count)
            {
                Select(index);
                this.Refresh();
            }
        }

        /// <summary>
        /// Process up/down arrow keys.
        /// </summary>
        /// <param name="msg">Windows message.</param>
        /// <param name="keyData">Information about the pressed key.</param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                if (this.SelectedIndex < myItems.Count - 1)
                {
                    Select(SelectedIndex + 1);
                    Refresh();
                }
                return true;
            }
            else if (keyData == Keys.Up)
            {
                if (this.SelectedIndex > 0)
                {
                    Select(SelectedIndex - 1);
                    Refresh();
                }
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #endregion Control method overrides

        #region Properties

        /// <summary>
        /// Gets and sets the index of the selected list item.
        /// </summary>
        /// <remarks>-1 means there is no selection.</remarks>
        public int SelectedIndex
        {
            get
            {
                return mySelection;
            }
        }

        #endregion Properties

        #region IRawElementProviderSimple

        // <Snippet120>
        /// <summary>
        /// Returns the object that supports the specified pattern.
        /// </summary>
        /// <param name="patternId">ID of the pattern.</param>
        /// <returns>Object that implements IInvokeProvider.</returns>
        /// <remarks>
        /// In this case, the ISelectionProvider interface is implemented in another provider-defined class,
        /// ListPattern. However, it could be implemented in the base provider class, in which case the
        /// method would simply return "this".
        /// </remarks>
        object IRawElementProviderSimple.GetPatternProvider(int patternId)
        {
            if (patternId == SelectionPatternIdentifiers.Pattern.Id)
            {
                return new ListPattern(myItems, SelectedIndex);
            }
            else
            {
                return null;
            }
        }
        // </Snippet120>

        // <Snippet117>
        /// <summary>
        /// Gets provider property values.
        /// </summary>
        /// <param name="propId">Property identifier.</param>
        /// <returns>The value of the property.</returns>
        object IRawElementProviderSimple.GetPropertyValue(int propId)
        {
            if (propId == AutomationElementIdentifiers.NameProperty.Id)
            {
                return "Custom list control";
            }
            else if (propId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.List.Id;
            }
            else if (propId == AutomationElementIdentifiers.IsContentElementProperty.Id)
            {
                return true;
            }
            else if (propId == AutomationElementIdentifiers.IsControlElementProperty.Id)
            {
                return true;
            }
            else
            {
                return null;
            }
        }
        // </Snippet117>

        // <Snippet121>
        /// <summary>
        /// Gets the host provider.
        /// </summary>
        /// <remarks>
        /// Fragment roots return their window providers; most others return null.
        /// </remarks>
        IRawElementProviderSimple IRawElementProviderSimple.HostRawElementProvider
        {
            get
            {
                return AutomationInteropProvider.HostProviderFromHandle(myHandle);
            }
        }
        // </Snippet121>

        /// <summary>
        /// Gets provider options.
        /// </summary>
        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get
            {
                return ProviderOptions.ServerSideProvider;
            }
        }

        #endregion IRawElementProviderSimple

        #region IRawElementProviderFragment

        /// <summary>
        /// Gets the bounding rectangle.
        /// </summary>
        /// <remarks>Fragment roots should return an empty rectangle.</remarks>
        System.Windows.Rect IRawElementProviderFragment.BoundingRectangle
        {
            get
            {
                return System.Windows.Rect.Empty;
            }
        }

        /// <summary>
        /// Gets the root of this fragment.
        /// </summary>
        IRawElementProviderFragmentRoot IRawElementProviderFragment.FragmentRoot
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets any fragment roots that are embedded in this fragment.
        /// </summary>
        /// <returns>Null in this case.</returns>
        IRawElementProviderSimple[] IRawElementProviderFragment.GetEmbeddedFragmentRoots()
        {
            return null;
        }

        /// <summary>
        /// Gets the runtime identifier of the UI Automation element.
        /// </summary>
        /// <returns>Fragement roots return null.</returns>
        int[] IRawElementProviderFragment.GetRuntimeId()
        {
            return null;
        }

        // <Snippet102>
        /// <summary>
        /// Navigates to adjacent elements in the automation tree.
        /// </summary>
        /// <param name="direction">Direction of navigation.</param>
        /// <returns>The element in that direction, or null.</returns>
        /// <remarks>myItems is the collection of items in the list.</remarks>
        IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
        {
            if (direction == NavigateDirection.FirstChild)
            {
                return (IRawElementProviderFragment)myItems[0];
            }
            else if (direction == NavigateDirection.LastChild)
            {
                return (IRawElementProviderFragment)myItems[myItems.Count-1];
            }
            else
            {
                return null;
            };
        }
        // </Snippet102>

        /// <summary>
        /// Responds to a client request to set the focus to this control.
        /// </summary>
        /// <remarks>Setting focus to the control is handled by the parent window.</remarks>
        void IRawElementProviderFragment.SetFocus()
        {
            throw new Exception("The method is not implemented.");
        }

        #endregion IRawElementProviderFragment

        #region IRawElementProviderFragmentRoot

        // <Snippet106>
        delegate Rectangle MyDelegate(Rectangle clientRect);

        /// <summary>
        /// Gets the child element that is at the specified point.
        /// </summary>
        /// <param name="x">Distance from the left of the application window.</param>
        /// <param name="y">Distance from the top of the application window.</param>
        /// <returns>The provider for the element at that point.</returns>
        IRawElementProviderFragment IRawElementProviderFragmentRoot.ElementProviderFromPoint(
            double x, double y)
        {
            // The RectangleToScreen method on the control can't be called directly from
            // this thread, so use delegation.
            MyDelegate del = new MyDelegate(this.RectangleToScreen);
            Rectangle screenRectangle = (Rectangle)this.Invoke(del, new object[] { this.DisplayRectangle });

            if (screenRectangle.Contains((int)x, (int)y))
            {
                int index = (int)(((int)(y - screenRectangle.Y)) / itemHeight);
                if (index < myItems.Count)
                {
                    return (IRawElementProviderFragment)myItems[index];
                }
                else
                {
                    return (IRawElementProviderFragment)this;
                }
            }
            else
            {
                return null;
            }
        }
        // </Snippet106>

        // <Snippet107>
        /// <summary>
        /// Returns the child element that is selected when the list gets focus.
        /// </summary>
        /// <returns>The selected item.</returns>
        /// <remarks>
        /// SelectedIndex is a class property that maintains the index of the currently
        /// selected item in the myItems collection.</remarks>
        IRawElementProviderFragment IRawElementProviderFragmentRoot.GetFocus()
        {
            if (SelectedIndex >= 0)
            {
                return (IRawElementProviderFragment)myItems[SelectedIndex];
            }
            else
            {
                return null;
            }
        }
        // </Snippet107>

        #endregion IRawElementProviderFragmentRoot

        #region IRawElementProviderAdviseEvents Members

        ArrayList subscribedProperties = new ArrayList();
// <Snippet124>
        void IRawElementProviderAdviseEvents.AdviseEventAdded(int eventId,
                                                              int[] properties)
        {
            if (eventId == AutomationElement.AutomationPropertyChangedEvent.Id)
            {
                foreach (int i in properties)
                {
                    AutomationProperty property = AutomationProperty.LookupById(i);
                    // Add to an ArrayList.
                    subscribedProperties.Add(property);
                }
            }
        }
// </Snippet124>

// <Snippet125>
        void IRawElementProviderAdviseEvents.AdviseEventRemoved(int eventId,
                                                                int[] properties)
        {
            if (eventId == AutomationElement.AutomationPropertyChangedEvent.Id)
            {
                Console.WriteLine("Property changes no longer subscribed to:");
                foreach (int i in properties)
                {
                    AutomationProperty property = AutomationProperty.LookupById(i);
                    // Remove from an ArrayList.
                    subscribedProperties.Remove(property);
                }
            }
        }
// </Snippet125>

        #endregion
    }  // ParentList class
}
