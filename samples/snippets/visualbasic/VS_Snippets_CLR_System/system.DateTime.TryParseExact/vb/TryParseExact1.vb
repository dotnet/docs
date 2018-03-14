Option Strict On

' <Snippet1>
Imports System.Globalization

Public Module Example
   Public Sub Main()
      Dim enUS As New CultureInfo("en-US") 
      Dim dateString As String
      Dim dateValue As Date
      
      ' Parse date with no style flags.
      dateString = " 5/01/2009 8:30 AM"
      If Date.TryParseExact(dateString, "g", enUS, _
                            DateTimeStyles.None, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If
      ' Allow a leading space in the date string.
      If Date.TryParseExact(dateString, "g", enUS, _
                            DateTimeStyles.AllowLeadingWhite, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If
      
      ' Use custom formats with M and MM.
      dateString = "5/01/2009 09:00"
      If Date.TryParseExact(dateString, "M/dd/yyyy hh:mm", enUS, _
                            DateTimeStyles.None, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If
      ' Allow a leading space in the date string.
      If Date.TryParseExact(dateString, "MM/dd/yyyy hh:mm", enUS, _
                            DateTimeStyles.None, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If

      ' Parse a string with time zone information.
      dateString = "05/01/2009 01:30:42 PM -05:00" 
      If Date.TryParseExact(dateString, "MM/dd/yyyy hh:mm:ss tt zzz", enUS, _
                            DateTimeStyles.None, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If
      ' Allow a leading space in the date string.
      If Date.TryParseExact(dateString, "MM/dd/yyyy hh:mm:ss tt zzz", enUS, _
                            DateTimeStyles.AdjustToUniversal, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If
           
      ' Parse a string represengting UTC.
      dateString = "2008-06-11T16:11:20.0904778Z"
      If Date.TryParseExact(dateString, "o", CultureInfo.InvariantCulture, _
                                     DateTimeStyles.None, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If
      
      If Date.TryParseExact(dateString, "o", CultureInfo.InvariantCulture, _
                            DateTimeStyles.RoundtripKind, dateValue) Then
         Console.WriteLine("Converted '{0}' to {1} ({2}).", dateString, dateValue, _
                           dateValue.Kind)
      Else
         Console.WriteLine("'{0}' is not in an acceptable format.", dateString)
      End If
   End Sub
End Module
' The example displays the following output:
'    ' 5/01/2009 8:30 AM' is not in an acceptable format.
'    Converted ' 5/01/2009 8:30 AM' to 5/1/2009 8:30:00 AM (Unspecified).
'    Converted '5/01/2009 09:00' to 5/1/2009 9:00:00 AM (Unspecified).
'    '5/01/2009 09:00' is not in an acceptable format.
'    Converted '05/01/2009 01:30:42 PM -05:00' to 5/1/2009 11:30:42 AM (Local).
'    Converted '05/01/2009 01:30:42 PM -05:00' to 5/1/2009 6:30:42 PM (Utc).
'    Converted '2008-06-11T16:11:20.0904778Z' to 6/11/2008 9:11:20 AM (Local).
'    Converted '2008-06-11T16:11:20.0904778Z' to 6/11/2008 4:11:20 PM (Utc).
' </Snippet1>
