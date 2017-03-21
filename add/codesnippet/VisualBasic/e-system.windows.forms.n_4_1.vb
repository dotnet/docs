    Sub notifyIcon1_BalloonTipClosed(ByVal sender As Object, _
        ByVal e As EventArgs) Handles notifyIcon1.BalloonTipClosed

        MessageBox.Show("The balloon tip is now closed.")

    End Sub