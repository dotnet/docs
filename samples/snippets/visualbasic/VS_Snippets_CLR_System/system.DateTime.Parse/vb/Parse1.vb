' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Class DateTimeParser
   Public Shared Sub Main()
      ' Assume the current culture is en-US. 
      ' The date is February 16, 2008, 12 hours, 15 minutes and 12 seconds.

      ' Use standard en-US date and time value
      Dim dateValue As Date
      Dim dateString As String = "2/16/2008 12:15:12 PM"
      Try
         dateValue = Date.Parse(dateString)
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}'.", dateString)
      End Try
            
      ' Reverse month and day to conform to the fr-FR culture.
      ' The date is February 16, 2008, 12 hours, 15 minutes and 12 seconds.
      dateString = "16/02/2008 12:15:12"
      Try
         dateValue = Date.Parse(dateString)
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}'.", dateString)
      End Try

      ' Call another overload of Parse to successfully convert string
      ' formatted according to conventions of fr-FR culture.      
      Try
         dateValue = Date.Parse(dateString, New CultureInfo("fr-FR", False))
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}'.", dateString)
      End Try
      
      ' Parse string with date but no time component.
      dateString = "2/16/2008"
      Try
         dateValue = Date.Parse(dateString)
         Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue)
      Catch e As FormatException
         Console.WriteLine("Unable to convert '{0}'.", dateString)
      End Try
   End Sub 
End Class 
' The example displays the following output to the console:
'       '2/16/2008 12:15:12 PM' converted to 2/16/2008 12:15:12 PM.
'       Unable to convert '16/02/2008 12:15:12'.
'       '16/02/2008 12:15:12' converted to 2/16/2008 12:15:12 PM.
'       '2/16/2008' converted to 2/16/2008 12:00:00 AM.
' </Snippet1>
