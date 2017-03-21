    Private treeViewWithToolTips As TreeView
    
    Private Sub InitializeTreeViewWithToolTips() 
        treeViewWithToolTips = New TreeView()
        Dim node1 As New TreeNode("Node1")
        node1.ToolTipText = "Help for Node1"
        Dim node2 As New TreeNode("Node2")
        node2.ToolTipText = "A Tip for Node2"
        treeViewWithToolTips.Nodes.AddRange(New TreeNode() {node1, node2})
        treeViewWithToolTips.ShowNodeToolTips = True
        Me.Controls.Add(treeViewWithToolTips)
    
    End Sub