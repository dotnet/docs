/*************************************************************************************************
 *
 * File: ListPattern.cs
 *
 * Description: Implements ISelectionProvider to support SelectionPattern in client applications.
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
using System.Windows.Automation.Provider;
using System.Collections;

namespace ElementProvider
{
    class ListPattern : ISelectionProvider
    {
        ArrayList MyList;
        int SelectedIndex;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">List box that this pattern supports.</param>
        /// <param name="index">Index of the selected item.</param>
        public ListPattern(ArrayList list, int index)
        {
            MyList = list;
            SelectedIndex = index;
        }

        // <Snippet119>
        #region ISelectionProvider Members

        // <Snippet108>
        /// <summary>
        /// Specifies whether selection of more than one item at a time is supported.
        /// </summary>
        public bool CanSelectMultiple
        {
            get
            {
                return false;
            }
        }
        // </Snippet108>

        /// <summary>
        /// Specifies whether the list has to have an item selected at all times.
        /// </summary>
        // <Snippet109>
        public bool IsSelectionRequired
        {
            get
            {
                return true;
            }
        }
        // </Snippet109>

        // <Snippet110>
        /// <summary>
        /// Returns the automation provider for the selected list item.
        /// </summary>
        /// <returns>The selected item.</returns>
        /// <remarks>
        /// MyList is an ArrayList collection of providers for items in the list box.
        /// SelectedIndex is the index of the selected item.
        /// </remarks>
        public IRawElementProviderSimple[] GetSelection()
        {
            if (SelectedIndex >= 0)
            {
                IRawElementProviderSimple itemProvider = (IRawElementProviderSimple)MyList[SelectedIndex];
                IRawElementProviderSimple[] providers =  { itemProvider };
                return providers;
            }
            else return null;
        }
        // </Snippet110>
        #endregion ISelectionProvider Members
        // </Snippet119>
    }
}
