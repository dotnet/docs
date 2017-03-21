    Private Sub Form1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles MyBase.Click
        Dim ctl As Control
        ctl = CType(sender, Control)
        ctl.SelectNextControl(ActiveControl, True, True, True, True)
    End Sub