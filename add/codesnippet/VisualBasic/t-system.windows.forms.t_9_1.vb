    Private Sub growStyleNoneBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles growStyleNoneBtn.CheckedChanged

        Me.tlpGrowStyle = TableLayoutPanelGrowStyle.FixedSize

    End Sub

    Private Sub growStyleAddRowBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles growStyleAddRowBtn.CheckedChanged

        Me.tlpGrowStyle = TableLayoutPanelGrowStyle.AddRows

    End Sub

    Private Sub growStyleAddColumnBtn_CheckedChanged( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles growStyleAddColumnBtn.CheckedChanged

        Me.tlpGrowStyle = TableLayoutPanelGrowStyle.AddColumns

    End Sub

    Private Sub testGrowStyleBtn_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles testGrowStyleBtn.Click

        Me.TableLayoutPanel1.GrowStyle = Me.tlpGrowStyle

        Try

            Me.TableLayoutPanel1.Controls.Add(New Button())

        Catch ex As ArgumentException

            Trace.WriteLine(ex.Message)

        End Try

    End Sub