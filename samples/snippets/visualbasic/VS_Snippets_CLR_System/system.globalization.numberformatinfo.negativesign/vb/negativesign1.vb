' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture("")
      ci.NumberFormat.NegativeSign = ChrW(&h203E)
      Dim numbers() As Double = { -1.0, -16.3, -106.35 }

      For Each number In numbers
         Console.WriteLine(number.ToString(culture))
      Next
   End Sub
End Module
' The example displays the following output:
'       ‾1
'       ‾16.3
'       ‾106.35
' </Snippet1>

