'<SNIPPET1>
Imports System
Imports System.IO

Module FileExample

    Sub Main()
        Try
            ' originalFile and fileToReplace must contain the path to files that already exist in the  
            ' file system. backUpOfFileToReplace is created during the execution of the Replace method.

            Dim originalFile As String = "test.xml"
            Dim fileToReplace As String = "test2.xml"
            Dim backUpOfFileToReplace As String = "test2.xml.bak"

            If (File.Exists(originalFile) And (File.Exists(fileToReplace))) Then
                Console.WriteLine("Move the contents of " + originalFile + " into " + fileToReplace + ", delete " + originalFile + ", and create a backup of " + fileToReplace + ".")

                ' Replace the file.
                ReplaceFile(originalFile, fileToReplace, backUpOfFileToReplace)

                Console.WriteLine("Done")

            Else
                Console.WriteLine("Either the file {0} or {1} doesn't " + "exist.", originalFile, fileToReplace)
            End If
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Console.ReadLine()

    End Sub

    ' Move a file into another file, delete the original, and create a backup of the replaced file.
    Sub ReplaceFile(ByVal fileToMoveAndDelete As String, ByVal fileToReplace As String, ByVal backupOfFileToReplace As String)
        ' Create a new FileInfo object.
        Dim fInfo As New FileInfo(fileToMoveAndDelete)

        ' Replace the file.
        fInfo.Replace(fileToReplace, backupOfFileToReplace, False)

    End Sub
End Module

' Move the contents of test.txt into test2.txt, delete test.txt, and 
' create a backup of test2.txt.
' Done

'</SNIPPET1>