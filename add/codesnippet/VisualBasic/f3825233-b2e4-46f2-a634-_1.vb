         Dim specificDate As Date = #5/1/2008 6:32AM#
         Dim offsetDate As New DateTimeOffset(specificDate.Year, _
                                              specificDate.Month, _
                                              specificDate.Day, _
                                              specificDate.Hour, _
                                              specificDate.Minute, _
                                              specificDate.Second, _
                                              New TimeSpan(-5, 0, 0))
         Console.WriteLine("Current time: {0}", offsetDate)
         Console.WriteLine("Corresponding UTC time: {0}", offsetDate.UtcDateTime)                                              
      ' The code produces the following output:
      '    Current time: 5/1/2008 6:32:00 AM -05:00
      '    Corresponding UTC time: 5/1/2008 11:32:00 AM      