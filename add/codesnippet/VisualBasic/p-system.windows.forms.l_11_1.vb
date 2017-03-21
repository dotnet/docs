    Private indentedListView As ListView
    
    
    Private Sub InitializeIndentedListViewItems() 
        indentedListView = New ListView()
        indentedListView.Width = 200
        
        ' View must be set to Details to use IndentCount.
        indentedListView.View = View.Details
        indentedListView.Columns.Add("Indented Items", 150)
        
        ' Create an image list and add an image.
        Dim list As New ImageList()
        list.Images.Add(New Bitmap(GetType(Button), "Button.bmp"))
        
        ' SmallImageList must be set when using IndentCount.
        indentedListView.SmallImageList = list
        
        Dim item1 As New ListViewItem("Click", 0)
        item1.IndentCount = 1
        Dim item2 As New ListViewItem("OK", 0)
        item2.IndentCount = 2
        Dim item3 As New ListViewItem("Cancel", 0)
        item3.IndentCount = 3
        indentedListView.Items.AddRange(New ListViewItem() {item1, item2, item3})
        
        ' Add the controls to the form.
        Me.Controls.Add(indentedListView)
    
    End Sub 'InitializeIndentedListViewItems 