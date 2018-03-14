' <snippet1>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Using zipToOpen As FileStream = New FileStream("c:\users\exampleuser\release.zip", FileMode.Open)
            Using archive As ZipArchive = New ZipArchive(zipToOpen, ZipArchiveMode.Update)
                Dim readmeEntry As ZipArchiveEntry = archive.CreateEntry("Readme.txt")
                Using writer As StreamWriter = New StreamWriter(readmeEntry.Open())
                    writer.WriteLine("Information about this package.")
                    writer.WriteLine("========================")
                End Using
            End Using
        End Using
    End Sub

End Module
' </snippet1>
