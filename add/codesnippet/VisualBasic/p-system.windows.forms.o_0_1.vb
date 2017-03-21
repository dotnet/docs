
    Private Function OpenFile() As FileStream

        ' Displays an OpenFileDialog and shows the read/only files.

        Dim DlgOpenFile As New OpenFileDialog()
        DlgOpenFile.ShowReadOnly = True

        If DlgOpenFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim path As New String("")

            ' If ReadOnlyChecked is true, uses the OpenFile method to
            ' open the file with read/only access.
            Try
                If (DlgOpenFile.ReadOnlyChecked = True) Then
                    Return DlgOpenFile.OpenFile()
                Else
                    ' Otherwise, opens the file with read/write access.
                    Path = DlgOpenFile.FileName
                    Return New FileStream(Path, System.IO.FileMode.Open, _
                            System.IO.FileAccess.ReadWrite)
                End If
            Catch SecEx As SecurityException
                ' The user lacks appropriate permissions to read files, discover paths, etc.
                MessageBox.Show("Security error. Please contact your administrator for details.\n\n" & _
                    "Error message: " & SecEx.Message * "\n\n" & _
                    "Details (send to Support):\n\n" & SecEx.StackTrace)
            Catch Ex As Exception
                ' Could not load the image - probably related to Windows file system permissions.
                MessageBox.Show("Cannot display the image: " & path.Substring(path.LastIndexOf("\\")) & _
                         ". You may not have permission to read the file, or " & _
                        "it may be corrupt.\n\nReported error: " + ex.Message)
            End Try
        End If

        Return Nothing
    End Function
