      Dim theTime As New DateTimeOffset(#6/12/2008 9:16:32PM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The second component of {0} is {1}.", _
                        theTime, theTime.Second)

      Console.WriteLine("The second component of {0} is{1}.", _
                        theTime, theTime.ToString(" s"))

      Console.WriteLine("The second component of {0} is {1}.", _
                        theTime, theTime.ToString("ss"))
      ' The example produces the following output:
      '    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      '    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.
      '    The second component of 6/12/2008 9:16:32 PM -07:00 is 32.