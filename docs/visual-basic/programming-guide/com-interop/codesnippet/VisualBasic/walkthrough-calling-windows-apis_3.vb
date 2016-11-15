    Private Sub Button1_Click(ByVal sender As System.Object,
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Stores the return value.
        Dim RetVal As Integer
        RetVal = MBox(0, "Declare DLL Test", "Windows API MessageBox",
            MB_ICONQUESTION Or MB_YESNO)

        ' Check the return value.
        If RetVal = IDYES Then
            MsgBox("You chose Yes")
        Else
            MsgBox("You chose No")
        End If
    End Sub