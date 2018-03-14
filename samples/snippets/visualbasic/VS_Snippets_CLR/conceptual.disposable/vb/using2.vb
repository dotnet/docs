' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.IO

Module Example
   Public Sub Main()
      Dim buffer(49) As Char
      Dim s As StreamReader = Nothing
      
      Try
         s = New StreamReader("File1.txt")
         Dim charsRead As Integer
         Do While s.Peek() <> -1
            charsRead = s.Read(buffer, 0, buffer.Length)         
            ' 
            ' Process characters read.
            '
         Loop
         s.Close()
      Finally
         ' If non-null, call the object's Dispose method.
         If s IsNot Nothing
            s.Dispose()
         End If
      End Try
   End Sub
End Module
' </Snippet2>
