    Sub Form1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles Me.DoubleClick

        notifyIcon1.Visible = True
        notifyIcon1.ShowBalloonTip(20000, "Information", "This is the text", _
                ToolTipIcon.Info)
    End Sub