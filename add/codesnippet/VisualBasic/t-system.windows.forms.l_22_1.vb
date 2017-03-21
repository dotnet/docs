    Private Sub HandleMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) _
            Handles Me.MouseDown, listView1.MouseDown

        Dim info As ListViewHitTestInfo = listView1.HitTest(e.X, e.Y)
        MessageBox.Show(info.Location.ToString())

    End Sub