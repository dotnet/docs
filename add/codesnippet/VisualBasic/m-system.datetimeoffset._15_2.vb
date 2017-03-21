      Dim firstTime As New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                       New TimeSpan(-7, 0, 0))
  
      Dim secondTime As DateTimeOffset = firstTime
      Console.WriteLine("{0} = {1}: {2}", _
                        firstTime, secondTime, _
                        firstTime.Equals(secondTime))

      secondTime = New DateTimeOffset(#09/01/2007 6:45:00AM#, _
                       New TimeSpan(-6, 0, 0))      
      Console.WriteLine("{0} = {1}: {2}", _
                       firstTime, secondTime, _
                       firstTime.Equals(secondTime))
      
      secondTime = New DateTimeOffset(#09/01/2007 8:45:00AM#, _
                       New TimeSpan(-5, 0, 0))
      Console.WriteLine("{0} = {1}: {2}", _
                       firstTime, secondTime, _
                       firstTime.Equals(secondTime))
      ' The example displays the following output to the console:
      '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True
      '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False
      '       9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True