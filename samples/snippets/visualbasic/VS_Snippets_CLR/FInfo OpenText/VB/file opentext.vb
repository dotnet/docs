'  <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class OpenTextTest
    Public Shared Sub Main()
        Dim path As String = "c:\MyTest.txt"

        Dim fi As New FileInfo(path)

        ' Check for existing file
        If fi.Exists = false Then
            ' Create the file.
            Dim fs As FileStream = fi.Create()
            Dim info() As Byte = _
                    New UTF8Encoding(true).GetBytes("This is some text in the file.")

            ' Add some information to the file.
            fs.Write(info, 0, info.Length)
            fs.Close()
        End If

        ' Open the stream and read it back.
        Dim sr As StreamReader = fi.OpenText()
        Dim s As String = ""
        While sr.EndOfStream = false
            s = sr.ReadLine()
            Console.WriteLine(s)
        End While
        sr.Close()
    End Sub
End Class
'This code produces output similar to the following;
'results may vary based on the computer/file structure/etc.:
'
'This is some text in the file.
'
' </Snippet1>
