'<Snippet1>
Imports System
Imports System.IO

Class Program
    Public Shared Sub Main(ByVal args As String())
        Dim diTop As New DirectoryInfo("d:\")
        Try
            For Each fi In diTop.EnumerateFiles()
                Try
                    ' Display each file over 10 MB;
                    If fi.Length > 10000000 Then
                        Console.WriteLine("{0}" & vbTab & vbTab & "{1}", fi.FullName, fi.Length.ToString("N0"))
                    End If
                Catch UnAuthTop As UnauthorizedAccessException
                    Console.WriteLine("{0}", UnAuthTop.Message)
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
                        Catch UnAuthFile As UnauthorizedAccessException
                            Console.WriteLine("UnAuthFile: {0}", UnAuthFile.Message)
                        End Try
                    Next
                Catch UnAuthSubDir As UnauthorizedAccessException
                    Console.WriteLine("UnAuthSubDir: {0}", UnAuthSubDir.Message)
                End Try
            Next
        Catch DirNotFound As DirectoryNotFoundException
            Console.WriteLine("{0}", DirNotFound.Message)
        Catch UnAuthDir As UnauthorizedAccessException
            Console.WriteLine("UnAuthDir: {0}", UnAuthDir.Message)
        Catch LongPath As PathTooLongException
            Console.WriteLine("{0}", LongPath.Message)
        End Try
    End Sub
End Class
' </Snippet1>