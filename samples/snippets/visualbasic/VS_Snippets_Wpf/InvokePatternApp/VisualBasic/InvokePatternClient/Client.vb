'*****************************************************************************
' * File: InvokePatternApp.vb
' *
'* Description: 
'*    This sample demonstrates the UI Automation ExpandCollapse, Invoke, and 
'*    Toggle control pattern classes.
'* 
'*    The sample consists of a Windows Presentation Foundation (WPF) client and 
'*    a WPF target containing a variety of TreeView controls. The client uses the 
'*    ExpandCollapse, Invoke, and Toggle control patterns to interact with the  
'*    controls in the target.  
'* 
'*    The functionality demonstrated by the sample includes the ability to 
'*    report target control properties and call the supported methods exposed 
'*    by the respective control patterns such as invoke, toggle, expand or collapse.
'* 
'* Notes:
'*    1. Hidden child controls are not present in the UI Automation tree until 
'*       they are created and displayed by expanding the top-level TreeViewItem. 
'*    2. Unless a menu item performs an action other than expanding/collapsing,
'*       it does not support the Invoke pattern (ie, the 'Help' menu item in 
'*       notepad supports ExpandCollapse but does not support Invoke, however, 
'*       the 'About Notepad' menu item under the 'Help' menu supports  
'*       InvokePattern as it creates an instance of the 'About Notepad' dialog).
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
' ****************************************************************************

Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Threading

