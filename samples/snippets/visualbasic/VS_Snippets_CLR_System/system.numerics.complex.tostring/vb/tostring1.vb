' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Numerics

Module Example
   Public Sub Main()
      Dim c() As Complex = { New Complex(17.3, 14.1), 
                             New Complex(-18.9, 147.2), 
                             New Complex(13.472, -18.115), 
                             New Complex(-11.154, -17.002) }
      For Each c1 As Complex In c
         Console.WriteLine(c1.ToString())
      Next                          
   End Sub
End Module
' The example displays the following output:
'       (17.3, 14.1)
'       (-18.9, 147.2)
'       (13.472, -18.115)
'       (-11.154, -17.002)
' </Snippet1>

