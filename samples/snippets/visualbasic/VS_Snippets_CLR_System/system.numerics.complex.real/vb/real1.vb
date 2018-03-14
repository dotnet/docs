' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { New Complex(12.5, -6.3), 
                                  New Complex(-17.8, 1.7), 
                                  New Complex(14.4, 8.9) }
      For Each value In values
         Console.WriteLine("{0} + {1}i", value.Real, value.Imaginary)
      Next                                   
   End Sub
End Module
' The example displays the following output:
'       12.5 + -6.3i
'       -17.8 + 1.7i
'       14.4 + 8.9i
' </Snippet1>
