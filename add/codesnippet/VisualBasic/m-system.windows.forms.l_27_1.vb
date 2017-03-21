    Private WithEvents listView1 As ListView
    
    Private Sub InitializeListView1()
        listView1 = New ListView()

        ' Set the view to details to show subitems.
        listView1.View = View.Details

        ' Add some columns and set the width.
        listView1.Columns.Add("Name")
        listView1.Columns.Add("Number")
        listView1.Columns.Add("Description")
        listView1.Width = 175

        ' Create some items and subitems; add the to the ListView.
        Dim item1 As New ListViewItem("Widget")
        item1.SubItems.Add(New ListViewItem.ListViewSubItem(item1, "14"))
        item1.SubItems.Add(New ListViewItem.ListViewSubItem(item1, "A description of Widget"))
        Dim item2 As New ListViewItem("Bracket")
        item2.SubItems.Add(New ListViewItem.ListViewSubItem(item2, "8"))
        listView1.Items.Add(item1)
        listView1.Items.Add(item2)

        ' Add the ListView to the form.
        Me.Controls.Add(listView1)
    End Sub
    
    Private Sub listView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)


        ' Get the item at the mouse pointer.
        Dim info As ListViewHitTestInfo = listView1.HitTest(e.X, e.Y)

        Dim subItem As ListViewItem.ListViewSubItem = Nothing

        ' Get the subitem 120 pixels to the right.
        If (info IsNot Nothing) Then
            If (info.Item IsNot Nothing) Then
                subItem = info.Item.GetSubItemAt(e.X + 120, e.Y)
            End If
        End If ' Show the text of the subitem, if found.
        If (subItem IsNot Nothing) Then
            MessageBox.Show(subItem.Text)
        End If
    End Sub