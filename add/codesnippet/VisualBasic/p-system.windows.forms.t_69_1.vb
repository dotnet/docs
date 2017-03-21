    Private lineTreeView As TreeView
    
    Public Sub InitializeLineTreeView() 
        lineTreeView = New TreeView()
        lineTreeView.Size = New Size(200, 200)
        
        lineTreeView.LineColor = Color.Red
        
        ' Create the root nodes.
        Dim docNode As New TreeNode("Documents")
        
        ' Add some additional nodes.
        docNode.Nodes.Add("phoneList.doc")
        docNode.Nodes.Add("resume.doc")
        
        lineTreeView.Nodes.Add(docNode)
        Controls.Add(lineTreeView)
    
    End Sub
    