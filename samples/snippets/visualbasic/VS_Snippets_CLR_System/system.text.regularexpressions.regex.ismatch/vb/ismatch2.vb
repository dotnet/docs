' Visual Basic .NET Document
Option Strict On
' Illustrates Regex.IsMatch(String) method.
' <Snippet2>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim partNumbers() As String = { "1298-673-4192", "A08Z-931-468A", _
                                      "_A90-123-129X", "12345-KKA-1230", _
                                      "0919-2893-1256" }
      Dim rgx As New Regex("^[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$")
      For Each partNumber As String In partNumbers
         Console.WriteLine("{0} {1} a valid part number.", _
                           partNumber, _
                           IIF(rgx.IsMatch(partNumber), "is", "is not"))
      Next
   End Sub
End Module
' The example displays the following output:
'       1298-673-4192 is a valid part number.
'       A08Z-931-468A is a valid part number.
'       _A90-123-129X is not a valid part number.
'       12345-KKA-1230 is not a valid part number.
'       0919-2893-1256 is not a valid part number.
' </Snippet2>


