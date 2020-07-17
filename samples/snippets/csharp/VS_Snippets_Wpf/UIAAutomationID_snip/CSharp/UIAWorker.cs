/*******************************************************************************
 *
 * File: UIAWorker.cs
 *
 * Description: A Class that implements UI Automation functionality
 *              in the form of a focus tracker on a separate thread.
 *
 * For a full description of the sample, see Client.cs.
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
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Diagnostics;
using System.Threading;
using System.Collections;

namespace UIAAutomationID_snip
{
    class UiaWorker
    {
        // Member variables

        AutomationElement targetApp;

        // The desktop.
        private AutomationElement rootElement;

        public Queue<ElementStore> elementQueue = new Queue<ElementStore>();

        public ArrayList controlStore;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="client">The client application.</param>
        /// <param name="target">The target application.</param>
        public UiaWorker(AutomationElement target)
        {
            // Initialize member variables.
            targetApp = target;
            // Get UI Automation root element.
            rootElement = AutomationElement.RootElement;

            RegisterTargetControls();

            Feedback("Worker created; now listening.");
        }

        private void RegisterTargetControls()
        {
            // Create a CacheRequest.
            CacheRequest cacheRequest = new CacheRequest();

            // Set the scope to Element. Remember that the scope is relative to the elements retrieved.
            // When we retrieve children, the properties of each of those children will be cached.
            cacheRequest.TreeScope = TreeScope.Element;

            // Specify properties to cache.
            cacheRequest.Add(AutomationElement.AutomationIdProperty);
            cacheRequest.Add(AutomationElement.NameProperty);

            // Get all immediate children of the target.
            AutomationElementCollection elementCollection;
            using (cacheRequest.Activate())
            {
                elementCollection = targetApp.FindAll(TreeScope.Children, Automation.ControlViewCondition);
            }

            // Put the collection in an ArrayList for added functionality.
            controlStore = new ArrayList();

            foreach (AutomationElement element in elementCollection)
            {
                AddToControlStore(element);
            }

            RegisterForEvents();
        }

        private void RegisterForEvents()
        {
            // Subscribe to events of interest.
            // Do this while a CacheRequest is activated, so that the AutomationElement passed
            // to the event handlers will have cached properties.
            CacheRequest cacheRequest = new CacheRequest();
            cacheRequest.Add(AutomationElement.NameProperty);
            cacheRequest.Add(AutomationElement.ControlTypeProperty);
            cacheRequest.TreeScope = TreeScope.Element;

            using (cacheRequest.Activate())
            {
                // Focus changes are global; we'll get cached properties for all elements that receive focus.
                AutomationFocusChangedEventHandler focusHandler =
                   new AutomationFocusChangedEventHandler(OnFocusChange);
                Automation.AddAutomationFocusChangedEventHandler(focusHandler);

                //foreach (AutomationElement element in controlStore)
                //{
                //    AutomationPattern[] automationPatterns = element.GetSupportedPatterns();
                //    foreach (AutomationPattern automationPattern in automationPatterns)
                //    {
                //        switch (automationPattern.ProgrammaticName)
                //        {
                //            case "InvokePatternIdentifiers.Pattern":
                //                AutomationEventHandler invokeHandler =
                //                    new AutomationEventHandler(OnInvoke);
                //                Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, element, TreeScope.Element, invokeHandler);
                //                break;
                //        }
                //    }
                //}
                //AutomationEventHandler invokeHandler = new AutomationEventHandler(OnInvoke);
                //Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent,
                //    targetApp, TreeScope.Descendants, invokeHandler);
                foreach (AutomationElement element in controlStore)
                {
                    if ((bool)element.GetCurrentPropertyValue(AutomationElement.IsInvokePatternAvailableProperty))
                    {
                        AutomationEventHandler invokeHandler =
                            new AutomationEventHandler(OnInvoke);
                        Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent,
                            element, TreeScope.Element, invokeHandler);
                    }
                    if ((bool)element.GetCurrentPropertyValue(AutomationElement.IsRangeValuePatternAvailableProperty))
                    {
                        //AutomationPropertyChangedEventHandler rangevalueHandler =
                        //    new AutomationPropertyChangedEventHandler(OnRangeValueChange);
                        //Automation.AddAutomationPropertyChangedEventHandler(
                        //    element, TreeScope.Element, rangevalueHandler, RangeValuePattern.
                        //Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent,
                        //    element, TreeScope.Element, invokeHandler));
                    }
                }
            }
        }

        /// <summary>
        /// Adds a top-level window to the collection of cached elements, and subscribes
        /// to window-closed events.
        /// </summary>
        /// <param name="element">The window element.</param>
        private void AddToControlStore(AutomationElement element)
        {
            //// If it's a real window (not Program Manager), subscribe to window-closed event.
            //Object pattern;
            //if (element.TryGetCachedPattern(WindowPattern.Pattern, out pattern))
            //{
            //    Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, element,
            //            TreeScope.Element, new AutomationEventHandler(OnWindowClosed));
            //}
            // Add it to our collection.
            controlStore.Add(element);
        }

        /// <summary>
        /// Handle invoke events of interest.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Some controls that have not implemented UI Automation correctly
        /// may fire spurious events. For example, a WinForms button will
        /// fire an InvokedEvent on a mouse-down and then another series of
        /// InvokedEvents on the subsequent mouse-up.</remarks>
        private void OnInvoke(object src, AutomationEventArgs e)
        {
            DateTime invokeTime = DateTime.Now;

            Feedback("Invoke event.");

            AutomationElement invokedElement = src as AutomationElement;

            Feedback(invokedElement.Current.Name);

            ElementStore invokeEvent = new ElementStore();
            try
            {
                invokeEvent.AutomationID = invokedElement.Current.AutomationId;
                invokeEvent.ClassName = invokedElement.Current.ClassName;
                invokeEvent.ControlType = invokedElement.Current.ControlType.ProgrammaticName;
                invokeEvent.EventID = e.EventId.ProgrammaticName;
                invokeEvent.SupportedPatterns = invokedElement.GetSupportedPatterns();
                invokeEvent.EventTime = invokeTime;
                elementQueue.Enqueue(invokeEvent);
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        /// <summary>
        /// Handle the event.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
        {
            DateTime invokeTime = DateTime.Now;

            Feedback("Focus changed.");

            AutomationElement focusedElement = src as AutomationElement;

            AutomationElement topLevelWindow =
                GetTopLevelWindow(focusedElement);

            if (topLevelWindow != targetApp)
            {
                return;
            }

            Feedback(focusedElement.Current.Name);

            ElementStore focusChange = new ElementStore();
            try
            {
                focusChange.AutomationID = focusedElement.Current.AutomationId;
                focusChange.ClassName = focusedElement.Current.ClassName;
                focusChange.ControlType = focusedElement.Current.ControlType.ProgrammaticName;
                focusChange.EventID = e.EventId.ProgrammaticName;
                focusChange.SupportedPatterns = focusedElement.GetSupportedPatterns();
                focusChange.EventTime = invokeTime;
                elementQueue.Enqueue(focusChange);
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Retrieves the top-level window that contains the
        /// UI Automation element of interest.
        /// </summary>
        /// <param name="element">The contained element.</param>
        /// <returns>The containing top-level window element.</returns>
        ///--------------------------------------------------------------------
        private AutomationElement GetTopLevelWindow(AutomationElement element)
        {
            TreeWalker walker = TreeWalker.ControlViewWalker;
            AutomationElement elementParent;
            AutomationElement node = element;
            if (node == rootElement)
            {
                return node;
            }
            do
            {
                elementParent = walker.GetParent(node);
                if (elementParent == rootElement)
                {
                    break;
                }
                node = elementParent;
            }
            while (true);
            return node;
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~UiaWorker()
        {
        }

        public void Shutdown()
        {
            Automation.RemoveAllEventHandlers();
        }

        /// <summary>
        /// Prints a line of text to the textbox.
        /// </summary>
        /// <param name="outputStr">The string to print.</param>
        /// <remarks>Must use Invoke so that UI is not being called directly from this thread.</remarks>
        private void Feedback(string outputStr)
        {
        }
    }
}
