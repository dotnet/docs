Imports System
Imports System.Windows.Forms
Imports System.Threading
Imports System.Drawing
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Security.Permissions

' Creates a class to throw the error.
Namespace Samples.Microsoft.WindowsThreadException
    ' Our Form class. Contains the program's entry point.
    Public Class ErrorHandlerForm
        Inherits System.Windows.Forms.Form


        Dim WithEvents button1 As Button
        Dim WithEvents button2 As Button

        ' Inserts the code to create a form.
        Public Sub New()
            Me.AutoSize = True
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink

            Dim flowPanel As New FlowLayoutPanel()
            flowPanel.AutoSize = True
            flowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.Controls.Add(flowPanel)

            button1 = New Button()
            button1.AutoSize = True
            button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            button1.Text = "Throw UI exception"
            flowPanel.Controls.Add(button1)

            ' Add a second button for firing off a second thread that will fire an exception.
            button2 = New Button()
            button2.AutoSize = True
            button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            button2.Text = "Throw non-UI exception"
            flowPanel.Controls.Add(button2)
        End Sub


        '<SNIPPET1>
        Private newThread As Thread = Nothing

        ' Starts the application. 
        <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.ControlAppDomain)> _
        Public Shared Sub Main()
            ' Add the event handler for handling UI thread exceptions to the event.
            AddHandler Application.ThreadException, AddressOf ErrorHandlerForm.Form1_UIThreadException

            ' Set the unhandled exception mode to force all Windows Forms errors to go through
            ' our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException)

            ' Add the event handler for handling non-UI thread exceptions to the event. 
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

            ' Runs the application.
            Application.Run(New ErrorHandlerForm())
        End Sub


        ' Programs the button to throw an exception when clicked.
        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
            Throw New ArgumentException("The parameter was invalid")
        End Sub

        ' Start a new thread, separate from Windows Forms, that will throw an exception.
        Private Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button2.Click
            Dim newThreadStart As New ThreadStart(AddressOf newThread_Execute)
            newThread = New Thread(newThreadStart)
            newThread.Start()
        End Sub


        ' The thread we start up to demonstrate non-UI exception handling. 
        Sub newThread_Execute()
            Throw New Exception("The method or operation is not implemented.")
        End Sub


        ' Handle the UI exceptions by showing a dialog box, and asking the user whether
        ' or not they wish to abort execution.
        Private Shared Sub Form1_UIThreadException(ByVal sender As Object, ByVal t As ThreadExceptionEventArgs)
            Dim result As System.Windows.Forms.DialogResult = _
                System.Windows.Forms.DialogResult.Cancel
            Try
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception)
            Catch
                Try
                    MessageBox.Show("Fatal Windows Forms Error", _
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
                Finally
                    Application.Exit()
                End Try
            End Try

            ' Exits the program when the user clicks Abort.
            If result = DialogResult.Abort Then
                Application.Exit()
            End If
        End Sub

        ' Handle the UI exceptions by showing a dialog box, and asking the user whether
        ' or not they wish to abort execution.
        ' NOTE: This exception cannot be kept from terminating the application - it can only 
        ' log the event, and inform the user about it. 
        Private Shared Sub CurrentDomain_UnhandledException(ByVal sender As Object, _
        ByVal e As UnhandledExceptionEventArgs)
            Try
                Dim ex As Exception = CType(e.ExceptionObject, Exception)
                Dim errorMsg As String = "An application error occurred. Please contact the adminstrator " & _
                    "with the following information:" & ControlChars.Lf & ControlChars.Lf

                ' Since we can't prevent the app from terminating, log this to the event log.
                If (Not EventLog.SourceExists("ThreadException")) Then
                    EventLog.CreateEventSource("ThreadException", "Application")
                End If

                ' Create an EventLog instance and assign its source.
                Dim myLog As New EventLog()
                myLog.Source = "ThreadException"
                myLog.WriteEntry((errorMsg + ex.Message & ControlChars.Lf & ControlChars.Lf & _
                    "Stack Trace:" & ControlChars.Lf & ex.StackTrace))
            Catch exc As Exception
                Try
                    MessageBox.Show("Fatal Non-UI Error", "Fatal Non-UI Error. Could not write the error to the event log. " & _
                        "Reason: " & exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Finally
                    Application.Exit()
                End Try
            End Try
        End Sub


        ' Creates the error message and displays it.
        Private Shared Function ShowThreadExceptionDialog(ByVal title As String, ByVal e As Exception) As DialogResult
            Dim errorMsg As String = "An application error occurred. Please contact the adminstrator " & _
		 "with the following information:" & ControlChars.Lf & ControlChars.Lf
            errorMsg = errorMsg & e.Message & ControlChars.Lf & _
		 ControlChars.Lf & "Stack Trace:" & ControlChars.Lf & e.StackTrace

            Return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
        End Function
        ' </SNIPPET1>
    End Class
End Namespace