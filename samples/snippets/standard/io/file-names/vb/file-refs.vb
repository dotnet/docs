Imports System.IO

Module Program
    Sub Main()
        Dim filenames() As String = {
                "c:\temp\test-file.txt",
                "\\127.0.0.1\c$\temp\test-file.txt",
                "\\LOCALHOST\c$\temp\test-file.txt",
                "\\.\c:\temp\test-file.txt",
                "\\?\c:\temp\test-file.txt",
                "\\.\UNC\LOCALHOST\c$\temp\test-file.txt"}

        For Each filename In filenames
            Dim fi As New FileInfo(filename)
            Console.WriteLine($"file {fi.Name}: {fi.Length:N0} bytes")
        Next
    End Sub
End Module
