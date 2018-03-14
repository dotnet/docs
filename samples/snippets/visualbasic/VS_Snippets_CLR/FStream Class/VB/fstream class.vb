' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"

        ' Delete the file if it exists.
        If File.Exists(path) Then
            File.Delete(path)
        End If

        'Create the file.
        Dim fs As FileStream = File.Create(path)

        AddText(fs, "This is some text")
        AddText(fs, "This is some more text,")
        AddText(fs, Environment.NewLine & "and this is on a new line")
        AddText(fs, Environment.NewLine & Environment.NewLine)
        AddText(fs, "The following is a subset of characters:" & Environment.NewLine)

        Dim i As Integer

        For i = 1 To 120
            AddText(fs, Convert.ToChar(i).ToString())

        Next

        fs.Close()

        'Open the stream and read it back.
        fs = File.OpenRead(path)
        Dim b(1024) As Byte
        Dim temp As UTF8Encoding = New UTF8Encoding(True)

        Do While fs.Read(b, 0, b.Length) > 0
            Console.WriteLine(temp.GetString(b))
        Loop

        fs.Close()
    End Sub

    Private Shared Sub AddText(ByVal fs As FileStream, ByVal value As String)
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(value)
        fs.Write(info, 0, info.Length)
    End Sub
End Class
' </Snippet1>
