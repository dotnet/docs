' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
  Public Shared Sub Main()
    Dim path As String = "c:\temp\MyTest.txt"

    ' Create the file if it does not exist. 
    If Not File.Exists(path) Then
      ' Create the file.
      Using fs As FileStream = File.Create(path)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")

        ' Add some information to the file.
        fs.Write(info, 0, info.Length)
      End Using
    End If

    ' Open the stream and read it back.
    Using fs As FileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None)
      Dim b(1024) As Byte
      Dim temp As UTF8Encoding = New UTF8Encoding(True)

      Do While fs.Read(b, 0, b.Length) > 0
        Console.WriteLine(temp.GetString(b))
      Loop

      Try
        ' Try to get another handle to the same file. 
        Using fs2 As FileStream = File.Open(path, FileMode.Open)
          ' Do some task here.
        End Using
      Catch e As Exception
        Console.Write("Opening the file twice is disallowed.")
        Console.WriteLine(", as expected: {0}", e.ToString())
      End Try

    End Using

  End Sub
End Class
' </Snippet1>