' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Module Example
   Public Sub Main()
      Dim utf8 As New UTF8Encoding(True, True)

      Dim s As String = "It was the best of times, it was the worst of times..."

      ' We need to dimension the array, since we'll populate it with 2 method calls.
      Dim bytes(utf8.GetByteCount(s) + utf8.GetPreamble().Length - 1) As Byte
      ' Encode the string.
      Array.Copy(utf8.GetPreamble(), bytes, utf8.GetPreamble().Length)
      utf8.GetBytes(s, 0, s.Length, bytes, utf8.GetPreamble().Length)

      ' Decode the byte array.
      Dim s2 As String = utf8.GetString(bytes, 0, bytes.Length)
      Console.WriteLine(s2)
   End Sub
End Module
' The example displays the following output:
'       ?It was the best of times, it was the worst of times...
' </Snippet1>

