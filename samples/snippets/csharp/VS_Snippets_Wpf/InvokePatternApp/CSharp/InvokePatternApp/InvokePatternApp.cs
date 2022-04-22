/******************************************************************************
 * File: InvokePatternApp.cs
 *
 * Description:
 *    This sample demonstrates the UI Automation ExpandCollapse, Invoke, and
 *    Toggle control pattern classes.
 *
 *    The sample consists of a Windows Presentation Foundation (WPF) client and
 *    a WPF target containing a variety of TreeView controls. The client uses the
 *    ExpandCollapse, Invoke, and Toggle control patterns to interact with the
 *    controls in the target.
 *
 *    The functionality demonstrated by the sample includes the ability to
 *    report target control properties and call the supported methods exposed
 *    by the respective control patterns such as invoke, toggle, expand or collapse.
 *
 * Notes:
 *    1. Hidden child controls are not present in the UI Automation tree until
 *       they are created and displayed by expanding the top-level TreeViewItem.
 *    2. Unless a menu item performs an action other than expanding/collapsing,
 *       it does not support the Invoke pattern (ie, the 'Help' menu item in
 *       notepad supports ExpandCollapse but does not support Invoke, however,
 *       the 'About Notepad' menu item under the 'Help' menu supports
 *       InvokePattern as it creates an instance of the 'About Notepad' dialog).
 *
 *
 * This file is part of the Microsoft .NET Framework SDK Code Samples.
 *
 * Copyright (C) Microsoft Corporation.  All rights reserved.
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
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Windows.Threading;
using System.Windows.Media;
using System.IO;

namespace SDKSample
{
    ///------------------------------------------------------------------------
    /// <summary>
    /// Interaction logic for WCP client and Win32 target
    /// </summary>
    ///------------------------------------------------------------------------
    public class InvokePatternApp : Application
    {
        #region Member variables
        private Window clientWindow;
        private AutomationElement rootElement;
        private StackPanel[] clientTreeViews;
        private TextBlock statusText;
        private StackPanel treeviewPanel;
        private StringBuilder elementInfoCompile;
        private ScrollViewer clientScrollViewer;
        private String targetApp;
        // Delegates for updating the client UI based on target application events.
        private delegate void OutputDelegate(string message);
        #endregion Member variables

        #region Target listeners
        ///--------------------------------------------------------------------
        /// <summary>
        /// Listens for a structure changed event in the target.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Since the events are happening on a different thread than the
        /// client we need to use a Dispatcher delegate to handle them.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void ChildElementsAdded(object sender, StructureChangedEventArgs e)
        {
            clientWindow.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new DispatcherOperationCallback(NotifyChildElementsAdded), null);
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// The delegate for the structure changed event in the target.
        /// </summary>
        /// <param name="arg">null argument</param>
        /// <returns>A null object.</returns>
        ///--------------------------------------------------------------------
        private object NotifyChildElementsAdded(object arg)
        {
            FindTreeViewsInTarget();
            return null;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the window closed event in the target.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void onTargetClose(object sender, AutomationEventArgs e)
        {
            clientWindow.Dispatcher.BeginInvoke(
                    DispatcherPriority.Background,
                    new DispatcherOperationCallback(CloseApp), null);
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// The delegate for the window closed event in the target.
        /// </summary>
        /// <param name="arg">null argument</param>
        /// <returns>A null object.</returns>
        ///--------------------------------------------------------------------
        private object CloseApp(object arg)
        {
            clientWindow.Close();
            return (null);
        }
        #endregion Target listeners

        #region Client setup
        ///--------------------------------------------------------------------
        /// <summary>
        /// Initialize both client and target applications.
        /// </summary>
        /// <param name="args">Startup arguments</param>
        ///--------------------------------------------------------------------
        protected override void OnStartup(StartupEventArgs args)
        {
            // Create our informational window
            CreateWindow();

            // Get the root element from our target application.
            // In general, you should try to obtain only direct children of
            // the RootElement. A search for descendants may iterate through
            // hundreds or even thousands of elements, possibly resulting in
            // a stack overflow. If you are attempting to obtain a specific
            // element at a lower level, you should start your search from the
            // application window or from a container at a lower level.
            targetApp =
                System.Windows.Forms.Application.StartupPath + "\\Target.exe";
            rootElement = StartApp(targetApp);
            if (rootElement == null)
            {
                return;
            }

            // Add a structure change listener for the root element.
            StructureChangedEventHandler structureChange =
                    new StructureChangedEventHandler(ChildElementsAdded);
            Automation.AddStructureChangedEventHandler(
                rootElement, TreeScope.Descendants, structureChange);

            // Iterate through the controls in the target application.
            FindTreeViewsInTarget();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Start the target application.
        /// </summary>
        /// <param name="app">The target application.</param>
        /// <remarks>
        /// Starts the application that we are going to use as our
        /// root element for this sample.
        /// </remarks>
        ///--------------------------------------------------------------------
        private AutomationElement StartApp(string app)
        {
            if (File.Exists(app))
            {
                AutomationElement targetElement;

                // Start application.
                Process p = Process.Start(app);

                //// Give application a second to startup.
                Thread.Sleep(2000);

                targetElement = AutomationElement.FromHandle(p.MainWindowHandle);
                if (targetElement == null)
                {
                    return null;
                }
                else
                {
                    AutomationEventHandler targetClosedHandler =
                        new AutomationEventHandler(onTargetClose);
                    Automation.AddAutomationEventHandler(
                        WindowPattern.WindowClosedEvent,
                        targetElement, TreeScope.Element, targetClosedHandler);

                    // Set size and position of target.
                    TransformPattern targetTransformPattern =
                        targetElement.GetCurrentPattern(TransformPattern.Pattern)
                        as TransformPattern;
                    if (targetTransformPattern == null)
                        return null;
                    targetTransformPattern.Resize(550, 400);
                    targetTransformPattern.Move(
                        clientWindow.Left + clientWindow.Width + 25, clientWindow.Top);

                    Output("Target started.");

                    // Return the AutomationElement
                    return (targetElement);
                }
            }
            else
            {
                Output(app + " not found.");
                return (null);
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Creates a client window to which output may be written.
        /// </summary>
        ///--------------------------------------------------------------------
        private void CreateWindow()
        {
            // Define a window.
            clientWindow = new Window();
            clientWindow.Width = 400;
            clientWindow.Height = 600;
            clientWindow.Left = 50;
            clientWindow.Top = 50;

            // Define a ScrollViewer.
            clientScrollViewer = new ScrollViewer();
            clientScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            clientScrollViewer.HorizontalContentAlignment = HorizontalAlignment.Stretch;

            // Add Layout control.
            StackPanel clientStackPanel = new StackPanel();
            StackPanel statusPanel = new StackPanel();
            statusPanel.HorizontalAlignment = HorizontalAlignment.Center;
            treeviewPanel = new StackPanel();

            statusText = new TextBlock();
            statusText.FontWeight = FontWeights.Bold;
            statusText.TextWrapping = TextWrapping.Wrap;

            // Add child elements to the parent StackPanel
            statusPanel.Children.Add(statusText);
            clientStackPanel.Children.Add(statusPanel);
            clientStackPanel.Children.Add(treeviewPanel);

            // Add the StackPanel as the lone Child of the Border
            clientScrollViewer.Content = clientStackPanel;

            // Add the Border as the Content of the Parent Window Object
            clientWindow.Content = clientScrollViewer;
            clientWindow.Show();
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Finds all TreeView controls in the target.
        /// </summary>
        ///--------------------------------------------------------------------
        private void FindTreeViewsInTarget()
        {
            // Initialize the client area used to report target controls.
            treeviewPanel.Children.Clear();
            // Set up our search condition
            PropertyCondition rootTreeViewCondition =
                new PropertyCondition(
                AutomationElement.ControlTypeProperty, ControlType.Tree);
            // Find all controls that support the condition.
            AutomationElementCollection targetTreeViewElements =
                rootElement.FindAll(TreeScope.Children, rootTreeViewCondition);
            if (targetTreeViewElements.Count <= 0)
            {
                Output("TreeView control(s) not found.");
                return;
            }
            // Create an area in the client to report each TreeView in the target.
            clientTreeViews = new StackPanel[targetTreeViewElements.Count];
            for (int elementIndex = 0;
                elementIndex < targetTreeViewElements.Count; elementIndex++)
            {
                clientTreeViews[elementIndex] = new StackPanel();
                Border clientTreeViewBorder = new Border();
                clientTreeViewBorder.BorderThickness = new Thickness(1);
                clientTreeViewBorder.BorderBrush = Brushes.Black;
                clientTreeViewBorder.Margin = new Thickness(5);
                clientTreeViewBorder.Background = Brushes.LightGray;
                clientTreeViewBorder.Child = clientTreeViews[elementIndex];
                treeviewPanel.Children.Add(clientTreeViewBorder);
                // Iterate through the descendant controls of each TreeView.
                FindTreeViewDescendants(
                    targetTreeViewElements[elementIndex], elementIndex);
            }
        }

        //<Snippet1100>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Walks the UI Automation tree of the target and reports the control
        /// type of each element it finds in the control view to the client.
        /// </summary>
        /// <param name="targetTreeViewElement">
        /// The root of the search on this iteration.
        /// </param>
        /// <param name="elementIndex">
        /// The TreeView index for this iteration.
        /// </param>
        /// <remarks>
        /// This is a recursive function that maps out the structure of the
        /// subtree of the target beginning at the AutomationElement passed in
        /// as the rootElement on the first call. This could be, for example,
        /// an application window.
        /// CAUTION: Do not pass in AutomationElement.RootElement. Attempting
        /// to map out the entire subtree of the desktop could take a very
        /// long time and even lead to a stack overflow.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void FindTreeViewDescendants(
            AutomationElement targetTreeViewElement, int treeviewIndex)
        {
            if (targetTreeViewElement == null)
                return;

            AutomationElement elementNode =
                TreeWalker.ControlViewWalker.GetFirstChild(targetTreeViewElement);

            while (elementNode != null)
            {
                Label elementInfo = new Label();
                elementInfo.Margin = new Thickness(0);
                clientTreeViews[treeviewIndex].Children.Add(elementInfo);

                // Compile information about the control.
                elementInfoCompile = new StringBuilder();
                string controlName =
                    (elementNode.Current.Name == "") ?
                    "Unnamed control" : elementNode.Current.Name;
                string autoIdName =
                    (elementNode.Current.AutomationId == "") ?
                    "No AutomationID" : elementNode.Current.AutomationId;

                elementInfoCompile.Append(controlName)
                    .Append(" (")
                    .Append(elementNode.Current.ControlType.LocalizedControlType)
                    .Append(" - ")
                    .Append(autoIdName)
                    .Append(")");

                // Test for the control patterns of interest for this sample.
                object objPattern;
                ExpandCollapsePattern expcolPattern;
                if (true == elementNode.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out objPattern))
                {
                    expcolPattern = objPattern as ExpandCollapsePattern;
                    if (expcolPattern.Current.ExpandCollapseState != ExpandCollapseState.LeafNode)
                    {
                        Button expcolButton = new Button();
                        expcolButton.Margin = new Thickness(0, 0, 0, 5);
                        expcolButton.Height = 20;
                        expcolButton.Width = 100;
                        expcolButton.Content = "ExpandCollapse";
                        expcolButton.Tag = expcolPattern;
                        expcolButton.Click +=
                            new RoutedEventHandler(ExpandCollapse_Click);
                        clientTreeViews[treeviewIndex].Children.Add(expcolButton);
                    }
                }
                TogglePattern togPattern;
                if (true == elementNode.TryGetCurrentPattern(TogglePattern.Pattern, out objPattern))
                {
                    togPattern = objPattern as TogglePattern;
                    Button togButton = new Button();
                    togButton.Margin = new Thickness(0, 0, 0, 5);
                    togButton.Height = 20;
                    togButton.Width = 100;
                    togButton.Content = "Toggle";
                    togButton.Tag = togPattern;
                    togButton.Click += new RoutedEventHandler(Toggle_Click);
                    clientTreeViews[treeviewIndex].Children.Add(togButton);
                }
                InvokePattern invPattern;
                if (true == elementNode.TryGetCurrentPattern(InvokePattern.Pattern, out objPattern))
                {
                    invPattern = objPattern as InvokePattern;
                    Button invButton = new Button();
                    invButton.Margin = new Thickness(0);
                    invButton.Height = 20;
                    invButton.Width = 100;
                    invButton.Content = "Invoke";
                    invButton.Tag = invPattern;
                    invButton.Click += new RoutedEventHandler(Invoke_Click);
                    clientTreeViews[treeviewIndex].Children.Add(invButton);
                }
                // Display compiled information about the control.
                elementInfo.Content = elementInfoCompile;
                Separator sep = new Separator();
                clientTreeViews[treeviewIndex].Children.Add(sep);

                // Iterate to next element.
                // elementNode - Current element.
                // treeviewIndex - Index of parent TreeView.
                FindTreeViewDescendants(elementNode, treeviewIndex);
                elementNode =
                    TreeWalker.ControlViewWalker.GetNextSibling(elementNode);
            }
        }
        //</Snippet1100>

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the Toggle click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        void Toggle_Click(object sender, RoutedEventArgs e)
        {
            Button clientButton = sender as Button;
            TogglePattern t = clientButton.Tag as TogglePattern;
            if (t == null)
                return;
            t.Toggle();
            statusText.Text = "Element toggled " + t.Current.ToggleState.ToString();
        }

        //<Snippet1102>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the Invoke click event on the client control.
        /// The client click handler calls Invoke() on the equivalent target control.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// The Tag property of the FrameworkElement, the client button in this
        /// case, is used to store the InvokePattern object previously obtained
        /// from the associated target control.
        /// </remarks>
        ///--------------------------------------------------------------------
        void Invoke_Click(object sender, RoutedEventArgs e)
        {
            Button clientButton = sender as Button;
            InvokePattern targetInvokePattern = clientButton.Tag as InvokePattern;
            if (targetInvokePattern == null)
                return;
            targetInvokePattern.Invoke();
            statusText.Text = "Button invoked.";
        }
        //</Snippet1102>

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the ExpandCollapse click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void ExpandCollapse_Click(object sender, RoutedEventArgs e)
        {
            Button clientButton = sender as Button;
            ExpandCollapsePattern ec = clientButton.Tag as ExpandCollapsePattern;
            if (ec == null)
                return;
            ExpandCollapseState currentState = ec.Current.ExpandCollapseState;
            try
            {
                if ((currentState == ExpandCollapseState.Collapsed) ||
                    (currentState == ExpandCollapseState.PartiallyExpanded))
                {
                    ec.Expand();
                    statusText.Text = "TreeItem expanded.";
                }
                else if (currentState == ExpandCollapseState.Expanded)
                {
                    ec.Collapse();
                    statusText.Text = "TreeItem collapsed.";
                }
            }
            catch (InvalidOperationException)
            {
                // The current state of the element is LeafNode.
                Output("Unable to expand or collapse the element.");
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Output target information to the client.
        /// </summary>
        /// <param name="message">The feedback string to display.</param>
        /// <remarks>
        /// Since the events are happening on a different thread than the
        /// client we need to use a Dispatcher delegate to handle them.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void Output(string message)
        {
            clientWindow.Dispatcher.BeginInvoke(
                DispatcherPriority.Background,
                new OutputDelegate(NotifyTargetEvent), message);
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// The delegate for the text changed event in the target.
        /// </summary>
        /// <param name="arg">string argument</param>
        ///--------------------------------------------------------------------
        private void NotifyTargetEvent(object arg)
        {
            string message = arg as string;
            statusText.Text = message;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///--------------------------------------------------------------------
        internal sealed class TestMain
        {
            [STAThread()]
            static void Main()
            {
                // Create an instance of the sample class
                // and call its Run() method to start it.
                InvokePatternApp app = new InvokePatternApp();

                app.Run();
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles our application shutdown.
        /// </summary>
        /// <param name="args">Event arguments.</param>
        ///--------------------------------------------------------------------
        protected override void OnExit(ExitEventArgs args)
        {
            if (rootElement != null)
            {
                Automation.RemoveAllEventHandlers();
            }
            base.OnExit(args);
        }
        #endregion Client setup
    }
}
