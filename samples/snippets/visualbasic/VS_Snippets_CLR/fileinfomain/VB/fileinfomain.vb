' <snippet1>
Imports System
Imports System.IO

Public Class FileInfoMainTest

    Public Shared Sub Main()
        ' Open an existing file, or create a new one.
        Dim fi As New FileInfo("temp.txt")
        ' Create a writer, ready to add entries to the file.
        Dim sw As StreamWriter = fi.AppendText()
        sw.WriteLine("This is a new entry to add to the file")
        sw.WriteLine("This is yet another line to add...")
        sw.Flush()
        sw.Close()
        Dim sr As New StreamReader(fi.OpenRead())
        ' Get the information out of the file and display it.
        While sr.Peek() <> -1
            Console.WriteLine(sr.ReadLine())
        End While
    End Sub 'Main
End Class 'FileInfoMainTest
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'This is a new entry to add to the file
'This is yet another line to add...
' </snippet1>