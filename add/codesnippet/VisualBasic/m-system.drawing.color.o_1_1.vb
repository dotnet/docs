    Private Sub Button2_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button2.Click

        If (Color.op_Inequality(Me.BackColor, SystemColors.ControlDark)) Then
            Me.BackColor = SystemColors.ControlDark
        End If
        If Not (Me.Font.Bold) Then
            Me.Font = New Font(Me.Font, FontStyle.Bold)
        End If
    End Sub