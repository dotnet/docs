   Public Function GetProcessId() As String
      ' Get the process identifier.
        Return String.Format("Process Id: {0}", _
        processInformation.ProcessID.ToString())
   End Function 'GetProcessId
   