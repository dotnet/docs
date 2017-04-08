' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Public Delegate Sub ShowValue

Public Class Name
   Private instanceName As String
   
   Public Sub New(name As String)
      Me.instanceName = name
   End Sub
   
   Public Sub DisplayToConsole()
      Console.WriteLine(Me.instanceName)
   End Sub   
   
   Public Sub DisplayToWindow()
      MsgBox(Me.instanceName)
   End Sub   
End Class

Public Module testDelegate
   Public Sub Main()
      Dim testName As New Name("Koani")
      Dim showMethod As ShowValue = AddressOf testName.DisplayToWindow
      showMethod   
   End Sub
End Module
' </Snippet1>

