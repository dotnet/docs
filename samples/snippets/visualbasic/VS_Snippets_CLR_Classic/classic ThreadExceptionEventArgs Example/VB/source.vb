' <Snippet1>
Imports System.Threading
Imports System.Windows.Forms

' Create a form with a button that, when clicked, throws an exception.
Public Class ErrorForm : Inherits Form
    Friend WithEvents button1 As Button

    Public Sub New()
       ' Add the button to the form.
      Me.button1 = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      Me.button1.Location = New System.Drawing.Point(100, 43)
      Me.button1.Size = New System.Drawing.Size(75, 23)
      Me.button1.Text = "Click!"
      Me.Controls.Add(Me.button1)

      Me.Text = "ThreadException"
      Me.ResumeLayout(False)
   End Sub

    ' Throw an exception when the button is clicked.
    Private Sub button1_Click(sender As Object, e As System.EventArgs) _
                Handles button1.Click
        Throw New ArgumentException("The parameter was invalid.")
    End Sub
    
    Public Shared Sub Main()
        ' Add the event handler.
        AddHandler Application.ThreadException,
                   AddressOf CustomExceptionHandler.OnThreadException
        
        ' Start the example.
        Application.Run(New ErrorForm())
    End Sub
End Class

' Create a class to handle the exception event.
Friend Class CustomExceptionHandler
    'Handle the exception event.
    Public Shared Sub OnThreadException(sender As Object, t As ThreadExceptionEventArgs)
        Dim result As DialogResult = ShowThreadExceptionDialog(t.Exception)

        ' Exit the program when the user clicks Abort.
        If result = DialogResult.Abort Then
            Application.Exit()
        End If
    End Sub
     
    ' Create and display the error message.
    Private Shared Function ShowThreadExceptionDialog(e As Exception) As DialogResult
        Dim errorMsg As String = "An error occurred.  Please contact the " &
            "adminstrator with the following information:" &
            vbCrLf & vbCrLf
        errorMsg &= "Exception Type: " & e.GetType().Name & vbCrLf & vbCrLf
        errorMsg &= e.Message & vbCrLf & vbCrLf
        errorMsg &= "Stack Trace: " & vbCrLf & e.StackTrace

        Return MessageBox.Show(errorMsg, "Application Error",
               MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
    End Function
End Class
' </Snippet1>
