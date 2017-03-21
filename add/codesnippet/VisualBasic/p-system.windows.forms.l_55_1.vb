    ' Declare the ListView.
    Private ListViewWithToolTips As ListView
    
    Private Sub InitializeItemsWithToolTips() 
        
        ' Construct and set the View property of the ListView.
        ListViewWithToolTips = New ListView()
        ListViewWithToolTips.Width = 200
        ListViewWithToolTips.View = View.List
        
        ' Show item tooltips.
        ListViewWithToolTips.ShowItemToolTips = True
        
        ' Create items with a tooltip.
        Dim item1WithToolTip As New ListViewItem("Item with a tooltip")
        item1WithToolTip.ToolTipText = "This is the item tooltip."
        Dim item2WithToolTip As New ListViewItem("Second item with a tooltip")
        item2WithToolTip.ToolTipText = "A different tooltip for this item."
        
        ' Create an item without a tooltip.
        Dim itemWithoutToolTip As New ListViewItem("Item without tooltip.")
        
        ' Add the items to the ListView.
        ListViewWithToolTips.Items.AddRange(New ListViewItem() _
            {item1WithToolTip, item2WithToolTip, itemWithoutToolTip})
        
        ' Add the ListView to the form.
        Me.Controls.Add(ListViewWithToolTips)
        Me.Controls.Add(button1)
    
    End Sub