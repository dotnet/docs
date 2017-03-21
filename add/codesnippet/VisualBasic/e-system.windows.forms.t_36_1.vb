    Friend WithEvents boldButton As ToolStripButton

    Private Sub InitializeBoldButton()
        boldButton = New ToolStripButton()
        boldButton.Text = "B"
        boldButton.CheckOnClick = True
        toolStrip1.Items.Add(boldButton)

    End Sub

    Private Sub boldButton_CheckedChanged(ByVal sender As [Object], _
        ByVal e As EventArgs) Handles boldButton.CheckedChanged
        If boldButton.Checked Then
            Me.Font = New Font(Me.Font, FontStyle.Bold)
        Else
            Me.Font = New Font(Me.Font, FontStyle.Regular)
        End If

    End Sub
