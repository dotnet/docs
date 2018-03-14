' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Public Class Name
   Private instanceName As String
   
   Public Sub New(name As String)
      Me.instanceName = name
   End Sub
   
   Public Function DisplayToConsole() As Integer
      Console.WriteLine(Me.instanceName)
      Return 0
   End Function
   
   Public Function DisplayToWindow() As Integer
      Return MsgBox(Me.instanceName)
   End Function      
End Class

Module LambdaExpression
   Public Sub Main()
      Dim name1 As New Name("Koani")
      Dim methodCall As Action = Sub() name1.DisplayToWindow()
      methodCall()
   End Sub
End Module
' </Snippet4>
