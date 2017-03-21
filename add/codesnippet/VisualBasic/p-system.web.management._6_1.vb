   Public Function GetProcessName() As String
      ' Get the requests in execution.
        Return String.Format("Process name: {0}", _
        ProcessInformation.ProcessName)
   End Function 'GetProcessName
   