' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"
        Dim fi As FileInfo = New FileInfo(path)

        ' Delete the file if it exists.
        If fi.Exists() Then
            fi.Delete()
        End If

        'Create the file.
        Dim fs As FileStream = fi.Create()
        Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")

        'Add some information to the file.
        fs.Write(info, 0, info.Length)
        fs.Close()

        'Open the stream and read it back.
        Dim sr As StreamReader = fi.OpenText()

        Do While sr.Peek() >= 0
            Console.WriteLine(sr.ReadLine())
        Loop
        sr.Close()
    End Sub
End Class

'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'This is some text in the file.
' </Snippet1>
