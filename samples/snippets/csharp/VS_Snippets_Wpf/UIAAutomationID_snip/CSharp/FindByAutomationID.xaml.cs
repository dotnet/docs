/******************************************************************************
 *
 * File: FindByAutomationID.xaml.cs
 *
 * Description:
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
 *****************************************************************************/

using System;
using System.Windows;
using System.Windows.Automation;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;

namespace UIAAutomationID_snip
{
    ///------------------------------------------------------------------------
    /// <summary>
    /// Interaction logic for FindByAutomationID.xaml.
    /// </summary>
    ///------------------------------------------------------------------------
    public partial class FindByAutomationID : Window
    {
        #region private members

        // The target application.
        private AutomationElement targetApp;
        // The queue of objects and associated events.
        private Queue<ElementStore> elementStore = new Queue<ElementStore>();
        private Queue<ElementStore> elementQueue = new Queue<ElementStore>();

        private Thread workerThread;
        private UiaWorker uiaWorker;

        #endregion private members

        public delegate void focusHandlerDelegate();

        ///--------------------------------------------------------------------
        /// <summary>
        /// Initialize the record and playback sample.
        /// </summary>
        ///--------------------------------------------------------------------
        public FindByAutomationID(AutomationElement target)
        {
            InitializeComponent();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Button click event listener.
        /// </summary>
        /// <param name="src">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Starts the target application, initializes the queue, and
        /// registers for events of interest.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void btnStartTarget_Click(object src, RoutedEventArgs e)
        {
            targetApp = StartTargetApp();
            if (targetApp == null)
            {
                throw new ApplicationException("Unable to start target application.");
            }
            btnStartTarget.IsEnabled = false;
        }

        private void StartRecording(object src, RoutedEventArgs e)
        {

            //StartQueue(AutomationElement.FocusedElement);
            RegisterTargetCloseEventListener();
            RegisterAutomationFocusChangeEventListener();
            //RegisterStructureChangeEventListener(targetApp);
        }

        private void StartPlayback(object src, RoutedEventArgs e)
        {
            StringBuilder queueDump = new StringBuilder();
            AutomationElement element;
            foreach (ElementStore item in elementStore)
            {
                queueDump.Append("AutomationID: ").AppendLine(item.AutomationID.ToString());
                queueDump.Append("ClassName: ").AppendLine(item.ClassName);
                queueDump.Append("ControlType: ").AppendLine(item.ControlType);
                queueDump.Append("EventID: ").AppendLine(item.EventID);
                queueDump.AppendLine("Supported Patterns:");
                foreach (AutomationPattern pattern in item.SupportedPatterns)
                {
                    queueDump.AppendLine(pattern.ProgrammaticName);
                }
                queueDump.AppendLine();
                txtFeedback.Text = queueDump.ToString();
                PropertyCondition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, item.AutomationID);
                element = targetApp.FindFirst(TreeScope.Descendants, condition);
                element.SetFocus();
                Thread.Sleep(500);
            }
        }

        internal void StopFocusTracking()
        {
        }

