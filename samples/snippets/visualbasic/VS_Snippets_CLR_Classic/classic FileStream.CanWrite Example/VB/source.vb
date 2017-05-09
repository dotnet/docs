' <Snippet1>
Imports System
Imports System.IO

Class TestRW
    Public Shared Sub Main()
        Dim fs As New FileStream("MyFile.txt", FileMode.OpenOrCreate, FileAccess.Write)

        If fs.CanRead And fs.CanWrite Then
            Console.WriteLine("MyFile.txt can be both written to and read from.")
        ElseIf fs.CanWrite Then
            Console.WriteLine("MyFile.txt is writable.")
        End If
    End Sub
End Class
' </Snippet1>