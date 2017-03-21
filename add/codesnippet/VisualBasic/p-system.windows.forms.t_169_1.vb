    Private checkTreeView As TreeView
    
    Private Sub InitializeCheckTreeView() 
        checkTreeView = New TreeView()
        
        ' Show check boxes for the TreeView.
        checkTreeView.CheckBoxes = True
        
        ' Create the StateImageList and add two images.
        checkTreeView.StateImageList = New ImageList()
        checkTreeView.StateImageList.Images.Add(SystemIcons.Question)
        checkTreeView.StateImageList.Images.Add(SystemIcons.Exclamation)
        
        ' Add some nodes to the TreeView and the TreeView to the form.
        checkTreeView.Nodes.Add("Node1")
        checkTreeView.Nodes.Add("Node2")
        Me.Controls.Add(checkTreeView)
    
    End Sub