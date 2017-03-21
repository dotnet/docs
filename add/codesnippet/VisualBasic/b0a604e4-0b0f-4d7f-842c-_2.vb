    Private Sub Button1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles Button1.Click
        Dim p As Control
        p = CType(sender, Button).Parent
        p.SelectNextControl(ActiveControl, True, True, True, True)
    End Sub