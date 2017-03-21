      Dim theTime As New DateTimeOffset(#5/1/2007 4:35PM#, _
                                             DateTimeOffset.Now.Offset)
      Console.WriteLine("The day component of {0} is {1}.", _
                        theTime, theTime.Day)

      Console.WriteLine("The day component of {0} is{1}.", _
                        theTime, theTime.ToString(" d"))

      Console.WriteLine("The day component of {0} is {1}.", _
                        theTime, theTime.ToString("dd"))
      ' The example produces the following output:
      '    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      '    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      '    The day component of 5/1/2007 4:35:00 PM -08:00 is 01.