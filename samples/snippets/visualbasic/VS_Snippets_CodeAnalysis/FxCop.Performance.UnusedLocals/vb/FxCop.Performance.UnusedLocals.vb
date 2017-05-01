'<Snippet1>
Imports System
Imports System.Windows.Forms

Namespace PerformanceLibrary

   Public Class UnusedLocals

      Sub SomeMethod()
      
         Dim unusedInteger As Integer
         Dim unusedString As String = "hello"
         Dim unusedArray As String() = Environment.GetLogicalDrives()
         Dim unusedButton As New Button()

      End Sub

   End Class

End Namespace
'</Snippet1>
