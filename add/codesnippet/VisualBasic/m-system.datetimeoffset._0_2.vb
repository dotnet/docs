      Dim firstTime As New DateTimeOffset(#11/15/2007 11:35AM#, _
                                          DateTimeOffset.Now.Offset)
      Dim secondTime As DateTimeOffset = firstTime
      Console.WriteLine("{0} = {1}: {2}", _
                        firstTime, secondTime, _
                        DateTimeOffset.Equals(firstTime, secondTime))

      ' The value of firstTime remains unchanged
      secondTime = New DateTimeOffset(firstTime.DateTime, _
                   TimeSpan.FromHours(firstTime.Offset.Hours + 1))      
      Console.WriteLine("{0} = {1}: {2}", _
                        firstTime, secondTime, _
                        DateTimeOffset.Equals(firstTime, secondTime))
      
      ' value of firstTime remains unchanged
      secondTime = New DateTimeOffset(firstTime.DateTime + TimeSpan.FromHours(1), _
                                      TimeSpan.FromHours(firstTime.Offset.Hours + 1))
      Console.WriteLine("{0} = {1}: {2}", _
                        firstTime, secondTime, _
                        DateTimeOffset.Equals(firstTime, secondTime))
       ' The example produces the following output:
       '       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -07:00: True
       '       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 11:35:00 AM -06:00: False
       '       11/15/2007 11:35:00 AM -07:00 = 11/15/2007 12:35:00 PM -06:00: True       