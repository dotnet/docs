    Private Sub HandleMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
        Handles Me.MouseDown, treeView1.MouseDown
        Dim info As TreeViewHitTestInfo = treeView1.HitTest(e.X, e.Y)
        If (info IsNot Nothing) Then
            MessageBox.Show("Hit the " + info.Location.ToString())
        End If

    End Sub