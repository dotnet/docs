'<Snippet1>
Imports System.IO

Class Program
    Public Shared Sub Main(ByVal args As String())
        Dim dirPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Dim diTop As New DirectoryInfo(dirPath)
        Try
            For Each fi In diTop.EnumerateFiles()
                Try
                    ' Display each file over 10 MB;
                    If fi.Length > 10000000 Then
                        Console.WriteLine("{0}" & vbTab & vbTab & "{1}", fi.FullName, fi.Length.ToString("N0"))
                    End If
                Catch unAuthTop As UnauthorizedAccessException
                    Console.WriteLine($"{unAuthTop.Message}")
                End Try
            Next

            For Each di In diTop.EnumerateDirectories("*")
                Try
                    For Each fi In di.EnumerateFiles("*", SearchOption.AllDirectories)
                        Try
                            ' // Display each file over 10 MB;
                            If fi.Length > 10000000 Then
                                Console.WriteLine("{0}" & vbTab &
                                vbTab & "{1}", fi.FullName, fi.Length.ToString("N0"))
                            End If
                        Catch unAuthFile As UnauthorizedAccessException
                            Console.WriteLine($"unAuthFile: {unAuthFile.Message}")
                        End Try
                    Next
                Catch unAuthSubDir As UnauthorizedAccessException
                    Console.WriteLine($"unAuthSubDir: {unAuthSubDir.Message}")
                End Try
            Next
        Catch dirNotFound As DirectoryNotFoundException
            Console.WriteLine($"{dirNotFound.Message}")
        Catch unAuthDir As UnauthorizedAccessException
            Console.WriteLine($"unAuthDir: {unAuthDir.Message}")
        Catch longPath As PathTooLongException
            Console.WriteLine($"{longPath.Message}")
        End Try
    End Sub
End Class
' </Snippet1>
