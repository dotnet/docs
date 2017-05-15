' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.IO

Module TestDelegate
   Public Sub Main()
      Dim output As New OutputTarget()
      Dim methodCall As Func(Of Boolean) = AddressOf output.SendToFile
      If methodCall() Then 
         Console.WriteLine("Success!")
      Else
         Console.WriteLine("File write operation failed.")
      End If      
   End Sub
End Module

Public Class OutputTarget
   Public Function SendToFile() As Boolean
      Try
         Dim fn As String = Path.GetTempFileName
         Dim sw As StreamWriter = New StreamWriter(fn)
         sw.WriteLine("Hello, World!")
         sw.Close      
         Return True
      Catch
         Return False
      End Try
   End Function
End Class
' </Snippet2>
