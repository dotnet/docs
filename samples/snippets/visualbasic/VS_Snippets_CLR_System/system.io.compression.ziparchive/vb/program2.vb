' <snippet2>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim zipPath As String = "c:\example\start.zip"

        Console.WriteLine("Provide path where to extract the zip file:")
        Dim extractPath As String = Console.ReadLine()

        ' Normalizes the path.
        extractPath = Path.GetFullPath(extractPath)

        ' Ensures that the last character on the extraction path
        ' is the directory separator char. 
        ' Without this, a malicious zip file could try to traverse outside of the expected
        ' extraction path.
        If Not extractPath.EndsWith(Path.DirectorySeparatorChar) Then
            extractPath += Path.DirectorySeparatorChar
        End If

        Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
            For Each entry As ZipArchiveEntry In archive.Entries
                If entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) Then

                    ' Gets the full path to ensure that relative segments are removed.
                    Dim destinationPath As String = Path.GetFullPath(Path.Combine(extractPath, entry.FullName))

                    ' Ordinal match is safest, case-sensitive volumes can be mounted within volumes that
                    ' are case-insensitive.
                    If destinationPath.StartsWith(extractPath, StringComparison.Ordinal) Then
                        entry.ExtractToFile(destinationPath, true)
                    End If

                End If
            Next
        End Using
    End Sub

End Module
' </snippet2>
