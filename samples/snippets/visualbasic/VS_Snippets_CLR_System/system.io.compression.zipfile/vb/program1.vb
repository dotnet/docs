' <snippet1>
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim startPath As String = ".\start"
        Dim zipPath As String = ".\result.zip"
        Dim extractPath As String = ".\extract"

        ZipFile.CreateFromDirectory(startPath, zipPath)

        ZipFile.ExtractToDirectory(zipPath, extractPath)
    End Sub

End Module
' </snippet1>
