      Dim theTime As New DateTimeOffset(#2/17/2008 9:00AM#, _
                                        DateTimeOffset.Now.Offset)
      Console.WriteLine("The year component of {0} is {1}.", _
                        theTime, theTime.Year)

      Console.WriteLine("The year component of {0} is{1}.", _
                        theTime, theTime.ToString(" y"))

      Console.WriteLine("The year component of {0} is {1}.", _
                        theTime, theTime.ToString("yy"))
                        
      Console.WriteLine("The year component of {0} is {1}.", _
                        theTime, theTime.ToString("yyyy"))
      ' The example produces the following output:
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 8.
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 08.
      '    The year component of 2/17/2008 9:00:00 AM -07:00 is 2008.