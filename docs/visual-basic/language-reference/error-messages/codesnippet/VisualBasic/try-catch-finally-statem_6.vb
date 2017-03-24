    Private Sub InnerExceptionExample()
        Try
            Try
                ' Set a reference to a StringBuilder.
                ' The exception below does not occur if the commented
                ' out statement is used instead.
                Dim sb As System.Text.StringBuilder
                'Dim sb As New System.Text.StringBuilder

                ' Cause a NullReferenceException.
                sb.Append("text")
            Catch ex As Exception
                ' Throw a new exception that has the inner exception
                ' set to the original exception.
                Throw New ApplicationException("Something happened :(", ex)
            End Try
        Catch ex2 As Exception
            ' Show the exception.
            Console.WriteLine("Exception: " & ex2.Message)
            Console.WriteLine(ex2.StackTrace)

            ' Show the inner exception, if one is present.
            If ex2.InnerException IsNot Nothing Then
                Console.WriteLine("Inner Exception: " & ex2.InnerException.Message)
                Console.WriteLine(ex2.StackTrace)
            End If
        End Try
    End Sub