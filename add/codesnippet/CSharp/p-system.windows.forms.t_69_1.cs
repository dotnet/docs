    private TreeView lineTreeView;
    public void InitializeLineTreeView()
    {
        lineTreeView = new TreeView();
        lineTreeView.Size = new Size(200, 200);

        lineTreeView.LineColor = Color.Red;

        // Create the root nodes.
        TreeNode docNode = new TreeNode("Documents");
       
        // Add some additional nodes.
        docNode.Nodes.Add("phoneList.doc");
        docNode.Nodes.Add("resume.doc");
        
        lineTreeView.Nodes.Add(docNode);
        Controls.Add(lineTreeView);
    }