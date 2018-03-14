Public Class Form1

    ' <snippet1>
    Private Sub Form1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles MyBase.Click
        Dim ctl As Control
        ctl = CType(sender, Control)
        ctl.SelectNextControl(ActiveControl, True, True, True, True)
    End Sub
    ' </snippet1>

    ' <snippet2>
    Private Sub Button1_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles Button1.Click
        Dim p As Control
        p = CType(sender, Button).Parent
        p.SelectNextControl(ActiveControl, True, True, True, True)
    End Sub
    ' </snippet2>

End Class
