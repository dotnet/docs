   ' Get the stack trace.
   Public Function GetThreadStackTrace() As String
        Return String.Format( _
        "Stack trace: {0}", _
        ThreadInformation.StackTrace)
   End Function 'GetThreadStackTrace
   