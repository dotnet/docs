    // Populates a TreeView control with example nodes. 
    private void InitializeTreeView()
    {
        treeView1.BeginUpdate();
        treeView1.Nodes.Add("Parent");
        treeView1.Nodes[0].Nodes.Add("Child 1");
        treeView1.Nodes[0].Nodes.Add("Child 2");
        treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
        treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
        treeView1.EndUpdate();
    }