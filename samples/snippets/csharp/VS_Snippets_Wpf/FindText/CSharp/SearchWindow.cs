/*****************************************************************************************
 * File: FindText.cs
 *
 * Description:
 *    This sample demonstrates the UI Automation TextPattern and TextPatternRange classes.
 *
 *    The sample consists of a Windows Presentation Foundation (WPF) client and the choice
 *    of a WPF FlowDocumentReader target or a Win32 WordPad target. The client uses the
 *    TextPattern control pattern and the TextPatternRange class to interact with the text
 *    controls in either target.
 *
 *    The functionality demonstrated by the sample includes the ability to search for and
 *    select text, expand a selection to a specific TextUnit, navigate by TextUnit, access
 *    embedded objects within a selection, and access the enclosing element of a selection.
 *
 *    Note: Three WPF documents, a RichText document, and a plain text document are provided
 *          in the Content folder of the TextProvider project.
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
 ******************************************************************************************/

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Diagnostics;
using System.IO;
using System.Windows.Automation.Text;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media;

namespace SDKSample
{
    ///--------------------------------------------------------------------
    /// <summary>
    /// Interaction logic for client and target
    /// </summary>
    ///--------------------------------------------------------------------
    public class SearchWindow
    {
        #region Member Variables
        // Client application window.
        private Window clientWindow;
        // Container for all client controls.
        private DockPanel clientDockPanel;
        // Target application window.
        private AutomationElement targetWindow;
        // Target text control.
        private AutomationElement targetDocument;
        // Text pattern obtained from the target text control.
        private TextPattern targetTextPattern;
        // Text range for entire target text control.
        private TextPatternRange documentRange;
        // Text range for current selection in target text control.
        private TextPatternRange searchRange;
        // Target applications based on underlying framework.
        private Button startWPFTargetButton;
        private Button startW32TargetButton;
        private string WPFTarget;
        private string W32Target;
        // Find the target text control.
        private Button findEditButton;
        // Display target status.
        private Label targetResult;
        // Layout grid for client controls.
        private Grid infoGrid;
        // String to search for in the target text control.
        private TextBox searchString;
        // Depending on the location of the selection in the target text
        // control, the client can search forward or backward for the
        // search string.
        private Button searchBackwardButton;
        private Button searchForwardButton;
        // Direction of search.
        private bool searchBackward;
        // Expand the target text selection by the specified text unit.
        private ComboBox expandHighlight;
        // Move the target text selection by the specified text unit.
        private ComboBox navigateTarget;
        private TextUnit navigationUnit;
        // Display the target text selection and attributes.
        private Label targetSelectionLabel;
        private Label targetSelectionAttributeLabel;
        private TextBox targetSelection;
        private TextBox targetSelectionAttributes;
        // Display target text selection details such as child and enclosing unit.
        private TextBox targetSelectionDetails;
        // Delegates for updating the client UI based on target application events.
        private delegate void TextChangeDelegate(string message);
        private delegate void SelectionChangeDelegate();
        private delegate void ProviderCloseDelegate();
        // Target applications.
        private enum targetApplication { FlowDocument, WordPad }
        // Search and navigation directions.
        private enum traversalDirection { Backward, Forward }
        #endregion Member Variables

