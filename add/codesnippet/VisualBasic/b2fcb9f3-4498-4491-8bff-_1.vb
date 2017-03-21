      Dim fmt As String = "dd MMM yyyy HH:mm:ss"
      Dim thisDate As DateTime = New Date(2007, 06, 12, 19, 00, 14, 16)
      Dim offsetDate As New DateTimeOffset(thisDate.Year, _
                                           thisDate.Month, _
                                           thisDate.Day, _
                                           thisDate.Hour, _
                                           thisDate.Minute, _
                                           thisDate.Second, _
                                           thisDate.Millisecond, _ 
                                           New TimeSpan(2, 0, 0))  
      Console.WriteLine("Current time: {0}:{1}", offsetDate.ToString(fmt), _ 
                                                 offsetDate.Millisecond)
      ' The code produces the following output:
      '    Current time: 12 Jun 2007 19:00:14:16      