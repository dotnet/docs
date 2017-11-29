' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim formats() As String = { "yyyyMMdd", "HHmmss" }
      Dim dateStrings() As String = { "20130816", "20131608",  
                                      "  20130816   ", "115216", 
                                      "521116", "  115216  " }
      Dim parsedDate As DateTime
      
      For Each dateString As String In dateStrings
         If DateTime.TryParseExact(dateString, formats, Nothing, 
                                   DateTimeStyles.AllowWhiteSpaces Or
                                   DateTimeStyles.AdjustToUniversal,
                                   parsedDate)
            Console.WriteLine($"{dateString} --> {parsedDate:g}")
         Else
            Console.WriteLine($"Cannot convert {dateString}")
         End If                                         
      Next
' The example displays the following output:
'       20130816 --> 8/16/2013 12:00 AM
'       Cannot convert 20131608
'         20130816    --> 8/16/2013 12:00 AM
'       115216 --> 4/22/2013 11:52 AM
'       Cannot convert 521116
'         115216   --> 4/22/2013 11:52 AM
' </Snippet2>

      ' <Snippet3>
      Dim iso8601String As String = "20080501T08:30:52Z"
      Dim dateISO8602 As DateTime = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ")
      Console.WriteLine($"{iso8601String} --> {dateISO8602:g}")
      ' </Snippet3>
      }
      
   End Sub
End Module
