' Visual Basic .NET Document
Option Strict On

' <Snippet20>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim formats() As String = { "dd MMM yyyy hh:mm tt PST", 
                                  "dd MMM yyyy hh:mm tt PDT" }
      Dim dat As New Date(2016, 8, 18, 16, 50, 0)
      ' Display the result string. 
      Console.WriteLine(dat.ToString(formats(1)))
      
      ' Parse a string. 
      Dim value As String = "25 Dec 2016 12:00 pm PST"
      Dim newDate As Date
      If Date.TryParseExact(value, formats, Nothing, 
                            DateTimeStyles.None, newDate) Then 
         Console.WriteLine(newDate)
      Else
         Console.WriteLine("Unable to parse '{0}'", value)
      End If                               
   End Sub
End Module
' The example displays the following output:
'       18 Aug 2016 04:50 PM PDT
'       12/25/2016 12:00:00 PM
' </Snippet20>
