    Private Sub SetBalloonTip()
        notifyIcon1.Icon = SystemIcons.Exclamation
        notifyIcon1.BalloonTipTitle = "Balloon Tip Title"
        notifyIcon1.BalloonTipText = "Balloon Tip Text."
        notifyIcon1.BalloonTipIcon = ToolTipIcon.Error

    End Sub

    Sub Form1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Click

        notifyIcon1.Visible = True
        notifyIcon1.ShowBalloonTip(30000)

    End Sub