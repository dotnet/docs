      Dim fmt As DateTimeFormatInfo = New CultureInfo("fr-fr").DateTimeFormat
      Dim dateString As String
      Dim offsetDate As DateTimeOffset
      
      dateString = "03-12-07"
      offsetDate = DateTimeOffset.Parse(dateString, fmt)
      Console.WriteLine("{0} returns {1}", _
                        dateString, _
                        offsetDate.ToString())
      
      dateString = "15/09/07 08:45:00 +1:00"
      offsetDate = DateTimeOffset.Parse(dateString, fmt)
      Console.WriteLine("{0} returns {1}", _
                        dateString, _
                        offsetDate.ToString())
      
      dateString = "mar. 1 janvier 2008 1:00:00 +1:00" 
      offsetDate = DateTimeOffset.Parse(dateString, fmt)
      Console.WriteLine("{0} returns {1}", _
                        dateString, _
                        offsetDate.ToString())
      ' The example displays the following output to the console:
      '    03-12-07 returns 12/3/2007 12:00:00 AM -08:00
      '    15/09/07 08:45:00 +1:00 returns 9/15/2007 8:45:00 AM +01:00
      '    mar. 1 janvier 2008 1:00:00 +1:00 returns 1/1/2008 1:00:00 AM +01:00                              