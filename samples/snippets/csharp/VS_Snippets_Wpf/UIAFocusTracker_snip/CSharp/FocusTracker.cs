/**************************************************************************************************
 *
 * File: FocusTracker
 *
 * Description: This is a simple console application that might be used as a starting-point for an
 * application that uses UI Automation to track events on the desktop.
 *
 * The program announces when the input focus changes. If the focus moves to a different application window,
 * the caption of the window is announced. If the focus moves within an application window, the type and name
 * of the control being read are announced.
 *
 * To know when the focus switches from one application to another, the program keeps a list of the runtime
 * identifiers of all open top-level windows. In response to each focus-changed event, a TreeWalker is used
 * to find the parent window, and that window is compared with the last window that had focus.
 *
 * The program subscribes to three event types:
 *
 *  -- Structure changed. The only event of interest is the addition of a new top-level window.
 *  -- Focus changed. All events are captured.
 * --  Window closed. When a top-level window is closed, its runtime ID is removed from the list.
 *
 * For simplicity, no caching is done. A full-scale application would likely cache all immediate children
 * of an application window as soon as that window received focus.
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
using System.Windows.Automation;
using System.Timers;
using System.Collections;
using System.Diagnostics;

namespace FocusTracker
{
    class Program
    {
        public static void Main(string[] args)
        {
            Reader reader = new Reader();
            Console.ReadLine();
            Automation.RemoveAllEventHandlers();
        }
    }

    class Reader
    {
        AutomationElement elementRoot;
        AutomationElement lastTopLevelWindow = null;
        //AutomationFocusChangedEventHandler onFocusChanged;
        ArrayList savedRuntimeIds;
        //StructureChangedEventHandler onStructureChanged;
        AutomationEventHandler onWindowClosed = null;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Reader()
        {
            // Get UI Automation root element.
            elementRoot = AutomationElement.RootElement;

            // Make a list of runtime IDs of top-level windows.
            // An alternative would be to keep a list of process IDs. However, it is somewhat more difficult
            // to track the termination of processes, because the only information available from a
            // window-closed event is the runtime ID.

            savedRuntimeIds = new ArrayList();
            AutomationElementCollection elementCollection = elementRoot.FindAll(TreeScope.Children, Condition.TrueCondition);

            // Add each application window to the list and subscribe it to the WindowClosedEvent handler.
            onWindowClosed = new AutomationEventHandler(WindowClosedHandler);
            foreach (AutomationElement element in elementCollection)
            {
               int[] rid = (int[])element.GetCurrentPropertyValue(AutomationElement.RuntimeIdProperty);
               if (RuntimeIdListed(rid, savedRuntimeIds) < 0)
                {
                    savedRuntimeIds.Add(rid);
                    AddToWindowHandler(element);
                }
            }

            // Add other event handlers.
            // <Snippet104>
            // elementRoot is an AutomationElement.
            Automation.AddStructureChangedEventHandler(elementRoot, TreeScope.Children,
                new StructureChangedEventHandler(OnStructureChanged));
            // </Snippet104>

            Automation.AddAutomationFocusChangedEventHandler(
                new AutomationFocusChangedEventHandler(OnFocusChanged));
        }

// <Snippet106>
        private void OnFocusChanged(object src, AutomationFocusChangedEventArgs e)
        {
            AutomationElement elementFocused = src as AutomationElement;
            // TODO: Do something in response to the focus change.
        }
// </Snippet106>

// <Snippet105>
        /// <summary>
        /// Handles structure-changed events. If a new app window has been added, this method ensures
        /// it's in the list of runtime IDs and subscribed to window-close events.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// An exception can be thrown by the UI Automation core if the element disappears
        /// before it can be processed -- for example, if a menu item is only briefly visible.
        /// This exception cannot be caught here because it crosses native/managed boundaries.
        /// In the debugger, you can ignore it and continue execution. The exception does not cause
        /// a break when the executable is being run.
        /// </remarks>
        private void OnStructureChanged(object sender, StructureChangedEventArgs e)
        {
            AutomationElement element = sender as AutomationElement;

            if (e.StructureChangeType == StructureChangeType.ChildAdded)
            {
                Object windowPattern;
                if (false == element.TryGetCurrentPattern(WindowPattern.Pattern, out windowPattern))
                {
                    return;
                }
                int[] rid = e.GetRuntimeId();
                if (RuntimeIdListed(rid, savedRuntimeIds) < 0)
                {
                    AddToWindowHandler(element);
                    savedRuntimeIds.Add(rid);
                }
            }
        }
// </Snippet105>

// <Snippet101>
        /// <summary>
        /// Handles window-closed events. Removes the window from the top-level window list.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// runtimeIds is an ArrayList that contains the runtime IDs of all top-level windows.
        /// </remarks>
        private void WindowClosedHandler(object sender, AutomationEventArgs e)
        {
            WindowClosedEventArgs windowEventArgs = (WindowClosedEventArgs)e;
            int[] runtimeIdentifiers = windowEventArgs.GetRuntimeId();
            int index = RuntimeIdListed(runtimeIdentifiers, savedRuntimeIds);
            if (index >= 0)
            {
                savedRuntimeIds.RemoveAt(index);
                Console.WriteLine("Window closed.");
            }
        }

        /// <summary>
        /// Ascertains whether the window is in the list.
        /// </summary>
        /// <param name="rid">Runtime ID of the window.</param>
        /// <returns>Index of the ID in the list, or -1 if it is not listed.</returns>
        /// <remarks>
        /// runtimeIds is an ArrayList that contains the runtime IDs of all top-level windows.
        /// </remarks>
// <Snippet103>
        private int RuntimeIdListed(int[] runtimeId, ArrayList runtimeIds)
        {
            for (int x = 0; x < runtimeIds.Count; x++)
            {
                int[] listedId = (int[])runtimeIds[x];
                if (Automation.Compare(listedId, runtimeId))
                {
                    return x;
                }
            }
            return -1;
        }
// </Snippet103>

// </Snippet101>

        /// <summary>
        /// Gets the caption of a window.
        /// </summary>
        /// <param name="elementWindow">The window element.</param>
        /// <returns>The caption.</returns>
        private string GetTitle(AutomationElement elementWindow)
        {
            AutomationElement elementTitle = null;
            Condition cond =
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TitleBar);
            elementTitle = elementWindow.FindFirst(TreeScope.Children, cond);
            if (elementTitle != null)
            {
                return elementTitle.Current.Name;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Subscribes a window element to the window-closed event.
        /// </summary>
        /// <param name="element">The window element.</param>
        private void AddToWindowHandler(AutomationElement element)
        {
            Object windowPattern;
            if (element.TryGetCurrentPattern(WindowPattern.Pattern, out windowPattern))
            {
                Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, element,
                    TreeScope.Element, onWindowClosed);
            }
        }

// <Snippet102>
        /// <summary>
        /// Retrieves the top-level window that contains the specified UI Automation element.
        /// </summary>
        /// <param name="element">The contained element.</param>
        /// <returns>The containing top-level window element.</returns>
        private AutomationElement GetTopLevelWindow(AutomationElement element)
        {
            TreeWalker walker = TreeWalker.ControlViewWalker;
            AutomationElement elementParent;
            AutomationElement node = element;
            if (node == elementRoot) return node;
            do
            {
                elementParent = walker.GetParent(node);
                if (elementParent == AutomationElement.RootElement) break;
                node = elementParent;
            }
            while (true);
            return node;
        }
        // </Snippet102>
    } // Reader class.
}  // FocusTracker namespace
