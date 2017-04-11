' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      Dim n1 As Integer = 12
      Dim n2 As Integer = 82
      Dim n3 As Long = 12
      
      Console.WriteLine("n1 and n2 are the same type: {0}",
                        Object.ReferenceEquals(n1.GetType(), n2.GetType()))
      Console.WriteLine("n1 and n3 are the same type: {0}",
                        Object.ReferenceEquals(n1.GetType(), n3.GetType()))
   End Sub
End Module
' The example displays the following output:
'       n1 and n2 are the same type: True
'       n1 and n3 are the same type: False      
' </Snippet1>

