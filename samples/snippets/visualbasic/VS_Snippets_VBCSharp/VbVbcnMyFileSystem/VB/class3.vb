﻿' cae77565-9f78-4e46-8e42-eb2f9f8e1ffd
' Walkthrough: Manipulating Files and Directories in Visual Basic

Public Class Class3
    Inherits Form

    Private WithEvents FolderBrowserDialog1 As New FolderBrowserDialog
    Private WithEvents filesListBox As New ListBox
    Private WithEvents saveCheckBox As New CheckBox
    Private WithEvents browseButton As New Button
    Private WithEvents examineButton As New Button

    ' <snippet111>

    ' This example uses classes from the System.IO namespace.

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the default directory of the folder browser to the current directory.
        FolderBrowserDialog1.SelectedPath =
            System.IO.Directory.GetCurrentDirectory()

        SetEnabled()
    End Sub

    Private Sub browseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseButton.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            ' List files in the folder.
            ListFiles(FolderBrowserDialog1.SelectedPath)
            SetEnabled()
        End If
    End Sub

    Private Sub ListFiles(ByVal folderPath As String)
        filesListBox.Items.Clear()

        Dim fileNames As String() =
            System.IO.Directory.GetFiles(folderPath,
                "*.txt", System.IO.SearchOption.TopDirectoryOnly)

        For Each fileName As String In fileNames
            filesListBox.Items.Add(fileName)
        Next
    End Sub

    Private Sub examineButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles examineButton.Click
        If filesListBox.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a file.")
            Exit Sub
        End If

        ' Obtain the file path from the list box selection.
        Dim filePath = filesListBox.SelectedItem.ToString

        ' Verify that the file was not removed since the
        ' Browse button was clicked.
        If System.IO.File.Exists(filePath) = False Then
            MessageBox.Show("File Not Found: " & filePath)
            Exit Sub
        End If

        ' Obtain file information in a string.
        Dim fileInfoText As String = GetTextForOutput(filePath)

        ' Show the file information.
        MessageBox.Show(fileInfoText)

        If saveCheckBox.Checked = True Then
            ' Place the log file in the same folder as the examined file.
            Dim logFolder As String =
                System.IO.Path.GetDirectoryName(filePath)
            Dim logFilePath = System.IO.Path.Combine(logFolder, "log.txt")

            ' Append text to the log file.
            Dim logText As String = "Logged: " & Date.Now.ToString &
                vbCrLf & fileInfoText & vbCrLf & vbCrLf

            System.IO.File.AppendAllText(logFilePath, logText)
        End If
    End Sub

    Private Function GetTextForOutput(ByVal filePath As String) As String
        ' Verify that the file exists.
        If System.IO.File.Exists(filePath) = False Then
            Throw New Exception("File Not Found: " & filePath)
        End If

        ' Create a new StringBuilder, which is used
        ' to efficiently build strings.
        Dim sb As New System.Text.StringBuilder()

        ' Obtain file information.
        Dim thisFile As New System.IO.FileInfo(filePath)

        ' Add file attributes.
        sb.Append("File: " & thisFile.FullName)
        sb.Append(vbCrLf)
        sb.Append("Modified: " & thisFile.LastWriteTime.ToString)
        sb.Append(vbCrLf)
        sb.Append("Size: " & thisFile.Length.ToString & " bytes")
        sb.Append(vbCrLf)

        ' Open the text file.
        Dim sr As System.IO.StreamReader =
            System.IO.File.OpenText(filePath)

        ' Add the first line from the file.
        If sr.Peek() >= 0 Then
            sb.Append("First Line: " & sr.ReadLine())
        End If
        sr.Close()

        Return sb.ToString
    End Function

    Private Sub filesListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filesListBox.SelectedIndexChanged
        SetEnabled()
    End Sub

    Private Sub SetEnabled()
        Dim anySelected As Boolean =
            (filesListBox.SelectedItem IsNot Nothing)

        examineButton.Enabled = anySelected
        saveCheckBox.Enabled = anySelected
    End Sub
    ' </snippet111>


End Class
