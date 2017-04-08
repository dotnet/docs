' <Snippet1>
Imports System
Imports System.IO

Public Class Test

    Public Shared Sub Main()
        Dim fi As FileInfo = New FileInfo("c:\temp\MyTest.txt")
        Dim sw As StreamWriter

        ' This text is added only once to the file.
        If fi.Exists = False Then
            'Create a file to write to.
            sw = fi.CreateText()
            sw.WriteLine("Hello")
            sw.WriteLine("And")
            sw.WriteLine("Welcome")
            sw.Flush()
            sw.Close()
        End If

        ' This text will always be added, making the file longer over time
        ' if it is not deleted.
        sw = fi.AppendText()

        sw.WriteLine("This")
        sw.WriteLine("is Extra")
        sw.WriteLine("Text")
        sw.Flush()
        sw.Close()

        'Open the file to read from.
        Dim sr As StreamReader = fi.OpenText()
        Dim s As String
        Do While sr.Peek() >= 0
            s = sr.ReadLine()
            Console.WriteLine(s)
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
'This
'is Extra
'Text

'When you run this application a second time, you will see the following output:
'
'Hello
'And
'Welcome
'This
'is Extra
'Text
'This
'is Extra
'Text
'</Snippet1>
