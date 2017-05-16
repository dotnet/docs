' <Snippet1>
Imports System
Imports System.IO

Namespace BigEndianExample
   Public Class Class1
      Public Overloads Shared Sub Main()
         ' Read a text file saved with Big Endian Unicode encoding.
         Dim encoding As System.Text.Encoding = System.Text.Encoding.BigEndianUnicode
         Dim reader As New StreamReader("TextFile.txt", encoding)
         Dim line As String = reader.ReadLine()
         While Not (line Is Nothing)
            Console.WriteLine(line)
            line = reader.ReadLine()
         End While
      End Sub
   End Class
End Namespace
' </Snippet1>