      Dim startOfMonth As New DateTimeOffset(#1/1/2008#, _
                                            DateTimeOffset.Now.Offset)
      Dim year As Integer = startOfMonth.Year
      Do While startOfMonth.Year = year
         Console.WriteLine("{0:MMM d, yyyy} is a {1}.", _
                           startOfMonth, startOfMonth.DayOfWeek)
         startOfMonth = startOfMonth.AddMonths(1)                   
      Loop      
      ' This example writes the following output to the console:
      '    Jan 1, 2008 is a Tuesday.
      '    Feb 1, 2008 is a Friday.
      '    Mar 1, 2008 is a Saturday.
      '    Apr 1, 2008 is a Tuesday.
      '    May 1, 2008 is a Thursday.
      '    Jun 1, 2008 is a Sunday.
      '    Jul 1, 2008 is a Tuesday.
      '    Aug 1, 2008 is a Friday.
      '    Sep 1, 2008 is a Monday.
      '    Oct 1, 2008 is a Wednesday.
      '    Nov 1, 2008 is a Saturday.
      '    Dec 1, 2008 is a Monday.      