'*****************************************************************************
' * File: Window1.xaml.cs
' *
' * Description: 
' *    This sample opens a 'canned' Win32 application and shows how to use 
' *    UI Automation to input text depending on the text control.
' * 
' *    InsertTextTarget.exe should be automatically copied to the InsertText 
' *    client folder when you build the sample. You may have to manually copy 
' *    this file if you receive an error stating the file cannot be found.
' *
' * Programming Elements:
' *    The sample demonstrates the following UI Automation programming elements.
' * 
' *       System.Windows.Automation Namespace:
' *         Automation Class
' *           AddAutomationEventHandler
' *           AddAutomationPropertyChangedEventHandler
' *         Condition Class
' *         AndCondition Class
' *         OrCondition Class
' *         AutomationElementCollection Class
' *         AutomationPattern Class 
' *         AutomationElement Class
' *           IsTextPatternAvailableProperty field
' *           TryGetCurrentPattern method
' *           FromHandle method
' *           ControlTypeProperty field
' *           FindAll method
' *           SetFocus method
' *         TreeScope Enumeration
' *           Element member
' *           Descendants member
' *         ControlType Class
' *           Text field
' *           Edit field
' *           Document field
' *         TextPattern Class
' *           Pattern field
' *         ValuePattern Class
' *           Pattern field
' *           SetValue method
' *         AutomationPropertyChangedEventHandler Delegate
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

Imports System
Imports System.Windows
Imports System.Diagnostics
Imports System.Windows.Automation
Imports System.Threading
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Windows.Threading


