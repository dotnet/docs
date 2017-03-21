    Private WithEvents listView1 As New ListView()

    Private Sub InitializeListView1()

        ' Initialize a ListView in detail view and add some columns.
        listView1.View = View.Details
        listView1.Width = 200
        listView1.Columns.Add("Column1")
        listView1.Columns.Add("Column2")
        Me.Controls.Add(listView1)

    End Sub


    ' Handle the ColumnWidthChangingEvent.
    Private Sub listView1_ColumnWidthChanging(ByVal sender As Object, _
        ByVal e As ColumnWidthChangingEventArgs) _
        Handles listView1.ColumnWidthChanging

        ' Check if the new width is too big or too small.
        If e.NewWidth > 100 OrElse e.NewWidth < 5 Then

            ' Cancel the event and inform the user if the new
            ' width does not meet the criteria.
            MessageBox.Show("Column width is too large or too small")
            e.Cancel = True
        End If

    End Sub