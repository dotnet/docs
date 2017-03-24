    Public Sub RunSample()
        Try
            CreateException()
        Catch ex As System.IO.IOException
            ' Code that reacts to IOException.
        Catch ex As NullReferenceException
            MessageBox.Show("NullReferenceException: " & ex.Message)
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Catch ex As Exception
            ' Code that reacts to any other exception.
        End Try
    End Sub

    Private Sub CreateException()
        ' This code throws a NullReferenceException.
        Dim obj = Nothing
        Dim prop = obj.Name

        ' This code also throws a NullReferenceException.
        'Throw New NullReferenceException("Something happened.")
    End Sub