Namespace InvokePatternSample
    '''------------------------------------------------------------------------
    ''' <summary>
    ''' Interaction logic for WCP client and Win32 target
    ''' </summary>
    '''------------------------------------------------------------------------

    Public Class InvokePatternApp
        Inherits Application
#Region "Member variables"
        Private clientWindow As Window
        Private rootElement As AutomationElement
        Private clientTreeViews() As StackPanel
        Private statusText As TextBlock
        Private treeviewPanel As StackPanel
        Private elementInfoCompile As StringBuilder
        Private clientScrollViewer As ScrollViewer
        Private targetApp As String
        ' Delegates for updating the client UI based on target application events.
        Private Delegate Sub OutputDelegate(ByVal message As String)
#End Region

#Region "Target listeners"
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Listens for a structure changed event in the target.
        ''' </summary>
        ''' <param name="sender">The object that raised the event.</param>
        ''' <param name="e">Event arguments.</param>
        ''' <remarks>
        ''' Since the events are happening on a different thread than the
        ''' client we need to use a Dispatcher delegate to handle them.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Sub ChildElementsAdded(ByVal sender As Object, ByVal e As StructureChangedEventArgs)
            clientWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, New DispatcherOperationCallback(AddressOf NotifyChildElementsAdded), Nothing)
        End Sub


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' The delegate for the structure changed event in the target.
        ''' </summary>
        ''' <param name="arg">null argument</param>
        ''' <returns>A null object.</returns>
        '''--------------------------------------------------------------------
        Private Function NotifyChildElementsAdded(ByVal arg As Object) As Object
            FindTreeViewsInTarget()
            Return Nothing

        End Function 'NotifyChildElementsAdded


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Handles the window closed event in the target.
        ''' </summary>
        ''' <param name="sender">The object that raised the event.</param>
        ''' <param name="e">Event arguments.</param>
        '''--------------------------------------------------------------------
        Private Sub onTargetClose(ByVal sender As Object, ByVal e As AutomationEventArgs)
            clientWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, New DispatcherOperationCallback(AddressOf CloseApp), Nothing)
        End Sub


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' The delegate for the window closed event in the target.
        ''' </summary>
        ''' <param name="arg">null argument</param>
        ''' <returns>A null object.</returns>
        '''--------------------------------------------------------------------
        Private Function CloseApp(ByVal arg As Object) As Object
            clientWindow.Close()
            Return Nothing
        End Function 'CloseApp
#End Region

#Region "Client setup"

        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Initialize both client and target applications.
        ''' </summary>
        ''' <param name="e">Startup arguments</param>
        '''--------------------------------------------------------------------
        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            ' Create our informational window
            CreateWindow()

            ' Get the root element from our target application.
            ' In general, you should try to obtain only direct children of 
            ' the RootElement. A search for descendants may iterate through 
            ' hundreds or even thousands of elements, possibly resulting in 
            ' a stack overflow. If you are attempting to obtain a specific 
            ' element at a lower level, you should start your search from the 
            ' application window or from a container at a lower level.
            targetApp =
            System.Windows.Forms.Application.StartupPath + "\InvokePatternTarget.exe"
            rootElement = StartApp(targetApp)
            If rootElement Is Nothing Then
                Return
            End If

            ' Add a structure change listener for the root element.
            Dim structureChange As _
            New StructureChangedEventHandler(AddressOf ChildElementsAdded)
            Automation.AddStructureChangedEventHandler(
            rootElement, TreeScope.Descendants, structureChange)

            ' Iterate through the controls in the target application.
            FindTreeViewsInTarget()
        End Sub


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Start the target application.
        ''' </summary>
        ''' <param name="app">The target application.</param>
        ''' <remarks>
        ''' Starts the application that we are going to use as our 
        ''' root element for this sample.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Function StartApp(ByVal app As String) As AutomationElement
            If (File.Exists(app)) Then
                Dim targetElement As AutomationElement

                ' Start application.
                Dim p As Process = Process.Start(app)

                ' Give application a second to startup.
                Thread.Sleep(2000)

                targetElement = AutomationElement.FromHandle(p.MainWindowHandle)
                If targetElement Is Nothing Then
                    Return Nothing
                Else
                    Dim targetClosedHandler As _
                    New AutomationEventHandler(AddressOf onTargetClose)
                    Automation.AddAutomationEventHandler(
                    WindowPattern.WindowClosedEvent,
                    targetElement, TreeScope.Element, targetClosedHandler)

                    ' Set size and position of target.
                    Dim targetTransformPattern As TransformPattern =
                    DirectCast(targetElement.GetCurrentPattern(TransformPattern.Pattern),
                    TransformPattern)
                    If (IsNothing(targetTransformPattern)) Then
                        Return Nothing
                    End If

                    targetTransformPattern.Resize(550, 400)
                    targetTransformPattern.Move(
                    clientWindow.Left + clientWindow.Width + 25, clientWindow.Top)

                    Output("Target started.")

                    ' Return the AutomationElement
                    Return targetElement
                End If
            Else
                Output((app + " not found."))
                Return Nothing
            End If
        End Function 'StartApp


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Creates a client window to which output may be written.
        ''' </summary>
        '''--------------------------------------------------------------------
        Private Sub CreateWindow()
            ' Define a window.
            clientWindow = New Window()
            clientWindow.Width = 400
            clientWindow.Height = 600
            clientWindow.Left = 50
            clientWindow.Top = 50

            ' Define a ScrollViewer.
            clientScrollViewer = New ScrollViewer()
            clientScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto
            clientScrollViewer.HorizontalContentAlignment = HorizontalAlignment.Stretch

            ' Add Layout control.
            Dim clientStackPanel As New StackPanel()
            Dim statusPanel As New StackPanel()
            statusPanel.HorizontalAlignment = HorizontalAlignment.Center
            treeviewPanel = New StackPanel()

            statusText = New TextBlock()
            statusText.FontWeight = FontWeights.Bold
            statusText.TextWrapping = TextWrapping.Wrap

            ' Add child elements to the parent StackPanel
            statusPanel.Children.Add(statusText)
            clientStackPanel.Children.Add(statusPanel)
            clientStackPanel.Children.Add(treeviewPanel)

            ' Add the StackPanel as the lone Child of the Border
            clientScrollViewer.Content = clientStackPanel

            ' Add the Border as the Content of the Parent Window Object
            clientWindow.Content = clientScrollViewer
            clientWindow.Show()

        End Sub


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Finds all TreeView controls in the target.
        ''' </summary>
        '''--------------------------------------------------------------------
        Private Sub FindTreeViewsInTarget()
            ' Initialize the client area used to report target controls.
            treeviewPanel.Children.Clear()
            ' Set up our search condition
            Dim rootTreeViewCondition As New _
            PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Tree)
            ' Find all controls that support the condition.
            Dim targetTreeViewElements As AutomationElementCollection = _
            rootElement.FindAll(TreeScope.Children, rootTreeViewCondition)
            If targetTreeViewElements.Count <= 0 Then
                Output("TreeView control(s) not found.")
                Return
            End If
            ' Create an area in the client to report each TreeView in the target.
            clientTreeViews = New StackPanel(targetTreeViewElements.Count) {}
            Dim elementIndex As Integer
            For elementIndex = 0 To targetTreeViewElements.Count - 1
                clientTreeViews(elementIndex) = New StackPanel()
                Dim clientTreeViewBorder As New Border()
                clientTreeViewBorder.BorderThickness = New Thickness(1)
                clientTreeViewBorder.BorderBrush = Brushes.Black
                clientTreeViewBorder.Margin = New Thickness(5)
                clientTreeViewBorder.Background = Brushes.LightGray
                clientTreeViewBorder.Child = clientTreeViews(elementIndex)
                treeviewPanel.Children.Add(clientTreeViewBorder)
                ' Iterate through the descendant controls of each TreeView.
                FindTreeViewDescendants(targetTreeViewElements(elementIndex), elementIndex)
            Next elementIndex

        End Sub


        '<Snippet1100>
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Walks the UI Automation tree of the target and reports the control 
        ''' type of each element it finds in the control view to the client.
        ''' </summary>
        ''' <param name="targetTreeViewElement">
        ''' The root of the search on this iteration.
        ''' </param>
        ''' <param name="treeviewIndex">
        ''' The TreeView index for this iteration.
        ''' </param>
        ''' <remarks>
        ''' This is a recursive function that maps out the structure of the 
        ''' subtree beginning at the AutomationElement passed in as 
        ''' rootElement on the first call. This could be, for example,
        ''' an application window.
        ''' CAUTION: Do not pass in AutomationElement.RootElement. Attempting 
        ''' to map out the entire subtree of the desktop could take a very 
        ''' long time and even lead to a stack overflow.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Sub FindTreeViewDescendants( _
        ByVal targetTreeViewElement As AutomationElement, _
        ByVal treeviewIndex As Integer)
            If (IsNothing(targetTreeViewElement)) Then
                Return
            End If

            Dim elementNode As AutomationElement = _
            TreeWalker.ControlViewWalker.GetFirstChild(targetTreeViewElement)

            While Not (elementNode Is Nothing)
                Dim elementInfo As New Label()
                elementInfo.Margin = New Thickness(0)
                clientTreeViews(treeviewIndex).Children.Add(elementInfo)

                ' Compile information about the control.
                elementInfoCompile = New StringBuilder()
                Dim controlName As String
                If (elementNode.Current.Name = "") Then
                    controlName = "Unnamed control"
                Else
                    controlName = elementNode.Current.Name
                End If
                Dim autoIdName As String
                If (elementNode.Current.AutomationId = "") Then
                    autoIdName = "No AutomationID"
                Else
                    autoIdName = elementNode.Current.AutomationId
                End If


                elementInfoCompile.Append(controlName).Append(" (") _
                .Append(elementNode.Current.ControlType.LocalizedControlType) _
                .Append(" - ").Append(autoIdName).Append(")")

                ' Test for the control patterns of interest for this sample.
                Dim objPattern As Object = Nothing
                Dim expcolPattern As ExpandCollapsePattern
                If True = elementNode.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, objPattern) Then
                    expcolPattern = DirectCast(objPattern, ExpandCollapsePattern)
                    If expcolPattern.Current.ExpandCollapseState <> ExpandCollapseState.LeafNode Then
                        Dim expcolButton As New Button()
                        expcolButton.Margin = New Thickness(0, 0, 0, 5)
                        expcolButton.Height = 20
                        expcolButton.Width = 100
                        expcolButton.Content = "ExpandCollapse"
                        expcolButton.Tag = expcolPattern
                        AddHandler expcolButton.Click, AddressOf ExpandCollapse_Click
                        clientTreeViews(treeviewIndex).Children.Add(expcolButton)
                    End If
                End If
                Dim togPattern As TogglePattern
                If True = elementNode.TryGetCurrentPattern(TogglePattern.Pattern, objPattern) Then
                    togPattern = DirectCast(objPattern, TogglePattern)
                    Dim togButton As New Button()
                    togButton.Margin = New Thickness(0, 0, 0, 5)
                    togButton.Height = 20
                    togButton.Width = 100
                    togButton.Content = "Toggle"
                    togButton.Tag = togPattern
                    AddHandler togButton.Click, AddressOf Toggle_Click
                    clientTreeViews(treeviewIndex).Children.Add(togButton)
                End If
                Dim invPattern As InvokePattern
                If True = elementNode.TryGetCurrentPattern(InvokePattern.Pattern, objPattern) Then
                    invPattern = DirectCast(objPattern, InvokePattern)
                    Dim invButton As New Button()
                    invButton.Margin = New Thickness(0)
                    invButton.Height = 20
                    invButton.Width = 100
                    invButton.Content = "Invoke"
                    invButton.Tag = invPattern
                    AddHandler invButton.Click, AddressOf Invoke_Click
                    clientTreeViews(treeviewIndex).Children.Add(invButton)
                End If
                ' Display compiled information about the control.
                elementInfo.Content = elementInfoCompile
                Dim sep As New Separator()
                clientTreeViews(treeviewIndex).Children.Add(sep)

                ' Iterate to next element.
                ' elementNode - Current element.
                ' treeviewIndex - Index of parent TreeView.
                FindTreeViewDescendants(elementNode, treeviewIndex)
                elementNode = TreeWalker.ControlViewWalker.GetNextSibling(elementNode)
            End While

        End Sub

        '</Snippet1100>
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Handles the Toggle click event.
        ''' </summary>
        ''' <param name="sender">The object that raised the event.</param>
        ''' <param name="e">Event arguments.</param>
        '''--------------------------------------------------------------------
        Private Sub Toggle_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim clientButton As Button = DirectCast(sender, Button)
            Dim t As TogglePattern = DirectCast(clientButton.Tag, TogglePattern)
            If (IsNothing(t)) Then
                Return
            End If
            t.Toggle()
            statusText.Text = "Element toggled " + t.Current.ToggleState.ToString()
        End Sub

        '<Snippet1102>
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Handles the Invoke click event on the client control. 
        ''' The client click handler calls Invoke() on the equivalent target control.
        ''' </summary>
        ''' <param name="sender">The object that raised the event.</param>
        ''' <param name="e">Event arguments.</param>
        ''' <remarks>
        ''' The Tag property of the FrameworkElement, the client button in this 
        ''' case, is used to store the InvokePattern object previously obtained 
        ''' from the associated target control.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Sub Invoke_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim clientButton As Button = DirectCast(sender, Button)
            Dim targetInvokePattern As InvokePattern = _
            DirectCast(clientButton.Tag, InvokePattern)
            If (IsNothing(targetInvokePattern)) Then
                Return
            End If
            targetInvokePattern.Invoke()
            statusText.Text = "Button invoked."
        End Sub

        '</Snippet1102>
        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Handles the ExpandCollapse click event.
        ''' </summary>
        ''' <param name="sender">The object that raised the event.</param>
        ''' <param name="e">Event arguments.</param>
        '''--------------------------------------------------------------------
        Private Sub ExpandCollapse_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim clientButton As Button = DirectCast(sender, Button)
            Dim ec As ExpandCollapsePattern = _
            DirectCast(clientButton.Tag, ExpandCollapsePattern)
            If (IsNothing(ec)) Then
                Return
            End If
            Dim currentState As ExpandCollapseState = ec.Current.ExpandCollapseState
            Try
                If currentState = ExpandCollapseState.Collapsed _
                OrElse currentState = ExpandCollapseState.PartiallyExpanded Then
                    ec.Expand()
                    statusText.Text = "TreeItem expanded."
                ElseIf currentState = ExpandCollapseState.Expanded Then
                    ec.Collapse()
                    statusText.Text = "TreeItem collapsed."
                End If
            Catch
                ' The current state of the element is LeafNode.
                Output("Unable to expand or collapse the element.")
            End Try
        End Sub


        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Handles the text changed event in the target.
        ''' </summary>
        ''' <param name="message">The feedback string to display.</param>
        ''' <remarks>
        ''' Since the events are happening on a different thread than the
        ''' client we need to use a Dispatcher delegate to handle them.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Sub Output(ByVal message As String)
            clientWindow.Dispatcher.BeginInvoke( _
            DispatcherPriority.Background, _
            New OutputDelegate(AddressOf NotifyTargetEvent), message)
        End Sub

        '''--------------------------------------------------------------------
        ''' <summary>
        ''' The delegate for the text changed event in the target.
        ''' </summary>
        ''' <param name="arg">string argument</param>
        '''--------------------------------------------------------------------
        Private Sub NotifyTargetEvent(ByVal arg As String)
            Dim message As String = DirectCast(arg, String)
            statusText.Text = message
        End Sub

        '''--------------------------------------------------------------------
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        '''--------------------------------------------------------------------

        Friend NotInheritable Class TestMain
            <STAThread()> _
            Shared Sub Main()
                ' Create an instance of the sample class 
                ' and call its Run() method to start it.
                Dim app As New InvokePatternApp()
                app.Run()
            End Sub
        End Class

        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Handles our application shutdown.
        ''' </summary>
        ''' <param name="e">Event arguments.</param>
        '''--------------------------------------------------------------------
        Protected Overrides Sub OnExit(ByVal e As ExitEventArgs)
            If Not (rootElement Is Nothing) Then
                Automation.RemoveAllEventHandlers()
            End If
            MyBase.OnExit(e)
        End Sub
#End Region

    End Class

End Namespace

