' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim pattern As String = "(\d{3})-(\d{3}-\d{4})"
      Dim input As String = "212-555-6666 906-932-1111 415-222-3333 425-888-9999"
      Dim matches As MatchCollection = Regex.Matches(input, pattern)
      
      For Each match As Match In matches
         Console.WriteLine("Area Code:        {0}", match.Groups(1).Value)
         Console.WriteLine("Telephone number: {0}", match.Groups(2).Value)
         Console.WriteLine()
      Next
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'       Area Code:        212
'       Telephone number: 555-6666
'       
'       Area Code:        906
'       Telephone number: 932-1111
'       
'       Area Code:        415
'       Telephone number: 222-3333
'       
'       Area Code:        425
'       Telephone number: 888-9999
' </Snippet1>
