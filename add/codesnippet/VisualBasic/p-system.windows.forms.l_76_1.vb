    Public Sub New()
        ' Initialize myListView.
        myListView = New ListView()
        myListView.Dock = DockStyle.Fill
        myListView.View = View.LargeIcon
        myListView.MultiSelect = False
        myListView.ListViewItemSorter = New ListViewIndexComparer()
        
        ' Initialize the insertion mark.
        myListView.InsertionMark.Color = Color.Green
        
        ' Add items to myListView.
        myListView.Items.Add("zero")
        myListView.Items.Add("one")
        myListView.Items.Add("two")
        myListView.Items.Add("three")
        myListView.Items.Add("four")
        myListView.Items.Add("five")
        
        ' Initialize the drag-and-drop operation when running
        ' under Windows XP or a later operating system.
        If OSFeature.Feature.IsPresent(OSFeature.Themes)
            myListView.AllowDrop = True
            AddHandler myListView.ItemDrag, AddressOf myListView_ItemDrag
            AddHandler myListView.DragEnter, AddressOf myListView_DragEnter
            AddHandler myListView.DragOver, AddressOf myListView_DragOver
            AddHandler myListView.DragLeave, AddressOf myListView_DragLeave
            AddHandler myListView.DragDrop, AddressOf myListView_DragDrop
        End If 

        ' Initialize the form.
        Me.Text = "ListView Insertion Mark Example"
        Me.Controls.Add(myListView)
    End Sub 'New