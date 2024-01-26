' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Public Class Object2
   Private value As Object
   
   Public Sub New(value As Object)
      Me.value = value
   End Sub
   
   Public Overrides Function ToString() As String
      Return MyBase.ToString + ": " + value.ToString()
   End Function
End Class

Module Example5
    Public Sub Main()
        Dim obj2 As New Object2("a"c)
        Console.WriteLine(obj2.ToString())
    End Sub
End Module
' The example displays the following output:
'       Object2: a
' </Snippet3>
