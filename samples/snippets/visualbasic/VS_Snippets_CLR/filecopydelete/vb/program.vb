Imports System.IO
Module Module1

    Sub Main()

' <Snippet1>
Dim sourceDir As String = "c:\current"
Dim backupDir As String = "c:\archives\2008"

Try
    Dim picList As String() = Directory.GetFiles(sourceDir, "*.jpg")
    Dim txtList As String() = Directory.GetFiles(sourceDir, "*.txt")

    ' Copy picture files.
    For Each f As String In picList
        'Remove path from the file name.
        Dim fName As String = f.Substring(sourceDir.Length + 1)

        ' Use the Path.Combine method to safely append the file name to the path.
        ' Will overwrite if the destination file already exists.
        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), True)
    Next

    ' Copy text files.
    For Each f As String In txtList

        'Remove path from the file name.
        Dim fName As String = f.Substring(sourceDir.Length + 1)

        Try
            ' Will not overwrite if the destination file already exists.
            File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName))

            ' Catch exception if the file was already copied.
        Catch copyError As IOException
            Console.WriteLine(copyError.Message)
        End Try
    Next

    For Each f As String In txtList
        File.Delete(f)
    Next

    For Each f As String In picList
        File.Delete(f)
    Next

Catch dirNotFound As DirectoryNotFoundException
    Console.WriteLine(dirNotFound.Message)
End Try
' </Snippet1>

    End Sub

End Module