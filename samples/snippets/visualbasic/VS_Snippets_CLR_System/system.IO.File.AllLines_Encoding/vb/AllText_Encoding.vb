'<snippet00>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"
        Dim sw As StreamWriter

        ' This text is added only once to the file.
        If File.Exists(path) = False Then

            ' Create a file to write to.
            Dim createText() As String = {"Hello", "And", "Welcome"}
            File.WriteAllLines(path, createText, Encoding.UTF8)
        End If

        ' This text is always added, making the file longer over time
        ' if it is not deleted.
        Dim appendText As String = "This is extra text" + Environment.NewLine
        File.AppendAllText(path, appendText, Encoding.UTF8)

        ' Open the file to read from.
        Dim readText() As String = File.ReadAllLines(path, Encoding.UTF8)
        Dim s As String
        For Each s In readText
            Console.WriteLine(s)
        Next
    End Sub
End Class
'</snippet00>