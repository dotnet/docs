' <snippet1>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim startPath As String = "c:\example\start"
        Dim zipPath As String = "c:\example\result.zip"
        Dim extractPath As String = "c:\example\extract"

        ZipFile.CreateFromDirectory(startPath, zipPath)

        ZipFile.ExtractToDirectory(zipPath, extractPath)
    End Sub

End Module
' </snippet1>
