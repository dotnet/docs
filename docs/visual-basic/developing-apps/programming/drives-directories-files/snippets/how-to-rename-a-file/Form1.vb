Imports System.IO

Public Class Form1

    Sub RenameFileNameMy()
        '<MyRename>
        Dim myDocsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        Dim filePath = System.IO.Path.Combine(myDocsFolder, "TextFile.txt")

        My.Computer.FileSystem.RenameFile(filePath, "NewName.txt")
        '</MyRename>
    End Sub

    Sub RenameFileNameBCL()

        '<BCLRename>
        Dim myDocsFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        Dim filePathSource = System.IO.Path.Combine(myDocsFolder, "TextFile.txt")
        Dim filePathTarget = System.IO.Path.Combine(myDocsFolder, "NewName.txt")

        System.IO.File.Move(filePathSource, filePathTarget)
        '</BCLRename>

    End Sub

End Class