        #region Client Setup
        ///--------------------------------------------------------------------
        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <remarks>
        /// Initialize the WPF client application.
        /// </remarks>
        ///--------------------------------------------------------------------
        public SearchWindow()
        {
            // Specify the target applications.
            WPFTarget =
                System.Windows.Forms.Application.StartupPath + "\\TextProvider.exe";
            W32Target = "WordPad.exe";

            // Initialize search direction.
            // Search direction buttons are enabled or disabled based on this value.
            searchBackward = false;

            // Layout the client controls.
            try
            {
               // Specs for Window.
                double clientHeight = 600;
                double clientWidth = 550;

                // Specs for TextBox.
                int maxSearchLines = 1;
                int maxSearchLength = 25;

                // Specs for Buttons.
                double buttonWidth = 140;

                // Instantiate the client window and set location and size.
                clientWindow = new Window();
                clientWindow.Height = clientHeight;
                clientWindow.Width = clientWidth;
                clientWindow.Left = SystemParameters.WorkArea.Location.X + 50;
                clientWindow.Top = SystemParameters.WorkArea.Location.Y + 50;
                clientWindow.Title = "Find Text";
                clientWindow.WindowStyle = WindowStyle.ToolWindow;

                // Create a dock panel to hold all controls.
                clientDockPanel = new DockPanel();
                clientDockPanel.Margin = new Thickness(10);
                clientDockPanel.LastChildFill = true;

                // Add the start target buttons.
                startWPFTargetButton = new Button();
                startWPFTargetButton.Width = buttonWidth;
                startWPFTargetButton.Content = "Start _FlowDocument (WPF)";
                startWPFTargetButton.Tag = targetApplication.FlowDocument;
                startWPFTargetButton.Click +=
                    new RoutedEventHandler(StartTargetApplication_Click);
                startW32TargetButton = new Button();
                startW32TargetButton.Width = buttonWidth;
                startW32TargetButton.Content = "Start _WordPad (Win32)";
                startW32TargetButton.Tag = targetApplication.WordPad;
                startW32TargetButton.Click +=
                    new RoutedEventHandler(StartTargetApplication_Click);
                DockPanel.SetDock(startWPFTargetButton, Dock.Top);
                DockPanel.SetDock(startW32TargetButton, Dock.Top);
                clientDockPanel.Children.Add(startWPFTargetButton);
                clientDockPanel.Children.Add(startW32TargetButton);

                // Add the find text control button.
                findEditButton = new Button();
                findEditButton.Width = buttonWidth;
                findEditButton.Content = "_Find text provider";
                findEditButton.Click +=
                    new RoutedEventHandler(FindTextProvider_Click);
                findEditButton.Visibility = Visibility.Collapsed;
                DockPanel.SetDock(findEditButton, Dock.Top);
                clientDockPanel.Children.Add(findEditButton);

                // Add the target status label.
                targetResult = new Label();
                targetResult.Content = "";
                targetResult.BorderThickness = new Thickness(1);
                targetResult.BorderBrush = Brushes.Black;
                targetResult.HorizontalAlignment = HorizontalAlignment.Center;
                targetResult.Margin = new Thickness(0, 0, 0, 10);
                targetResult.Visibility = Visibility.Hidden;
                DockPanel.SetDock(targetResult, Dock.Top);
                clientDockPanel.Children.Add(targetResult);

                // Add the client control layout grid.
                infoGrid = new Grid();
                infoGrid.HorizontalAlignment = HorizontalAlignment.Center;
                infoGrid.VerticalAlignment = VerticalAlignment.Top;
                infoGrid.ShowGridLines = false; ;
                infoGrid.Visibility = Visibility.Collapsed;
                infoGrid.MinWidth = 400;
                // Define the columns.
                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                infoGrid.ColumnDefinitions.Add(colDef1);
                infoGrid.ColumnDefinitions.Add(colDef2);
                // Define the rows.
                RowDefinition rowDef1 = new RowDefinition();
                rowDef1.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef2 = new RowDefinition();
                rowDef2.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef3 = new RowDefinition();
                rowDef3.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef4 = new RowDefinition();
                rowDef4.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef5 = new RowDefinition();
                rowDef5.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef6 = new RowDefinition();
                rowDef6.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef7 = new RowDefinition();
                rowDef7.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef8 = new RowDefinition();
                rowDef8.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef9 = new RowDefinition();
                rowDef9.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef10 = new RowDefinition();
                rowDef10.Height = new GridLength(1, GridUnitType.Auto);
                RowDefinition rowDef11 = new RowDefinition();
                rowDef11.Height = new GridLength(1, GridUnitType.Auto);
                infoGrid.RowDefinitions.Add(rowDef1);
                infoGrid.RowDefinitions.Add(rowDef2);
                infoGrid.RowDefinitions.Add(rowDef3);
                infoGrid.RowDefinitions.Add(rowDef4);
                infoGrid.RowDefinitions.Add(rowDef5);
                infoGrid.RowDefinitions.Add(rowDef6);
                infoGrid.RowDefinitions.Add(rowDef7);
                infoGrid.RowDefinitions.Add(rowDef8);
                infoGrid.RowDefinitions.Add(rowDef9);
                infoGrid.RowDefinitions.Add(rowDef10);
                infoGrid.RowDefinitions.Add(rowDef11);

                // Define the content of the cells.
                // Row 1 - Search string details.
                searchString = new TextBox();
                searchString.Name = "SearchString";
                searchString.MaxLines = maxSearchLines;
                searchString.MaxLength = maxSearchLength;
                searchString.Width = 200;
                //searchString.Height = 25;
                searchString.TextChanged +=
                    new TextChangedEventHandler(SearchString_Change);
                searchString.IsEnabled = false;
                Grid.SetRow(searchString, 0);
                Grid.SetColumn(searchString, 1);
                Label searchLabel = new Label();
                searchLabel.Target = searchString;
                searchLabel.Content = "_Search for: ";
                searchLabel.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(searchLabel, 0);
                Grid.SetColumn(searchLabel, 0);
                infoGrid.Children.Add(searchLabel);
                infoGrid.Children.Add(searchString);

                // Row 2 - Search direction buttons.
                searchBackwardButton = new Button();
                searchBackwardButton.Width = buttonWidth;
                //searchBackwardButton.Height = buttonHeight;
                searchBackwardButton.Content = "Search _Backward";
                searchBackwardButton.Tag = traversalDirection.Backward;
                searchBackwardButton.Click +=
                    new RoutedEventHandler(SearchDirection_Click);
                searchBackwardButton.Margin = new Thickness(0, 0, 0, 10);
                searchBackwardButton.IsEnabled = false;
                Grid.SetRow(searchBackwardButton, 1);
                Grid.SetColumn(searchBackwardButton, 0);
                searchForwardButton = new Button();
                searchForwardButton.Width = buttonWidth;
                //searchForwardButton.Height = buttonHeight;
                searchForwardButton.Content = "Search _Forward";
                searchForwardButton.Tag = traversalDirection.Forward;
                searchForwardButton.Click +=
                    new RoutedEventHandler(SearchDirection_Click);
                searchForwardButton.Margin = new Thickness(0, 0, 0, 10);
                searchForwardButton.IsEnabled = false;
                Grid.SetRow(searchForwardButton, 1);
                Grid.SetColumn(searchForwardButton, 1);
                infoGrid.Children.Add(searchBackwardButton);
                infoGrid.Children.Add(searchForwardButton);

                // Row 3 - Target selection.
                targetSelectionLabel = new Label();
                targetSelectionLabel.Target = targetSelection;
                targetSelectionLabel.Content = "Currently selected:";
                Grid.SetRow(targetSelectionLabel, 2);
                Grid.SetColumn(targetSelectionLabel, 0);
                Grid.SetColumnSpan(targetSelectionLabel, 2);
                infoGrid.Children.Add(targetSelectionLabel);
                // Row 4.
                targetSelection = new TextBox();
                targetSelection.TextWrapping = TextWrapping.Wrap;
                targetSelection.MaxWidth = 400;
                targetSelection.Height = 100;
                targetSelection.VerticalScrollBarVisibility =
                    ScrollBarVisibility.Auto;
                targetSelection.IsReadOnly = true;
                targetSelection.Margin = new Thickness(0, 0, 0, 0);
                Grid.SetRow(targetSelection, 3);
                Grid.SetColumn(targetSelection, 0);
                Grid.SetColumnSpan(targetSelection, 2);
                infoGrid.Children.Add(targetSelection);

                // Row 5 - Target selection attributes.
                targetSelectionAttributeLabel = new Label();
                targetSelectionAttributeLabel.Target = targetSelection;
                targetSelectionAttributeLabel.Content = "Attribute values: ";
                Grid.SetRow(targetSelectionAttributeLabel, 4);
                Grid.SetColumn(targetSelectionAttributeLabel, 0);
                Grid.SetColumnSpan(targetSelectionAttributeLabel, 2);
                infoGrid.Children.Add(targetSelectionAttributeLabel);
                // Row 6.
                targetSelectionAttributes = new TextBox();
                targetSelectionAttributes.TextWrapping = TextWrapping.Wrap;
                targetSelectionAttributes.MaxWidth = 400;
                targetSelectionAttributes.Height = 100;
                targetSelectionAttributes.VerticalScrollBarVisibility =
                    ScrollBarVisibility.Auto;
                targetSelectionAttributes.IsReadOnly = true;
                targetSelectionAttributes.Margin = new Thickness(0, 0, 0, 10);
                Grid.SetRow(targetSelectionAttributes, 5);
                Grid.SetColumn(targetSelectionAttributes, 0);
                Grid.SetColumnSpan(targetSelectionAttributes, 2);
                infoGrid.Children.Add(targetSelectionAttributes);

                // Row 7 - Navigate target details.
                navigateTarget = new ComboBox();
                navigateTarget.Width = buttonWidth;
                navigateTarget.Items.Add(TextUnit.Character);
                navigateTarget.Items.Add(TextUnit.Format);
                navigateTarget.Items.Add(TextUnit.Word);
                navigateTarget.Items.Add(TextUnit.Line);
                navigateTarget.Items.Add(TextUnit.Paragraph);
                navigateTarget.Items.Add(TextUnit.Page);
                navigateTarget.SelectedIndex = 0;
                navigateTarget.SelectionChanged +=
                    new SelectionChangedEventHandler(NavigationUnit_Change);
                Grid.SetRow(navigateTarget, 6);
                Grid.SetColumn(navigateTarget, 1);
                Label navigateLabel = new Label();
                navigateLabel.Target = navigateTarget;
                navigateLabel.Content = "_Navigate target by text unit of: ";
                navigateLabel.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRow(navigateLabel, 6);
                Grid.SetColumn(navigateLabel, 0);
                infoGrid.Children.Add(navigateLabel);
                infoGrid.Children.Add(navigateTarget);

                // Row 8 - Navigate target direction buttons.
                Button navigateBackwardButton = new Button();
                navigateBackwardButton.Width = buttonWidth;
                navigateBackwardButton.Content = "_Backward";
                navigateBackwardButton.Tag = traversalDirection.Backward;
                navigateBackwardButton.Click += new RoutedEventHandler(Navigate_Click);
                navigateBackwardButton.Margin = new Thickness(0, 0, 0, 10);
                Grid.SetRow(navigateBackwardButton, 7);
                Grid.SetColumn(navigateBackwardButton, 0);
                Button navigateForwardButton = new Button();
                navigateForwardButton.Width = buttonWidth;
                navigateForwardButton.Content = "_Forward";
                navigateForwardButton.Tag = traversalDirection.Forward;
                navigateForwardButton.Click += new RoutedEventHandler(Navigate_Click);
                navigateForwardButton.Margin = new Thickness(0, 0, 0, 10);
                Grid.SetRow(navigateForwardButton, 7);
                Grid.SetColumn(navigateForwardButton, 1);
                infoGrid.Children.Add(navigateBackwardButton);
                infoGrid.Children.Add(navigateForwardButton);

                // Row 9 - Expand the target selection controls.
                expandHighlight = new ComboBox();
                expandHighlight.Width = buttonWidth;
                expandHighlight.Items.Add("");
                expandHighlight.Items.Add("None");
                expandHighlight.Items.Add(TextUnit.Character);
                expandHighlight.Items.Add(TextUnit.Format);
                expandHighlight.Items.Add(TextUnit.Word);
                expandHighlight.Items.Add(TextUnit.Line);
                expandHighlight.Items.Add(TextUnit.Paragraph);
                expandHighlight.Items.Add(TextUnit.Page);
                expandHighlight.Items.Add(TextUnit.Document);
                expandHighlight.SelectedIndex = 0;
                expandHighlight.SelectionChanged +=
                    new SelectionChangedEventHandler(ExpandToTextUnit_Change);
                expandHighlight.Margin = new Thickness(0, 0, 0, 10);
                Grid.SetRow(expandHighlight, 8);
                Grid.SetColumn(expandHighlight, 1);
                Label expandLabel = new Label();
                expandLabel.Target = expandHighlight;
                expandLabel.Content = "_Expand selection to text unit of: ";
                expandLabel.VerticalAlignment = VerticalAlignment.Center;
                expandLabel.Margin = new Thickness(0, 0, 0, 10);
                Grid.SetRow(expandLabel, 8);
                Grid.SetColumn(expandLabel, 0);
                infoGrid.Children.Add(expandLabel);
                infoGrid.Children.Add(expandHighlight);

                // Row 10 - target selection details such as child elements
                //         and enclosing unit.
                targetSelectionDetails = new TextBox();
                targetSelectionDetails.Height = 100;
                targetSelectionDetails.VerticalScrollBarVisibility =
                    ScrollBarVisibility.Auto;
                targetSelectionDetails.IsReadOnly = true;
                Grid.SetRow(targetSelectionDetails, 9);
                Grid.SetColumn(targetSelectionDetails, 0);
                Grid.SetColumnSpan(targetSelectionDetails, 2);
                infoGrid.Children.Add(targetSelectionDetails);

                // Row 11 - get the child elements and the enclosing unit
                //         of the target selection.
                Button getChildren = new Button();
                getChildren.Width = buttonWidth;
                getChildren.Content = "Get children of selection";
                getChildren.Click += new RoutedEventHandler(GetChildren_Click);
                Grid.SetRow(getChildren, 10);
                Grid.SetColumn(getChildren, 0);
                Button getEnclosingElement = new Button();
                getEnclosingElement.Width = buttonWidth;
                getEnclosingElement.Content = "Get enclosing element";
                getEnclosingElement.Click += new RoutedEventHandler(GetEnclosingElement_Click);
                Grid.SetRow(getEnclosingElement, 10);
                Grid.SetColumn(getEnclosingElement, 1);
                infoGrid.Children.Add(getChildren);
                infoGrid.Children.Add(getEnclosingElement);

                // Add the grid to the dock panel.
                DockPanel.SetDock(infoGrid, Dock.Top);
                clientDockPanel.Children.Add(infoGrid);

                // Add the dock panel to the window.
                clientWindow.Content = clientDockPanel;
                clientWindow.Show();
            }
            // Do we successfully create the client app?
            catch (InvalidOperationException)
            {
                // TODO: error handling.
                return;
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the Start Application button click.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Starts the application that we are going to use for as our
        /// root element for this sample.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void StartTargetApplication_Click(object sender, RoutedEventArgs e)
        {
            Button targetOption = (Button)sender;

            // Start the target selected by the user.
            if ((targetApplication)targetOption.Tag == targetApplication.WordPad)
            {
                targetWindow = StartApp(W32Target);
            }
            else
            {
                targetWindow = StartApp(WPFTarget);
            }

            // Target is not available.
            Debug.Assert(targetWindow != null);

            // Set a listener for the window closed event on the target.
            Automation.AddAutomationEventHandler(
                WindowPattern.WindowClosedEvent,
                targetWindow, TreeScope.Element, OnTargetClose);

            // Set size and position of target.
            // Since the target is started and manipulated from the client
            // and both windows show UI changes this section of code just
            // ensures neither window obscures the other.
            TransformPattern targetTransformPattern =
                targetWindow.GetCurrentPattern(TransformPattern.Pattern)
                as TransformPattern;
            targetTransformPattern.Resize(clientWindow.Width, clientWindow.Height);
            targetTransformPattern.Move(
                clientWindow.Left + clientWindow.Width + 25, clientWindow.Top);

            // Set visibility of client controls.
            startWPFTargetButton.Visibility = Visibility.Collapsed;
            startW32TargetButton.Visibility = Visibility.Collapsed;
            findEditButton.Visibility = Visibility.Visible;
            targetResult.Visibility = Visibility.Visible;
        }

        //<SnippetStartApp>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Starts the target application.
        /// </summary>
        /// <param name="app">
        /// The application to start.
        /// </param>
        /// <returns>The automation element for the app main window.</returns>
        /// <remarks>
        /// Three WPF documents, a rich text document, and a plain text document
        /// are provided in the Content folder of the TextProvider project.
        /// </remarks>
        ///--------------------------------------------------------------------
        private AutomationElement StartApp(string app)
        {
            // Start application.
            Process p = Process.Start(app);

            // Give the target application some time to start.
            // For Win32 applications, WaitForInputIdle can be used instead.
            // Another alternative is to listen for WindowOpened events.
            // Otherwise, an ArgumentException results when you try to
            // retrieve an automation element from the window handle.
            Thread.Sleep(2000);

            targetResult.Content =
                WPFTarget +
                " started. \n\nPlease load a document into the target " +
                "application and click the 'Find edit control' button above. " +
                "\n\nNOTE: Documents can be found in the 'Content' folder of the FindText project.";
            targetResult.Background = Brushes.LightGreen;

            // Return the automation element for the app main window.
            return (AutomationElement.FromHandle(p.MainWindowHandle));
        }
        //</SnippetStartApp>
        #endregion Client Setup

        #region Target Text Info
        //<SnippetFindTextProvider>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Finds the text control in our target.
        /// </summary>
        /// <param name="src">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Initializes the TextPattern object and event handlers.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void FindTextProvider_Click(object src, RoutedEventArgs e)
        {
            //<SnippetTextPatternPattern>
            // Set up the conditions for finding the text control.
            PropertyCondition documentControl = new PropertyCondition(
                AutomationElement.ControlTypeProperty,
                ControlType.Document);
            PropertyCondition textPatternAvailable = new PropertyCondition(
                AutomationElement.IsTextPatternAvailableProperty, true);
            AndCondition findControl =
                new AndCondition(documentControl, textPatternAvailable);

            // Get the Automation Element for the first text control found.
            // For the purposes of this sample it is sufficient to find the
            // first text control. In other cases there may be multiple text
            // controls to sort through.
            targetDocument =
                targetWindow.FindFirst(TreeScope.Descendants, findControl);

            // Didn't find a text control.
            if (targetDocument == null)
            {
                targetResult.Content =
                    WPFTarget +
                    " does not contain a Document control type.";
                targetResult.Background = Brushes.Salmon;
                startWPFTargetButton.IsEnabled = false;
                return;
            }

            // Get required control patterns
            targetTextPattern =
                targetDocument.GetCurrentPattern(
                TextPattern.Pattern) as TextPattern;

            // Didn't find a text control that supports TextPattern.
            if (targetTextPattern == null)
            {
                targetResult.Content =
                    WPFTarget +
                    " does not contain an element that supports TextPattern.";
                targetResult.Background = Brushes.Salmon;
                startWPFTargetButton.IsEnabled = false;
                return;
            }
            //</SnippetTextPatternPattern>

            // Text control is available so display the client controls.
            infoGrid.Visibility = Visibility.Visible;

            targetResult.Content =
                "Text provider found.";
            targetResult.Background = Brushes.LightGreen;

            //<SnippetDocumentRange>
            // Initialize the document range for the text of the document.
            documentRange = targetTextPattern.DocumentRange;
            //</SnippetDocumentRange>

            // Initialize the client's search buttons.
            if (targetTextPattern.DocumentRange.GetText(1).Length > 0)
            {
                searchForwardButton.IsEnabled = true;
            }
            // Initialize the client's search TextBox.
            searchString.IsEnabled = true;

            // Check if the text control supports text selection
            if (targetTextPattern.SupportedTextSelection ==
                SupportedTextSelection.None)
            {
                targetResult.Content = "Unable to select text.";
                targetResult.Background = Brushes.Salmon;
                return;
            }

            // Edit control found so remove the find button from the client.
            findEditButton.Visibility = Visibility.Collapsed;

            // Initialize the client with the current target selection, if any.
            NotifySelectionChanged();

            // Search starts at beginning of doc and goes forward
            searchBackward = false;

            //<SnippetTextChanged>
            // Initialize a text changed listener.
            // An instance of TextPatternRange will become invalid if
            // one of the following occurs:
            // 1) The text in the provider changes via some user activity.
            // 2) ValuePattern.SetValue is used to programatically change
            // the value of the text in the provider.
            // The only way the client application can detect if the text
            // has changed (to ensure that the ranges are still valid),
            // is by setting a listener for the TextChanged event of
            // the TextPattern. If this event is raised, the client needs
            // to update the targetDocumentRange member data to ensure the
            // user is working with the updated text.
            // Clients must always anticipate the possibility that the text
            // can change underneath them.
            Automation.AddAutomationEventHandler(
                TextPattern.TextChangedEvent,
                targetDocument,
                TreeScope.Element,
                TextChanged);
            //</SnippetTextChanged>

            //<SnippetSelectionChanged>
            // Initialize a selection changed listener.
            // The target selection is reflected in the client.
            Automation.AddAutomationEventHandler(
                TextPattern.TextSelectionChangedEvent,
                targetDocument,
                TreeScope.Element,
                OnTextSelectionChange);
            //</SnippetSelectionChanged>
        }
        // </SnippetFindTextProvider>

        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the enclosing element of the target selection.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void GetEnclosingElement_Click(object sender, RoutedEventArgs e)
        {
            // Obtain the enclosing element.
            AutomationElement enclosingElement;
            try
            {
                enclosingElement = searchRange.GetEnclosingElement();
            }
            catch (ElementNotAvailableException)
            {
                // TODO: error handling.
                return;
            }

            // Assemble the information about the enclosing element.
            StringBuilder enclosingElementInformation = new StringBuilder();
            enclosingElementInformation.Append(
                "Enclosing element:\t").AppendLine(
                enclosingElement.Current.ControlType.ProgrammaticName);

            // The WPF target doesn't show selected text as highlighted unless
            // the window has focus.
            targetWindow.SetFocus();

            // Display the enclosing element information in the client.
            targetSelectionDetails.Text = enclosingElementInformation.ToString();

            // Is the enclosing element the entire document?
            // If so, select the document.
            if (enclosingElement == targetDocument)
            {
                documentRange = targetTextPattern.DocumentRange;
                documentRange.Select();
                return;
            }
            // Otherwise, select the range from the child element.
            TextPatternRange childRange =
                documentRange.TextPattern.RangeFromChild(enclosingElement);
            childRange.Select();
        }

        // <SnippetGetChildren>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Gets the children of the target selection.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void GetChildren_Click(object sender, RoutedEventArgs e)
        {
            // Obtain an array of child elements.
            AutomationElement[] textProviderChildren;
            try
            {
                textProviderChildren = searchRange.GetChildren();
            }
            catch (ElementNotAvailableException)
            {
                // TODO: error handling.
                return;
            }

            // Assemble the information about the enclosing element.
            StringBuilder childInformation = new StringBuilder();
            childInformation.Append(textProviderChildren.Length)
                .AppendLine(" child element(s).");

            // Iterate through the collection of child elements and obtain
            // information of interest about each.
            for (int i = 0; i < textProviderChildren.Length; i++)
            {
                childInformation.Append("Child").Append(i).AppendLine(":");
                // Obtain the name of the child control.
                childInformation.Append("\tName:\t")
                    .AppendLine(textProviderChildren[i].Current.Name);
                // Obtain the control type.
                childInformation.Append("\tControl Type:\t")
                    .AppendLine(textProviderChildren[i].Current.ControlType.ProgrammaticName);

                // Obtain the supported control patterns.
                // NOTE: For the purposes of this sample we use GetSupportedPatterns().
                // However, the use of GetSupportedPatterns() is strongly discouraged
                // as it calls GetCurrentPattern() internally on every known pattern.
                // It is therefore much more efficient to use GetCurrentPattern() for
                // the specific patterns you are interested in.
                AutomationPattern[] childPatterns =
                    textProviderChildren[i].GetSupportedPatterns();
                childInformation.AppendLine("\tSupported Control Patterns:");
                if (childPatterns.Length <= 0)
                {
                    childInformation.AppendLine("\t\t\tNone");
                }
                else
                {
                    foreach (AutomationPattern pattern in childPatterns)
                    {
                        childInformation.Append("\t\t\t")
                            .AppendLine(pattern.ProgrammaticName);
                    }
                }

                // Obtain the child elements, if any, of the child control.
                TextPatternRange childRange =
                    documentRange.TextPattern.RangeFromChild(textProviderChildren[i]);
                AutomationElement[] childRangeChildren =
                    childRange.GetChildren();
                childInformation.Append("\tChildren: \t").Append(childRangeChildren.Length).AppendLine();
            }
            // Display the information about the child controls.
            targetSelectionDetails.Text = childInformation.ToString();
        }
        // </SnippetGetChildren>
        #endregion Target Text Info

        #region Search Target
        // <SnippetSearchTarget>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles changes to the search text in the client.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Reset all controls if user changes search text
        /// </remarks>
        ///--------------------------------------------------------------------
        void SearchString_Change(object sender, TextChangedEventArgs e)
        {
            int startPoints = documentRange.CompareEndpoints(
                TextPatternRangeEndpoint.Start,
                searchRange,
                TextPatternRangeEndpoint.Start);
            int endPoints = documentRange.CompareEndpoints(
                TextPatternRangeEndpoint.End,
                searchRange,
                TextPatternRangeEndpoint.End);

            // If the starting endpoints of the document range and the search
            // range are equivalent then we can search forward only since the
            // search range is at the start of the document.
            if (startPoints == 0)
            {
                searchForwardButton.IsEnabled = true;
                searchBackwardButton.IsEnabled = false;
            }
            // If the ending endpoints of the document range and the search
            // range are identical then we can search backward only since the
            // search range is at the end of the document.
            else if (endPoints == 0)
            {
                searchForwardButton.IsEnabled = false;
                searchBackwardButton.IsEnabled = true;
            }
            // Otherwise we can search both directions.
            else
            {
                searchForwardButton.IsEnabled = true;
                searchBackwardButton.IsEnabled = true;
            }
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the Search button click.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>Find the text specified in the text box.</remarks>
        ///--------------------------------------------------------------------
        void SearchDirection_Click(object sender, RoutedEventArgs e)
        {
            Button searchDirection = (Button)sender;

            // Are we searching backward through the text control?
            searchBackward =
                ((traversalDirection)searchDirection.Tag == traversalDirection.Backward);

            // Check if search text entered
            if (searchString.Text.Trim() == "")
            {
                targetResult.Content = "No search criteria.";
                targetResult.Background = Brushes.Salmon;
                return;
            }

            //<SnippetSupportedTextSelection>
            // Does target range support text selection?
            if (targetTextPattern.SupportedTextSelection ==
                SupportedTextSelection.None)
            {
                targetResult.Content = "Unable to select text.";
                targetResult.Background = Brushes.Salmon;
                return;
            }
            // Does target range support multiple selections?
            if (targetTextPattern.SupportedTextSelection ==
                SupportedTextSelection.Multiple)
            {
                targetResult.Content = "Multiple selections present.";
                targetResult.Background = Brushes.Salmon;
                return;
            }
            //</SnippetSupportedTextSelection>

            // Clone the document range since we modify the endpoints
            // as we search.
            TextPatternRange documentRangeClone = documentRange.Clone();

            // Move the cloned document range endpoints to enable the
            // selection of the next matching text range.
            TextPatternRange[] selectionRange =
                targetTextPattern.GetSelection();
            if (selectionRange[0] != null)
            {
                if (searchBackward)
                {
                    documentRangeClone.MoveEndpointByRange(
                        TextPatternRangeEndpoint.End,
                        selectionRange[0],
                        TextPatternRangeEndpoint.Start);
                }
                else
                {
                    documentRangeClone.MoveEndpointByRange(
                        TextPatternRangeEndpoint.Start,
                        selectionRange[0],
                        TextPatternRangeEndpoint.End);
                }
            }

            // Find the text specified in the Search textbox.
            // Clone the search range since we need to modify it.
            TextPatternRange searchRangeClone = searchRange.Clone();
            // backward = false? -- search forward, otherwise backward.
            // ignoreCase = false? -- search is case sensitive.
            searchRange =
                documentRangeClone.FindText(
                searchString.Text, searchBackward, false);

            // Search unsuccessful.
            if (searchRange == null)
            {
                // Search string not found at all.
                if (documentRangeClone.CompareEndpoints(
                    TextPatternRangeEndpoint.Start,
                    searchRangeClone,
                    TextPatternRangeEndpoint.Start) == 0)
                {
                    targetResult.Content = "Text not found.";
                    targetResult.Background = Brushes.Wheat;
                    searchBackwardButton.IsEnabled = false;
                    searchForwardButton.IsEnabled = false;
                }
                // End of document (either the start or end of the document
                // range depending on search direction) was reached before
                // finding another occurence of the search string.
                else
                {
                    targetResult.Content = "End of document reached.";
                    targetResult.Background = Brushes.Wheat;
                    if (!searchBackward)
                    {
                        searchRangeClone.MoveEndpointByRange(
                            TextPatternRangeEndpoint.Start,
                            documentRange,
                            TextPatternRangeEndpoint.End);
                        searchBackwardButton.IsEnabled = true;
                        searchForwardButton.IsEnabled = false;
                    }
                    else
                    {
                        searchRangeClone.MoveEndpointByRange(
                            TextPatternRangeEndpoint.End,
                            documentRange,
                            TextPatternRangeEndpoint.Start);
                        searchBackwardButton.IsEnabled = false;
                        searchForwardButton.IsEnabled = true;
                    }
                }
                searchRange = searchRangeClone;
            }
            // The search string was found.
            else
            {
                targetResult.Content = "Text found.";
                targetResult.Background = Brushes.LightGreen;
            }

            searchRange.Select();
            // Scroll the selection into view and align with top of viewport
            searchRange.ScrollIntoView(true);
            // The WPF target doesn't show selected text as highlighted unless
            // the window has focus.
            targetWindow.SetFocus();
        }
        // </SnippetSearchTarget>
        #endregion Search Target

        #region Target Navigation
        // <SnippetNavigate>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the navigation item selected event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void NavigationUnit_Change(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            navigationUnit = (TextUnit)cb.SelectedValue;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the Navigate button click event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void Navigate_Click(object sender, RoutedEventArgs e)
        {
            Button moveSelection = (Button)sender;

            // Which direction is the user searching through the text control?
            int navDirection =
                ((traversalDirection)moveSelection.Tag == traversalDirection.Forward) ? 1 : -1;

            // Obtain the ranges to move.
            TextPatternRange[] selectionRanges =
                           targetTextPattern.GetSelection();

            // Iterate throught the ranges for a text control that supports
            // multiple selections and move the selections the specified text
            // unit and direction.
            foreach (TextPatternRange textRange in selectionRanges)
            {
                textRange.Move(navigationUnit, navDirection);
                textRange.Select();
           }
           // The WPF target doesn't show selected text as highlighted unless
           // the window has focus.
           targetDocument.SetFocus();
        }
        // </SnippetNavigate>
        #endregion Target Navigation

        #region Expand Selection
        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the expand to enclosing unit item selected event.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void ExpandToTextUnit_Change(
            object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            // Expand the target selection to the selected text unit.
            TextPatternRange[] selectionRanges =
                           targetTextPattern.GetSelection();
            foreach (TextPatternRange textRange in selectionRanges)
            {
                switch (cb.SelectedValue.ToString())
                {
                    case "None":
                        textRange.MoveEndpointByRange(
                            TextPatternRangeEndpoint.End,
                            textRange,
                            TextPatternRangeEndpoint.Start);
                        break;
                    case "Character":
                        textRange.ExpandToEnclosingUnit(TextUnit.Character);
                        break;
                    case "Format":
                        textRange.ExpandToEnclosingUnit(TextUnit.Format);
                        break;
                    case "Word":
                        textRange.ExpandToEnclosingUnit(TextUnit.Word);
                        break;
                    case "Line":
                        textRange.ExpandToEnclosingUnit(TextUnit.Line);
                        break;
                    case "Paragraph":
                        textRange.ExpandToEnclosingUnit(TextUnit.Paragraph);
                        break;
                    case "Page":
                        textRange.ExpandToEnclosingUnit(TextUnit.Page);
                        break;
                    case "Document":
                        textRange.ExpandToEnclosingUnit(TextUnit.Document);
                        break;
                }
                textRange.Select();
                // The WPF target doesn't show selected text as highlighted unless
                // the window has focus.
                targetWindow.SetFocus();
            }
        }
        #endregion Expand Highlight

        #region Target Listeners
        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the text changed event in the target.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Since the events are happening on a different thread than the
        /// client we need to use a Dispatcher delegate to handle them.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void TextChanged(object sender, AutomationEventArgs e)
        {
            clientWindow.Dispatcher.BeginInvoke(
            DispatcherPriority.Send,
            new TextChangeDelegate(NotifyTextChanged),
            "Text changed, range reset.\n");
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// The delegate for the target text changed event.
        /// </summary>
        /// <param name="arg">null argument</param>
        /// <returns>A null object.</returns>
        ///--------------------------------------------------------------------
       private void NotifyTextChanged(string message)
        {
           // Notify the user of the text changed event.
           targetSelectionLabel.Content = message;
           // Re-initialize the document range for the text of the document
           // since we don't know the extent of the changes. For example, a
           // change in the font color attribute, such as on a hyperlink
           // mouseover, raises this event but doesn't change the content of
           // the text control.
           documentRange = targetTextPattern.DocumentRange;
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the text selection changed event in the target.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        /// <remarks>
        /// Since the events are happening on a different thread than the
        /// client we need to use a Dispatcher delegate to handle them.
        /// </remarks>
        ///--------------------------------------------------------------------
        private void OnTextSelectionChange(object sender, AutomationEventArgs e)
        {
            clientWindow.Dispatcher.BeginInvoke(
                DispatcherPriority.Send,
                new SelectionChangeDelegate(NotifySelectionChanged));
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// The delegate for the target text selection changed event.
        /// </summary>
        /// <param name="arg">null argument</param>
        /// <returns>A null object.</returns>
        ///--------------------------------------------------------------------
        private void NotifySelectionChanged()
        {
            // Get the array of disjoint selections.
            TextPatternRange[] selectionRanges =
                targetTextPattern.GetSelection();
            // Update the current search range.
            // For the purposes of this sample only the first selection
            // range will be echoed in the client.
            searchRange = selectionRanges[0];
            // For performance and security reasons we'll limit
            // the length of the string retrieved to 100 characters.
            // Alternatively, GetText(-1) will retrieve all selected text.
            string selectedText = searchRange.GetText(100);
            targetSelectionLabel.Content =
                "Currently selected (100 character maximum): " +
                selectedText.Length + " characters.";

            // Report target selection details.
            DisplaySelectedTextWithAttributes(selectedText);
        }

        // <SnippetRetrieveMixedAttributes>
        ///--------------------------------------------------------------------
        /// <summary>
        /// Display the target selection with attribute details in client.
        /// </summary>
        /// <param name="selectedText">The current target selection.</param>
        ///--------------------------------------------------------------------
        private void DisplaySelectedTextWithAttributes(string selectedText)
        {
            targetSelection.Text = selectedText;
            // We're only interested in the FontNameAttribute for the purposes
            // of this sample.
            targetSelectionAttributes.Text =
                ParseTextRangeByAttribute(
                selectedText, TextPattern.FontNameAttribute);
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// Parse the target selection based on the text attribute of interest.
        /// </summary>
        /// <param name="selectedText">The current target selection.</param>
        /// <param name="automationTextAttribute">
        /// The text attribute of interest.
        /// </param>
        /// <returns>
        /// A string representing the requested attribute details.
        /// </returns>
        ///--------------------------------------------------------------------
        private string ParseTextRangeByAttribute(
            string selectedText,
            AutomationTextAttribute automationTextAttribute)
        {
            StringBuilder attributeDetails = new StringBuilder();
            // Initialize the current attribute value.
            string attributeValue = "";
            // Make a copy of the text range.
            TextPatternRange searchRangeClone = searchRange.Clone();
            // Collapse the range to the starting endpoint.
            searchRangeClone.Move(TextUnit.Character, -1);
            // Iterate through the range character by character.
            for (int x = 1; x <= selectedText.Length; x++)
            {
                searchRangeClone.Move(TextUnit.Character, 1);
                // Get the attribute value of the current character.
                string newAttributeValue =
                    searchRangeClone.GetAttributeValue(automationTextAttribute).ToString();
                // If the new attribute value is not equal to the old then report
                // the new value along with its location within the range.
                if (newAttributeValue != attributeValue)
                {
                    attributeDetails.Append(automationTextAttribute.ProgrammaticName)
                        .Append(":\n<")
                        .Append(newAttributeValue)
                        .Append("> at text range position ")
                        .AppendLine(x.ToString());
                    attributeValue = newAttributeValue;
                }
            }
            return attributeDetails.ToString();
        }
        // </SnippetRetrieveMixedAttributes>

        ///--------------------------------------------------------------------
        /// <summary>
        /// Handles the window closed event in the target.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        ///--------------------------------------------------------------------
        private void OnTargetClose(object sender, AutomationEventArgs e)
        {
            clientWindow.Dispatcher.BeginInvoke(
               DispatcherPriority.Send,
               new ProviderCloseDelegate(CloseApp));
        }

        ///--------------------------------------------------------------------
        /// <summary>
        /// The delegate for the window closed event in the target.
        /// </summary>
        /// <param name="arg">null argument</param>
        /// <returns>A null object.</returns>
        ///--------------------------------------------------------------------
        private void CloseApp()
        {
            // Close the client window when the target window is closed.
            clientWindow.Close();
        }
        #endregion Target Listeners
    }
}