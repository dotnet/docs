'****************************************************************************************
' * File: FindText.cs
' *
' * Description:
' *    This sample demonstrates the UI Automation TextPattern and TextPatternRange classes.
' *
' *    The sample consists of a Windows Presentation Foundation (WPF) client and the choice
' *    of a WPF FlowDocumentReader target or a Win32 WordPad target. The client uses the
' *    TextPattern control pattern and the TextPatternRange class to interact with the text
' *    controls in either target.
' *
' *    The functionality demonstrated by the sample includes the ability to search for and
' *    select text, expand a selection to a specific TextUnit, navigate by TextUnit, access
' *    embedded objects within a selection, and access the enclosing element of a selection.
' *
' *    Note: Three WPF documents, a RichText document, and a plain text document are provided
' *          in the Content folder of the TextProvider project.
' *
' *
' * This file is part of the Microsoft .NET Framework SDK Code Samples.
' *
' * Copyright (C) Microsoft Corporation.  All rights reserved.
' *
' * This source code is intended only as a supplement to Microsoft
' * Development Tools and/or on-line documentation.  See these other
' * materials for detailed information regarding Microsoft code samples.
' *
' * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' * PARTICULAR PURPOSE.
' *
' *****************************************************************************************

Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Automation.Text
Imports System.Text
Imports System.Threading
Imports System.Windows.Threading
Imports System.Windows.Media

Namespace SDKSample

    '--------------------------------------------------------------------
    ' <summary>
    ' Interaction logic for client and target
    ' </summary>
    '--------------------------------------------------------------------

    Public Class SearchWindow
#Region "Member Variables"
        ' Client application window.
        Private clientWindow As Window
        ' Container for all client controls.
        Private clientDockPanel As DockPanel
        ' Target application window.
        Private targetWindow As AutomationElement
        ' Target text control.
        Private targetDocument As AutomationElement
        ' Text pattern obtained from the target text control.
        Private targetTextPattern As TextPattern
        ' Text range for entire target text control.
        Private documentRange As TextPatternRange
        ' Text range for current selection in target text control.
        Private searchRange As TextPatternRange
        ' Target applications based on underlying framework.
        Private startWPFTargetButton As Button
        Private startW32TargetButton As Button
        Private WPFTarget As String
        Private W32Target As String
        ' Find the target text control.
        Private findEditButton As Button
        ' Display target status.
        Private targetResult As Label
        ' Layout grid for client controls.
        Private infoGrid As Grid
        ' String to search for in the target text control.
        Private searchString As TextBox
        ' Depending on the location of the selection in the target text
        ' control, the client can search forward or backward for the
        ' search string.
        Private searchBackwardButton As Button
        Private searchForwardButton As Button
        ' Direction of search.
        Private searchBackward As Boolean
        ' Expand the target text selection by the specified text unit.
        Private expandHighlight As ComboBox
        ' Move the target text selection by the specified text unit.
        Private navigateTarget As ComboBox
        Private navigationUnit As TextUnit
        ' Display the target text selection and attributes.
        Private targetSelectionLabel As Label
        Private targetSelectionAttributeLabel As Label
        Private targetSelection As TextBox
        Private targetSelectionAttributes As TextBox
        ' Display target text selection details such as child and enclosing unit.
        Private targetSelectionDetails As TextBox

        ' Delegates for updating the client UI based on target application events.
        Private Delegate Sub TextChangeDelegate(ByVal message As String)

        Private Delegate Sub SelectionChangeDelegate()

        Private Delegate Sub ProviderCloseDelegate()
        ' Target applications.

        Private Enum targetApplication
            FlowDocument
            WordPad
        End Enum 'targetApplication ' Search and navigation directions.

        Private Enum traversalDirection
            Backward
            Forward
        End Enum 'traversalDirection
#End Region

