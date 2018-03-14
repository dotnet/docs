' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Module Example
   Public Sub Main()
       Dim values(9) As Integer
       For ctr As Integer = 0 To 9
          values(ctr) = ctr * 2
       Next
          
       For Each value In values
          Console.WriteLine(value)
       Next      
   End Sub
End Module
' The example displays the following output:
'    0
'    2
'    4
'    6
'    8
'    10
'    12
'    14
'    16
'    18
' </Snippet11>
