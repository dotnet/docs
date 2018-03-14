'<snippet1>
Imports System
Imports System.IO

Class DirectoryCopyExample

    Shared Sub Main()
        ' Copy from the current directory, include subdirectories.
        DirectoryCopy(".", ".\\temp", True)
    End Sub

    Private Shared Sub DirectoryCopy( _
        ByVal sourceDirName As String, _
        ByVal destDirName As String, _
        ByVal copySubDirs As Boolean)

        ' Get the subdirectories for the specified directory.
        Dim dir As DirectoryInfo = New DirectoryInfo(sourceDirName)

        If Not dir.Exists Then
            Throw New DirectoryNotFoundException( _
                "Source directory does not exist or could not be found: " _
                + sourceDirName)
        End If

        Dim dirs As DirectoryInfo() = dir.GetDirectories()
        ' If the destination directory doesn't exist, create it.
        If Not Directory.Exists(destDirName) Then
            Directory.CreateDirectory(destDirName)
        End If
        ' Get the files in the directory and copy them to the new location.
        Dim files As FileInfo() = dir.GetFiles()
        For Each file In files
            Dim temppath As String = Path.Combine(destDirName, file.Name)
            file.CopyTo(temppath, False)
        Next file

        ' If copying subdirectories, copy them and their contents to new location.
        If copySubDirs Then
            For Each subdir In dirs
                Dim temppath As String = Path.Combine(destDirName, subdir.Name)
                DirectoryCopy(subdir.FullName, temppath, copySubDirs)
            Next subdir
        End If
    End Sub
End Class
'</snippet1>