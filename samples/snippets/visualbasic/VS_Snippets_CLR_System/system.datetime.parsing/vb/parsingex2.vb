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
            Console.WriteLine("{0} --> {1:g}", dateString, parsedDate)
         Else
            Console.WriteLine("Cannot convert {0}", dateString)
         End If                                         
      Next
   End Sub
End Module
' The example displays the following output:
'       20130816 --> 8/16/2013 12:00 AM
'       Cannot convert 20131608
'         20130816    --> 8/16/2013 12:00 AM
'       115216 --> 4/22/2013 11:52 AM
'       Cannot convert 521116
'         115216   --> 4/22/2013 11:52 AM
' </Snippet2>
