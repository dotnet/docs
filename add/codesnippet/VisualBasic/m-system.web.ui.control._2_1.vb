      Public Overrides Sub Dispose()
         Try
            Context.Response.Write("Disposing " & ToString())
            ' Perform resource cleanup.
            myTextWriter.Close()
            myButton.Dispose()
         Catch myException As Exception
            Context.Response.Write("Exception occurred: " & myException.Message)
         End Try
      End Sub