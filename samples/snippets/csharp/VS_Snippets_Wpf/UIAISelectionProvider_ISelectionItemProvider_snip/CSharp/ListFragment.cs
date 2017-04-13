/*************************************************************************************************
 *
 * File: ListFragment.cs
 *
 * Description: Implements a UI Automation provider for a custom list control.
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
using System.Windows.Automation.Provider;
using System.Windows.Automation;
using System.Collections;
using System.Threading;


namespace CustomControls 
{
    public class ListProvider : IRawElementProviderFragmentRoot, ISelectionProvider
    {
        // Control that contains the list.
        CustomListControl OwnerListControl;
        // Window handle of the control.
        IntPtr WindowHandle;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">
        /// The control for which this object is providing UI Automation functionality.
        /// </param>
        public ListProvider(CustomListControl control)
        {
            OwnerListControl = control;
            WindowHandle = control.Handle;
        }
        
        #region IRawElementProviderSimple Members

        /// <summary>
        /// Retrieves the object that supports the specified control pattern.
        /// </summary>
        /// <param name="patternId">The pattern identifier</param>
        /// <returns>
        /// The supporting object, or null if the pattern is not supported.
        /// </returns>
        object IRawElementProviderSimple.GetPatternProvider(int patternId)
        {
            if (patternId == SelectionPatternIdentifiers.Pattern.Id)
            {
                return this;
            }
            return null;
        }


        /// <summary>
        /// Gets provider property values.
        /// </summary>
        /// <param name="propertyId">The property identifier.</param>
        /// <returns>The value of the property.</returns>
        object IRawElementProviderSimple.GetPropertyValue(int propertyId)
        {
            if (propertyId == AutomationElementIdentifiers.ControlTypeProperty.Id)
            {
                return ControlType.List.Id;
            }
            // It is necessary to supply a value for IsKeyboardFocusable in a Windows Forms control,        
            //  because this value cannot be discovered by the HWND host provider. This is not 
            //  necessary for a Win32 provider.
            else if (propertyId == AutomationElementIdentifiers.IsKeyboardFocusableProperty.Id)
            {
                return true;
            }
            else if (propertyId == AutomationElementIdentifiers.FrameworkIdProperty.Id)
            {
                return "Custom";
            }
            return null;
        }

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
                return AutomationInteropProvider.HostProviderFromHandle(WindowHandle);
            }
        }

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

        #endregion IRawElementProviderSimple Members
        
        
        #region IRawElementProviderFragment Members

        /// <summary>
        /// Gets the bounding rectangle.
        /// </summary>
        /// <remarks>
        /// Fragment roots should return an empty rectangle. UI Automation will get the rectangle
        /// from the host control (the HWND in this case).
        /// </remarks>
        System.Windows.Rect IRawElementProviderFragment.BoundingRectangle
        {
            get
            {
                return System.Windows.Rect.Empty; 
            }
        }

        /// <summary>
        /// Gets the root of this fragment.
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
        /// <returns>Fragment roots return null.</returns>
        int[] IRawElementProviderFragment.GetRuntimeId()
        {
            return null;
        }

        /// <summary>
        /// Navigates to adjacent elements in the UI Automation tree.
        /// </summary>
        /// <param name="direction">Direction of navigation.</param>
        /// <returns>The element in that direction, or null.</returns>
        /// <remarks>The provider only returns directions that it is responsible for.  
        /// UI Automation knows how to navigate between HWNDs, so only the custom item 
        /// navigation needs to be provided.
        ///</remarks>
        IRawElementProviderFragment IRawElementProviderFragment.Navigate(NavigateDirection direction)
        {
            if (direction == NavigateDirection.FirstChild)
            {
                return GetProviderForIndex(0);
            }
            else if (direction == NavigateDirection.LastChild)
            {
                return GetProviderForIndex(OwnerListControl.ItemCount-1);
            }
            return null;
        }

        /// <summary>
        /// Responds to a client request to set the focus to this control.
        /// </summary>
        /// <remarks>Setting focus to the control is handled by the parent window.</remarks>
        void IRawElementProviderFragment.SetFocus()
        {
            throw new Exception("The method is not implemented.");
        }

        #endregion IRawElementProviderFragment Members
        
        
        #region IRawElementProviderFragmentRoot Members

        /// <summary>
        /// Gets the child element at the specified point.
        /// </summary>
        /// <param name="x">Distance from the left of the application window.</param>
        /// <param name="y">Distance from the top of the application window.</param>
        /// <returns>The provider for the element at that point.</returns>
        IRawElementProviderFragment 
            IRawElementProviderFragmentRoot.ElementProviderFromPoint(double x, double y)
        {
            int index = -1;
            System.Drawing.Point clientPoint = new System.Drawing.Point((int)x, (int)y);

            // Invoke control method on separate thread to avoid clashing with UI.
            // Use anonymous method for simplicity.
            this.OwnerListControl.Invoke(new MethodInvoker(delegate()       
            {
                clientPoint = this.OwnerListControl.PointToClient(clientPoint);
            }));

            index = OwnerListControl.ItemIndexFromPoint(clientPoint);
            
            if (index == -1)
            {
                return null;
            }
            return GetProviderForIndex(index);
        }


        /// <summary>
        /// Returns the child element that is selected when the list gets focus.
        /// </summary>
        /// <returns>The selected item.</returns>
        IRawElementProviderFragment IRawElementProviderFragmentRoot.GetFocus()
        {
            int index = OwnerListControl.SelectedIndex;
            return GetProviderForIndex(index);
        }

        #endregion IRawElementProviderFragmentRoot
        

        #region ISelectionProvider Members

        // <SnippetCanSelectMultiple>
        /// <summary>
        /// Specifies whether selection of more than one item at a time is supported.
        /// </summary>
        bool ISelectionProvider.CanSelectMultiple
        {
            get
            {
                return false;
            }
        }
        // </SnippetCanSelectMultiple>

        // <SnippetGetSelection>
        /// <summary>
        /// Returns the UI Automation provider for the selected list items.
        /// </summary>
        /// <returns>The selected items.</returns>
        /// <remarks>
        /// Because this is a single-selection list box, only one item is 
        /// returned.
        /// </remarks>
        IRawElementProviderSimple[] ISelectionProvider.GetSelection()
        {
            int index = OwnerListControl.SelectedIndex;
            return new IRawElementProviderSimple[] { GetProviderForIndex(index) };
        }
        // </SnippetGetSelection>

        // <SnippetIsSelectionRequired>
        /// <summary>
        /// Specifies whether the list must have an item selected at all times.
        /// </summary>
        bool ISelectionProvider.IsSelectionRequired
        {
            get
            {
                return true;
            }
        }
        // </SnippetIsSelectionRequired>

        #endregion ISelectionProvider Members
        
        #region Helper methods
        
        /// <summary>
        /// Gets the UI Automation provider for the item at the specified index.
        /// </summary>
        /// <param name="index">Index of the item.</param>
        /// <returns>The provider object, or null if the index is out of range.</returns>
        public IRawElementProviderFragment GetProviderForIndex(int index)
        {
            int OwnerCustomListItemCount = OwnerListControl.ItemCount - 1;
            if ((index < 0) || (index > OwnerCustomListItemCount))
            {
                return null;
            }
            return (IRawElementProviderFragment)this.OwnerListControl.GetItem(index).Provider;
        }


        /// <summary>
        /// Responds to a focus change by raising an event.
        /// </summary>
        /// <param name="listItem">The item that has received focus.</param>
        public static void OnFocusChange(CustomListItem listItem)
        {
            if (AutomationInteropProvider.ClientsAreListening)
            {
                AutomationEventArgs args = new AutomationEventArgs(
                    AutomationElementIdentifiers.AutomationFocusChangedEvent);
                AutomationInteropProvider.RaiseAutomationEvent(
                    AutomationElementIdentifiers.AutomationFocusChangedEvent,
                    listItem.Provider, args);
            }
        }


        /// <summary>
        /// Responds to a selection change by raising an event.
        /// </summary>
        /// <param name="listItem">The item that has been selected.</param>
        public static void OnSelectionChange(CustomListItem listItem)
        {
            if (AutomationInteropProvider.ClientsAreListening)
            {
                AutomationEventArgs args = new AutomationEventArgs(SelectionItemPatternIdentifiers.ElementSelectedEvent);
                AutomationInteropProvider.RaiseAutomationEvent(SelectionItemPatternIdentifiers.ElementSelectedEvent, 
                    listItem.Provider, args);
            }
        }

// <Snippet101>
        /// <summary>
        /// Responds to an addition to the UI Automation tree structure by raising an event.
        /// </summary>
        /// <param name="list">
        /// The list to which the item was added.
        /// </param>
        /// <remarks>
        /// For the runtime Id of the item, pass 0 because the provider cannot know
        /// what its actual runtime Id is.
        /// </remarks>
        public static void OnStructureChangeAdd(CustomListControl list)
        {
            if (AutomationInteropProvider.ClientsAreListening)
            {
                int[] fakeRuntimeId = { 0 };
                StructureChangedEventArgs args =
                    new StructureChangedEventArgs(StructureChangeType.ChildrenBulkAdded, 
                    fakeRuntimeId);
                AutomationInteropProvider.RaiseStructureChangedEvent(
                    (IRawElementProviderSimple)list.Provider, args);
            }
        }

        /// <summary>
        /// Responds to a removal from the UI Automation tree structure 
        /// by raising an event.
        /// </summary>
        /// <param name="list">
        /// The list from which the item was removed.
        /// </param>
        /// <remarks>
        /// For the runtime Id of the list, pass 0 because the provider cannot know
        /// what its actual runtime ID is.
        /// </remarks>
        public static void OnStructureChangeRemove(CustomListControl list)
        {
            if (AutomationInteropProvider.ClientsAreListening)
            {
                int[] fakeRuntimeId = { 0 };
                StructureChangedEventArgs args =
                    new StructureChangedEventArgs(StructureChangeType.ChildrenBulkRemoved, 
                    fakeRuntimeId);
                AutomationInteropProvider.RaiseStructureChangedEvent(
                    (IRawElementProviderSimple)list.Provider, args);
            }
        }
// </Snippet101>        

        #endregion Helper methods
 
    }  // ListProvider class
}
