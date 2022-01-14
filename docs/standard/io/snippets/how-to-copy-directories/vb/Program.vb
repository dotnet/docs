Imports System.IO

Module Program
    Sub Main(args As String())
        CopyDirectory(".\", ".\copytest", True)
    End Sub

    Public Sub CopyDirectory(sourceDir As String, destinationDir As String, recursive As Boolean)

        ' Get information about the source directory
        Dim dir As New DirectoryInfo(sourceDir)

        ' Check if the source directory exists
        If Not dir.Exists Then
            Throw New DirectoryNotFoundException($"Source directory not found: {dir.FullName}")
        End If

        ' Cache directories before we start copying
        Dim dirs As DirectoryInfo() = dir.GetDirectories()

        ' Create the destination directory
        Directory.CreateDirectory(destinationDir)

        ' Get the files in the source directory and copy to the destination directory
        For Each file As FileInfo In dir.GetFiles()
            Dim targetFilePath As String = Path.Combine(destinationDir, file.Name)
            file.CopyTo(targetFilePath)
        Next

        ' If recursive and copying subdirectories, recursively call this method
        If recursive Then
            For Each subDir As DirectoryInfo In dirs
                Dim newDestinationDir As String = Path.Combine(destinationDir, subDir.Name)
                CopyDirectory(subDir.FullName, newDestinationDir, True)
            Next
        End If

    End Sub
End Module
