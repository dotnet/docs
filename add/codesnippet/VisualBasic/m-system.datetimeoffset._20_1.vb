      Dim localTime As Date = Date.Now
      Dim nonLocalDateWithOffset As New DateTimeOffset(localTime.Ticks, _
                                        New TimeSpan(2, 0, 0))
      Console.WriteLine(nonLocalDateWithOffset)                                        
      '
      ' The code produces the following output if run on Feb. 23, 2007:
      '    2/23/2007 4:37:50 PM +02:00