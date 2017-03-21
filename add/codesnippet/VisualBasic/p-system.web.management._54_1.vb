   ' Get the task Id.
   Public Function GetThreadId() As String
      ' Get the request principal.
        Return String.Format( _
        "Thread Id: {0}", _
        ThreadInformation.ThreadID.ToString())
   End Function 'GetThreadId
   