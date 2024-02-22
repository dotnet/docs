' *************************************************************************************************
' *
' * File: FocusTracker
' *
' * Description: This is a simple console application that might be used as a starting-point for an
' * application that uses UI Automation to track events on the desktop.
' *
' * The program announces when the input focus changes. If the focus moves to a different application window,
' * the caption of the window is announced. If the focus moves within an application window, the type and name
' * of the control being read are announced.
' *
' * To know when the focus switches from one application to another, the program keeps a list of the runtime
' * identifiers of all open top-level windows. In response to each focus-changed event, a TreeWalker is used
' * to find the parent window, and that window is compared with the last window that had focus.
' *
' * The program subscribes to three event types:
' *
' *  -- Structure changed. The only event of interest is the addition of a new top-level window.
' *  -- Focus changed. All events are captured.
' * --  Window closed. When a top-level window is closed, its runtime ID is removed from the list.
' *
' * For simplicity, no caching is done. A full-scale application would likely cache all immediate children
' * of an application window as soon as that window received focus.
' *
' *
' *  This file is part of the Microsoft Windows SDK Code Samples.
' *
' *  Copyright (C) Microsoft Corporation.  All rights reserved.
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
' ************************************************************************************************


Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation
Imports System.Timers
Imports System.Collections
Imports System.Diagnostics



Class Program

    Public Shared Sub Main(ByVal args() As String)
        Dim reader As New Reader()
        Console.ReadLine()
        Automation.RemoveAllEventHandlers()

    End Sub
End Class


