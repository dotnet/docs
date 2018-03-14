' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim values() As Complex = { New Complex(12.4, 6.3), 
                                  New Complex(12.4, -6.3) }
      For Each value In values
         Console.WriteLine("Original value: {0}", value)
         Console.WriteLine("Conjugate:      {0}", 
                           Complex.Conjugate(value).ToString())
         Console.WriteLine()                        
      Next                            
   End Sub
End Module
' The example displays the following output:
'       Original value: (12.4, 6.3)
'       Conjugate:      (12.4, -6.3)
'       
'       Original value: (12.4, -6.3)
'       Conjugate:      (12.4, 6.3)
' </Snippet1>
