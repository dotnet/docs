/*************************************************************************************************
 *
 * File: ListItemFragment.cs
 *
 * Description: Implements a list item as a fragment within a custom control that supports UI Automation.
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
    class MyListItem : IRawElementProviderFragment
    {
        ParentList parentControl;
        ArrayList parentItems; 
        String myText = "";
        Rectangle myBounds;
        bool amSelected;
        int myID;
        int myIndex;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainForm">Host form.</param>
        /// <param name="rect">Position and size of control.</param>
        /// <param name="ownerControl">Control that parents this one in the UI automation tree.</param>
        public MyListItem(ParentList parent, ArrayList items, String text, Rectangle myRect)
        {
            myText = text;
            parentControl = parent;
            parentItems = items;
            myID = parentItems.Count+1;
            myIndex = parentItems.Count;
            myBounds = myRect;
        }

        /// <summary>
        /// Gets and sets the text of the item.
        /// </summary>
        public String Text
        {
            get
            {
                return myText;
            }
            set
            {
                myText = value;
            }
        }

        /// <summary>
        /// Gets and sets the selected state of this item.
        /// </summary>
        public bool Selected
        {
            get
            {
                return amSelected;
            }
            set
            {
                amSelected = value;
            }
        }

        /// <summary>
        ///  Gets the index of this item within the list.
        /// </summary>
        public int Index
        {
            get
            {
                return myIndex;
            }
        }

        #region IRawElementProviderSimple Members

        /// <summary>
        /// Returns the object that supports the specified pattern.
        /// </summary>
        /// <param name="patternId">ID of the pattern.</param>
        /// <returns>Object that implements IInvokeProvider.</returns>
        object IRawElementProviderSimple.GetPatternProvider(int patternId)
        {
            AutomationPattern ap = AutomationPattern.LookupById(patternId);

            if (patternId == SelectionItemPatternIdentifiers.Pattern.Id)
            {
                return new ListItemPattern(this, parentControl);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns UI automation property values.
        /// </summary>
        /// <param name="propId">Identifier of the property.</param>
        /// <returns>The value of the property.</returns>
        object IRawElementProviderSimple.GetPropertyValue(int propId)
        {
            if (propId == AutomationElementIdentifiers.NameProperty.Id)
            {
                return this.Text;
            }
            else if (propId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.ListItem.Id;            
            }
            else if (propId == AutomationElementIdentifiers.IsControlElementProperty.Id)
            {
                return true;
            }
            else if (propId == AutomationElementIdentifiers.IsContentElementProperty.Id)
            {
                return true;
            }
            else if (propId == AutomationElementIdentifiers.RuntimeIdProperty.Id)
            {
                return GetRuntimeId();
            }
            else if (propId == AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id)
            {
                return true;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a host provider. 
        /// </summary>
        /// <remarks>
        /// In this case, because the element is not directly hosted in a
        /// window, null is returned.
        /// </remarks>
        IRawElementProviderSimple IRawElementProviderSimple.HostRawElementProvider
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets provider options.
        /// </summary>
        ProviderOptions IRawElementProviderSimple.ProviderOptions
        {
            get
            {
                return ProviderOptions.ServerSideProvider | ProviderOptions.ProviderOwnsSetFocus;
            }
        }
        #endregion

        #region IRawElementProviderFragment

        // <Snippet104>
        /// <summary>
        /// Gets the bounding rectangle.
        /// </summary>
        public System.Windows.Rect BoundingRectangle
        {
            get 
            {
                return new System.Windows.Rect(myBounds.X, myBounds.Y, myBounds.Width, myBounds.Height);
            }
        }
        // </Snippet104>

        // <Snippet105>
        /// <summary>
        /// Gets the root of this fragment.
        /// </summary>
        /// <remarks>
        /// parentControl is the automation provider for the root fragment. In other cases,
        /// the parent element might not be the root.
        /// </remarks>
        public IRawElementProviderFragmentRoot FragmentRoot
        {
            get
            {
                return (IRawElementProviderFragmentRoot)parentControl;
            }
        }
        // </Snippet105>

        /// <summary>
        /// Gets any fragment roots that are embedded in this fragment.
        /// </summary>
        /// <returns>Null in this case.</returns>
        public IRawElementProviderSimple[] GetEmbeddedFragmentRoots()
        {
            return null;
        }

        // <Snippet101>
        /// <summary>
        /// Gets the runtime identifier of the UI Automation element.
        /// </summary>
        /// <remarks>
        /// myID is a unique identifier for the item within this instance of the list.
        /// </remarks>
        public int[] GetRuntimeId()
        {
            return new int[] { AutomationInteropProvider.AppendRuntimeId, myID };
        }
        // </Snippet101>

        // <Snippet103>
        /// <summary>
        /// Navigate to adjacent elements in the automation tree.
        /// </summary>
        /// <param name="direction">Direction to navigate.</param>
        /// <returns>The element in that direction, or null.</returns>
        /// <remarks>
        /// parentControl is the provider for the list box.
        /// parentItems is the collection of list item providers.
        /// </remarks>
        public IRawElementProviderFragment Navigate(NavigateDirection direction)
        {
            int myIndex = parentItems.IndexOf(this);
            if (direction == NavigateDirection.Parent)
            {
                return (IRawElementProviderFragment)parentControl;
            }
            else if (direction == NavigateDirection.NextSibling)
            {
                if (myIndex < parentItems.Count - 1)
                {
                    return (IRawElementProviderFragment)parentItems[myIndex + 1];
                }
                else
                {
                    return null;
                }
            }
            else if (direction == NavigateDirection.PreviousSibling)
            {
                if (myIndex > 0)
                {
                    return (IRawElementProviderFragment)parentItems[myIndex - 1];
                }
                else return null;
            }
            else return null;
        }
        // </Snippet103>

        /// <summary>
        /// Responds to a client request to set the focus to this control. 
        /// </summary>
        public void SetFocus()
        {
            // Force refresh. This must be done through delegation because it's illegal to 
            // operate directly on the UI from a different thread.
            PaintEventArgs args = new PaintEventArgs(parentControl.CreateGraphics(), parentControl.DisplayRectangle);
            PaintEventHandler handler = parentControl.PaintMe;
            parentControl.BeginInvoke(handler, new object[] { this, args });
        }

        #endregion IRawElementProviderFragment
    }
}
