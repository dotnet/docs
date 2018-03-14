' <Snippet1>
Imports System
Imports System.IO



Module DirectoryFileCount

    Dim files As Long = 0
    Dim directories As Long = 0



    Sub Main()
        Try
            Console.WriteLine("Enter the path to a directory:")

            Dim directory As String = Console.ReadLine()

            ' Create a new DirectoryInfo object.
            Dim dir As New DirectoryInfo(directory)

            If Not dir.Exists Then
                Throw New DirectoryNotFoundException("The directory does not exist.")
            End If

            ' Call the GetFileSystemInfos method.
            Dim infos As FileSystemInfo() = dir.GetFileSystemInfos()

            Console.WriteLine("Working...")

            ' Pass the result to the ListDirectoriesAndFiles
            ' method defined below.
            ListDirectoriesAndFiles(infos)

            ' Display the results to the console. 
            Console.WriteLine("Directories: {0}", directories)
            Console.WriteLine("Files: {0}", files)

        Catch e As Exception
            Console.WriteLine(e.Message)
        Finally

            Console.ReadLine()
        End Try

    End Sub


    Sub ListDirectoriesAndFiles(ByVal FSInfo() As FileSystemInfo)
        ' Check the FSInfo parameter.
        If FSInfo Is Nothing Then
            Throw New ArgumentNullException("FSInfo")
        End If

        ' Iterate through each item.
        Dim i As FileSystemInfo
        For Each i In FSInfo
            ' Check to see if this is a DirectoryInfo object.
            If TypeOf i Is DirectoryInfo Then
                ' Add one to the directory count.
                directories += 1

                ' Cast the object to a DirectoryInfo object.
                Dim dInfo As DirectoryInfo = CType(i, DirectoryInfo)

                ' Iterate through all sub-directories.
                ListDirectoriesAndFiles(dInfo.GetFileSystemInfos())
                ' Check to see if this is a FileInfo object.
            ElseIf TypeOf i Is FileInfo Then
                ' Add one to the file count.
                files += 1
            End If
        Next i

    End Sub
End Module
' </Snippet1>