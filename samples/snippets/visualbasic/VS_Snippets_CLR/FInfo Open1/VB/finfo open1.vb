' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"
        Dim fi As FileInfo = New FileInfo(path)
        Dim fs As FileStream

        ' Delete the file if it exists.
        If fi.Exists = False Then
            'Create the file.
            fs = fi.Create()
            Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")
            'Add some information to the file.
            fs.Write(info, 0, info.Length)
            fs.Close()
        End If

        'Open the stream and read it back.
        fs = fi.Open(FileMode.Open)
        Dim b(1024) As Byte
        Dim temp As UTF8Encoding = New UTF8Encoding(True)
        Do While fs.Read(b, 0, b.Length) > 0
            Console.WriteLine(temp.GetString(b))
        Loop
        fs.Close()
    End Sub
End Class
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'This is some text in the file.
'
'
'
'
'
'
'
'
'
'
'
'
' </Snippet1>
