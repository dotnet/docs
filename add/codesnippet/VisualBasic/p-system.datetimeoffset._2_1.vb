      Dim theTime As New DateTimeOffset(#9/7/2008 11:25AM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The month component of {0} is {1}.", _
                        theTime, theTime.Month)

      Console.WriteLine("The month component of {0} is{1}.", _
                        theTime, theTime.ToString(" M"))

      Console.WriteLine("The month component of {0} is {1}.", _
                        theTime, theTime.ToString("MM"))
      ' The example produces the following output:
      '    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      '    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      '    The month component of 9/7/2008 11:25:00 AM -08:00 is 09.      