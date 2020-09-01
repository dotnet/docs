 '******************************************************************************
' *
' * File: UIAWorker.cs
' *
' * Description: A Class that implements UI Automation functionality
' *              in the form of a focus tracker on a separate thread.
' * 
' * For a full description of the sample, see Client.cs.
' *
' *     
' *  This file is part of the Microsoft WinfFX SDK Code Samples.
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
' *****************************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation
Imports System.Diagnostics
Imports System.Threading
Imports System.Collections



Class UIAWorker
    ' Member variables
    Private targetApp As AutomationElement
    
    ' The desktop.
    Private rootElement As AutomationElement
    
    Public elementQueue As New Queue()

    Public controlStore As ArrayList
    
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="target">The target application.</param>
    Public Sub New(ByVal target As AutomationElement)
        ' Initialize member variables.
        targetApp = target
        ' Get UI Automation root element.
        rootElement = AutomationElement.RootElement

        RegisterTargetControls()

        Feedback("Worker created; now listening.")

    End Sub


    Private Sub RegisterTargetControls()
        ' Create a CacheRequest.
        Dim cacheRequest As New CacheRequest()

        ' Set the scope to Element. Remember that the scope is relative to the elements retrieved.
        ' When we retrieve children, the properties of each of those children will be cached.
        cacheRequest.TreeScope = TreeScope.Element

        ' Specify properties to cache.
        cacheRequest.Add(AutomationElement.AutomationIdProperty)
        cacheRequest.Add(AutomationElement.NameProperty)

        ' Get all immediate children of the target.
        Dim elementCollection As AutomationElementCollection
        Using cacheRequest.Activate()
            elementCollection = targetApp.FindAll(TreeScope.Children, Automation.ControlViewCondition)
        End Using

        ' Put the collection in an ArrayList for added functionality.
        controlStore = New ArrayList()

        Dim element As AutomationElement
        For Each element In elementCollection
            AddToControlStore(element)
        Next element

        RegisterForEvents()

    End Sub


    Private Sub RegisterForEvents()
        ' Subscribe to events of interest. 
        ' Do this while a CacheRequest is activated, so that the AutomationElement passed
        ' to the event handlers will have cached properties.
        Dim cacheRequest As New CacheRequest()
        cacheRequest.Add(AutomationElement.NameProperty)
        cacheRequest.Add(AutomationElement.ControlTypeProperty)
        cacheRequest.TreeScope = TreeScope.Element

        Using cacheRequest.Activate()
                            ' Focus changes are global; we'll get cached properties for all elements that receive focus.
            Dim focusHandler As New AutomationFocusChangedEventHandler(AddressOf OnFocusChange)
            Automation.AddAutomationFocusChangedEventHandler(focusHandler)

            'foreach (AutomationElement element in controlStore)
            '{
            '    AutomationPattern[] automationPatterns = element.GetSupportedPatterns();
            '    foreach (AutomationPattern automationPattern in automationPatterns)
            '    {
            '        switch (automationPattern.ProgrammaticName)
            '        {
            '            case "InvokePatternIdentifiers.Pattern":
            '                AutomationEventHandler invokeHandler =
            '                    new AutomationEventHandler(OnInvoke);
            '                Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, element, TreeScope.Element, invokeHandler);
            '                break;
            '        }
            '    }
            '}
            'AutomationEventHandler invokeHandler = new AutomationEventHandler(OnInvoke);
            'Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, 
            '    targetApp, TreeScope.Descendants, invokeHandler);
            Dim element As AutomationElement
            For Each element In controlStore
                If CBool(element.GetCurrentPropertyValue(AutomationElement.IsInvokePatternAvailableProperty)) Then
                    Dim invokeHandler As New AutomationEventHandler(AddressOf OnInvoke)
                    Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent, element, TreeScope.Element, invokeHandler)
                End If
                If CBool(element.GetCurrentPropertyValue(AutomationElement.IsRangeValuePatternAvailableProperty)) Then
                End If
            Next element 'AutomationPropertyChangedEventHandler rangevalueHandler =
        End Using
        '    new AutomationPropertyChangedEventHandler(OnRangeValueChange);
    End Sub
    'Automation.AddAutomationPropertyChangedEventHandler(
    '    element, TreeScope.Element, rangevalueHandler, RangeValuePattern.
    'Automation.AddAutomationEventHandler(InvokePattern.InvokedEvent,
    '    element, TreeScope.Element, invokeHandler));

    ''' <summary>
    ''' Adds a top-level window to the collection of cached elements, and subscribes
    ''' to window-closed events.
    ''' </summary>
    ''' <param name="element">The window element.</param>
    Private Sub AddToControlStore(ByVal element As AutomationElement) 
        ' If it's a real window (not Program Manager), subscribe to window-closed event.
        'Object pattern;
        'if (element.TryGetCachedPattern(WindowPattern.Pattern, out pattern))
        '{
        '    Automation.AddAutomationEventHandler(WindowPattern.WindowClosedEvent, element,
        '            TreeScope.Element, new AutomationEventHandler(OnWindowClosed));
        '}
        ' Add it to our collection.
        controlStore.Add(element)

    End Sub


    ''' <summary>
    ''' Handle invoke events of interest.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    ''' <remarks>
    ''' Some controls that have not implemented UI Automation correctly
    ''' may fire spurious events. For example, a WinForms button will 
    ''' fire an InvokedEvent on a mouse-down and then another series of 
    ''' InvokedEvents on the subsequent mouse-up.</remarks>
    Private Sub OnInvoke(ByVal src As Object, ByVal e As AutomationEventArgs)
        Dim invokeTime As DateTime = DateTime.Now

        Feedback("Invoke event.")

        Dim invokedElement As AutomationElement = DirectCast(src, AutomationElement) 
        Feedback(invokedElement.Current.Name)

        Dim invokeEvent As New ElementStore()
        Try
            invokeEvent.AutomationID = invokedElement.Current.AutomationId
            invokeEvent.ClassName = invokedElement.Current.ClassName
            invokeEvent.ControlType = invokedElement.Current.ControlType.ProgrammaticName
            invokeEvent.EventID = e.EventId.ProgrammaticName
            invokeEvent.SupportedPatterns = invokedElement.GetSupportedPatterns()
            invokeEvent.EventTime = invokeTime
            elementQueue.Enqueue(invokeEvent)
        Catch
            Return
        End Try

    End Sub


    ''' <summary>
    ''' Handle the event.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub OnFocusChange(ByVal src As Object, ByVal e As AutomationFocusChangedEventArgs)
        Dim invokeTime As DateTime = DateTime.Now

        Feedback("Focus changed.")

        Dim focusedElement As AutomationElement = DirectCast(src, AutomationElement)

        Dim topLevelWindow As AutomationElement = GetTopLevelWindow(focusedElement)

        If topLevelWindow <> targetApp Then
            Return
        End If

        Feedback(focusedElement.Current.Name)

        Dim focusChange As New ElementStore()
        Try
            focusChange.AutomationID = focusedElement.Current.AutomationId
            focusChange.ClassName = focusedElement.Current.ClassName
            focusChange.ControlType = focusedElement.Current.ControlType.ProgrammaticName
            focusChange.EventID = e.EventId.ProgrammaticName
            focusChange.SupportedPatterns = focusedElement.GetSupportedPatterns()
            focusChange.EventTime = invokeTime
            elementQueue.Enqueue(focusChange)
        Catch
            Return
        End Try

    End Sub
    
    
    '''--------------------------------------------------------------------
    ''' <summary>
    ''' Retrieves the top-level window that contains the 
    ''' UI Automation element of interest.
    ''' </summary>
    ''' <param name="element">The contained element.</param>
    ''' <returns>The containing top-level window element.</returns>
    '''--------------------------------------------------------------------
    Private Function GetTopLevelWindow(ByVal element As AutomationElement) As AutomationElement 
        Dim walker As TreeWalker = TreeWalker.ControlViewWalker
        Dim elementParent As AutomationElement
        Dim node As AutomationElement = element
        If node = rootElement Then
            Return node
        End If
        Do
            elementParent = walker.GetParent(node)
            If elementParent = rootElement Then
                Exit Do
            End If
            node = elementParent
        Loop While True
        Return node
    
    End Function 'GetTopLevelWindow
    
    
    ''' <summary>
    ''' Destructor.
    ''' </summary>
    Protected Overloads Overrides Sub Finalize()
        MyBase.Finalize()

    End Sub


    Public Sub Shutdown()
        Automation.RemoveAllEventHandlers()

    End Sub


    ''' <summary>
    ''' Prints a line of text to the textbox.
    ''' </summary>
    ''' <param name="outputStr">The string to print.</param>
    ''' <remarks>Must use Invoke so that UI is not being called directly from this thread.</remarks>
    Private Sub Feedback(ByVal outputStr As String) 
    
    End Sub
End Class

