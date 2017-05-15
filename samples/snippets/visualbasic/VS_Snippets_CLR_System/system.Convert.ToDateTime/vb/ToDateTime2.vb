' Visual Basic .NET Document
' Illustrates Convert.ToDateTime(String) method.
Option Strict On

' <Snippet2>
Module ConversionToDateTime
   Public Sub Main()
      Dim dateString As String = Nothing
      
      ' Convert a null string.
      ConvertToDateTime(dateString)
      
      ' Convert an empty string.
      dateString = String.Empty
      ConvertToDateTime(dateString)
      
      ' Convert a non-date string.
      dateString = "not a date"
      ConvertToDateTime(dateString)
      
      ' Try to convert various date strings.
      dateString = "05/01/1996"
      ConvertToDateTime(dateString)
      dateString = "Tue Apr 28, 2009"
      ConvertToDateTime(dateString)
      dateString = "Wed Apr 28, 2009"
      ConvertToDateTime(dateString)
      dateString = "06 July 2008 7:32:47 AM"
      ConvertToDateTime(dateString)
      dateString = "17:32:47.003"
      ConvertToDateTime(dateString)
      ' Convert a string returned by DateTime.ToString("R").
      dateString = "Sat, 10 May 2008 14:32:17 GMT"
      ConvertToDateTime(dateString)
      ' Convert a string returned by DateTime.ToString("o")
      dateString = "2009-05-01T07:54:59.9843750-04:00"
      ConvertToDateTime(dateString)
   End Sub
   
   Private Sub ConvertToDateTime(value As String)
      Dim convertedDate As Date
      Try
         convertedDate = Convert.ToDateTime(value)
         Console.WriteLine("'{0}' converts to {1}.", value, convertedDate)
      Catch e As FormatException
         Console.WriteLine("'{0}' is not in the proper format.", value)
      End Try
   End Sub
End Module
' The example displays the following output:
'    '' converts to 1/1/0001 12:00:00 AM.
'    '' is not in the proper format.
'    'not a date' is not in the proper format.
'    '05/01/1996' converts to 5/1/1996 12:00:00 AM.
'    'Tue Apr 28, 2009' converts to 4/28/2009 12:00:00 AM.
'    'Wed Apr 28, 2009' is not in the proper format.
'    '06 July 2008 7:32:47 AM' converts to 7/6/2008 7:32:47 AM.
'    '17:32:47.003' converts to 5/30/2008 5:32:47 PM.
'    'Sat, 10 May 2008 14:32:17 GMT' converts to 5/10/2008 7:32:17 AM.
'    '2009-05-01T07:54:59.9843750-04:00' converts to 5/1/2009 4:54:59 AM.
' </Snippet2>
