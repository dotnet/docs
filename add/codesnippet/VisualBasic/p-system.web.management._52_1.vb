   ' Obtains the current process information.
   Public Function GetProcessInfo() As String
      Dim tempPi As New StringBuilder()
      Dim pi As WebProcessInformation = ProcessInformation
        tempPi.Append( _
        (pi.ProcessName + Environment.NewLine))
        tempPi.Append( _
        (pi.ProcessID.ToString() + Environment.NewLine))
        tempPi.Append( _
        (pi.AccountName + Environment.NewLine))
      Return tempPi.ToString()
   End Function 'GetProcessInfo
   