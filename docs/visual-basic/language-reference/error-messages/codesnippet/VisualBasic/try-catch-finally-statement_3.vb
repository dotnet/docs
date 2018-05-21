    Public Sub TryExample()
        ' Declare variables.
        Dim x As Integer = 5
        Dim y As Integer = 0

        ' Set up structured error handling.
        Try
            ' Cause a "Divide by Zero" exception.
            x = x \ y

            ' This statement does not execute because program
            ' control passes to the Catch block when the
            ' exception occurs.
            MessageBox.Show("end of Try block")
        Catch ex As Exception
            ' Show the exception's message.
            MessageBox.Show(ex.Message)

            ' Show the stack trace, which is a list of methods
            ' that are currently executing.
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            ' This line executes whether or not the exception occurs.
            MessageBox.Show("in Finally block")
        End Try
    End Sub