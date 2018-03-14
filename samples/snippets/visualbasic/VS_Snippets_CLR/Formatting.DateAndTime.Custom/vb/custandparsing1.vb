' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet18>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim dateValues() As String = { "30-12-2011", "12-30-2011", 
                                      "30-12-11", "12-30-11" }
      Dim pattern As String = "MM-dd-yy"
      Dim parsedDate As Date
      
      For Each dateValue As String In dateValues
         If DateTime.TryParseExact(dateValue, pattern, Nothing, 
                                   DateTimeStyles.None, parsedDate) Then
            Console.WriteLine("Converted '{0}' to {1:d}.", 
                              dateValue, parsedDate)
         Else
            Console.WriteLine("Unable to convert '{0}' to a date and time.", 
                              dateValue)
         End If                                                         
      Next
   End Sub
End Module
' The example displays the following output:
'    Unable to convert '30-12-2011' to a date and time.
'    Unable to convert '12-30-2011' to a date and time.
'    Unable to convert '30-12-11' to a date and time.
'    Converted '12-30-11' to 12/30/2011.
' </Snippet18>

