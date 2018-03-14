' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
  Public Shared Sub Main()
  
    ' Create a temporary file, and put some data into it. 
    Dim path1 As String = Path.GetTempFileName()
    Using fs As FileStream = File.Open(path1, FileMode.Open, FileAccess.Write, FileShare.None)
      Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")
      ' Add some information to the file.
      fs.Write(info, 0, info.Length)
    End Using

    ' Open the stream and read it back. 
    Using fs As FileStream = File.Open(path1, FileMode.Open)
      Dim b(1024) As Byte
      Dim temp As UTF8Encoding = New UTF8Encoding(True)
      Do While fs.Read(b, 0, b.Length) > 0
        Console.WriteLine(temp.GetString(b))
      Loop
    End Using

  End Sub
End Class
' </Snippet1>
