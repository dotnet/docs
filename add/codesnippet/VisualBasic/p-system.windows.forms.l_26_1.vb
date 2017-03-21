    Private Sub InitializeListViewItems()
        ListView1.View = View.List
        Dim aCursor As Cursor

        Dim favoriteCursors() As Cursor = New Cursor() _
                    {Cursors.Help, Cursors.Hand, Cursors.No, Cursors.Cross}

        ' Populate the ListView control with the array of Cursors.
        For Each aCursor In favoriteCursors

            ' Construct the ListViewItem object
            Dim item As New ListViewItem

            ' Set the Text property to the cursor name.
            item.Text = aCursor.ToString

            ' Set the Tag property to the cursor.
            item.Tag = aCursor

            ' Add the ListViewItem to the ListView.
            ListView1.Items.Add(item)
        Next
    End Sub