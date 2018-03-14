' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim value As UShort = 21708 
      Dim specifiers() As String = { "G", "C", "D3", "E2", "e3", "F", _
                                     "N", "P", "X", "000000.0", "#.0", _
                                     "00000000;(0);**Zero**" }
      
      For Each specifier As String In specifiers
         Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
      Next
   End Sub
End Module
' The example displays the following output:
'       G: 21708
'       C: $21,708.00
'       D3: 21708
'       E2: 2.17E+004
'       e3: 2.171e+004
'       F: 21708.00
'       N: 21,708.00
'       P: 2,170,800.00 %
'       X: 54CC
'       000000.0: 021708.0
'       #.0: 21708.0
'       00000000;(0);**Zero**: 00021708
' </Snippet3>
