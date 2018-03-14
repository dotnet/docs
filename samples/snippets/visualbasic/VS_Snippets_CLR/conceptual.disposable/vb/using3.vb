' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.IO

Module Example
   Public Sub Main()
      Dim buffer(49) As Char
''      Dim s As New StreamReader("File1.txt")
With s As New StreamReader("File1.txt")
      Try
         Dim charsRead As Integer
         Do While s.Peek() <> -1
            charsRead = s.Read(buffer, 0, buffer.Length)         
            ' 
            ' Process characters read.
            '
         Loop
         s.Close()
      Finally
         If s IsNot Nothing Then DirectCast(s, IDisposable).Dispose()
      End Try
End With
   End Sub
End Module
' </Snippet3>
