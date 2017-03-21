Public Class myForm
    Inherits Form

    Protected Overrides Sub OnClosed(ByVal e As EventArgs)
        MessageBox.Show("The form is now closing.", "Close Warning", _
            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        MyBase.OnClosed(e)
    End Sub

    Public Sub New()
        MyBase.New()
    End Sub

End Class
