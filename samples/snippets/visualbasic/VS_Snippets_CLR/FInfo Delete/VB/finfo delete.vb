' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\MyTest.txt"
        Dim fi As FileInfo = New FileInfo(path)

        Try
            Dim sw As StreamWriter = fi.CreateText()
            sw.Close()
            Dim path2 As String = path + "temp"
            Dim fi2 As FileInfo = New FileInfo(path2)

            'Ensure that the target does not exist.
            fi2.Delete()

            'Copy the file.
            fi.CopyTo(path2)
            Console.WriteLine("{0} was copied to {1}.", path, path2)

            'Delete the newly created file.
            fi2.Delete()
            Console.WriteLine("{0} was successfully deleted.", path2)

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
'This code produces output similar to the following; 
'results may vary based on the computer/file structure/etc.:
'
'c:\MyTest.txt was copied to c:\MyTest.txttemp.
'c:\MyTest.txttemp was successfully deleted.
' </Snippet1>
