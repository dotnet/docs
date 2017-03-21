/*************************************************************************************************
 *
 * File: CustomControl.cs
 *
 * Description: 
 * 
 * A custom list control that supports UI Automation.
 *  
 * See ProviderForm.cs for a full description of this sample.
 * 
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
 *************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Security.Permissions;

namespace CustomControls
{
    public enum Availability { Online, Offline };

    public class CustomListControl : Control
    {
        #region Private Members

        // Collection of strings that are items in the list.
        ArrayList itemsArray;
        // Index of selected item, or -1 if no item is selected.
        int currentSelection = -1;  
        // Constraints on list size.
        int maxNumberOfItems = 10;
        int minNumberOfItems = 1; 
        // Dimensions of list item.
        const int itemHeight = 15; 
        const int listWidth = 70;  
        // Dimensions of image that signifies item status.
        const int imageWidth = 10;
        const int imageHeight = 10;
        // Text indentation to allow room for image.
        const int textIndent = 15; 
        
        // Unique identifier for each list item; never reused during the life of the control.
        int uniqueIdentifier = 0;

        // The UI Automation provider for this instance of the control.
        ListProvider myListProvider;

        #endregion Private Members

        #region Public Methods

        /// <summary>
        /// Constructor.
        /// </summary>
        public CustomListControl()
        {
            this.Size = new System.Drawing.Size(listWidth, itemHeight * MaximumNumberOfItems);

            // Initialize list item collection.
            itemsArray = new ArrayList();
        }


        /// <summary>
        /// Gets the maximum number of items the list can accommodate. For this example, this is constrained
        /// by the size of the window so that we do not have to handle scrolling.
        /// </summary>
        public int MaximumNumberOfItems
        {
            get
            {
                return maxNumberOfItems;
            }
        }

        /// <summary>
        /// Gets the minimum number of items the list can accommodate. 
        /// </summary>
        public int MinimumNumberOfItems
        {
            get
            {
                return minNumberOfItems;
            }
        }

        /// <summary>
        /// Gets the unique identifier of a list item. This number is never reused within an instance
        /// of the control.
        /// </summary>
        public int UniqueId
        {
            get
            {
                uniqueIdentifier++;  
                return uniqueIdentifier;
            }
        }
  
        /// <summary>
        /// Gets and sets the index of the selected item.
        /// </summary>
        public int SelectedIndex
        {
            get
            {
                return this.currentSelection;
            }
            set
            {
                InternalSelect(value);
            }
        }

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="i">The zero-based index of the item.</param>
        /// <returns>The control for the item.</returns>
        public CustomListItem GetItem(int i)
        {
            return (CustomListItem)itemsArray[i];
        }

        /// <summary>
        /// Gets the number of items in the list.
        /// </summary>
        public int ItemCount
        {
            get
            {
                return itemsArray.Count;
            }
        }

        /// <summary>
        /// Gets the index of the specified item.
        /// </summary>
        /// <param name="listItem">The item.</param>
        /// <returns>The zero-based index.</returns>
        public int ItemIndex(CustomListItem listItem)
        {
            // Allows CustomListItem to requery its index, as it can change.
            return itemsArray.IndexOf(listItem);
        }

        /// <summary>
        /// Removes an item from the list.
        /// </summary>
        /// <param name="itemIndex">Index of the item.</param>
        /// <returns>true if successful.</returns>
        public bool Remove(int itemIndex)
        {
            if ((this.ItemCount == minNumberOfItems) || (itemIndex <= -1) || (itemIndex >= this.ItemCount))
            {
                // If the number of items in the list is already at minimum,
                // no additional items can be removed.
                return false; 
            }
            CustomListItem itemToBeRemoved = (CustomListItem)itemsArray[itemIndex];

            // Notify the provider that item it going to be destroyed.
            itemToBeRemoved.IsAlive = false; 

            // Force refresh.
            this.Invalidate();

            // Raise notification.
            if (myListProvider != null)
            {
                ListProvider.OnStructureChangeRemove(itemToBeRemoved.Container);
            }
            itemsArray.RemoveAt(itemIndex);
            currentSelection = 0;  // Reset selection to first item.

            return true;
        }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="item">Index at which to add the item.</param>
        /// <param name="a">Item to add.</param>
        /// <returns>true if successful.</returns>
        public bool Add(string item, Availability a)
        {
            if (itemsArray.Count < maxNumberOfItems)
            {
                CustomListItem listItem;
                listItem = new CustomListItem(this, item, this.UniqueId, a);
                itemsArray.Add(listItem);

                // Initialize the selection if necessary.
                if (currentSelection < 0)
                {
                    currentSelection = 0; 
                    listItem.IsSelected = true;
                }
                this.Invalidate(); // update to draw new added item
                
                // Raise a UI Automation event.
                if (myListProvider != null)
                {
                    ListProvider.OnStructureChangeAdd(listItem.Container);
                }
                return true;
            }
            return false;
        }

        #endregion Public Methods


        #region Private/Internal methods

        /// <summary>
        /// Responds to GotFocus event by repainting the list.
        /// </summary>
        /// <param name="e">Event arguments</param>
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

            // Colors for online/offline image.
            System.Drawing.Brush itemOnBrush = Brushes.Green;
            System.Drawing.Brush itemOffBrush = Brushes.Red;

            System.Drawing.Font itemTextFont = SystemFonts.DefaultFont;

            System.Drawing.Brush itemInk = SystemBrushes.ControlText;
            System.Drawing.Brush selectedItemInk = SystemBrushes.HighlightText;
            
            // Loop through items to draw their text onto screen
            for (int i = 0; i < itemsArray.Count; i++)
            {
                System.Drawing.Point pt = new System.Drawing.Point(DisplayRectangle.Left+2, DisplayRectangle.Top + (i * itemHeight));
                CustomListItem listItem = ((CustomListItem)itemsArray[i]);
                Rectangle rc = GetRectForItem(i);
                rc = new Rectangle(rc.X, rc.Y+2, imageWidth, imageHeight);
                if (listItem.Status == Availability.Online)
                {
                    e.Graphics.FillRectangle(itemOnBrush, rc);
                }
                else
                {
                    e.Graphics.FillRectangle(itemOffBrush, rc);
                }
                rc = new Rectangle(rc.X + textIndent, rc.Y-2, listWidth - textIndent, itemHeight);
                if (i == SelectedIndex)
                {
                    e.Graphics.FillRectangle(focusedBrush, rc);
                    e.Graphics.DrawString(listItem.Text, itemTextFont, selectedItemInk, rc);
                }
                else
                {
                    // Item not selected.
                    e.Graphics.DrawString(listItem.Text, itemTextFont, itemInk, rc);
                }
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
            int index = ItemIndexFromPoint(new System.Drawing.Point(e.X, e.Y));
            if (index != -1)
            {
                InternalSelect(index);
            }
        }

        /// <summary>
        /// Gets the index at the specified screen coordinates.
        /// </summary>
        /// <param name="pt">The screen coordinates.</param>
        /// <returns>The index of the item, or -1 if pt is not within the control.</returns>
        /// <remarks>This logic is simple because the control does not support scrolling.</remarks>
        internal int ItemIndexFromPoint(System.Drawing.Point pt)
        {
            // Determine whether the point is within the control. 
            if (!this.DisplayRectangle.Contains(pt))
            {
                return -1;
            }
            
            int index = (this.DisplayRectangle.Y + pt.Y) / itemHeight;
            if (index >= itemsArray.Count)
            {
                index = -1;
            }
            return index;
        }

        /// <summary>
        /// Gets the screen coordinates of an item.
        /// </summary>
        /// <param name="index">The index of the item.</param>
        /// <returns>The screen coordinates.</returns>
        internal Rectangle GetRectForItem(int index)
        {
            int itemTop = DisplayRectangle.Top + (itemHeight * index) + 1;
            return new Rectangle(DisplayRectangle.X, itemTop, DisplayRectangle.Width, itemHeight);
        }

        /// <summary>
        /// Processes up/down arrow keys.
        /// </summary>
        /// <param name="msg">The Windows message.</param>
        /// <param name="keyData">Information about the key press.</param>
        /// <returns>true if successful.</returns>
        [PermissionSetAttribute(SecurityAction.Demand, Unrestricted = true)]
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Down)
            {
                if (currentSelection < itemsArray.Count - 1)
                {
                    InternalSelect(currentSelection + 1);
                }
                return true;

            }
            else if (keyData == Keys.Up)
            {
                if (currentSelection > 0)
                {
                    InternalSelect(currentSelection - 1);
                }
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        /// <summary>
        /// Selects an item in the list.
        /// </summary>
        /// <param name="index">Index of the item to select.</param>
        private void InternalSelect(int index)
        {
            if ((index >= itemsArray.Count) || (index < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                if (currentSelection != index)
                {
                    ((CustomListItem)itemsArray[currentSelection]).IsSelected = false;
                    ((CustomListItem)itemsArray[index]).IsSelected = true;
                    currentSelection = index;
                    // Force refresh.
                    Invalidate();
                    CustomControls.ListProvider.OnSelectionChange((CustomListItem)itemsArray[index]);
                }
                
                // Raise an event.
                ListProvider.OnFocusChange((CustomListItem)itemsArray[index]);
            }
        }

        #endregion Private/Internal methods


        #region UI Automation related methods

        /// <summary>
        /// Gets the UI Automation provider for the control.
        /// </summary>
        public ListProvider Provider
        {
            get
            {
                return myListProvider;
            }
        }

        /// <summary>
        /// Gets a value that specifies whether the UI Automation provider is attached.
        /// </summary>
        protected bool AutomationIsActive
        {
            get
            {
                return (myListProvider != null);
            }
        }

        /// <summary>
        /// Handles WM_GETOBJECT message; others are passed to base handler.
        /// </summary>
        /// <param name="winMessage">Windows message.</param>
        /// <remarks>This method enables UI Automation to find the control.</remarks>
        [PermissionSetAttribute(SecurityAction.Demand, Unrestricted = true)]
        protected override void WndProc(ref Message winMessage)
        {
            const int WM_GETOBJECT = 0x003D;

            if (winMessage.Msg == WM_GETOBJECT)
            {
                if (!AutomationIsActive)
                {
                    // If no provider has been created, then create one.
                    myListProvider = new ListProvider(this);
             
                    // Create providers for each existing item in the list.
                    foreach (CustomListItem listItem in itemsArray)
                    {
                        listItem.Provider = new ListItemProvider(myListProvider,listItem);
                    }
                }

                winMessage.Result =
                    AutomationInteropProvider.ReturnRawElementProvider(
                        Handle, winMessage.WParam, winMessage.LParam, myListProvider);
                return;
            }
            base.WndProc(ref winMessage);
        }

        #endregion UI Automation related methods
    }  // End class


    
    public class CustomListItem 
    {
        bool ItemIsSelected = false;
        
        string ItemText;
        int ItemIndex;
        CustomListControl ItemOwnerList;
        Availability ItemStatus;
        int ItemId;
        ListItemProvider ItemProvider;
        Rectangle ItemRect;
        bool ItemIsAlive;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parent">The owning list.</param>
        /// <param name="text">The text of the item.</param>
        /// <param name="id">The unique identifier of the item within the list.</param>
        /// <param name="availability">The status (online or offline) of the item.</param>
        public CustomListItem(CustomListControl parent, string text, int id, Availability availability) 
        {
            ItemIsAlive = true; 
            ItemOwnerList = parent;
            ItemText = text;
            ItemId = id;
            ItemStatus = availability;
        }

        /// <summary>
        /// Gets and sets the status of the item (alive if it is still displayed).
        /// </summary>
        public bool IsAlive
        {
            get
            {
                return ItemIsAlive;
            }
            set
            {
                ItemIsAlive = value;
            }
        }

       /// <summary>
       /// Gets the CustomListControl that contains this item.
       /// </summary>
        public CustomListControl Container
        {
            get
            {
                return ItemOwnerList;
            }
        }

        /// <summary>
        /// Gets and sets the selection status of the item.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return ItemIsSelected;
            }
            set
            {
                ItemIsSelected = value;
            }
        }

        /// <summary>
        /// Gets the unique identifier of the item within the list.
        /// </summary>
        public int Id
        {
            get
            {
                return ItemId;
            }
        }

        /// <summary>
        /// Gets the location of the item on the screen.
        /// </summary>
        /// <remarks>
        /// Uses delegation to avoid interacting with the UI on a different thread.
        /// </remarks>
        public Rectangle Location
        {
            get
            {
                ItemRect = this.ItemOwnerList.GetRectForItem(this.Index);
                // Invoke control method on separate thread to avoid clashing with UI.
                // Use anonymous method for simplicity.
                this.ItemOwnerList.Invoke(new MethodInvoker(delegate()
                {
                    ItemRect = this.ItemOwnerList.RectangleToScreen(ItemRect);
                }));
                return ItemRect;
            }
        }

        /// <summary>
        /// Gets and sets the text of the item.
        /// </summary>
        public string Text
        {
            get
            {
                return ItemText;
            }
            set
            {
                ItemText = value;
            }
        }

        /// <summary>
        /// Gets and sets the index of the item.
        /// </summary>
        public int Index
        {
            get
            {
                ItemIndex = ItemOwnerList.ItemIndex(this);
                return ItemIndex;
            }
            set
            {
                ItemIndex = value;
            }
        }

        /// <summary>
        /// Gets and sets the status (online or offline) of the item.
        /// </summary>
        public Availability Status
        {
            get
            {
                return ItemStatus;
            }
            set
            {
                ItemStatus = value;
            }
        }

        
        /// <summary>
        /// Gets and sets the UI Automation provider for the item.
        /// </summary>
        public ListItemProvider Provider
        {
            get
            {
                if (ItemProvider == null)
                {
                    ItemProvider = new ListItemProvider(ItemOwnerList.Provider, this);
                                        
                }
                return ItemProvider;
            }
            set
            {
                ItemProvider = value;
            }
        }
        
         
    }
}
