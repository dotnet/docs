    Private positionListView As ListView
    Private moveItem As ListViewItem
    Private WithEvents button1 As Button
    
    
    Private Sub InitializePositionedListViewItems() 
        ' Set some basic properties on the ListView and button.
        positionListView = New ListView()
        positionListView.Height = 200
        button1 = New Button()
        button1.Location = New Point(160, 30)
        button1.AutoSize = True
        button1.Text = "Click to reposition"

        ' View must be set to icon view to use the Position property.
        positionListView.View = View.LargeIcon
        
        ' Create the items and add them to the ListView.
        Dim item1 As New ListViewItem("Click")
        Dim item2 As New ListViewItem("OK")
        moveItem = New ListViewItem("Move")
        positionListView.Items.AddRange(New ListViewItem() _
            {item1, item2, moveItem})
        
        ' Add the controls to the form.
        Me.Controls.Add(positionListView)
        Me.Controls.Add(button1)

    End Sub
    
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        moveItem.Position = New Point(30, 30)
    End Sub