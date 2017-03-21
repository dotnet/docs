    Private Sub borderStyleOutsetRadioBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles borderStyleOutsetRadioBtn.CheckedChanged

        Me.TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset

    End Sub

    Private Sub borderStyleNoneRadioBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles borderStyleNoneRadioBtn.CheckedChanged

        Me.TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.None

    End Sub

    Private Sub borderStyleInsetRadioBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles borderStyleInsetRadioBtn.CheckedChanged

        Me.TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset

    End Sub