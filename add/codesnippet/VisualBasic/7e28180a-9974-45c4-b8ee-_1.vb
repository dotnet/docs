    Private resizingListView2 As New ListView()
    Private WithEvents resizeButton As New Button()
    
    
    Private Sub InitializeResizingListView2() 

        ' Set location and text for button.
        resizeButton.Location = New Point(100, 15)
        resizeButton.Text = "Resize"

        ' Set the ListView to details view.
        resizingListView2.View = View.Details
        
        'Set size, location and populate the ListView.
        resizingListView2.Size = New Size(200, 100)
        resizingListView2.Location = New Point(40, 40)
        resizingListView2.Columns.Add("HeaderSize")
        resizingListView2.Columns.Add("ColumnContent")
        Dim listItem1 As New ListViewItem("Short")
        Dim listItem2 As New ListViewItem("Tiny")
        listItem1.SubItems.Add(New ListViewItem.ListViewSubItem(listItem1, _
            "Something longer"))
        listItem2.SubItems.Add(New ListViewItem.ListViewSubItem(listItem2, _
            "Something even longer"))
        resizingListView2.Items.Add(listItem1)
        resizingListView2.Items.Add(listItem2)
        
        ' Add the ListView and the Button to the form.
        Me.Controls.Add(resizingListView2)
        Me.Controls.Add(resizeButton)
    
    End Sub
    
    Private Sub resizeButton_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles resizeButton.Click

        resizingListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
    End Sub