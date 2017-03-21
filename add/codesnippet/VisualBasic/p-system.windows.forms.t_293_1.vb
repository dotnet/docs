    Friend WithEvents changeDirectionButton As ToolStripButton

    Private Sub InitializeMovingToolStrip()
        changeDirectionButton = New ToolStripButton()

        movingToolStrip.AutoSize = True
        movingToolStrip.RenderMode = ToolStripRenderMode.System

        changeDirectionButton.TextDirection = ToolStripTextDirection.Vertical270
        changeDirectionButton.Overflow = ToolStripItemOverflow.Never
        changeDirectionButton.Text = "Change Alignment"
        movingToolStrip.Items.Add(changeDirectionButton)
    End Sub


    Public Sub changeDirectionButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles changeDirectionButton.Click

        Dim item As ToolStripItem = CType(sender, ToolStripItem)

        If item.TextDirection = ToolStripTextDirection.Vertical270 _
            OrElse item.TextDirection = ToolStripTextDirection.Vertical90 Then

            item.TextDirection = ToolStripTextDirection.Horizontal
            movingToolStrip.Dock = System.Windows.Forms.DockStyle.Top
        Else
            item.TextDirection = ToolStripTextDirection.Vertical270
            movingToolStrip.Dock = System.Windows.Forms.DockStyle.Left
        End If

    End Sub
