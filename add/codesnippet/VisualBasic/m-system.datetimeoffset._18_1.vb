      Dim parsedDate As DateTimeOffset
      Dim dateString As String
      
      ' String with date only
      dateString = "05/01/2008"
      If DateTimeOffset.TryParse(dateString, parsedDate) Then _
         Console.WriteLine("{0} was converted to to {1}.", _
                           dateString, parsedDate)

      ' String with time only
      dateString = "11:36 PM"
      If DateTimeOffset.TryParse(dateString, parsedDate) Then _
         Console.WriteLine("{0} was converted to to {1}.", _
                           dateString, parsedDate)

      ' String with date and offset 
      dateString = "05/01/2008 +7:00"
      If DateTimeOffset.TryParse(dateString, parsedDate) Then _
         Console.WriteLine("{0} was converted to to {1}.", _
                           dateString, parsedDate)

      ' String with day abbreviation
      dateString = "Thu May 01, 2008"
      If DateTimeOffset.TryParse(dateString, parsedDate) Then _
         Console.WriteLine("{0} was converted to to {1}.", _
                           dateString, parsedDate)

      ' String with date, time with AM/PM designator, and offset
      dateString = "5/1/2008 10:00 AM -07:00"
      If DateTimeOffset.TryParse(dateString, parsedDate) Then _
         Console.WriteLine("{0} was converted to to {1}.", _
                           dateString, parsedDate)
      ' If run on 3/29/07, the example displays the following output
      ' to the console:
      '    05/01/2008 was converted to to 5/1/2008 12:00:00 AM -07:00.
      '    11:36 PM was converted to to 3/29/2007 11:36:00 PM -07:00.
      '    05/01/2008 +7:00 was converted to to 5/1/2008 12:00:00 AM +07:00.
      '    Thu May 01, 2008 was converted to to 5/1/2008 12:00:00 AM -07:00.
      '    5/1/2008 10:00 AM -07:00 was converted to to 5/1/2008 10:00:00 AM -07:00.                                 