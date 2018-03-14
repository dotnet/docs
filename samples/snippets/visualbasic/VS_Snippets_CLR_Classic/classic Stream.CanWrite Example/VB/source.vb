' <Snippet1>
Imports System
Imports System.IO

Class TestRW    

    Public Shared Sub Main()
        Dim fs As New FileStream("MyFile.txt", FileMode.OpenOrCreate, _
           FileAccess.Write)
        If fs.CanRead And fs.CanWrite Then
            Console.WriteLine("MyFile.txt can be both written to and read from.")
        Else
            If fs.CanWrite Then
                Console.WriteLine("MyFile.txt is writable.")
            End If
        End If
    End Sub
End Class

'This code outputs "MyFile.txt is writable."
'To get the output message "MyFile.txt can be both written to and read from.",
'change the FileAccess parameter to ReadWrite in the FileStream constructor.
' </Snippet1>