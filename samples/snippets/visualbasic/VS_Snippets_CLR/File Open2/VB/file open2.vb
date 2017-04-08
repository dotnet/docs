' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
  Public Shared Sub Main()
    ' This sample assumes that you have a folder named "c:\temp" on your computer. 
    Dim filePath As String = "c:\temp\MyTest.txt"

    ' Delete the file if it exists. 
    If File.Exists(filePath) Then
      File.Delete(filePath)
    End If

    ' Create the file.
    Using fs As FileStream = File.Create(filePath)
      Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")

      ' Add some information to the file.
      fs.Write(info, 0, info.Length)
    End Using

    ' Open the stream and read it back.
    Using fs As FileStream = File.Open(filePath, FileMode.Open, FileAccess.Read)
      Dim b(1024) As Byte
      Dim temp As UTF8Encoding = New UTF8Encoding(True)

      ' Display the information on the console. 
      Do While fs.Read(b, 0, b.Length) > 0
        Console.WriteLine(temp.GetString(b))
      Loop

      Try
        ' Try to write to the file
        fs.Write(b, 0, b.Length)
      Catch e As Exception
        Console.WriteLine("Writing was disallowed, as expected: " & e.ToString())
      End Try

    End Using

  End Sub
End Class
' </Snippet1>