Namespace InsertTextClient
    '' ------------------------------------------------------------------------
    ''  <summary>
    ''  Interaction logic for Window1.xaml
    ''  </summary>
    '' ------------------------------------------------------------------------

    Partial Public Class Window1
        Inherits Window
        Private targetWindow As AutomationElement
        Private textControls As AutomationElementCollection
        ' InsertTextTarget.exe should be automatically copied to the 
        ' InsertText client folder when you build the sample. 
        ' You may have to manually copy this file if you receive an error 
        ' stating the file cannot be found.
        Private filePath As String = _
        System.Windows.Forms.Application.StartupPath + "\InsertTextTarget.exe"
        Private feedbackText As StringBuilder
        ' Delegates to be used in placing jobs onto the Dispatcher.
        Private Delegate Sub ControlsDelegate(ByVal arg1 As Boolean, ByVal arg2 As Boolean)
        Private Delegate Sub FeedbackDelegate(ByVal arg1 As String)

        '' --------------------------------------------------------------------
        ''  <summary>
        ''  The class constructor.
        ''  </summary>
        '' --------------------------------------------------------------------
        Public Sub New()
            InitializeComponent()
        End Sub 'New


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Handles the click event for the Start App button.
        ''  </summary>
        ''  <param name="sender">The object that raised the event.</param>
        ''  <param name="e">Event arguments.</param>
        '' --------------------------------------------------------------------
        Private Sub btnStartApp_Click( _
        ByVal sender As Object, ByVal e As RoutedEventArgs)
            targetWindow = StartTargetApp(filePath)

            If targetWindow Is Nothing Then
                Return
            End If

            Feedback("Target started.")

            Dim clientLocationTop As Double = Client.Top
            Dim clientLocationRight As Double = Client.Left + Client.Width + 100
            Dim transformPattern As TransformPattern = _
            CType(targetWindow.GetCurrentPattern(transformPattern.Pattern), TransformPattern)
            If Not (transformPattern Is Nothing) Then
                transformPattern.Move(clientLocationRight, clientLocationTop)
            End If

            ' Get required control patterns 
            '
            ' Once you have an instance of an AutomationElement for the target 
            ' obtain a WindowPattern object to handle the WindowClosed event.
            Dim s As String = targetWindow.Current.ProcessId.ToString()
            Try
                Dim targetWindowPattern As WindowPattern
                targetWindowPattern = _
                CType(targetWindow.GetCurrentPattern(WindowPattern.Pattern), WindowPattern)
            Catch exc As NullReferenceException
                Feedback(exc.ToString())
                Return
            Catch exc As InvalidOperationException
                Feedback(exc.ToString() & "\nObject does not support the Window Pattern.")
            End Try

            ' Register for an Event
            ' 
            ' The WindowPattern allows you to programmatically 
            ' manipulate a window. 
            ' It also exposes a window closed event. 
            ' The following code shows an example of listening 
            ' for the WindowClosed event.
            '
            ' To intercept the WindowClosed event for our target application
            ' you define an AutomationEventHandler delegate.
            Dim targetClosedHandler As AutomationEventHandler = AddressOf OnTargetClosed

            ' Use AddAutomationEventHandler() to add this event handler.
            ' When listening for a WindowClosed event you must either scope 
            ' the event to the automation element as done here, or cast 
            ' the AutomationEventArgs in the handler to WindowClosedEventArgs 
            ' and compare the RuntimeId of the automation element that raised 
            ' the WindowClosed event to the automation element in the 
            ' class member data.
            Automation.AddAutomationEventHandler( _
            WindowPattern.WindowClosedEvent, _
            targetWindow, _
            TreeScope.Element, _
            targetClosedHandler)

            SetClientControlProperties(False, True)

            ' Get our collection of interesting controls.
            textControls = FindTextControlsInTarget()

        End Sub 'btnStartApp_Click


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Handles the click event for the Insert Text buttons.
        ''  </summary>
        ''  <param name="sender">The object that raised the event.</param>
        ''  <param name="e">Event arguments.</param>
        '' --------------------------------------------------------------------
        Private Sub btnInsert_Click( _
        ByVal sender As Object, ByVal e As RoutedEventArgs)
            feedbackText = New StringBuilder()
            If String.IsNullOrEmpty(tbInsert.Text) Then
                Feedback("Please enter some text to insert.")
                Return
            End If
            Select Case CType(sender, System.Windows.Controls.Button).Content.ToString()
                Case "UIAutomation"
                    SetValueWithUIAutomation(tbInsert.Text)
                Case "Win32"
                    SetValueWin32(tbInsert.Text)
                Case Else
                    Feedback("Insert failed.")
                    Return
            End Select

        End Sub 'btnInsert_Click


        '<SnippetInsertText>
        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Sets the values of the text controls using managed methods.
        ''  </summary>
        ''  <param name="s">The string to be inserted.</param>
        '' --------------------------------------------------------------------
        Private Sub SetValueWithUIAutomation(ByVal s As String)
            Dim control As AutomationElement
            For Each control In textControls
                InsertTextWithUIAutomation(control, s)
            Next control

        End Sub


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Inserts a string into each text control of interest.
        ''  </summary>
        ''  <param name="element">A text control.</param>
        ''  <param name="value">The string to be inserted.</param>
        '' --------------------------------------------------------------------
        Private Sub InsertTextWithUIAutomation( _
        ByVal element As AutomationElement, ByVal value As String)
            Try
                ' Validate arguments / initial setup
                If value Is Nothing Then
                    Throw New ArgumentNullException( _
                    "String parameter must not be null.")
                End If

                If element Is Nothing Then
                    Throw New ArgumentNullException( _
                    "AutomationElement parameter must not be null")
                End If

                ' A series of basic checks prior to attempting an insertion.
                '
                ' Check #1: Is control enabled?
                ' An alternative to testing for static or read-only controls 
                ' is to filter using 
                ' PropertyCondition(AutomationElement.IsEnabledProperty, true) 
                ' and exclude all read-only text controls from the collection.
                If Not element.Current.IsEnabled Then
                    Throw New InvalidOperationException( _
                    "The control with an AutomationID of " + _
                    element.Current.AutomationId.ToString() + _
                    " is not enabled." + vbLf + vbLf)
                End If

                ' Check #2: Are there styles that prohibit us 
                '           from sending text to this control?
                If Not element.Current.IsKeyboardFocusable Then
                    Throw New InvalidOperationException( _
                    "The control with an AutomationID of " + _
                    element.Current.AutomationId.ToString() + _
                    "is read-only." + vbLf + vbLf)
                End If


                ' Once you have an instance of an AutomationElement,  
                ' check if it supports the ValuePattern pattern.
                Dim targetValuePattern As Object = Nothing

                ' Control does not support the ValuePattern pattern 
                ' so use keyboard input to insert content.
                '
                ' NOTE: Elements that support TextPattern 
                '       do not support ValuePattern and TextPattern
                '       does not support setting the text of 
                '       multi-line edit or document controls.
                '       For this reason, text input must be simulated
                '       using one of the following methods.
                '       
                If Not element.TryGetCurrentPattern(ValuePattern.Pattern, targetValuePattern) Then
                    feedbackText.Append("The control with an AutomationID of ") _
                    .Append(element.Current.AutomationId.ToString()) _
                    .Append(" does not support ValuePattern."). _
                    AppendLine(" Using keyboard input.").AppendLine()

                    ' Set focus for input functionality and begin.
                    element.SetFocus()

                    ' Pause before sending keyboard input.
                    Thread.Sleep(100)

                    ' Delete existing content in the control and insert new content.
                    SendKeys.SendWait("^{HOME}") ' Move to start of control
                    SendKeys.SendWait("^+{END}") ' Select everything
                    SendKeys.SendWait("{DEL}") ' Delete selection
                    SendKeys.SendWait(value)
                Else
                    ' Control supports the ValuePattern pattern so we can 
                    ' use the SetValue method to insert content.
                    feedbackText.Append("The control with an AutomationID of ") _
                    .Append(element.Current.AutomationId.ToString()) _
                    .Append(" supports ValuePattern.") _
                    .AppendLine(" Using ValuePattern.SetValue().").AppendLine()

                    ' Set focus for input functionality and begin.
                    element.SetFocus()
                    Dim valueControlPattern As ValuePattern = _
                    DirectCast(targetValuePattern, ValuePattern)
                    valueControlPattern.SetValue(value)
                End If
            Catch exc As ArgumentNullException
                feedbackText.Append(exc.Message)
            Catch exc As InvalidOperationException
                feedbackText.Append(exc.Message)
            Finally
                Feedback(feedbackText.ToString())
            End Try

        End Sub

        '</SnippetInsertText>

        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Sets the values of the text controls using unmanaged methods.
        ''  </summary>
        ''  <param name="s">The string to be inserted.</param>
        '' --------------------------------------------------------------------
        Private Sub SetValueWin32(ByVal s As String)
            Dim control As AutomationElement
            For Each control In textControls
                ' An alternative to testing for static or read-only controls
                ' is to filter using 
                ' PropertyCondition(AutomationElement.IsEnabledProperty, true) 
                ' and exclude all read-only text controls from the collection.
                InsertTextUsingWin32(control, s)
            Next control

        End Sub 'SetValueWin32


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Inserts the specified string into a text control.
        ''  </summary>
        ''  <param name="element">A text control.</param>
        ''  <param name="value">The string to be inserted.</param>
        '' --------------------------------------------------------------------
        Private Sub InsertTextUsingWin32( _
        ByVal element As AutomationElement, ByVal value As String)
            Try
                ' Validate arguments / initial setup
                If value Is Nothing Then
                    Throw New ArgumentNullException( _
                    "String parameter 'value' must not be null.")
                End If

                If element Is Nothing Then
                    Throw New ArgumentNullException( _
                    "AutomationElement parameter 'element' must not be null")
                End If

                ' Get hwnd
                Dim _hwnd As New IntPtr(element.Current.NativeWindowHandle)
                If _hwnd = IntPtr.Zero Then
                    Throw New InvalidOperationException("Unable to get handle to object.")
                End If

                ' A series of basic checks for the text control 
                ' prior to attempting an insertion.
                '
                ' Check #1: Is control enabled?
                ' An alternative to testing for static or read-only controls 
                ' is to filter using 
                ' PropertyCondition(AutomationElement.IsEnabledProperty, true) 
                ' and exclude all read-only text controls from the collection.
                If Not UnmanagedClass.IsWindowEnabled(_hwnd) Then
                    Throw New InvalidOperationException( _
                    "The control with an AutomationID of " + _
                    element.Current.AutomationId.ToString() + _
                    " is not enabled." + vbLf)
                End If

                ' Check #2: Are there styles that prohibit us from 
                '           sending text to this control?
                Dim hwnd As UnmanagedClass.HWND = UnmanagedClass.HWND.Cast(_hwnd)
                Dim ControlStyle As Integer = _
                UnmanagedClass.GetWindowLong(hwnd, UnmanagedClass.GCL_STYLE)

                If IsBitSet(ControlStyle, UnmanagedClass.ES_READONLY) Then
                    Throw New InvalidOperationException( _
                    "The control with an AutomationID of " + _
                    element.Current.AutomationId.ToString() + _
                    " is read-only.")
                End If

                ' Check #3: Is the size of the text we want to set 
                '           greater than what the control accepts?
                Dim result As IntPtr
                Dim resultInt As Integer

                Dim resultSendMessage As IntPtr = _
                UnmanagedClass.SendMessageTimeout( _
                hwnd, _
                UnmanagedClass.EM_GETLIMITTEXT, _
                IntPtr.Zero, IntPtr.Zero, 1, 10000, result)
                Dim lastWin32Error As Integer = _
                System.Runtime.InteropServices.Marshal.GetLastWin32Error()

                If resultSendMessage = IntPtr.Zero Then
                    Throw New InvalidOperationException("SendMessageTimeout() timed out.")
                End If

                resultInt = CType(CType(result, Long), Int32)

                ' A result of -1 means that no limit is set.
                If resultInt <> -1 AndAlso resultInt < value.Length Then
                    Throw New InvalidOperationException( _
                    "The length of text entered (" + value.Length.ToString() + _
                    ") is greater than the upper limit of the " + _
                    "control with an AutomationID of " + _
                    element.Current.AutomationId.ToString() + _
                    " (" + resultInt.ToString() + ")" + ".")
                End If

                ' Send the message...!
                result = UnmanagedClass.SendMessageTimeout( _
                UnmanagedClass.HWND.Pointer(hwnd), _
                UnmanagedClass.WM_SETTEXT, IntPtr.Zero, _
                New StringBuilder(value), 1, 10000, result)
                resultInt = CType(CType(result, Long), Int32)

                If resultInt <> 1 Then
                    Throw New InvalidOperationException( _
                    "The text of the control with an AutomationID of " + _
                    element.Current.AutomationId.ToString() + _
                    " cannot be changed.")
                End If
                feedbackText.Append("The text of the control with an AutomationID of ") _
                .Append(element.Current.AutomationId.ToString()) _
                .AppendLine(" has been set.").AppendLine()
            Catch exc As EntryPointNotFoundException
                feedbackText.AppendLine(exc.Message)
            Catch exc As ArgumentNullException
                feedbackText.AppendLine(exc.Message)
            Catch exc As InvalidOperationException
                feedbackText.AppendLine(exc.Message)
            Finally
                Feedback(feedbackText.ToString())
            End Try

        End Sub 'InsertTextUsingWin32


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Gets a pointer to an AutomationElement
        ''  </summary>
        ''  <param name="element">A text control.</param>
        ''  <returns>A pointer to an AutomationElement</returns>
        '' --------------------------------------------------------------------
        Private Function GetWindowHandleFromAutomationElement( _
        ByVal element As AutomationElement) As IntPtr
            Dim ptr As IntPtr = IntPtr.Zero
            Try
                Dim objHwnd As Object = _
                element.GetCurrentPropertyValue(AutomationElement.NativeWindowHandleProperty)

                If TypeOf objHwnd Is IntPtr Then
                    ptr = CType(objHwnd, IntPtr)
                Else
                    ptr = New IntPtr(Convert.ToInt64(objHwnd))
                End If

                If ptr = IntPtr.Zero Then
                    Throw New InvalidOperationException( _
                    "Unable to get a handle for the element with an AutomationID of " + _
                    element.Current.AutomationId.ToString() + ".")
                End If
            Catch exc As InvalidOperationException
                Feedback(exc.Message.ToString())
            End Try
            Return ptr

        End Function 'GetWindowHandleFromAutomationElement


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Is bit set?
        ''  </summary>
        ''  <param name="flags">The flag(s) of interest.</param>
        ''  <param name="bit">The bit value(s).</param>
        '' --------------------------------------------------------------------
        Private Function IsBitSet(ByVal flags As Integer, ByVal bit As Integer) As Boolean
            Return (flags And bit) = bit

        End Function 'IsBitSet


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Finds the text controls of interest.
        ''  </summary>
        ''  <returns>A collection of Automation Elements
        ''  that satisfy the specified conditions.</returns>
        '' --------------------------------------------------------------------
        ' Find all 'text' controls that support TextPattern.
        Private Function FindTextControlsInTarget() As AutomationElementCollection
            Dim condition As New AndCondition( _
            New OrCondition( _
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit), _
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document), _
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text)), _
            New PropertyCondition(AutomationElement.IsTextPatternAvailableProperty, True))
            Return targetWindow.FindAll(TreeScope.Descendants, condition)

        End Function 'FindTextControlsInTarget


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Starts the target app that contains the text controls of interest.
        ''  </summary>
        ''  <param name="sTarget">The target exe.</param>
        ''  <returns>An Automation Element from our target window.</returns>
        '' --------------------------------------------------------------------
        ' Start our target Win32 application
        Private Function StartTargetApp(ByVal target As String) As AutomationElement
            If Not File.Exists(target) Then
                feedbackText.Append(target).Append(" not found.")
                Feedback(feedbackText.ToString())
                Return Nothing
            End If
            Dim p As Process
            Try
                ' Start application.
                p = Process.Start(target)
                If p Is Nothing Then
                    Return Nothing
                End If

                ' Give the target application some time to startup.
                ' For Win32 applications, WaitForInputIdle can be used instead.
                ' Another alternative is to listen for WindowOpened events.
                ' Otherwise, an ArgumentException results when you try to
                ' retrieve an automation element from the window handle.
                Thread.Sleep(2500)

                ' Return the automation element
                Return AutomationElement.FromHandle(p.MainWindowHandle)
            Catch e As Win32Exception
                Feedback(e.ToString())
                Return Nothing
            End Try

        End Function 'StartTargetApp


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Intercepts the target window closed event and starts the client
        ''  window BackgroundWorker object.
        ''  </summary>
        ''  <param name="sender">The object that raised the event.</param>
        ''  <param name="e">Event arguments.</param>
        ''  <remarks>
        ''  It is not advisable to operate on your own UI within an 
        ''  event handler. This is especially true in a multi-threaded 
        ''  environment as the event handler is unlikely to be called on the 
        ''  UI thread. 
        ''  </remarks>
        '' --------------------------------------------------------------------
        Private Sub OnTargetClosed(ByVal sender As Object, ByVal e As AutomationEventArgs)
            ' Schedule the update function in the UI thread.
            spInsert.Dispatcher.BeginInvoke( _
            DispatcherPriority.Send, _
            New ControlsDelegate(AddressOf SetClientControlProperties), True, False)
            txtFeedback.Dispatcher.BeginInvoke( _
            DispatcherPriority.Send, _
            New FeedbackDelegate(AddressOf Feedback), "Target closed.")
        End Sub 'OnTargetClosed

        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Sets attributes of the controls in the client app.
        ''  </summary>
        ''  <param name="e">Enabled property.</param>
        ''  <param name="v">Visibility property.</param>
        '' --------------------------------------------------------------------
        Private Sub SetClientControlProperties(ByVal e1 As Boolean, ByVal e2 As Boolean)
            btnStartApp.IsEnabled = e1
            tbkInsert.IsEnabled = e2
            spInsert.IsEnabled = e2

        End Sub 'SetClientControlProperties


        '' --------------------------------------------------------------------
        ''  <summary>
        ''  Outputs information to the client window.
        ''  </summary>
        ''  <param name="s">The string to display.</param>
        '' --------------------------------------------------------------------
        Private Sub Feedback(ByVal s As String)
            txtFeedback.Text = s

        End Sub 'Feedback
    End Class 'Window1
End Namespace
