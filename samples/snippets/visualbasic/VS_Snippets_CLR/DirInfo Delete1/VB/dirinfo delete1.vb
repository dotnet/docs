' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        ' Specify the directories you want to manipulate.
        Dim di1 As DirectoryInfo = New DirectoryInfo("c:\MyDir")

        Try
            ' Create the directories.
            di1.Create()
            di1.CreateSubdirectory("temp")

            'This operation will not be allowed because there are subdirectories.
            Console.WriteLine("I am about to attempt to delete {0}", di1.Name)
            di1.Delete()
            Console.WriteLine("The Delete operation was successful, which was unexpected.")

        Catch
            Console.WriteLine("The Delete operation was unsuccessful, as expected.")
        End Try
    End Sub
End Class
' </Snippet1>
