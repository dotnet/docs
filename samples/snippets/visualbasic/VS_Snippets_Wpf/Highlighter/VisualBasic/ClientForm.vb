 '******************************************************************************
' * File: ClientForm.vb
' *
' * Description: 
' * 
' * The sample demonstrates how to keep track of focus changes so that focused
' * elements can be highlighted on the screen. The highlight is a simple colored
' * rectangle, but it could be a magnifier window or some other tool to make the
' * focused element more accessible.
' * 
' * For convenience and simplicity, the sample runs in its own window. A real-world
' * application might run in the background.
' * 
' * Sometimes focus-changed events occur in rapid succession: for example, when
' * the user rapidly moves the cursor down a menu. Also, when a complex element 
' * such as a list box receives the focus, generally two events are raised: one
' * for the container receiving the focus, and one for the focused item within
' * the container. To avoid flicker (rapid drawing and erasing of the highlight),
' * the sample uses a timer. The timer is started, or restarted, whenever an event
' * is received. Only when the timer reaches its interval is the highlight redrawn.
' * Thus the response to an event becomes "pending" when the event occurs and is 
' * discarded if another event occurs before the timer interval has elapsed.
' * 
' * You can experiment with different timer intervals by using the slider.
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
' *****************************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Automation
Imports System.Threading
Imports System.Timers



''' <summary>
''' The form for the client application.
''' </summary>
Class ClientForm
    Inherits Form
    Private highlight As HighlightRectangle
    Private useTimer As Boolean = True
    Private WithEvents eventTimer As System.Timers.Timer
    Private focusedRect As System.Windows.Rect
    Private focusHandler As AutomationFocusChangedEventHandler
    Private focusedElement As AutomationElement
    Private timerInterval As Integer


    ''' <summary>
    ''' Constructor.
    ''' </summary>
    Public Sub New()
        ' Make the process DPI-aware. Doing this ensures that when the
        ' screen is set to a nonstandard DPI, all coordinates are 
        ' correctly scaled and the highlight rectangle is displayed
        ' in the correct place.
        On Error Resume Next   ' Not running under Vista.
        NativeMethods.SetProcessDPIAware()
        InitializeComponent()

        ' Create timer.
        timerInterval = tbInterval.Value
        eventTimer = New System.Timers.Timer()
        With eventTimer
            .Enabled = False
            .AutoReset = False
            .Interval = tbInterval.Value
        End With

        ' Create highlight rectangle.
        highlight = New HighlightRectangle()

        ' Start a new thread to subscribe to UI Automation events.
        Dim threadDelegate As New ThreadStart(AddressOf StartListening)
        Dim UIAutoThread As New Thread(threadDelegate)
        UIAutoThread.Start()

    End Sub 'New



    ''' <summary>
    ''' Subscribe to UI Automation events.
    ''' </summary>
    ''' <remarks>
    ''' Do not call from the UI thread.
    ''' </remarks>
    Private Sub StartListening()
        focusHandler = New AutomationFocusChangedEventHandler(AddressOf OnFocusChanged)
        Automation.AddAutomationFocusChangedEventHandler(focusHandler)

    End Sub 'StartListening


    ''' <summary>
    ''' Unsubscribe to UI Automation events.  
    ''' </summary>
    Private Sub StopListening()
        eventTimer.Stop()
        Automation.RemoveAutomationFocusChangedEventHandler(focusHandler)

    End Sub 'StopListening



    ''' <summary>
    ''' Responds to focus changes. Starts the timer so that the highlight 
    ''' will be updated, or updates the highlight immediately if the timer
    ''' interval is set to 0.
    ''' </summary>
    ''' <param name="src">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    ''' 
    Private Sub OnFocusChanged(ByVal src As Object, ByVal e As AutomationFocusChangedEventArgs)

        focusedElement = CType(src, AutomationElement)
        focusedRect = focusedElement.Current.BoundingRectangle
        If useTimer Then
            eventTimer.Interval = timerInterval
            eventTimer.Start()
        Else
            UpdateHighlight()
        End If

    End Sub 'OnFocusChanged


    ''' <summary>
    ''' Hides the old rectangle and creates a new one.
    ''' </summary>
    Private Sub UpdateHighlight()
        With highlight
            ' Hide old rectangle.
            .Visible = False
            ' Show new rectangle.
            .Location = New Rectangle(CInt(focusedRect.Left), CInt(focusedRect.Top), _
                CInt(focusedRect.Width), CInt(focusedRect.Height))
            .Visible = True
        End With
    End Sub 'UpdateHighlight


    ''' <summary>
    ''' Updates the highlight rectangle.
    ''' </summary>
    ''' <param name="sender">Ojbect that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    ''' <remarks>The timer stops because AutoReset is false.</remarks>
    Private Sub OnTimerTick(ByVal sender As Object, ByVal e As ElapsedEventArgs) _
        Handles eventTimer.Elapsed

        UpdateHighlight()

    End Sub 'OnTimerTick


    ''' <summary>
    ''' Responds to a change in the trackbar.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    ''' <remarks>
    ''' Setting the value to 0 is equivalent to turning off the timer.
    ''' </remarks>
    Private Sub tbInterval_ValueChanged(ByVal sender As Object, _
        ByVal e As EventArgs) _
        Handles tbInterval.ValueChanged

        If tbInterval.Value > 0 Then
            timerInterval = tbInterval.Value
            useTimer = True
        Else
            useTimer = False
        End If

    End Sub 'tbInterval_ValueChanged


    ''' <summary>
    ''' Responds to Exit button click.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub btnExit_Click(ByVal sender As Object, _
        ByVal e As EventArgs) _
        Handles btnExit.Click

        Application.Exit()

    End Sub 'btnExit_Click



    ''' <summary>
    ''' Responds to form closing. Unsubscribes to UI Automation events.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub ClientForm_FormClosing(ByVal sender As Object, _
        ByVal e As FormClosingEventArgs)

        ' Start a new thread to unsubscribe to UI Automation events.
        Dim threadDelegate As New ThreadStart(AddressOf StopListening)
        Dim UIAutoThread As New Thread(threadDelegate)
        UIAutoThread.Start()

    End Sub 'ClientForm_FormClosing


End Class 'ClientForm 

