    Private Sub wrapContentsCheckBox_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles wrapContentsCheckBox.CheckedChanged

        Me.FlowLayoutPanel1.WrapContents = Me.wrapContentsCheckBox.Checked

    End Sub