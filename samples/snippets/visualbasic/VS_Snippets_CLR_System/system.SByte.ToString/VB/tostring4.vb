' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim values() As SByte = { -124, 0, 118 }
      Dim specifiers() As String = { "G", "C", "D3", "E2", "e3", "F", _
                                     "N", "P", "X", "00.0", "#.0", _
                                     "000;(0);**Zero**" }
      
      For Each value As SByte In values
         For Each specifier As String In specifiers
            Console.WriteLine("{0}: {1}", specifier, value.ToString(specifier))
         Next
         Console.WriteLine()
      Next
   End Sub
End Module
' The example displays the following output:
'       G: -124
'       C: ($124.00)
'       D3: -124
'       E2: -1.24E+002
'       e3: -1.240e+002
'       F: -124.00
'       N: -124.00
'       P: -12,400.00 %
'       X: 84
'       00.0: -124.0
'       #.0: -124.0
'       000;(0);**Zero**: (124)
'       
'       G: 0
'       C: $0.00
'       D3: 000
'       E2: 0.00E+000
'       e3: 0.000e+000
'       F: 0.00
'       N: 0.00
'       P: 0.00 %
'       X: 0
'       00.0: 00.0
'       #.0: .0
'       000;(0);**Zero**: **Zero**
'       
'       G: 118
'       C: $118.00
'       D3: 118
'       E2: 1.18E+002
'       e3: 1.180e+002
'       F: 118.00
'       N: 118.00
'       P: 11,800.00 %
'       X: 76
'       00.0: 118.0
'       #.0: 118.0
'       000;(0);**Zero**: 118
' </Snippet4>
