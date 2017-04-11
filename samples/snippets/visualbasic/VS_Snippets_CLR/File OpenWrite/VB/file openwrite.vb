' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
  Public Shared Sub Main()
    Dim path As String = "c:\temp\MyTest.txt"

    ' Open the stream and write to it.
    Using fs As FileStream = File.OpenWrite(path)
      Dim info As Byte() = _
       New UTF8Encoding(True).GetBytes("This is to test the OpenWrite method.")

      ' Add some information to the file.
      fs.Write(info, 0, info.Length)
    End Using

    'Open the stream and read it back.
    Using fs As FileStream = File.OpenRead(path)
      Dim b(1024) As Byte
      Dim temp As UTF8Encoding = New UTF8Encoding(True)

      Do While fs.Read(b, 0, b.Length) > 0
        Console.WriteLine(temp.GetString(b))
      Loop
    End Using

  End Sub
End Class
' </Snippet1>
