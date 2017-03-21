    void treeView1_MouseDown(object sender, MouseEventArgs e)
    {
        TreeViewHitTestInfo info = treeView1.HitTest(e.X, e.Y);
        TreeNode hitNode;
        if (info.Node != null) {
            hitNode = info.Node;
            MessageBox.Show(hitNode.Level.ToString());
        }
    }