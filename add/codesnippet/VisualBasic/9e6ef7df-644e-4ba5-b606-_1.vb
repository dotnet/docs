    Private resizingListView As New ListView()
    Private WithEvents button1 As New Button()


    Private Sub InitializeResizingListView()
        ' Set location and text for button.
        button1.Location = New Point(100, 15)
        button1.Text = "Resize"
        AddHandler button1.Click, AddressOf button1_Click

        ' Set the ListView to details view.
        resizingListView.View = View.Details

        'Set size, location and populate the ListView.
        resizingListView.Size = New Size(200, 100)
        resizingListView.Location = New Point(40, 40)
        resizingListView.Columns.Add("HeaderSize")
        resizingListView.Columns.Add("ColumnContent")
        Dim listItem1 As New ListViewItem("Short")
        Dim listItem2 As New ListViewItem("Tiny")
        listItem1.SubItems.Add(New ListViewItem.ListViewSubItem(listItem1, _
            "Something longer"))
        listItem2.SubItems.Add(New ListViewItem.ListViewSubItem(listItem2, _
            "Something even longer"))
        resizingListView.Items.Add(listItem1)
        resizingListView.Items.Add(listItem2)

        ' Add the ListView and the Button to the form.
        Me.Controls.Add(resizingListView)
        Me.Controls.Add(button1)

    End Sub


    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles button1.Click

        ' Resize the first column to the header size.
        resizingListView.AutoResizeColumn(0, _
            ColumnHeaderAutoResizeStyle.HeaderSize)

        ' Resize the second column to the column content.
        resizingListView.AutoResizeColumn(1, _
            ColumnHeaderAutoResizeStyle.ColumnContent)

    End Sub