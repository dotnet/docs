' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      Dim n1 As Integer = 10
      Dim n2 As Integer = 20
      ' <Snippet4>
      Dim result As String = String.Format("{0} + {1} = {2}", 
                                           n1, n2, n1 + n2)
      ' </Snippet4>
      Console.WriteLine(result)
      Main2()
   End Sub

   Public Sub Main2()
      ' <Snippet3>
      Dim n1 As Integer = 10
      Dim n2 As Integer = 20
      Dim result As String = String.Format("{0 + {1] = {2}", 
                                           n1, n2, n1 + n2)
      ' </Snippet3>
   End Sub
End Module

