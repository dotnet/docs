' <snippet3>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim startPath As String = "c:\example\start"
        Dim zipPath As String = "c:\example\result.zip"

        ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, True)
    End Sub

End Module
' </snippet3>