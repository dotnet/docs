      Dim firstDate As New DateTimeOffset(#3/25/2008 6:00PM#, _
                                          New TimeSpan(-7, 0, 0))
      Dim secondDate As New DateTimeOffset(#3/25/2008 6:00PM#, _
                                           New TimeSpan(-5, 0, 0))
      Dim thirdDate As New DateTimeOffset(#2/28/2008 9:00AM#, _
                                          New TimeSpan(-7, 0, 0))
      Dim difference As TimeSpan
      
      difference = firstDate.Subtract(secondDate)
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", _
                        firstDate.ToString(), _
                        secondDate.ToString(), _
                        difference.Days, _
                        difference.Hours, _
                        difference.Minutes)      
      difference = firstDate.Subtract(thirdDate)
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", _
                        firstDate.ToString(), _
                        secondDate.ToString(), _
                        difference.Days, _
                        difference.Hours, _
                        difference.Minutes) 
      ' The example produces the following output:
      '    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 0 days, 2:00
      '    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 26 days, 9:00                                 