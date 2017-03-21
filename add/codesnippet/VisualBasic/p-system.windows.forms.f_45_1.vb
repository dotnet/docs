    Private Sub flowTopDownBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowTopDownBtn.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown

    End Sub

    Private Sub flowBottomUpBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowBottomUpBtn.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.BottomUp

    End Sub

    Private Sub flowLeftToRight_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowLeftToRight.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight

    End Sub

    Private Sub flowRightToLeftBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles flowRightToLeftBtn.CheckedChanged

        Me.FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft

    End Sub