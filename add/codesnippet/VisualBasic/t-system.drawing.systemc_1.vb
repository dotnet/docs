    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        If (Color.op_Equality(Me.BackColor, SystemColors.ControlDark)) Then
            Me.BackColor = SystemColors.Control
        End If
    End Sub