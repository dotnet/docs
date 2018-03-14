    Private Sub Button2_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles Button2.Click

        Dim RetVal As Boolean = MoveFile("c:\tmp\Test.txt", "c:\Test.txt")
        If RetVal = True Then
            MsgBox("The file was moved successfully.")
        Else
            MsgBox("The file could not be moved.")
        End If
    End Sub