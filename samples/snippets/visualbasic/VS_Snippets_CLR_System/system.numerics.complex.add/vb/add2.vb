' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Numerics

Module modMain
   Public Sub Main()
      Dim values() As Complex = { New Complex(12.3, -1.4), 
                                  New Complex(-6.2, 3.1), 
                                  New Complex(8.9, 1.5) }   
      For Each c1 In values
         For Each c2 In values
            Console.WriteLine("{0} + {1} = {2}", c1, c2, c1 + c2)
         Next
      Next      
   End Sub
End Module
' The example displays the following output:
'       (12.3, -1.4) + (12.3, -1.4) = (24.6, -2.8)
'       (12.3, -1.4) + (-6.2, 3.1) = (6.1, 1.7)
'       (12.3, -1.4) + (8.9, 1.5) = (21.2, 0.1)
'       (-6.2, 3.1) + (12.3, -1.4) = (6.1, 1.7)
'       (-6.2, 3.1) + (-6.2, 3.1) = (-12.4, 6.2)
'       (-6.2, 3.1) + (8.9, 1.5) = (2.7, 4.6)
'       (8.9, 1.5) + (12.3, -1.4) = (21.2, 0.1)
'       (8.9, 1.5) + (-6.2, 3.1) = (2.7, 4.6)
'       (8.9, 1.5) + (8.9, 1.5) = (17.8, 3)
' </Snippet2>
