' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim c() As Complex = { New Complex(17.3, 14.1), 
                             New Complex(-18.9, 147.2), 
                             New Complex(13.472, -18.115), 
                             New Complex(-11.154, -17.002) }
      Dim formats() As String = { "F2", "N2", "G5" } 
      
      For Each c1 As Complex In c
         For Each format As String In formats
            Console.WriteLine("{0}: {1}    ", format, c1.ToString(format))
         Next
         Console.WriteLine()
      Next                          
   End Sub
End Module
' The example displays the following output:
'       F2: (17.30, 14.10)
'       N2: (17.30, 14.10)
'       G5: (17.3, 14.1)
'       
'       F2: (-18.90, 147.20)
'       N2: (-18.90, 147.20)
'       G5: (-18.9, 147.2)
'       
'       F2: (13.47, -18.12)
'       N2: (13.47, -18.12)
'       G5: (13.472, -18.115)
'       
'       F2: (-11.15, -17.00)
'       N2: (-11.15, -17.00)
'       G5: (-11.154, -17.002)
' </Snippet3>

