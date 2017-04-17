' <snippet1>
Imports System
Imports System.IO

Public Class AppendTextTest
    Public Shared Sub Main()
        Dim fi As New FileInfo("temp.txt")
        Dim sw As StreamWriter = fi.AppendText()
        sw.WriteLine("Add as many lines as you like...")
        sw.WriteLine("Add another line to the output...")
        sw.Flush()
        sw.Close()
        Dim sr As New StreamReader(fi.OpenRead())
        ' Get the information out of the file and display it.
        ' Remember that the file might have other lines if it already existed.
        While sr.Peek() <> -1
            Console.WriteLine(sr.ReadLine())
        End While
    End Sub 'Main
End Class 'AppendTextTest
'This code produces output similar to the following;
'results may vary based on the computer/file structure/etc.:
'Add as many lines as you like...
'Add another line to the output...
' </snippet1>