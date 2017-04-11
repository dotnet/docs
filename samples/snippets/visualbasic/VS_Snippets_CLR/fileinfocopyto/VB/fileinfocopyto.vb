' <snippet1>
Imports System
Imports System.IO

Public Class CopyToTest
    Public Shared Sub Main()
        ' Create a reference to a file, which might or might not exist.
        ' If it does not exist, it is not yet created.
        Dim fi As New FileInfo("temp.txt")
        ' Create a writer, ready to add entries to the file.
        Dim sw As StreamWriter = fi.AppendText()
        sw.WriteLine("Add as many lines as you like...")
        sw.WriteLine("Add another line to the output...")
        sw.Flush()
        sw.Close()
        ' Get the information out of the file and display it.
        Dim sr As New StreamReader(fi.OpenRead())
        Console.WriteLine("This is the information in the first file:")
        While sr.Peek() <> -1
            Console.WriteLine(sr.ReadLine())
        End While
        ' Copy this file to another file. The true parameter specifies 
        ' that the file will be overwritten if it already exists.
        Dim newfi As FileInfo = fi.CopyTo("newTemp.txt", True)
        ' Get the information out of the new file and display it.
        sr = New StreamReader(newfi.OpenRead())
        Console.WriteLine("{0}This is the information in the second file:", Environment.NewLine)
        While sr.Peek() <> -1
            Console.WriteLine(sr.ReadLine())
        End While
    End Sub 'Main
End Class 'CopyToTest
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'This is the information in the first file:
'Add as many lines as you like...
'Add another line to the output...
'
'This is the information in the second file:
'Add as many lines as you like...
'Add another line to the output...
'
' </snippet1>