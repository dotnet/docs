' <Snippet1>
Imports System
Imports System.IO

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"

        'Ensure that the file is readonly.
        File.SetAttributes(path, File.GetAttributes(path) Or FileAttributes.ReadOnly)

        'Create the file.
        Dim fs As FileStream = New FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)

        If fs.CanWrite Then
            Console.WriteLine("The stream connected to {0} is writable.", path)
        Else
            Console.WriteLine("The stream connected to {0} is not writable.", path)
        End If
        fs.Close()
    End Sub
End Class
' </Snippet1>
