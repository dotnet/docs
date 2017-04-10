' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateString, format As String  
      Dim result As Date
      Dim provider As CultureInfo = CultureInfo.InvariantCulture

      ' Parse date-only value with invariant culture.
      dateString = "06/15/2008"
      format = "d"
      Try
         result = Date.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 

      ' Parse date-only value without leading zero in month using "d" format.
      ' Should throw a FormatException because standard short date pattern of 
      ' invariant culture requires two-digit month.
      dateString = "6/15/2008"
      Try
         result = Date.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 
      
      ' Parse date and time with custom specifier.
      dateString = "Sun 15 Jun 2008 8:30 AM -06:00"
      format = "ddd dd MMM yyyy h:mm tt zzz"        
      Try
         result = Date.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 
      
      ' Parse date and time with offset but without offset's minutes.
      ' Should throw a FormatException because "zzz" specifier requires leading  
      ' zero in hours.
      dateString = "Sun 15 Jun 2008 8:30 AM -06"
      Try
         result = Date.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try 
      
      ' Parse a date string using the French (France) culture.
      dateString = "15/06/2008 08:30"
      format = "g"
      provider = New CultureInfo("fr-FR")
      Try
         result = Date.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try

      ' Parse a date that includes seconds and milliseconds
      ' by using the French (France) and invariant cultures.
      dateString = "18/08/2015 06:30:15.006542"
      format = "dd/MM/yyyy HH:mm:ss.ffffff"
      Try
         result = Date.ParseExact(dateString, format, provider)
         Console.WriteLine("{0} converts to {1}.", dateString, result.ToString())
      Catch e As FormatException
         Console.WriteLine("{0} is not in the correct format.", dateString)
      End Try
   End Sub
End Module
' The example displays the following output:
'       06/15/2008 converts to 6/15/2008 12:00:00 AM.
'       6/15/2008 is not in the correct format.
'       Sun 15 Jun 2008 8:30 AM -06:00 converts to 6/15/2008 7:30:00 AM.
'       Sun 15 Jun 2008 8:30 AM -06 is not in the correct format.
'       15/06/2008 08:30 converts to 6/15/2008 8:30:00 AM.
'       18/08/2015 06:30:15.006542 converts to 8/18/2015 6:30:15 AM.
' </Snippet1>

