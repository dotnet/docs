      Dim formats() As String = { "G", "F", "D", "X"}
      Dim status As ArrivalStatus = ArrivalStatus.Late
      For Each fmt As String In formats
         Console.WriteLine(status.ToString(fmt))
      Next
      ' The example displays the following output:
      '       Late
      '       Late
      '       -1
      '       FFFFFFFF