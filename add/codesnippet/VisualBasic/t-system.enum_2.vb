Public Module Example
   Public Sub Main()
      Dim status As ArrivalStatus = ArrivalStatus.OnTime
      Console.WriteLine("Arrival Status: {0} ({0:D})", status)
   End Sub
End Module
' The example displays the following output:
'        Arrival Status: OnTime (0)