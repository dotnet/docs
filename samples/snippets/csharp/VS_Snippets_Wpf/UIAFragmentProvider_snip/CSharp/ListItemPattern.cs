/*************************************************************************************************
 *
 * File: ListItemPattern.cs
 *
 * Description: Implements ISelectionItemProvider for items in the custom list box,
 * to support SelectionItemPattern in client applications.
 * 
 * See ProviderForm.cs in the ElementProvider project for a full description of this sample.
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
using System.Windows.Automation;
using System.Windows.Automation.Provider;
using System.Collections;

namespace ElementProvider
{
    class ListItemPattern : ISelectionItemProvider
    {
        MyListItem myListItem;
        ParentList parentList;
        ArrayList selectedItems;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="listItem">Item for which this pattern is implemented.</param>
        /// <param name="parent">List that contains the item.</param>
        public ListItemPattern(MyListItem listItem, ParentList parent)
        {
            myListItem = listItem;
            parentList = parent;
            selectedItems = new ArrayList();

        }

        #region ISelectionItemProvider

        /// <summary>
        /// Adds an item to the selection in list boxes that support multiple selection.
        /// </summary>
        // <Snippet111>
        public void AddToSelection()
        {
            selectedItems.Add(this);
            // TODO: Update UI.
        }
        // </Snippet111>

        /// <summary>
        /// Specifies whether the item is selected.
        /// </summary>
        /// <remarks>selectedItems is a collection.</remarks>
        // <Snippet113>
        public bool IsSelected
        {
            get
            {
                return selectedItems.Contains(this);
            }
        }
        // </Snippet113>

        /// <summary>
        /// Removes an item from the selection is list boxes that support multiple selection
        /// or no selection at all.
        /// </summary>
        /// <remarks>selectedItems is a collection.</remarks>
        // <Snippet112>
        public void RemoveFromSelection()
        {
            selectedItems.Remove(this);
            // TODO: Update UI.
        }
        // </Snippet112>

        /// <summary>
        /// Selects the item.
        /// </summary>
        // <Snippet115>
        public void Select()
        {
            selectedItems.Clear();
            selectedItems.Add(this);
            // TODO: Update UI.
        }
        // </Snippet115>

        /// <summary>
        /// Gets the list box that contains the item.
        /// </summary>
        // <Snippet114>
        public IRawElementProviderSimple SelectionContainer
        {
            get 
            {
                return (IRawElementProviderSimple)parentList;
            }
        }
        // </Snippet114>

        #endregion ISelectionItemProvider
    }
}
