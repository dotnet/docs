    TreeView treeViewWithToolTips;
    private void InitializeTreeViewWithToolTips()
    {
        treeViewWithToolTips = new TreeView();
        TreeNode node1 = new TreeNode("Node1");
        node1.ToolTipText = "Help for Node1";
        TreeNode node2 = new TreeNode("Node2");
        node2.ToolTipText = "A Tip for Node2";
        treeViewWithToolTips.Nodes.AddRange(new TreeNode[] { node1, node2 });
        treeViewWithToolTips.ShowNodeToolTips = true;
        this.Controls.Add(treeViewWithToolTips);

    }