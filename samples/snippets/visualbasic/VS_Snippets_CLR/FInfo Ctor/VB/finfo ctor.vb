' <Snippet1>
Imports System
Imports System.IO

Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"
        Dim fi1 As FileInfo = New FileInfo(path)

        If fi1.Exists = False Then
            'Create a file to write to.
            Dim sw As StreamWriter = fi1.CreateText()
            sw.WriteLine("Hello")
            sw.WriteLine("And")
            sw.WriteLine("Welcome")
            sw.Flush()
            sw.Close()
        End If

        'Open the file to read from.
        Dim sr As StreamReader = fi1.OpenText()

        Do While sr.Peek() >= 0
            Console.WriteLine(sr.ReadLine())
        Loop

        Try
            Dim path2 As String = path + "temp"
            Dim fi2 As FileInfo = New FileInfo(path2)

            'Ensure that the target does not exist.
            fi2.Delete()

            'Copy the file.
            fi1.CopyTo(path2)
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
'Hello
'And
'Welcome
'c:\MyTest.txt was copied to c:\MyTest.txttemp.
'c:\MyTest.txttemp was successfully deleted.
' </Snippet1>
