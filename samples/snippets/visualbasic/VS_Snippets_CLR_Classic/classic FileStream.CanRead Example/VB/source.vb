' <Snippet1>
Imports System
Imports System.IO

Class TestRW

    Public Shared Sub Main()
        Dim fs As New FileStream("MyFile.txt", FileMode.OpenOrCreate, FileAccess.Read)
        If fs.CanRead And fs.CanWrite Then
            Console.WriteLine("MyFile.txt can be both written to and read from.")
        Else
            If fs.CanRead Then
                Console.WriteLine("MyFile.txt is not writable.")
            End If
        End If
    End Sub
End Class
' </Snippet1>