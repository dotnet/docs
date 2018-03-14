' <snippet1>
Imports System
Imports System.IO

Module Module1
    Public Sub CopyDirectory(ByVal SourceDirectory As String, ByVal TargetDirectory As String)
        Dim source As DirectoryInfo = New DirectoryInfo(SourceDirectory)
        Dim target As DirectoryInfo = New DirectoryInfo(TargetDirectory)

        'Determine whether the source directory exists.
        If (source.Exists = False) Then
            Return
        End If
        If (target.Exists = False) Then
            target.Create()
        End If

        'Copy files.
        Dim sourceFiles As FileInfo() = source.GetFiles()
        Dim i, j As Integer
        For i = 0 To sourceFiles.Length - 1
            File.Copy(sourceFiles(i).FullName, target.FullName + "\\" + sourceFiles(i).Name, True)
        Next i

        'Copy directories.
        Dim sourceDirectories As DirectoryInfo() = source.GetDirectories()
        For j = 0 To sourceDirectories.Length - 1
            CopyDirectory(sourceDirectories(j).FullName, target.FullName + "\\" + sourceDirectories(j).Name)
        Next j
        source = Nothing
        target = Nothing
    End Sub
    Sub Main()
        CopyDirectory("D:\\Tools", "D:\\NewTools")
    End Sub
End Module
' </snippet1>

