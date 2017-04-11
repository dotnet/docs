' <snippet1>
Imports System.IO
Imports System.Text

Module Module1
    Sub Main()
        Dim attributes = File.GetAttributes("c:/Temp/testfile.txt")
        If ((attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly) Then
            Console.WriteLine("read-only file")
        Else
            Console.WriteLine("not read-only file")
        End If
    End Sub
End Module
' </snippet1>