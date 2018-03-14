' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Text

Module Example
   Public Sub Main()
      Dim utf32 As New UTF32Encoding(Not BitConverter.IsLittleEndian, True)

      Dim s As String = "It was the best of times, it was the worst of times..."

      ' We need to dimension the array, since we'll populate it with 2 method calls.
      Dim bytes(utf32.GetByteCount(s) + utf32.GetPreamble().Length - 1) As Byte
      ' Encode the string.
      Array.Copy(utf32.GetPreamble(), bytes, utf32.GetPreamble().Length)
      utf32.GetBytes(s, 0, s.Length, bytes, utf32.GetPreamble().Length)

      ' Decode the byte array.
      Dim s2 As String = utf32.GetString(bytes, 0, bytes.Length)
      Console.WriteLine(s2)
   End Sub
End Module
' The example displays the following output:
'       ?It was the best of times, it was the worst of times...
' </Snippet2>

