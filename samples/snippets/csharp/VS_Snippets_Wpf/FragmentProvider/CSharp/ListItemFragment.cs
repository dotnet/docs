/*************************************************************************************************
 *
 * File: ListItemFragment.cs
 *
 * Description: Implements a list item as a fragment within a custom control 
 * that supports UI Automation.
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
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace CustomControls
{
    public class ListItemProvider : IRawElementProviderFragment, ISelectionItemProvider
    {
        // Provider for the list that contains the item.
        ListProvider ContainingListProvider;
        // Control that contains the list.
        CustomListItem ListItemControl;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rootProvider">UI Automation provider for the 
        /// fragment root (the containing list).</param>
        /// <param name="thisItem">The control that owns this provider.</param>
        public ListItemProvider(ListProvider rootProvider, CustomListItem thisItem) 
        {
            ContainingListProvider = rootProvider;
            ListItemControl = thisItem;
        }

        
        /// <summary>
        /// Gets the index of the item within the list.
        /// </summary>
        public int Index
        {
            get
            {
                return ListItemControl.Index;
            }
        }

        
        #region IRawElementProviderSimple Members

        /// <summary>
        /// Retrieves the object that supports the specified control pattern.
        /// </summary>
        /// <param name="patternId">The pattern identifier</param>
        /// <returns>
        /// The supporting object, or null if the pattern is not supported.
        /// </returns>
        public object GetPatternProvider(int patternId)
        {
            if (patternId == SelectionItemPatternIdentifiers.Pattern.Id)
            {
                return this;
            }
            return null;
        }

        /// <summary>
        /// Returns UI Automation property values.
        /// </summary>
        /// <param name="propId">The identifier of the property.</param>
        /// <returns>The value of the property.</returns>
        public object GetPropertyValue(int propId)
        {
            if (ListItemControl.IsAlive == false)
            {
                throw new ElementNotAvailableException();
            }
            if (propId == AutomationElementIdentifiers.NameProperty.Id)
            {       
                return ListItemControl.Text;     
            }
            else if (propId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.ListItem.Id;            
            }
            else if (propId == AutomationElementIdentifiers.AutomationIdProperty.Id)
            {
                return ListItemControl.Id.ToString();
            }
            else if (propId == AutomationElementIdentifiers.HasKeyboardFocusProperty.Id)
            {
                return ListItemControl.IsSelected;
            }
            else if (propId == AutomationElementIdentifiers.ItemStatusProperty.Id)
            {
                if (ListItemControl.Status == CustomControls.Availability.Online)
                {
                    return "Contact is online";
                }
                else
                {
                    return "Contact is offline";
                }
            }
            else if (propId == AutomationElementIdentifiers.IsEnabledProperty.Id)
            {
                return true;
            }
            else if (propId == AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id)
            {
                return true;
            }
            else if (propId == AutomationElementIdentifiers.FrameworkIdProperty.Id)
            {
                return "Custom";
            }
            return null;
        }

        /// <summary>
        /// Returns a host provider. 
        /// </summary>
        /// <remarks>
        /// In this case, because the element is not directly hosted in a
        /// window, null is returned.
        /// </remarks>
        public IRawElementProviderSimple HostRawElementProvider
        {
            get
            {
                // Because the element is not directly hosted in a window, null is returned.
                return null;
            }
        }

        /// <summary>
        /// Gets provider options.
        /// </summary>
        public ProviderOptions ProviderOptions
        {
            get
            {
                return ProviderOptions.ServerSideProvider;
            }
        }

        #endregion IRawElementProviderSimple Members

        #region IRawElementProviderFragment Members

        /// <summary>
        /// Gets the bounding rectangle, in screen coordinates.
        /// </summary>
        public System.Windows.Rect BoundingRectangle
        {
            get 
            {
                Rectangle rc = this.ListItemControl.Location;
                return new System.Windows.Rect(rc.X, rc.Y, rc.Width, rc.Height);
            }
        }

        /// <summary>
        /// Gets the root of this fragment.
        /// </summary>
        public IRawElementProviderFragmentRoot FragmentRoot
        {
            get
            {
                return ContainingListProvider;
            }
        }

        /// <summary>
        /// Gets any fragment roots that are embedded in this fragment.
        /// </summary>
        /// <returns>Null in this case.</returns>
        public IRawElementProviderSimple[] GetEmbeddedFragmentRoots()
        {
            return null;
        }

        /// <summary>
        /// Gets the runtime identifier of the UI Automation element.
        /// </summary>
        /// <returns>An array of integers.</returns>
        public int[] GetRuntimeId()
        {
            return new int[] { AutomationInteropProvider.AppendRuntimeId, ListItemControl.Id};
        }

        /// <summary>
        /// Navigate to adjacent elements in the UI Automation tree.
        /// </summary>
        /// <param name="direction">Direction to navigate.</param>
        /// <returns>The element in that direction, or null.</returns>
        public IRawElementProviderFragment Navigate(NavigateDirection direction)
        {
            if (direction == NavigateDirection.Parent)
            {
                return ContainingListProvider;
            }
            else if (direction == NavigateDirection.NextSibling)
            {
                return ContainingListProvider.GetProviderForIndex(
                    ListItemControl.Index + 1);
            }
            else if (direction == NavigateDirection.PreviousSibling)
            {
                return ContainingListProvider.GetProviderForIndex(
                    ListItemControl.Index - 1);
            }
            return null;
        }


        /// <summary>
        /// Responds to a client request to set the focus to this control. 
        /// </summary>
        public void SetFocus()
        {
            if (ListItemControl.IsAlive == false)
            {
                throw new ElementNotAvailableException();
            }
            ListItemControl.Container.SelectedIndex = Index;
        }

        #endregion IRawElementProviderFragment Members
        
        #region ISelectionItemProvider Members

        /// <summary>
        /// Adds an item to the selection in list boxes that support multiple 
        /// selection.
        /// </summary>
        public void AddToSelection()
        {
            throw new System.InvalidOperationException("Multiple selection is not supported.");
        }

        /// <summary>
        /// Specifies whether the item is selected.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return this.ListItemControl.IsSelected;
            }
        }

        /// <summary>
        /// Removes the item from the selection in list boxes that support 
        /// multiple selection or no selection at all.
        /// </summary>
        public void RemoveFromSelection()
        {
            throw new InvalidOperationException("Selection is required for this control.");
        }

        /// <summary>
        /// Selects the item.
        /// </summary>
        public void Select()
        {
            // For this list box, Focus and Selection are the same.
            SetFocus();
        }

        /// <summary>
        /// Gets the list box that contains the item.
        /// </summary>
        public IRawElementProviderSimple SelectionContainer
        {
            get 
            {
                return ContainingListProvider;
            }
        }

        #endregion ISelectionPatternProvider Members
    }
}
