'<SNIPPET1>
Imports System
Imports System.IO

Module FileExample

    Sub Main()
        Try
            Dim OriginalFile As String = "test.xml"
            Dim FileToReplace As String = "test2.xml"
            Dim BackUpOfFileToReplace As String = "test2.xml.bac"

            Console.WriteLine("Move the contents of " + OriginalFile + " into " + FileToReplace + ", delete " + OriginalFile + ", and create a backup of " + FileToReplace + ".")

            ' Replace the file.
            ReplaceFile(OriginalFile, FileToReplace, BackUpOfFileToReplace)

            Console.WriteLine("Done")
        Catch e As Exception
            Console.WriteLine(e)
        End Try

        Console.ReadLine()

    End Sub

    ' Move a file into another file, delete the original, and create a backup of the replaced file.
    Sub ReplaceFile(ByVal FileToMoveAndDelete As String, ByVal FileToReplace As String, ByVal BackupOfFileToReplace As String)

        ' Replace the file.
        File.Replace(FileToMoveAndDelete, FileToReplace, BackupOfFileToReplace, False)

    End Sub
End Module
'</SNIPPET1>