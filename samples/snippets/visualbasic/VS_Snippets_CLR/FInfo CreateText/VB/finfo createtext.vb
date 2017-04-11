' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\MyTest.txt"
        Dim fi As FileInfo = New FileInfo(path)

        If fi.Exists = False Then
            'Create a file to write to.
            Dim sw As StreamWriter = fi.CreateText()
            sw.WriteLine("Hello")
            sw.WriteLine("And")
            sw.WriteLine("Welcome")
            sw.Flush()
            sw.Close()
        End If

        'Open the file to read from.
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
'Hello
'And
'Welcome
' </Snippet1>
