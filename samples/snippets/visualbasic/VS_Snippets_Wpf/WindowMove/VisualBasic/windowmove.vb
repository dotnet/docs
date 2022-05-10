'******************************************************************************
'*
'* File: WindowMove.vb
'*
'* Description:  
'*       Moves a WCP window from a random location on the desktop to the 
'*       top-left corner of the desktop. This is accomplished by obtaining an 
'*       automation element based on the text value of the window, 
'*       and then obtaining a TransformPattern object from this element.
'*       If the element is moveable, rects for both the element and the 
'*       desktop are created.
'*       The top and left coordinates needed to move the parent window are set
'*       and, if not out of range, the window is moved to the new coordinates.
'* 
'* Programming Elements:
'*    This sample demonstrates the following UI Automation programming elements 
'*    from the System.Windows.Automation namespace:
'*       Automation class
'*           ScopeFlags
'*       AutomationElement class
'*           RootElement property
'*           AutomationIDProperty property
'*           TryGetCurrentPattern() method
'*           Current struct
'*           BoundingRectangle property
'*           Condition property
'*       WindowPattern class
'*           WaitForInputIdle method
'*           WindowVisualState property
'*           SetWindowVisualState method
'*       TransformPattern class
'*           CanMove property
'*           Move() method
'*       AutomationProperty class
'*           ToString() method
'*
' *
' *  This file is part of the Microsoft .NET Framework SDK Code Samples.
' * 
' *  Copyright (C) Microsoft Corporation.  All rights reserved.
' * 
' *  This source code is intended only as a supplement to Microsoft
' *  Development Tools and/or on-line documentation.  See these other
' *  materials for detailed information regarding Microsoft code samples.
' *
' *  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' *  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' *  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' *  PARTICULAR PURPOSE.
' *
' *****************************************************************************

Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Threading
Imports System.Windows.Threading
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.ComponentModel