#Region "Client Setup"
        '--------------------------------------------------------------------
        ' <summary>
        ' The class constructor.
        ' </summary>
        ' <remarks>
        ' Initialize the WPF client application.
        ' </remarks>
        '--------------------------------------------------------------------
        Public Sub SearchWindow()
            ' Specify the target applications.
            WPFTarget = _
            System.Windows.Forms.Application.StartupPath + "\TextProvider.exe"
            W32Target = "WordPad.exe"

            ' Initialize search direction.
            ' Search direction buttons are enabled or disabled based on this value.
            searchBackward = False

            ' Layout the client controls.
            Try
                ' Specs for Window.
                Dim clientHeight As Double = 600
                Dim clientWidth As Double = 550

                ' Specs for TextBox.
                Dim maxSearchLines As Integer = 1
                Dim maxSearchLength As Integer = 25

                ' Specs for Buttons.
                Dim buttonWidth As Double = 140

                ' Instantiate the client window and set location and size.
                clientWindow = New Window()
                clientWindow.Height = clientHeight
                clientWindow.Width = clientWidth
                clientWindow.Left = SystemParameters.WorkArea.Location.X + 50
                clientWindow.Top = SystemParameters.WorkArea.Location.Y + 50
                clientWindow.Title = "Find Text"
                clientWindow.WindowStyle = WindowStyle.ToolWindow

                ' Create a dock panel to hold all controls.
                clientDockPanel = New DockPanel()
                clientDockPanel.Margin = New Thickness(10)
                clientDockPanel.LastChildFill = True

                ' Add the start target buttons.
                startWPFTargetButton = New Button()
                startWPFTargetButton.Width = buttonWidth
                startWPFTargetButton.Content = "Start _FlowDocument (WPF)"
                startWPFTargetButton.Tag = targetApplication.FlowDocument
                AddHandler startWPFTargetButton.Click, AddressOf StartTargetApplication_Click
                startW32TargetButton = New Button()
                startW32TargetButton.Width = buttonWidth
                startW32TargetButton.Content = "Start _WordPad (Win32)"
                startW32TargetButton.Tag = targetApplication.WordPad
                AddHandler startW32TargetButton.Click, AddressOf StartTargetApplication_Click
                DockPanel.SetDock(startWPFTargetButton, Dock.Top)
                DockPanel.SetDock(startW32TargetButton, Dock.Top)
                clientDockPanel.Children.Add(startWPFTargetButton)
                clientDockPanel.Children.Add(startW32TargetButton)

                ' Add the find text control button.
                findEditButton = New Button()
                findEditButton.Width = buttonWidth
                findEditButton.Content = "_Find text provider"
                AddHandler findEditButton.Click, AddressOf FindTextProvider_Click
                findEditButton.Visibility = Visibility.Collapsed
                DockPanel.SetDock(findEditButton, Dock.Top)
                clientDockPanel.Children.Add(findEditButton)

                ' Add the target status label.
                targetResult = New Label()
                targetResult.Content = ""
                targetResult.BorderThickness = New Thickness(1)
                targetResult.BorderBrush = Brushes.Black
                targetResult.HorizontalAlignment = HorizontalAlignment.Center
                targetResult.Margin = New Thickness(0, 10, 0, 20)
                targetResult.Visibility = Visibility.Hidden
                DockPanel.SetDock(targetResult, Dock.Top)
                clientDockPanel.Children.Add(targetResult)

                ' Add the client control layout grid.
                infoGrid = New Grid()
                infoGrid.HorizontalAlignment = HorizontalAlignment.Center
                infoGrid.VerticalAlignment = VerticalAlignment.Top
                infoGrid.ShowGridLines = False
                infoGrid.Visibility = Visibility.Collapsed
                infoGrid.MinWidth = 400
                ' Define the columns.
                Dim colDef1 As New ColumnDefinition()
                Dim colDef2 As New ColumnDefinition()
                infoGrid.ColumnDefinitions.Add(colDef1)
                infoGrid.ColumnDefinitions.Add(colDef2)
                ' Define the rows.
                Dim rowDef1 As RowDefinition = New RowDefinition()
                rowDef1.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef2 As RowDefinition = New RowDefinition()
                rowDef2.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef3 As RowDefinition = New RowDefinition()
                rowDef3.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef4 As RowDefinition = New RowDefinition()
                rowDef4.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef5 As RowDefinition = New RowDefinition()
                rowDef5.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef6 As RowDefinition = New RowDefinition()
                rowDef6.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef7 As RowDefinition = New RowDefinition()
                rowDef7.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef8 As RowDefinition = New RowDefinition()
                rowDef8.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef9 As RowDefinition = New RowDefinition()
                rowDef9.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef10 As RowDefinition = New RowDefinition()
                rowDef10.Height = New GridLength(1, GridUnitType.Auto)
                Dim rowDef11 As RowDefinition = New RowDefinition()
                rowDef11.Height = New GridLength(1, GridUnitType.Auto)
                infoGrid.RowDefinitions.Add(rowDef1)
                infoGrid.RowDefinitions.Add(rowDef2)
                infoGrid.RowDefinitions.Add(rowDef3)
                infoGrid.RowDefinitions.Add(rowDef4)
                infoGrid.RowDefinitions.Add(rowDef5)
                infoGrid.RowDefinitions.Add(rowDef6)
                infoGrid.RowDefinitions.Add(rowDef7)
                infoGrid.RowDefinitions.Add(rowDef8)
                infoGrid.RowDefinitions.Add(rowDef9)
                infoGrid.RowDefinitions.Add(rowDef10)
                infoGrid.RowDefinitions.Add(rowDef11)

                ' Define the content of the cells.
                ' Row 1 - search string details.
                searchString = New TextBox()
                searchString.Name = "SearchString"
                searchString.MaxLines = maxSearchLines
                searchString.MaxLength = maxSearchLength
                searchString.Width = 200
                AddHandler searchString.TextChanged, AddressOf SearchString_Change
                searchString.IsEnabled = False
                Grid.SetRow(searchString, 0)
                Grid.SetColumn(searchString, 1)
                Dim searchLabel As New Label()
                searchLabel.Target = searchString
                searchLabel.Content = "_Search for: "
                searchLabel.VerticalAlignment = VerticalAlignment.Center
                Grid.SetRow(searchLabel, 0)
                Grid.SetColumn(searchLabel, 0)
                infoGrid.Children.Add(searchLabel)
                infoGrid.Children.Add(searchString)

                ' Row 2 - search direction buttons.
                searchBackwardButton = New Button()
                searchBackwardButton.Width = buttonWidth
                searchBackwardButton.Content = "Search _Backward"
                searchBackwardButton.Tag = traversalDirection.Backward
                AddHandler searchBackwardButton.Click, AddressOf SearchDirection_Click
                searchBackwardButton.Margin = New Thickness(0, 0, 0, 10)
                searchBackwardButton.IsEnabled = False
                Grid.SetRow(searchBackwardButton, 1)
                Grid.SetColumn(searchBackwardButton, 0)
                searchForwardButton = New Button()
                searchForwardButton.Width = buttonWidth
                searchForwardButton.Content = "Search _Forward"
                searchForwardButton.Tag = traversalDirection.Forward
                AddHandler searchForwardButton.Click, AddressOf SearchDirection_Click
                searchForwardButton.Margin = New Thickness(0, 0, 0, 10)
                searchForwardButton.IsEnabled = False
                Grid.SetRow(searchForwardButton, 1)
                Grid.SetColumn(searchForwardButton, 1)
                infoGrid.Children.Add(searchBackwardButton)
                infoGrid.Children.Add(searchForwardButton)

                ' Row 3 - Target selection.
                targetSelectionLabel = New Label()
                targetSelectionLabel.Target = targetSelection
                targetSelectionLabel.Content = "Currently selected:"
                Grid.SetRow(targetSelectionLabel, 2)
                Grid.SetColumn(targetSelectionLabel, 0)
                Grid.SetColumnSpan(targetSelectionLabel, 2)
                infoGrid.Children.Add(targetSelectionLabel)
                ' Row 4.
                targetSelection = New TextBox()
                targetSelection.TextWrapping = TextWrapping.Wrap
                targetSelection.MaxWidth = 400
                targetSelection.Height = 100
                targetSelection.VerticalScrollBarVisibility = _
                    ScrollBarVisibility.Auto
                targetSelection.IsReadOnly = True
                targetSelection.Margin = New Thickness(0, 0, 0, 0)
                Grid.SetRow(targetSelection, 3)
                Grid.SetColumn(targetSelection, 0)
                Grid.SetColumnSpan(targetSelection, 2)
                infoGrid.Children.Add(targetSelection)

                ' Row 5 - Target selection attributes.
                targetSelectionAttributeLabel = New Label()
                targetSelectionAttributeLabel.Target = targetSelection
                targetSelectionAttributeLabel.Content = "Attribute values: "
                Grid.SetRow(targetSelectionAttributeLabel, 4)
                Grid.SetColumn(targetSelectionAttributeLabel, 0)
                Grid.SetColumnSpan(targetSelectionAttributeLabel, 2)
                infoGrid.Children.Add(targetSelectionAttributeLabel)
                ' Row 6.
                targetSelectionAttributes = New TextBox()
                targetSelectionAttributes.TextWrapping = TextWrapping.Wrap
                targetSelectionAttributes.MaxWidth = 400
                targetSelectionAttributes.Height = 100
                targetSelectionAttributes.VerticalScrollBarVisibility = _
                    ScrollBarVisibility.Auto
                targetSelectionAttributes.IsReadOnly = True
                targetSelectionAttributes.Margin = New Thickness(0, 0, 0, 10)
                Grid.SetRow(targetSelectionAttributes, 5)
                Grid.SetColumn(targetSelectionAttributes, 0)
                Grid.SetColumnSpan(targetSelectionAttributes, 2)
                infoGrid.Children.Add(targetSelectionAttributes)

                ' Row 7 - Navigate target details.
                navigateTarget = New ComboBox()
                navigateTarget.Width = buttonWidth
                navigateTarget.Items.Add(TextUnit.Character)
                navigateTarget.Items.Add(TextUnit.Format)
                navigateTarget.Items.Add(TextUnit.Word)
                navigateTarget.Items.Add(TextUnit.Line)
                navigateTarget.Items.Add(TextUnit.Paragraph)
                navigateTarget.Items.Add(TextUnit.Page)
                navigateTarget.SelectedIndex = 0
                AddHandler navigateTarget.SelectionChanged, _
                    New SelectionChangedEventHandler(AddressOf NavigationUnit_Change)
                Grid.SetRow(navigateTarget, 6)
                Grid.SetColumn(navigateTarget, 1)
                Dim navigateLabel As Label = New Label()
                navigateLabel.Target = navigateTarget
                navigateLabel.Content = "_Navigate target by text unit of: "
                navigateLabel.VerticalAlignment = VerticalAlignment.Center
                Grid.SetRow(navigateLabel, 6)
                Grid.SetColumn(navigateLabel, 0)
                infoGrid.Children.Add(navigateLabel)
                infoGrid.Children.Add(navigateTarget)

                ' Row 8 - Navigate target direction buttons.
                Dim navigateBackwardButton As Button = New Button()
                navigateBackwardButton.Width = buttonWidth
                navigateBackwardButton.Content = "_Backward"
                navigateBackwardButton.Tag = traversalDirection.Backward
                AddHandler navigateBackwardButton.Click, _
                    New RoutedEventHandler(AddressOf Navigate_Click)
                navigateBackwardButton.Margin = New Thickness(0, 0, 0, 10)
                Grid.SetRow(navigateBackwardButton, 7)
                Grid.SetColumn(navigateBackwardButton, 0)
                Dim navigateForwardButton As Button = New Button()
                navigateForwardButton.Width = buttonWidth
                navigateForwardButton.Content = "_Forward"
                navigateForwardButton.Tag = traversalDirection.Forward
                AddHandler navigateForwardButton.Click, _
                    New RoutedEventHandler(AddressOf Navigate_Click)
                navigateForwardButton.Margin = New Thickness(0, 0, 0, 10)
                Grid.SetRow(navigateForwardButton, 7)
                Grid.SetColumn(navigateForwardButton, 1)
                infoGrid.Children.Add(navigateBackwardButton)
                infoGrid.Children.Add(navigateForwardButton)

                ' Row 9 - Expand the target selection controls.
                expandHighlight = New ComboBox()
                expandHighlight.Width = buttonWidth
                expandHighlight.Items.Add("")
                expandHighlight.Items.Add("None")
                expandHighlight.Items.Add(TextUnit.Character)
                expandHighlight.Items.Add(TextUnit.Format)
                expandHighlight.Items.Add(TextUnit.Word)
                expandHighlight.Items.Add(TextUnit.Line)
                expandHighlight.Items.Add(TextUnit.Paragraph)
                expandHighlight.Items.Add(TextUnit.Page)
                expandHighlight.Items.Add(TextUnit.Document)
                expandHighlight.SelectedIndex = 0
                AddHandler expandHighlight.SelectionChanged, _
                    New SelectionChangedEventHandler(AddressOf ExpandToTextUnit_Change)
                expandHighlight.Margin = New Thickness(0, 0, 0, 10)
                Grid.SetRow(expandHighlight, 8)
                Grid.SetColumn(expandHighlight, 1)
                Dim expandLabel As Label = New Label()
                expandLabel.Target = expandHighlight
                expandLabel.Content = "_Expand selection to text unit of: "
                expandLabel.VerticalAlignment = VerticalAlignment.Center
                expandLabel.Margin = New Thickness(0, 0, 0, 10)
                Grid.SetRow(expandLabel, 8)
                Grid.SetColumn(expandLabel, 0)
                infoGrid.Children.Add(expandLabel)
                infoGrid.Children.Add(expandHighlight)

                ' Row 10 - target selection details such as child elements
                '         and enclosing unit.
                targetSelectionDetails = New TextBox()
                targetSelectionDetails.Height = 100
                targetSelectionDetails.VerticalScrollBarVisibility = _
                    ScrollBarVisibility.Auto
                targetSelectionDetails.IsReadOnly = True
                Grid.SetRow(targetSelectionDetails, 9)
                Grid.SetColumn(targetSelectionDetails, 0)
                Grid.SetColumnSpan(targetSelectionDetails, 2)
                infoGrid.Children.Add(targetSelectionDetails)

                ' Row 11 - get the child elements and the enclosing unit
                '         of the target selection.
                Dim getChildren As Button = New Button()
                getChildren.Width = buttonWidth
                getChildren.Content = "Get children of selection"
                AddHandler getChildren.Click, _
                    New RoutedEventHandler(AddressOf GetChildren_Click)
                Grid.SetRow(getChildren, 10)
                Grid.SetColumn(getChildren, 0)
                Dim getEnclosingElement As Button = New Button()
                getEnclosingElement.Width = buttonWidth
                getEnclosingElement.Content = "Get enclosing element"
                AddHandler getEnclosingElement.Click, _
                    New RoutedEventHandler(AddressOf GetEnclosingElement_Click)
                Grid.SetRow(getEnclosingElement, 10)
                Grid.SetColumn(getEnclosingElement, 1)
                infoGrid.Children.Add(getChildren)
                infoGrid.Children.Add(getEnclosingElement)

                ' Add the grid to the dock panel.
                DockPanel.SetDock(infoGrid, Dock.Top)
                clientDockPanel.Children.Add(infoGrid)

                ' Add the dock panel to the window.
                clientWindow.Content = clientDockPanel
                clientWindow.Show()
                ' Do we successfully create the client app?
            Catch
                ' TODO: error handling.
                Return
            End Try

        End Sub


        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the Start Application button click.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        ' <remarks>
        ' Starts the application that we are going to use for as our
        ' root element for this sample.
        ' </remarks>
        '--------------------------------------------------------------------
        Private Sub StartTargetApplication_Click( _
        ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim targetOption As Button = CType(sender, Button)

            ' Start the target selected by the user.
            If CType(targetOption.Tag, targetApplication) = _
            targetApplication.WordPad Then
                targetWindow = StartApp(W32Target)
            Else
                targetWindow = StartApp(WPFTarget)
            End If

            ' Target is not available.
            Debug.Assert(Not (targetWindow Is Nothing))

            Dim targetCloseListener As AutomationEventHandler = _
            New AutomationEventHandler(AddressOf OnTargetClose)
            ' Set a listener for the window closed event on the target.
            Automation.AddAutomationEventHandler( _
            WindowPattern.WindowClosedEvent, _
            targetWindow, TreeScope.Element, targetCloseListener)

            ' Set size and position of target.
            ' Since the target is started and manipulated from the client
            ' and both windows show UI changes this section of code just
            ' ensures neither window obscures the other.
            Dim targetTransformPattern As TransformPattern = _
            DirectCast(targetWindow.GetCurrentPattern( _
            TransformPattern.Pattern), TransformPattern)
            targetTransformPattern.Resize(clientWindow.Width, clientWindow.Height)
            targetTransformPattern.Move( _
            clientWindow.Left + clientWindow.Width + 25, clientWindow.Top)

            ' Set visibility of client controls.
            startWPFTargetButton.Visibility = Visibility.Collapsed
            startW32TargetButton.Visibility = Visibility.Collapsed
            findEditButton.Visibility = Visibility.Visible
            targetResult.Visibility = Visibility.Visible

        End Sub


        '<SnippetStartApp>
        '--------------------------------------------------------------------
        ' <summary>
        ' Starts the target application.
        ' </summary>
        ' <param name="app">
        ' The application to start.
        ' </param>
        ' <returns>The automation element for the app main window.</returns>
        ' <remarks>
        ' Three WPF documents, a rich text document, and a plain text document
        ' are provided in the Content folder of the TextProvider project.
        ' </remarks>
        '--------------------------------------------------------------------
        Private Function StartApp(ByVal app As String) As AutomationElement
            ' Start application.
            Dim p As Process = Process.Start(app)

            ' Give the target application some time to start.
            ' For Win32 applications, WaitForInputIdle can be used instead.
            ' Another alternative is to listen for WindowOpened events.
            ' Otherwise, an ArgumentException results when you try to
            ' retrieve an automation element from the window handle.
            Thread.Sleep(2000)

            targetResult.Content = WPFTarget + " started. " + vbLf + vbLf + _
            "Please load a document into the target application and click " + _
            "the 'Find edit control' button above. " + vbLf + vbLf + _
            "NOTE: Documents can be found in the 'Content' folder of the FindText project."
            targetResult.Background = Brushes.LightGreen

            ' Return the automation element for the app main window.
            Return AutomationElement.FromHandle(p.MainWindowHandle)

        End Function 'StartApp
        '</SnippetStartApp>
#End Region

#Region "Target Text Info"
        '<SnippetFindTextProvider>
        '--------------------------------------------------------------------
        ' <summary>
        ' Finds the text control in our target.
        ' </summary>
        ' <param name="src">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        ' <remarks>
        ' Initializes the TextPattern object and event handlers.
        ' </remarks>
        '--------------------------------------------------------------------
        Private Sub FindTextProvider_Click( _
        ByVal src As Object, ByVal e As RoutedEventArgs)
            '<SnippetTextPatternPattern>
            ' Set up the conditions for finding the text control.
            Dim documentControl As New PropertyCondition( _
            AutomationElement.ControlTypeProperty, ControlType.Document)
            Dim textPatternAvailable As New PropertyCondition( _
            AutomationElement.IsTextPatternAvailableProperty, True)
            Dim findControl As New AndCondition(documentControl, textPatternAvailable)

            ' Get the Automation Element for the first text control found.
            ' For the purposes of this sample it is sufficient to find the
            ' first text control. In other cases there may be multiple text
            ' controls to sort through.
            targetDocument = targetWindow.FindFirst(TreeScope.Descendants, findControl)

            ' Didn't find a text control.
            If targetDocument Is Nothing Then
                targetResult.Content = _
                WPFTarget + " does not contain a Document control type."
                targetResult.Background = Brushes.Salmon
                startWPFTargetButton.IsEnabled = False
                Return
            End If

            ' Get required control patterns
            targetTextPattern = DirectCast( _
            targetDocument.GetCurrentPattern(TextPattern.Pattern), TextPattern)

            ' Didn't find a text control that supports TextPattern.
            If targetTextPattern Is Nothing Then
                targetResult.Content = WPFTarget + _
                " does not contain an element that supports TextPattern."
                targetResult.Background = Brushes.Salmon
                startWPFTargetButton.IsEnabled = False
                Return
            End If
            '</SnippetTextPatternPattern>
            ' Text control is available so display the client controls.
            infoGrid.Visibility = Visibility.Visible

            targetResult.Content = "Text provider found."
            targetResult.Background = Brushes.LightGreen

            '<SnippetDocumentRange>
            ' Initialize the document range for the text of the document.
            documentRange = targetTextPattern.DocumentRange
            '</SnippetDocumentRange>

            ' Initialize the client's search buttons.
            If targetTextPattern.DocumentRange.GetText(1).Length > 0 Then
                searchForwardButton.IsEnabled = True
            End If
            ' Initialize the client's search TextBox.
            searchString.IsEnabled = True

            ' Check if the text control supports text selection
            If targetTextPattern.SupportedTextSelection = SupportedTextSelection.None Then
                targetResult.Content = "Unable to select text."
                targetResult.Background = Brushes.Salmon
                Return
            End If

            ' Edit control found so remove the find button from the client.
            findEditButton.Visibility = Visibility.Collapsed

            ' Initialize the client with the current target selection, if any.
            NotifySelectionChanged()

            ' Search starts at beginning of doc and goes forward
            searchBackward = False

            '<SnippetTextChanged>
            ' Initialize a text changed listener.
            ' An instance of TextPatternRange will become invalid if
            ' one of the following occurs:
            ' 1) The text in the provider changes via some user activity.
            ' 2) ValuePattern.SetValue is used to programmatically change
            ' the value of the text in the provider.
            ' The only way the client application can detect if the text
            ' has changed (to ensure that the ranges are still valid),
            ' is by setting a listener for the TextChanged event of
            ' the TextPattern. If this event is raised, the client needs
            ' to update the targetDocumentRange member data to ensure the
            ' user is working with the updated text.
            ' Clients must always anticipate the possibility that the text
            ' can change underneath them.
            Dim onTextChanged As AutomationEventHandler = _
            New AutomationEventHandler(AddressOf TextChanged)
            Automation.AddAutomationEventHandler( _
            TextPattern.TextChangedEvent, targetDocument, TreeScope.Element, onTextChanged)
            '</SnippetTextChanged>
            '<SnippetSelectionChanged>
            ' Initialize a selection changed listener.
            ' The target selection is reflected in the client.
            Dim onSelectionChanged As AutomationEventHandler = _
            New AutomationEventHandler(AddressOf OnTextSelectionChange)
            Automation.AddAutomationEventHandler( _
            TextPattern.TextSelectionChangedEvent, targetDocument, _
            TreeScope.Element, onSelectionChanged)
            '</SnippetSelectionChanged>

        End Sub
        '</SnippetFindTextProvider>

        '--------------------------------------------------------------------
        ' <summary>
        ' Gets the enclosing element of the target selection.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        '--------------------------------------------------------------------
        Private Sub GetEnclosingElement_Click( _
        ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Obtain the enclosing element.
            Dim enclosingElement As AutomationElement
            Try
                enclosingElement = searchRange.GetEnclosingElement()
            Catch
                ' TODO: error handling.
                Return
            End Try

            ' Assemble the information about the enclosing element.
            Dim enclosingElementInformation As New StringBuilder()
            enclosingElementInformation.Append("Enclosing element:" + vbTab) _
            .AppendLine(enclosingElement.Current.ControlType.ProgrammaticName)

            ' The WPF target doesn't show selected text as highlighted unless
            ' the window has focus.
            targetWindow.SetFocus()

            ' Display the enclosing element information in the client.
            targetSelectionDetails.Text = enclosingElementInformation.ToString()

            ' Is the enclosing element the entire document?
            ' If so, select the document.
            If enclosingElement = targetDocument Then
                documentRange = targetTextPattern.DocumentRange
                documentRange.Select()
                Return
            End If
            ' Otherwise, select the range from the child element.
            Dim childRange As TextPatternRange = _
            documentRange.TextPattern.RangeFromChild(enclosingElement)
            childRange.Select()

        End Sub


        ' <SnippetGetChildren>
        '--------------------------------------------------------------------
        ' <summary>
        ' Gets the children of the target selection.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        '--------------------------------------------------------------------
        Private Sub GetChildren_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Obtain an array of child elements.
            Dim textProviderChildren() As AutomationElement
            Try
                textProviderChildren = searchRange.GetChildren()
            Catch
                ' TODO: error handling.
                Return
            End Try

            ' Assemble the information about the enclosing element.
            Dim childInformation As New StringBuilder()
            childInformation.Append(textProviderChildren.Length).AppendLine(" child element(s).")

            ' Iterate through the collection of child elements and obtain
            ' information of interest about each.
            Dim i As Integer
            For i = 0 To textProviderChildren.Length - 1
                childInformation.Append("Child").Append(i).AppendLine(":")
                ' Obtain the name of the child control.
                childInformation.Append(vbTab + "Name:" + vbTab) _
                .AppendLine(textProviderChildren(i).Current.Name)
                ' Obtain the control type.
                childInformation.Append(vbTab + "Control Type:" + vbTab) _
                .AppendLine(textProviderChildren(i).Current.ControlType.ProgrammaticName)

                ' Obtain the supported control patterns.
                ' NOTE: For the purposes of this sample we use GetSupportedPatterns().
                ' However, the use of GetSupportedPatterns() is strongly discouraged
                ' as it calls GetCurrentPattern() internally on every known pattern.
                ' It is therefore much more efficient to use GetCurrentPattern() for
                ' the specific patterns you are interested in.
                Dim childPatterns As AutomationPattern() = _
                textProviderChildren(i).GetSupportedPatterns()
                childInformation.AppendLine(vbTab + "Supported Control Patterns:")
                If childPatterns.Length <= 0 Then
                    childInformation.AppendLine(vbTab + vbTab + vbTab + "None")
                Else
                    Dim pattern As AutomationPattern
                    For Each pattern In childPatterns
                        childInformation.Append(vbTab + vbTab + vbTab) _
                        .AppendLine(pattern.ProgrammaticName)
                    Next pattern
                End If

                ' Obtain the child elements, if any, of the child control.
                Dim childRange As TextPatternRange = _
                documentRange.TextPattern.RangeFromChild(textProviderChildren(i))
                Dim childRangeChildren As AutomationElement() = _
                childRange.GetChildren()
                childInformation.Append(vbTab + "Children: " + vbTab) _
                .Append(childRangeChildren.Length).AppendLine()
            Next i
            ' Display the information about the child controls.
            targetSelectionDetails.Text = childInformation.ToString()

        End Sub
        '</SnippetGetChildren>
#End Region

#Region "Search Target"
        '<SnippetSearchTarget>
        '--------------------------------------------------------------------
        ' <summary>
        ' Handles changes to the search text in the client.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        ' <remarks>
        ' Reset all controls if user changes search text
        ' </remarks>
        '--------------------------------------------------------------------
        Private Sub SearchString_Change( _
        ByVal sender As Object, ByVal e As TextChangedEventArgs)
            Dim startPoints As Integer = _
            documentRange.CompareEndpoints( _
            TextPatternRangeEndpoint.Start, searchRange, _
            TextPatternRangeEndpoint.Start)
            Dim endPoints As Integer = _
            documentRange.CompareEndpoints(TextPatternRangeEndpoint.End, _
            searchRange, TextPatternRangeEndpoint.End)

            ' If the starting endpoints of the document range and the search
            ' range are equivalent then we can search forward only since the
            ' search range is at the start of the document.
            If startPoints = 0 Then
                searchForwardButton.IsEnabled = True
                searchBackwardButton.IsEnabled = False
                ' If the ending endpoints of the document range and the search
                ' range are identical then we can search backward only since the
                ' search range is at the end of the document.
            ElseIf endPoints = 0 Then
                searchForwardButton.IsEnabled = False
                searchBackwardButton.IsEnabled = True
                ' Otherwise we can search both directions.
            Else
                searchForwardButton.IsEnabled = True
                searchBackwardButton.IsEnabled = True
            End If

        End Sub

        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the Search button click.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        ' <remarks>Find the text specified in the text box.</remarks>
        '--------------------------------------------------------------------
        Private Sub SearchDirection_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim searchDirection As Button = CType(sender, Button)

            ' Are we searching backward through the text control?
            searchBackward = _
            (CType(searchDirection.Tag, traversalDirection) = traversalDirection.Backward)

            ' Check if search text entered
            If searchString.Text.Trim() = "" Then
                targetResult.Content = "No search criteria."
                targetResult.Background = Brushes.Salmon
                Return
            End If

            '<SnippetSupportedTextSelection>
            ' Does target range support text selection?
            If targetTextPattern.SupportedTextSelection = SupportedTextSelection.None Then
                targetResult.Content = "Unable to select text."
                targetResult.Background = Brushes.Salmon
                Return
            End If
            ' Does target range support multiple selections?
            If targetTextPattern.SupportedTextSelection = SupportedTextSelection.Multiple Then
                targetResult.Content = "Multiple selections present."
                targetResult.Background = Brushes.Salmon
                Return
            End If
            '</SnippetSupportedTextSelection>
            ' Clone the document range since we modify the endpoints
            ' as we search.
            Dim documentRangeClone As TextPatternRange = documentRange.Clone()

            ' Move the cloned document range endpoints to enable the
            ' selection of the next matching text range.
            Dim selectionRange As TextPatternRange() = targetTextPattern.GetSelection()
            If Not (selectionRange(0) Is Nothing) Then
                If searchBackward Then
                    documentRangeClone.MoveEndpointByRange( _
                    TextPatternRangeEndpoint.End, selectionRange(0), _
                    TextPatternRangeEndpoint.Start)
                Else
                    documentRangeClone.MoveEndpointByRange( _
                    TextPatternRangeEndpoint.Start, selectionRange(0), _
                    TextPatternRangeEndpoint.End)
                End If
            End If

            ' Find the text specified in the Search textbox.
            ' Clone the search range since we need to modify it.
            Dim searchRangeClone As TextPatternRange = searchRange.Clone()
            ' backward = false? -- search forward, otherwise backward.
            ' ignoreCase = false? -- search is case sensitive.
            searchRange = documentRangeClone.FindText(searchString.Text, searchBackward, False)

            ' Search unsuccessful.
            If searchRange Is Nothing Then
                ' Search string not found at all.
                If documentRangeClone.CompareEndpoints( _
                TextPatternRangeEndpoint.Start, searchRangeClone, _
                TextPatternRangeEndpoint.Start) = 0 Then
                    targetResult.Content = "Text not found."
                    targetResult.Background = Brushes.Wheat
                    searchBackwardButton.IsEnabled = False
                    searchForwardButton.IsEnabled = False
                Else
                    ' End of document (either the start or end of the document
                    ' range depending on search direction) was reached before
                    ' finding another occurrence of the search string.
                    targetResult.Content = "End of document reached."
                    targetResult.Background = Brushes.Wheat
                    If Not searchBackward Then
                        searchRangeClone.MoveEndpointByRange( _
                        TextPatternRangeEndpoint.Start, documentRange, _
                        TextPatternRangeEndpoint.End)
                        searchBackwardButton.IsEnabled = True
                        searchForwardButton.IsEnabled = False
                    Else
                        searchRangeClone.MoveEndpointByRange( _
                        TextPatternRangeEndpoint.End, documentRange, _
                        TextPatternRangeEndpoint.Start)
                        searchBackwardButton.IsEnabled = False
                        searchForwardButton.IsEnabled = True
                    End If
                End If
                searchRange = searchRangeClone
            Else
                ' The search string was found.
                targetResult.Content = "Text found."
                targetResult.Background = Brushes.LightGreen
            End If

            searchRange.Select()
            ' Scroll the selection into view and align with top of viewport
            searchRange.ScrollIntoView(True)
            ' The WPF target doesn't show selected text as highlighted unless
            ' the window has focus.
            targetWindow.SetFocus()

        End Sub
        '</SnippetSearchTarget>
#End Region

#Region "Target Navigation"
        ' <SnippetNavigate>
        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the navigation item selected event.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        '--------------------------------------------------------------------
        Private Sub NavigationUnit_Change( _
        ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            Dim cb As ComboBox = CType(sender, ComboBox)
            navigationUnit = CType(cb.SelectedValue, TextUnit)

        End Sub

        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the Navigate button click event.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        '--------------------------------------------------------------------
        Private Sub Navigate_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim moveSelection As Button = CType(sender, Button)
            Dim navDirection As Integer

            ' Which direction is the user searching through the text control?
            If (CType(moveSelection.Tag, traversalDirection) = traversalDirection.Forward) Then
                navDirection = 1
            Else
                navDirection = -1
            End If

            ' Obtain the ranges to move.
            Dim selectionRanges As TextPatternRange() = targetTextPattern.GetSelection()

            ' Iterate through the ranges for a text control that supports
            ' multiple selections and move the selections the specified text
            ' unit and direction.
            Dim textRange As TextPatternRange
            For Each textRange In selectionRanges
                textRange.Move(navigationUnit, navDirection)
                textRange.Select()
            Next textRange
            ' The WPF target doesn't show selected text as highlighted unless
            ' the window has focus.
            targetDocument.SetFocus()

        End Sub
        ' </SnippetNavigate>
#End Region

#Region "Expand Selection"
        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the expand to enclosing unit item selected event.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        '--------------------------------------------------------------------
        Private Sub ExpandToTextUnit_Change( _
        ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
            Dim cb As ComboBox = CType(sender, ComboBox)

            ' Expand the target selection to the selected text unit.
            Dim selectionRanges As TextPatternRange() = _
            targetTextPattern.GetSelection()
            Dim textRange As TextPatternRange
            For Each textRange In selectionRanges
                Select Case cb.SelectedValue.ToString()
                    Case "None"
                        textRange.MoveEndpointByRange( _
                        TextPatternRangeEndpoint.End, textRange, _
                        TextPatternRangeEndpoint.Start)
                    Case "Character"
                        textRange.ExpandToEnclosingUnit(TextUnit.Character)
                    Case "Format"
                        textRange.ExpandToEnclosingUnit(TextUnit.Format)
                    Case "Word"
                        textRange.ExpandToEnclosingUnit(TextUnit.Word)
                    Case "Line"
                        textRange.ExpandToEnclosingUnit(TextUnit.Line)
                    Case "Paragraph"
                        textRange.ExpandToEnclosingUnit(TextUnit.Paragraph)
                    Case "Page"
                        textRange.ExpandToEnclosingUnit(TextUnit.Page)
                    Case "Document"
                        textRange.ExpandToEnclosingUnit(TextUnit.Document)
                End Select
                textRange.Select()
                ' The WPF target doesn't show selected text as highlighted unless
                ' the window has focus.
                targetWindow.SetFocus()
            Next textRange

        End Sub
#End Region

#Region "Target Listeners"
        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the text changed event in the target.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        ' <remarks>
        ' Since the events are happening on a different thread than the
        ' client we need to use a Dispatcher delegate to handle them.
        ' </remarks>
        '--------------------------------------------------------------------
        Private Sub TextChanged(ByVal sender As Object, ByVal e As AutomationEventArgs)
            clientWindow.Dispatcher.BeginInvoke(DispatcherPriority.Send, _
            New TextChangeDelegate(AddressOf NotifyTextChanged), _
            "Text changed, range reset." + vbLf)

        End Sub


        '--------------------------------------------------------------------
        ' <summary>
        ' The delegate for the text changed event in the target.
        ' </summary>
        ' <param name="arg">null argument</param>
        ' <returns>A null object.</returns>
        '--------------------------------------------------------------------
        Private Sub NotifyTextChanged(ByVal message As String)
            ' Notify the user of the text changed event.
            targetSelectionLabel.Content = message
            ' Re-initialize the document range for the text of the document
            ' since we don't know the extent of the changes. For example, a
            ' change in the font color attribute, such as on a hyperlink
            ' mouseover, raises this event but doesn't change the content of
            ' the text control.
            documentRange = targetTextPattern.DocumentRange

        End Sub


        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the text selection changed event in the target.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        ' <remarks>
        ' Since the events are happening on a different thread than the
        ' client we need to use a Dispatcher delegate to handle them.
        ' </remarks>
        '--------------------------------------------------------------------
        Private Sub OnTextSelectionChange( _
        ByVal sender As Object, ByVal e As AutomationEventArgs)
            clientWindow.Dispatcher.BeginInvoke(DispatcherPriority.Send, _
            New SelectionChangeDelegate(AddressOf NotifySelectionChanged))

        End Sub


        '--------------------------------------------------------------------
        ' <summary>
        ' The delegate for the text selection changed event in the target.
        ' </summary>
        ' <param name="arg">null argument</param>
        ' <returns>A null object.</returns>
        '--------------------------------------------------------------------
        Private Sub NotifySelectionChanged()
            ' Get the array of disjoint selections.
            Dim selectionRanges As TextPatternRange() = targetTextPattern.GetSelection()
            ' Update the current search range.
            ' For the purposes of this sample only the first selection
            ' range will be echoed in the client.
            searchRange = selectionRanges(0)
            ' For performance and security reasons we'll limit
            ' the length of the string retrieved to 100 characters.
            ' Alternatively, GetText(-1) will retrieve all selected text.
            Dim selectedText As String = searchRange.GetText(100)
            targetSelectionLabel.Content = _
            "Currently selected (a maximum of 100 characters displayed): " + _
            selectedText.Length.ToString() + " characters." + vbLf

            ' Report target selection details.
            DisplaySelectedTextWithAttributes(selectedText)

        End Sub

        ' <SnippetRetrieveMixedAttributes>
        '--------------------------------------------------------------------
        ' <summary>
        ' Display the target selection with attribute details in client.
        ' </summary>
        ' <param name="selectedText">The current target selection.</param>
        '--------------------------------------------------------------------
        Private Sub DisplaySelectedTextWithAttributes(ByVal selectedText As String)
            targetSelection.Text = selectedText
            ' We're only interested in the FontNameAttribute for the purposes
            ' of this sample.
            targetSelectionAttributes.Text = _
                ParseTextRangeByAttribute( _
                selectedText, TextPattern.FontNameAttribute)
        End Sub

        '--------------------------------------------------------------------
        ' <summary>
        ' Parse the target selection based on the text attribute of interest.
        ' </summary>
        ' <param name="selectedText">The current target selection.</param>
        ' <param name="automationTextAttribute">
        ' The text attribute of interest.
        ' </param>
        ' <returns>
        ' A string representing the requested attribute details.
        ' </returns>
        '--------------------------------------------------------------------
        Function ParseTextRangeByAttribute( _
        ByVal selectedText As String, _
        ByVal automationTextAttribute As AutomationTextAttribute) As String
            Dim attributeDetails As StringBuilder = New StringBuilder()
            ' Initialize the current attribute value.
            Dim attributeValue As String = ""
            ' Make a copy of the text range.
            Dim searchRangeClone As TextPatternRange = searchRange.Clone()
            ' Collapse the range to the starting endpoint.
            searchRangeClone.Move(TextUnit.Character, -1)
            ' Iterate through the range character by character.
            Dim x As Integer
            For x = 1 To selectedText.Length
                searchRangeClone.Move(TextUnit.Character, 1)
                ' Get the attribute value of the current character.
                Dim newAttributeValue As String = _
                    searchRangeClone.GetAttributeValue(automationTextAttribute).ToString()
                ' If the new attribute value is not equal to the old then report
                ' the new value along with its location within the range.
                If (newAttributeValue <> attributeValue) Then
                    attributeDetails.Append(automationTextAttribute.ProgrammaticName) _
                    .Append(":") _
                    .Append(vbLf) _
                    .Append("<") _
                    .Append(newAttributeValue) _
                    .Append("> at text range position ") _
                    .AppendLine(x.ToString())
                    attributeValue = newAttributeValue
                End If
            Next
            Return attributeDetails.ToString()
        End Function
        ' </SnippetRetrieveMixedAttributes>


        '--------------------------------------------------------------------
        ' <summary>
        ' Handles the window closed event in the target.
        ' </summary>
        ' <param name="sender">The object that raised the event.</param>
        ' <param name="e">Event arguments.</param>
        '--------------------------------------------------------------------
        Private Sub OnTargetClose(ByVal sender As Object, ByVal e As AutomationEventArgs)
            clientWindow.Dispatcher.BeginInvoke(DispatcherPriority.Send, _
            New ProviderCloseDelegate(AddressOf CloseApp))

        End Sub


        '--------------------------------------------------------------------
        ' <summary>
        ' The delegate for the window closed event in the target.
        ' </summary>
        ' <param name="arg">null argument</param>
        ' <returns>A null object.</returns>
        '--------------------------------------------------------------------
        Private Sub CloseApp()
            ' Close the client window when the target window is closed.
            clientWindow.Close()

        End Sub
#End Region
    End Class
End Namespace