Class Reader
    Private elementRoot As AutomationElement
    Private lastTopLevelWindow As AutomationElement = Nothing
    'AutomationFocusChangedEventHandler onFocusChanged;
    Private savedRuntimeIds As ArrayList
    'StructureChangedEventHandler onStructureChanged;
    Private onWindowClosed As AutomationEventHandler = Nothing


    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()
        ' Get UI Automation root element.
        elementRoot = AutomationElement.RootElement

        ' Make a list of runtime IDs of top-level windows.
        ' An alternative would be to keep a list of process IDs. However, it is somewhat more difficult
        ' to track the termination of processes, because the only information available from a
        ' window-closed event is the runtime ID.
        savedRuntimeIds = New ArrayList()
        Dim elementCollection As AutomationElementCollection = elementRoot.FindAll(TreeScope.Children, Condition.TrueCondition)

        ' Add each application window to the list and subscribe it to the WindowClosedEvent handler.
        onWindowClosed = New AutomationEventHandler(AddressOf WindowClosedHandler)
        Dim element As AutomationElement
        For Each element In elementCollection
            Dim rid As Integer() = CType(element.GetCurrentPropertyValue(AutomationElement.RuntimeIdProperty), Integer())
            If RuntimeIdListed(rid, savedRuntimeIds) < 0 Then
                savedRuntimeIds.Add(rid)
                AddToWindowHandler(element)
            End If
        Next element

        ' Add other event handlers.
        ' <Snippet104>
        ' elementRoot is an AutomationElement.
        Automation.AddStructureChangedEventHandler(elementRoot, TreeScope.Children, New StructureChangedEventHandler(AddressOf OnStructureChanged))
        ' </Snippet104>
        Automation.AddAutomationFocusChangedEventHandler(New AutomationFocusChangedEventHandler(AddressOf OnFocusChanged))

    End Sub



    ' <Snippet106>
    Private Sub OnFocusChanged(ByVal src As Object, ByVal e As AutomationFocusChangedEventArgs)
        Dim elementFocused As AutomationElement = DirectCast(src, AutomationElement)
        ' TODO: Do something in response to the focus change.
    End Sub
    ' </Snippet106>

    ' <Snippet105>
    ''' <summary>
    ''' Handles structure-changed events. If a new app window has been added, this method ensures
    ''' it's in the list of runtime IDs and subscribed to window-close events.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    ''' <remarks>
    ''' An exception can be thrown by the UI Automation core if the element disappears
    ''' before it can be processed -- for example, if a menu item is only briefly visible.
    ''' This exception cannot be caught here because it crosses native/managed boundaries.
    ''' In the debugger, you can ignore it and continue execution. The exception does not cause
    ''' a break when the executable is being run.
    ''' </remarks>
    Private Sub OnStructureChanged(ByVal sender As Object, ByVal e As StructureChangedEventArgs)

        Dim element As AutomationElement = DirectCast(sender, AutomationElement)
        If e.StructureChangeType = StructureChangeType.ChildAdded Then
            Dim myWindowPattern As Object = Nothing
            If False = element.TryGetCurrentPattern(WindowPattern.Pattern, myWindowPattern) Then
                Return
            End If
            Dim rid As Integer() = e.GetRuntimeId()
            If RuntimeIdListed(rid, savedRuntimeIds) < 0 Then
                AddToWindowHandler(element)
                savedRuntimeIds.Add(rid)
            End If
        End If

    End Sub
    ' </Snippet105>

    ' <Snippet101>
    ''' <summary>
    ''' Handles window-closed events. Removes the window from the top-level window list.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    ''' <remarks>
    ''' runtimeIds is an ArrayList that contains the runtime IDs of all top-level windows.
    ''' </remarks>
    Private Sub WindowClosedHandler(ByVal sender As Object, ByVal e As AutomationEventArgs)
        Dim windowEventArgs As WindowClosedEventArgs = CType(e, WindowClosedEventArgs)
        Dim runtimeIdentifiers As Integer() = windowEventArgs.GetRuntimeId()
        Dim index As Integer = RuntimeIdListed(runtimeIdentifiers, savedRuntimeIds)
        If index >= 0 Then
            savedRuntimeIds.RemoveAt(index)
            Console.WriteLine("Window closed.")
        End If

    End Sub


    ''' <summary>
    ''' Ascertains whether the window is in the list.
    ''' </summary>
    ''' <param name="rid">Runtime ID of the window.</param>
    ''' <returns>Index of the ID in the list, or -1 if it is not listed.</returns>
    ''' <remarks>
    ''' runtimeIds is an ArrayList that contains the runtime IDs of all top-level windows.
    ''' </remarks>
    ' <Snippet103>
    Private Function RuntimeIdListed(ByVal runtimeId() As Integer, ByVal runtimeIds As ArrayList) As Integer
        Dim x As Integer
        For x = 0 To runtimeIds.Count - 1
            Dim listedId As Integer() = CType(runtimeIds(x), Integer())
            If Automation.Compare(listedId, runtimeId) Then
                Return x
            End If
        Next x
        Return -1

    End Function 'RuntimeIdListed

    ' </Snippet103>

    ' </Snippet101>

    ''' <summary>
    ''' Gets the caption of a window.
    ''' </summary>
    ''' <param name="elementWindow">The window element.</param>
    ''' <returns>The caption.</returns>
    Private Function GetTitle(ByVal elementWindow As AutomationElement) As String
        Dim elementTitle As AutomationElement = Nothing
        Dim cond As Condition = New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TitleBar)
        elementTitle = elementWindow.FindFirst(TreeScope.Children, cond)
        If Not (elementTitle Is Nothing) Then
            Return elementTitle.Current.Name
        Else
            Return Nothing
        End If

    End Function 'GetTitle

    ''' <summary>
    ''' Subscribes a window element to the window-closed event.
    ''' </summary>
    ''' <param name="element">The window element.</param>
    Private Sub AddToWindowHandler(ByVal element As AutomationElement)
        Dim myWindowPattern As Object = Nothing
        If element.TryGetCurrentPattern(WindowPattern.Pattern, myWindowPattern) Then
            Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, element, TreeScope.Element, onWindowClosed)
        End If

    End Sub


    ' <Snippet102>
    ''' <summary>
    ''' Retrieves the top-level window that contains the specified UI Automation element.
    ''' </summary>
    ''' <param name="element">The contained element.</param>
    ''' <returns>The containing top-level window element.</returns>
    Private Function GetTopLevelWindow(ByVal element As AutomationElement) As AutomationElement
        Dim walker As TreeWalker = TreeWalker.ControlViewWalker
        Dim elementParent As AutomationElement
        Dim node As AutomationElement = element
        If node = elementRoot Then
            Return node
        End If
        Do
            elementParent = walker.GetParent(node)
            If elementParent = AutomationElement.RootElement Then
                Exit Do
            End If
            node = elementParent
        Loop While True
        Return node

    End Function 'GetTopLevelWindow
End Class
' </Snippet102>
' Reader class.
' FocusTracker namespace
