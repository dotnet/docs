    ' Draws a node.
    Private Sub myTreeView_DrawNode(ByVal sender As Object, _
        ByVal e As DrawTreeNodeEventArgs) Handles myTreeView.DrawNode

        ' Draw the background and node text for a selected node.
        If (e.State And TreeNodeStates.Selected) <> 0 Then

            ' Draw the background of the selected node. The NodeBounds
            ' method makes the highlight rectangle large enough to
            ' include the text of a node tag, if one is present.
            e.Graphics.FillRectangle(Brushes.Green, NodeBounds(e.Node))

            ' Retrieve the node font. If the node font has not been set,
            ' use the TreeView font.
            Dim nodeFont As Font = e.Node.NodeFont
            If nodeFont Is Nothing Then
                nodeFont = CType(sender, TreeView).Font
            End If

            ' Draw the node text.
            e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, _
                e.Bounds.Left - 2, e.Bounds.Top)

        ' Use the default background and node text.
        Else
            e.DrawDefault = True
        End If

        ' If a node tag is present, draw its string representation 
        ' to the right of the label text.
        If (e.Node.Tag IsNot Nothing) Then
            e.Graphics.DrawString(e.Node.Tag.ToString(), tagFont, _
                Brushes.Yellow, e.Bounds.Right + 2, e.Bounds.Top)
        End If

        ' If the node has focus, draw the focus rectangle large, making
        ' it large enough to include the text of the node tag, if present.
        If (e.State And TreeNodeStates.Focused) <> 0 Then
            Dim focusPen As New Pen(Color.Black)
            Try
                focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
                Dim focusBounds As Rectangle = NodeBounds(e.Node)
                focusBounds.Size = New Size(focusBounds.Width - 1, _
                    focusBounds.Height - 1)
                e.Graphics.DrawRectangle(focusPen, focusBounds)
            Finally
                focusPen.Dispose()
            End Try
        End If

    End Sub 'myTreeView_DrawNode