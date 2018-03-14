' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Module modMain

   Public Sub Main()
      ParseOverload1()
      Console.WriteLine()
      ParseOverload2()
      Console.WriteLine()
      ParseOverload3()
   End Sub
   
   Private Sub ParseOverload1()
      ' <Snippet1>
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
      ' </Snippet1>
   End Sub
   
   Private Sub ParseOverload2()
      ' <Snippet2>   
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
      ' </Snippet2>   
   End Sub
   
   Private Sub ParseOverload3()
      ' <Snippet3>
      Dim dateString As String
      Dim offsetDate As DateTimeOffset

      dateString = "05/01/2008 6:00:00"
      ' Assume time is local 
      offsetDate = DateTimeOffset.Parse(dateString, Nothing, DateTimeStyles.AssumeLocal)
      Console.WriteLine(offsetDate.ToString())   ' Displays 5/1/2008 6:00:00 AM -07:00

      ' Assume time is UTC
      offsetDate = DateTimeOffset.Parse(dateString, Nothing, DateTimeStyles.AssumeUniversal)
      Console.WriteLine(offsetDate.ToString())   ' Displays 5/1/2008 6:00:00 AM +00:00

      ' Parse and convert to UTC 
      dateString = "05/01/2008 6:00:00AM +5:00"
      offsetDate = DateTimeOffset.Parse(dateString, Nothing, DateTimeStyles.AdjustToUniversal)
      Console.WriteLine(offsetDate.ToString())   ' Displays 5/1/2008 1:00:00 AM +00:00
      ' </Snippet3>
   End Sub
End Module

