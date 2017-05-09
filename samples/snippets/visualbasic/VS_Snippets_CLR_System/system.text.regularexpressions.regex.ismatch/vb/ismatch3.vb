' Visual Basic .NET Document
Option Strict On
' Illustrates Regex.IsMatch(String) method.
' <Snippet3>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim partNumbers() As String = { "Part Number: 1298-673-4192", "Part No: A08Z-931-468A", _
                                      "_A90-123-129X", "123K-000-1230", _
                                      "SKU: 0919-2893-1256" }
      Dim rgx As New Regex("[a-zA-Z0-9]\d{2}[a-zA-Z0-9](-\d{3}){2}[A-Za-z0-9]$")
      For Each partNumber As String In partNumbers
         Dim start As Integer = partNumber.IndexOf(":"c)
         If start >= 0 Then 
            Console.WriteLine("{0} {1} a valid part number.", _
                              partNumber, _
                              IIF(rgx.IsMatch(partNumber, start), "is", "is not"))
         Else
            Console.WriteLine("Cannot find starting position in {0}.", partNumber)
         End If                              
      Next
   End Sub
End Module
' The example displays the following output:
'       Part Number: 1298-673-4192 is a valid part number.
'       Part No: A08Z-931-468A is a valid part number.
'       Cannot find starting position in _A90-123-129X.
'       Cannot find starting position in 123K-000-1230.
'       SKU: 0919-2893-1256 is not a valid part number.
' </Snippet3>