Namespace SDKSample

    '' <summary>
    '' WindowMove application.
    '' </summary>
    Public Class WindowMove
        Inherits System.Windows.Application
        Private informationPanel As DockPanel
        Private targetWindow As AutomationElement
        Private windowPattern As WindowPattern
        Private transformPattern As TransformPattern
        Private targetLocation As Point
        Private xCoordinate As TextBox
        Private yCoordinate As TextBox
        Private moveTarget As Button
        Private feedbackText As StringBuilder = New StringBuilder()
        Private targetApplication As String = "Notepad.exe"
        ' Delegates for updating the client UI based on target application events.
        Private Delegate Sub FeedbackDelegate(ByVal message As String)
        Private Delegate Sub ClientControlsDelegate(ByVal src As Object)

        ' <Snippet1301>
        '' <summary>
        '' The Startup handler.
        '' </summary>
        '' <param name="e">The event arguments</param>
        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)

            ' Start the WindowMove client.
            CreateWindow()

            Try
                ' Obtain an AutomationElement from the target window handle.
                targetWindow = StartTargetApp(targetApplication)

                ' Does the automation element exist?
                If targetWindow Is Nothing Then
                    Feedback("No target.")
                    Return
                End If
                Feedback("Found target.")

                ' Obtain required control patterns from our automation element
                windowPattern = CType( _
                GetControlPattern(targetWindow, windowPattern.Pattern), _
                WindowPattern)

                If (windowPattern Is Nothing) Then Return

                ' Make sure our window is usable.
                ' WaitForInputIdle will return before the specified time 
                ' if the window is ready.
                If (False = windowPattern.WaitForInputIdle(10000)) Then
                    Feedback("Object not responding in a timely manner.")
                    Return
                End If
                Feedback("Window ready for user interaction")

                ' Register for required events
                RegisterForEvents( _
                targetWindow, windowPattern.Pattern, TreeScope.Element)

                ' find current location of our window
                targetLocation = _
                targetWindow.Current.BoundingRectangle.Location

                ' Obtain required control patterns from our automation element
                transformPattern = CType( _
                GetControlPattern(targetWindow, transformPattern.Pattern), _
                TransformPattern)

                If (transformPattern Is Nothing) Then Return

                ' Is the TransformPattern object moveable?
                If transformPattern.Current.CanMove Then
                    ' Enable our WindowMove fields
                    xCoordinate.IsEnabled = True
                    yCoordinate.IsEnabled = True
                    moveTarget.IsEnabled = True

                    ' Move element
                    transformPattern.Move(0, 0)
                Else
                    Feedback("Wndow is not moveable.")
                End If

            Catch exc As ElementNotAvailableException
                Feedback("Client window no longer available.")

            Catch exc As InvalidOperationException
                Feedback("Client window cannot be moved.")
                Return

            Catch exc As Exception
                Feedback(exc.ToString())

            End Try

        End Sub
        ' </Snippet1301>

        '' <summary>
        '' Start the WindowMove client.
        '' </summary>
        Private Sub CreateWindow()
            Dim window As Window = New Window()
            Dim sp As StackPanel = New StackPanel()
            sp.Orientation = Orientation.Horizontal
            sp.HorizontalAlignment = HorizontalAlignment.Center

            Dim txtX As TextBlock = New TextBlock()
            txtX.Text = "X-coordinate: "
            txtX.VerticalAlignment = VerticalAlignment.Center

            xCoordinate = New TextBox()
            xCoordinate.Text = "0"
            xCoordinate.IsEnabled = False
            xCoordinate.MaxLines = 1
            xCoordinate.MaxLength = 4
            xCoordinate.Margin = New Thickness(10, 0, 10, 0)

            Dim txtY As TextBlock = New TextBlock()
            txtY.Text = "Y-coordinate: "
            txtY.VerticalAlignment = VerticalAlignment.Center

            yCoordinate = New TextBox()
            yCoordinate.Text = "0"
            yCoordinate.IsEnabled = False
            yCoordinate.MaxLines = 1
            yCoordinate.MaxLength = 4
            yCoordinate.Margin = New Thickness(10, 0, 10, 0)

            moveTarget = New Button()
            moveTarget.IsEnabled = False
            moveTarget.Width = 100
            moveTarget.Content = "Move Window"
            AddHandler moveTarget.Click, AddressOf btnMove_Click

            sp.Children.Add(txtX)
            sp.Children.Add(xCoordinate)
            sp.Children.Add(txtY)
            sp.Children.Add(yCoordinate)
            sp.Children.Add(moveTarget)

            informationPanel = New DockPanel()
            informationPanel.LastChildFill = False
            DockPanel.SetDock(sp, Dock.Top)
            informationPanel.Children.Add(sp)

            window.Content = informationPanel
            window.Show()
        End Sub

        '<Snippet1300>
        '' <summary>
        '' Handles the 'Move' button invoked event.
        '' By default, the Move method does not allow an object 
        '' to be moved completely off-screen.
        '' </summary>
        '' <param name="src">The object that raised the event.</param>
        '' <param name="e">Event arguments.</param>
        Private Sub btnMove_Click( _
        ByVal sender As Object, ByVal e As RoutedEventArgs)
            Try
                ' If coordinate left blank, substitute 0
                If (xCoordinate.Text = "") Then xCoordinate.Text = "0"
                If (yCoordinate.Text = "") Then yCoordinate.Text = "0"

                ' Reset background colours
                xCoordinate.Background = System.Windows.Media.Brushes.White
                yCoordinate.Background = System.Windows.Media.Brushes.White

                If (windowPattern.Current.WindowVisualState = WindowVisualState.Minimized) Then
                    windowPattern.SetWindowVisualState(WindowVisualState.Normal)
                End If

                Dim X As Double = Double.Parse(xCoordinate.Text)
                Dim Y As Double = Double.Parse(yCoordinate.Text)

                ' Should validate the requested screen location.
                If (X >= (SystemParameters.WorkArea.Width - targetWindow.Current.BoundingRectangle.Width)) Then
                    Feedback("X-coordinate would place the window all or partially off-screen.")
                    xCoordinate.Background = System.Windows.Media.Brushes.Yellow
                End If

                If (Y >= (SystemParameters.WorkArea.Height - targetWindow.Current.BoundingRectangle.Height)) Then
                    Feedback("Y-coordinate would place the window all or partially off-screen.")
                    yCoordinate.Background = System.Windows.Media.Brushes.Yellow
                End If

                ' transformPattern was obtained from the target window.
                transformPattern.Move(X, Y)

            Catch exc As ElementNotAvailableException
                Feedback("Client window no longer available.")

            Catch exc As InvalidOperationException
                Feedback("Client window cannot be moved.")
                Return

            Catch exc As Exception
                Feedback(exc.ToString())

            End Try

        End Sub
        '</Snippet1300>

        ''' <summary>
        ''' Update client controls based on target location changes.
        ''' </summary>
        ''' <param name="src">The object that raised the event.</param>
        Private Sub UpdateClientControls(ByVal src As Object)
            ' If window is minimized, no need to report new screen coordinates
            If (windowPattern.Current.WindowVisualState = WindowVisualState.Minimized) Then Return

            Dim rCurrent As Rect = _
                CType(src, AutomationElement).Current.BoundingRectangle
            Dim ptCurrent As Point = rCurrent.Location

            If Not (targetLocation = ptCurrent) Then
                Feedback("Window moved from " + _
                targetLocation.ToString() + " to " + ptCurrent.ToString())
                targetLocation = ptCurrent
            End If
            If Not (targetLocation.X = Double.Parse(xCoordinate.Text)) Then
                Feedback("Alert: Final X-coordinate not equal to requested X-coordinate.")
                xCoordinate.Text = targetLocation.X.ToString()
            End If
            If Not (targetLocation.Y = Double.Parse(yCoordinate.Text)) Then
                Feedback("Alert: Final Y-coordinate not equal to requested Y-coordinate.")
                yCoordinate.Text = targetLocation.Y.ToString()
            End If
        End Sub

        ''' <summary>
        ''' Window move event handler.
        ''' </summary>
        ''' <param name="src">The object that raised the event.</param>
        ''' <param name="e">Event arguments.</param>
        Private Sub OnWindowMove(ByVal src As Object, ByVal e As AutomationPropertyChangedEventArgs)
            ' Pass the same function to BeginInvoke,
            ' but the call would come on the correct
            ' thread and InvokeRequired will be false.
            Me.Dispatcher.BeginInvoke( _
                DispatcherPriority.Send, _
                New ClientControlsDelegate(AddressOf UpdateClientControls), src)
        End Sub

        '''--------------------------------------------------------------------
        ''' <summary>
        ''' Provides feedback in the client.
        ''' </summary>
        ''' <param name="message">The string to display.</param>
        ''' <remarks>
        ''' Since the events may happen on a different thread than the
        ''' client we need to use a Dispatcher delegate to handle them.
        ''' </remarks>
        '''--------------------------------------------------------------------
        Private Sub Feedback(ByVal message As String)
            ' Check if we need to call BeginInvoke.
            If (Me.Dispatcher.CheckAccess() = False) Then
                ' Pass the same function to BeginInvoke,
                ' but the call would come on the correct
                ' thread and InvokeRequired will be false.
                Me.Dispatcher.BeginInvoke( _
                    DispatcherPriority.Send, _
                    New FeedbackDelegate(AddressOf Feedback), _
                    message)
                Return
            End If
            Dim textElement As TextBlock = New TextBlock()
            textElement.Text = message
            DockPanel.SetDock(textElement, Dock.Top)
            informationPanel.Children.Add(textElement)
        End Sub

        '' <summary>
        '' Starts the target application.
        '' </summary>
        '' <param name="sender">The object that raised the event.</param>
        '' <param name="e">Event arguments.</param>
        '' <returns>The target automation element.</returns>
        Private Function StartTargetApp(ByVal app As String) As AutomationElement
            Try
                ' Start application.
                Dim p As Process = Process.Start(app)
                If (p.WaitForInputIdle(20000) = True) Then
                    Feedback("Window ready for user interaction")
                Else
                    Return Nothing
                End If

                ' Give application a second to startup.
                Thread.Sleep(2000)

                ' Return the automation element
                Return AutomationElement.FromHandle(p.MainWindowHandle)
            Catch exc As ArgumentException
                Feedback(exc.ToString())
                Return Nothing
            Catch exc As Win32Exception
                Feedback(exc.ToString())
                Return Nothing
            End Try
        End Function

        '' <summary>
        '' Obtains a specified control pattern.
        '' </summary>
        '' <param name="ae">
        '' The automation element we want to obtain the control pattern from.
        '' </param>
        '' <param name="ap">The control pattern of interest.</param>
        '' <returns>A ControlPattern object.</returns>
        Private Function GetControlPattern(ByVal ae As AutomationElement, _
            ByVal apPattern As AutomationPattern) As Object
            Dim oPattern As Object = Nothing

            If (False = ae.TryGetCurrentPattern(apPattern, oPattern)) Then
                Feedback("Object does not support the " + _
                apPattern.ProgrammaticName.ToString() + " Pattern")
                Return Nothing
            End If

            Feedback("Object supports the " + _
            apPattern.ProgrammaticName.ToString() + " Pattern.")

            Return oPattern
        End Function

        '' <summary>
        '' Register for events of interest.
        '' </summary>
        '' <param name="ae">The automation element of interest.</param>
        '' <param name="ap">The control pattern of interest.</param>
        '' <param name="ts">The tree scope of interest.</param>
        Private Sub RegisterForEvents(ByVal ae As AutomationElement, _
            ByVal ap As AutomationPattern, ByVal ts As TreeScope)
            If (ap.Id = windowPattern.Pattern.Id) Then
                ' The WindowPattern exposes an elements ability to change 
                ' its on-screen position or size.

                ' The following code shows an example of listening for the 
                ' BoundingRectangle property changed event on the window.
                Feedback("Start listening for WindowMove events for the control.")

                ' Define an AutomationPropertyChangedEventHandler delegate to 
                ' listen for window moved events.
                Dim hWindowMove As AutomationPropertyChangedEventHandler = _
                    AddressOf OnWindowMove
                Automation.AddAutomationPropertyChangedEventHandler( _
                    ae, ts, _
                    hWindowMove, AutomationElement.BoundingRectangleProperty)
            End If
        End Sub

        '' <summary>
        '' Window shut down event handler.
        '' </summary>
        '' <param name="e">The exit event arguments.</param>
        Protected Overrides Sub OnExit(ByVal e As ExitEventArgs)
            Automation.RemoveAllEventHandlers()
            MyBase.OnExit(e)
        End Sub

        '' <summary>
        '' Launch the sample application.
        '' </summary>
        Friend NotInheritable Class TestMain

            <STAThread()> _
            Shared Sub Main()
                ' Create an instance of the sample class.
                Dim app As New WindowMove()
                app.Run()
            End Sub
        End Class
    End Class
End Namespace 'SDKSample
