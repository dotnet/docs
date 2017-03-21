    Private Sub findListView_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)


        Dim info As ListViewHitTestInfo = findListView.HitTest(e.X, e.Y)
        Dim foundItem As ListViewItem = Nothing
        If (info.Item IsNot Nothing) Then
            foundItem = info.Item.FindNearestItem(SearchDirectionHint.Up)
        End If
        If (foundItem IsNot Nothing) Then
            label1.Text = "Previous Item: " + foundItem.Text

        Else
            label1.Text = "No item found"
        End If

    End Sub