        private void StopRecording(object src, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(workerThread.ThreadState.ToString());
            //focusTracker.RemoveAutomationFocusChangedEventHandler();
            //Thread.Sleep(5000);
            //focusTracker.Dispose();

            //AppForm.Invoke(new MethodInvoker(delegate()
            //{
            //    AppForm.OutputResults(outputStr + Environment.NewLine);
            //}
            //));

            //focusTracker.Dispose();
            //focusTracker.RemoveAutomationFocusChangedEventHandler();
            //Automation.RemoveAllEventHandlers();
            StringBuilder queueDump = new StringBuilder();
            foreach (ElementStore item in elementStore)
            {
                queueDump.Append("AutomationID: ").AppendLine(item.AutomationID.ToString());
                queueDump.Append("ClassName: ").AppendLine(item.ClassName);
                queueDump.Append("ControlType: ").AppendLine(item.ControlType);
                queueDump.Append("EventID: ").AppendLine(item.EventID);
                queueDump.AppendLine("Supported Patterns:");
                foreach (AutomationPattern pattern in item.SupportedPatterns)
                {
                    queueDump.AppendLine(pattern.ProgrammaticName);
                }
                queueDump.AppendLine();
                txtFeedback.Text = queueDump.ToString();
                //PropertyCondition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, item.AutomationID);
                //element = targetApp.FindFirst(TreeScope.Descendants, condition);
                //element.SetFocus();
                //Thread.Sleep(500);
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Place the initial focused element into the queue.
        /// </summary>
        /// <param name="focusedElement">
        /// The initial focused element.
        /// </param>
        ///--------------------------------------------------------------------
        //private void StartQueue(AutomationElement focusedElement)
        //{
        //    ElementStore initialElement = new ElementStore();
        //    initialElement.AutomationID = focusedElement.Current.AutomationId;
        //    initialElement.ClassName = focusedElement.Current.ClassName;
        //    initialElement.ControlType = focusedElement.Current.ControlType.ProgrammaticName;
        //    initialElement.EventID = null;
        //    initialElement.SupportedPatterns = focusedElement.GetSupportedPatterns();
        //    RegisterElementEventListeners(initialElement.SupportedPatterns, focusedElement);
        //    eventTracker.Enqueue(initialElement);
        //}

        private void RegisterElementEventListeners(AutomationPattern[] automationPatterns, AutomationElement focusedElement)
        {
            foreach (AutomationPattern automationPattern in automationPatterns)
            {
                switch (automationPattern.ProgrammaticName)
                {
                    case "ScrollPatternIdentifiers.Pattern":
                        AutomationPropertyChangedEventHandler targetScrollListener =
                            new AutomationPropertyChangedEventHandler(OnTargetScrolled);
                        Automation.AddAutomationPropertyChangedEventHandler(
                            focusedElement,
                            TreeScope.Element,
                            targetScrollListener,
                            ScrollPattern.HorizontallyScrollableProperty);
                        Automation.AddAutomationPropertyChangedEventHandler(focusedElement,
                            TreeScope.Element,
                            targetScrollListener,
                            ScrollPattern.VerticalScrollPercentProperty);
                        break;
                    case "TextPatternIdentifiers.Pattern":
                        AutomationEventHandler targetTextSelectionListener = new AutomationEventHandler(OnTextSelectionChanged);
                        Automation.AddAutomationEventHandler(TextPattern.TextSelectionChangedEvent, focusedElement, TreeScope.Element, targetTextSelectionListener);
                        AutomationEventHandler targetTextChangeListener = new AutomationEventHandler(OnTextChanged);
                        Automation.AddAutomationEventHandler(TextPattern.TextChangedEvent, focusedElement, TreeScope.Descendants | TreeScope.Element, targetTextChangeListener);
                        break;
                    case "RangeValuePatternIdentifiers.Pattern":
                        AutomationPropertyChangedEventHandler targetRangeValueChangeListener =
                            new AutomationPropertyChangedEventHandler(OnRangeValueChange);
                        Automation.AddAutomationPropertyChangedEventHandler(focusedElement,
                            TreeScope.Element, targetRangeValueChangeListener, RangeValuePattern.ValueProperty);
                        break;
                    default:
                        return;
                }
            }
        }

        private void OnRangeValueChange(object src, AutomationPropertyChangedEventArgs e)
        {
            //MessageBox.Show(e.EventId.ProgrammaticName);
        }

        private void OnTextSelectionChanged(object src, AutomationEventArgs e)
        {
            //MessageBox.Show(e.EventId.ProgrammaticName);
        }

        private void OnTextChanged(object src, AutomationEventArgs e)
        {
            //MessageBox.Show(e.EventId.ProgrammaticName);
        }

        private void OnTargetScrolled(object src, AutomationPropertyChangedEventArgs e)
        {
            //MessageBox.Show(e.EventId.ProgrammaticName);
        }

        private void RegisterTargetCloseEventListener()
        {
            AutomationEventHandler targetCloseListener = new AutomationEventHandler(OnTargetClosed);
            Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, targetApp, TreeScope.Element, targetCloseListener);
        }

        private void OnTargetClosed(object src, AutomationEventArgs e)
        {
            //focusTracker.Dispose();
            //focusTracker.RemoveAutomationFocusChangedEventHandler();
            //Automation.RemoveAllEventHandlers();
            //StringBuilder queueDump = new StringBuilder();
            //foreach (ElementStore item in elementStore)
            //{
            //    queueDump.Append("AutomationID: ").AppendLine(item.AutomationID.ToString());
            //    queueDump.Append("ClassName: ").AppendLine(item.ClassName);
            //    queueDump.Append("ControlType: ").AppendLine(item.ControlType);
            //    queueDump.Append("EventID: ").AppendLine(item.EventID);
            //    queueDump.AppendLine("Supported Patterns:");
            //    foreach (AutomationPattern pattern in item.SupportedPatterns)
            //    {
            //        queueDump.AppendLine(pattern.ProgrammaticName);
            //    }
            //    queueDump.AppendLine();
            //}
            //txtFeedback.Text = queueDump.ToString();
        }

        private void btnFindElement_Click(object src, RoutedEventArgs e)
        {
            AutomationElementCollection targetElements = FindElementFromAutomationID(targetApp, tbAutomationID.Text);
            System.Windows.MessageBox.Show(targetElements.Count.ToString());
        }

        // <Snippet100>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Finds all elements in the UI Automation tree that have a specified
        /// AutomationID.
        /// </summary>
        /// <param name="targetApp">
        /// The root element from which to start searching.
        /// </param>
        /// <param name="automationID">
        /// The AutomationID value of interest.
        /// </param>
        /// <returns>
        /// The collection of UI Automation elements that have the specified
        /// AutomationID value.
        /// </returns>
        ///--------------------------------------------------------------------
        private AutomationElementCollection FindElementFromAutomationID(AutomationElement targetApp,
            string automationID)
        {
            return targetApp.FindAll(
                TreeScope.Descendants,
                new PropertyCondition(AutomationElement.AutomationIdProperty, automationID));
        }
        // </Snippet100>

        //private void RegisterAutomationFocusChangeEventListener()
        //{
        //    btnRecord.Dispatcher.BeginInvoke(
        //        System.Windows.Threading.DispatcherPriority.Background,
        //        new focusHandlerDelegate(InitializeFocusTracker));

            //AutomationFocusChangedEventHandler focusChangeListener = new AutomationFocusChangedEventHandler(OnFocusChange);
            //Automation.AddAutomationFocusChangedEventHandler(focusChangeListener);
        //}

        private void RegisterAutomationFocusChangeEventListener()
        {
            //focusTracker = new FocusHandler(targetApp, elementStore);
            ThreadStart focusTrackerWorker = new ThreadStart(FocusTrackerWorkerThread);
            workerThread = new Thread(focusTrackerWorker);
            workerThread.Start();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Function to start UI Automation tasks on a separate thread.
        /// This is the best practice when the application may be
        /// attempting to access its own UI.
        /// </summary>
        ///--------------------------------------------------------------------
        private void FocusTrackerWorkerThread()
        {
            uiaWorker = new UiaWorker(targetApp);
            //focusTracker.PropertyChanged += new PropertyChangedEventHandler(OnFocusChange);
        }

        // <SnippetUIAWorkerThread>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Creates a UI Automation thread.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// UI Automation must be called on a separate thread if the client
        /// application itself could become a target for event handling.
        /// For example, focus tracking is a desktop event that could involve
        /// the client application.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void CreateUIAThread(object sender, EventArgs e)
        {
            // Start another thread to do the UI Automation work.
            ThreadStart threadDelegate = new ThreadStart(CreateUIAWorker);
            Thread workerThread = new Thread(threadDelegate);
            workerThread.Start();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Delegated method for ThreadStart. Creates a UI Automation worker
        /// class that does all UI Automation related work.
        /// </summary>
        ///--------------------------------------------------------------------
        public void CreateUIAWorker()
        {
           uiautoWorker = new FindByAutomationID(targetApp);
        }
        private FindByAutomationID uiautoWorker;

        // </SnippetUIAWorkerThread>

        // <SnippetPlayback>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Function to playback through a series of recorded events calling
        /// a WriteToScript function for each event of interest.
        /// </summary>
        /// <remarks>
        /// A major drawback to using AutomationID for recording user
        /// interactions in a volatile UI is the probability of catastrophic
        /// change in the UI. For example, the //Processes// dialog where items
        /// in the listbox container can change with no input from the user.
        /// This mandates thtat a record and playback application must be
        /// reliant on the tester owning the UI being tested. In other words,
        /// there has to be a contract between the provider and client that
        /// excludes uncontrolled, external applications. The added benefit
        /// is the guarantee that each control in the UI should have an
        /// AutomationID assigned to it.
        ///
        /// This function relies on a UI Automation worker class to create
        /// the System.Collections.Generic.Queue object that stores the
        /// information for the recorded user interactions. This
        /// allows post-processing of the recorded items prior to actually
        /// writing them to a script. If this is not necessary the interaction
        /// could be written to the script immediately.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void Playback(AutomationElement targetApp)
        {
            AutomationElement element;
            foreach(ElementStore storedItem in uiautoWorker.elementQueue)
            {
                PropertyCondition propertyCondition =
                    new PropertyCondition(
                    AutomationElement.AutomationIdProperty, storedItem.AutomationID);
                // Confirm the existence of a control.
                // Depending on the controls and complexity of interaction
                // this step may not be necessary or may require additional
                // functionality. For example, to confirm the existence of a
                // child menu item that had been invoked the parent menu item
                // would have to be expanded.
                element = targetApp.FindFirst(TreeScope.Descendants, propertyCondition);
                if(element == null)
                {
                    // Control not available, unable to continue.
                    // TODO: Handle error condition.
                    return;
                }
                WriteToScript(storedItem.AutomationID, storedItem.EventID);
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Generates script code and outputs the code to a text control in
        /// the client.
        /// </summary>
        /// <param name="automationID">
        /// The AutomationID of the current control.
        /// </param>
        /// <param name="eventID">
        /// The event recorded on that control.
        /// </param>
        ///--------------------------------------------------------------------
        private void WriteToScript(string automationID, string eventID)
        {
            // Script code would be generated and written to an output file
            // as plain text at this point, but for the
            // purposes of this example we just write to the console.
            Console.WriteLine(automationID + " - " + eventID);
        }
        // </SnippetPlayback>

       //private void OnFocusChange(object src, PropertyChangedEventArgs e)
        //{
        //    FocusHandler focusedElement = src as FocusHandler;
        //    ElementStore focusChange = new ElementStore();
        //    try
        //    {
        //        focusChange.AutomationID = focusedElement.CurrentlyFocusedElement.Current.AutomationId;
        //        focusChange.ClassName = focusedElement.CurrentlyFocusedElement.Current.ClassName;
        //        focusChange.ControlType = focusedElement.CurrentlyFocusedElement.Current.ControlType.ProgrammaticName;
        //        focusChange.EventID = e.PropertyName;
        //        focusChange.SupportedPatterns = focusedElement.CurrentlyFocusedElement.GetSupportedPatterns();
        //        //if (elementStore.Contains(focusChange))
        //        //{
        //        //    return;
        //        //}
        //        elementStore.Enqueue(focusChange);
        //    }
        //    catch (NullReferenceException)
        //    {
        //        return;
        //    }
        //}

        private void RegisterStructureChangeEventListener(AutomationElement targetApp)
        {
            StructureChangedEventHandler structureChangeListener = new StructureChangedEventHandler(OnStructureChange);
            Automation.AddStructureChangedEventHandler(targetApp, TreeScope.Descendants, structureChangeListener);
        }

        private void OnStructureChange(object src, StructureChangedEventArgs e)
        {
            AutomationElement source = src as AutomationElement;
            ElementStore structureChange = new ElementStore();
            structureChange.AutomationID = source.Current.AutomationId;
            structureChange.EventID = e.EventId.ProgrammaticName;
            elementStore.Enqueue(structureChange);
        }

        /// <summary>
        /// Starts the target application.
        /// </summary>
        /// <returns>The target automation element.</returns>
        private AutomationElement StartTargetApp()
        {
            try
            {
                // Start target application.
ProcessStartInfo startInfo =
    new ProcessStartInfo(System.Windows.Forms.Application.StartupPath + "\\target.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            startInfo.UseShellExecute = true;

            Process p = Process.Start(startInfo);

                // Give the target application some time to startup.
                // For Win32 applications, WaitForInputIdle can be used instead.
                // Another alternative is to listen for WindowOpened events.
            Thread.Sleep(3000);

                // Return the automation element
                IntPtr windowHandle = p.MainWindowHandle;
                return (AutomationElement.FromHandle(windowHandle));
            }
            catch (FileNotFoundException)
            {
                // To do: error handling
                return null;
            }
        }
    }
}