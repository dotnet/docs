' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
  Public Shared Sub Main()
    Dim path As String = "c:\temp\MyTest.txt"

    Try

      ' Delete the file if it exists. 
      If File.Exists(path) Then
        ' Note that no lock is put on the file and the possibility exists 
        ' that another process could do something with it between 
        ' the calls to Exists and Delete.
        File.Delete(path)
      End If

      ' Create the file. 
      Using fs As FileStream = File.Create(path, 1024)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")

        ' Add some information to the file.
        fs.Write(info, 0, info.Length)
      End Using

      ' Open the stream and read it back. 
      Using sr As StreamReader = File.OpenText(path)
        Do While sr.Peek() >= 0
          Console.WriteLine(sr.ReadLine())
        Loop
      End Using

    Catch ex As Exception
      Console.WriteLine(ex.ToString())
    End Try

  End Sub
End Class
' </Snippet1>

