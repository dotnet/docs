      Dim dateString As String
      Dim offsetDate As DateTimeOffset

      ' String with date only
      dateString = "05/01/2008"
      offsetDate = DateTimeOffset.Parse(dateString)
      Console.WriteLine(offsetDate.ToString())   ' Displays 5/1/2008 12:00:00 AM -07:00  

      ' String with time only
      dateString = "11:36 PM"
      offsetDate = DateTimeOffset.Parse(dateString)
      Console.WriteLine(offsetDate.ToString())   ' Displays 3/26/2007 11:36:00 PM -07:00

      ' String with date and offset 
      dateString = "05/01/2008 +7:00"
      offsetDate = DateTimeOffset.Parse(dateString)
      Console.WriteLine(offsetDate.ToString())   ' Displays 5/1/2008 12:00:00 AM +07:00

      ' String with day abbreviation
      dateString = "Thu May 01, 2008"
      offsetDate = DateTimeOffset.Parse(dateString)
      Console.WriteLine(offsetDate.ToString())   ' Displays 5/1/2008 12:00:00 AM -07:00