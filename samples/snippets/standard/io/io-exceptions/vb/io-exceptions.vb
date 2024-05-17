Imports System.IO

Module Program
    Sub Main(args As String())
        Dim sw = OpenStream(".\textfile.txt")
        If sw Is Nothing Then Return

        sw.WriteLine("This is the first line.")
        sw.WriteLine("This is the second line.")
        sw.Close()
    End Sub

    Function OpenStream(path As String) As StreamWriter
        If path Is Nothing Then
            Console.WriteLine("You did not supply a file path.")
            Return Nothing
        End If

        Try
            Dim fs As New FileStream(path, FileMode.CreateNew)
            Return New StreamWriter(fs)
        Catch e As FileNotFoundException
            Console.WriteLine("The file or directory cannot be found.")
        Catch e As DirectoryNotFoundException
            Console.WriteLine("The file or directory cannot be found.")
        Catch e As DriveNotFoundException
            Console.WriteLine("The drive specified in 'path' is invalid.")
        Catch e As PathTooLongException
            Console.WriteLine("'path' exceeds the maximum supported path length.")
        Catch e As UnauthorizedAccessException
            Console.WriteLine("You do not have permission to create this file.")
        Catch e As IOException When (e.HResult And &h0000FFFF) = 32
            Console.WriteLine("There is a sharing violation.")
        Catch e As IOException When (e.HResult And &h0000FFFF) = 80
            Console.WriteLine("The file already exists.")
        Catch e As IOException
            Console.WriteLine($"An exception occurred:{vbCrLf}Error code: " +
                              $"{e.HResult And &h0000FFFF}{vbCrLf}Message: {e.Message}")
        End Try
        Return Nothing
    End Function
End Module
