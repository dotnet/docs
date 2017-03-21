    void treeView1_NodeMouseClick(object sender,  
        TreeNodeMouseClickEventArgs e)
    {
        textBox1.Text = e.Node.Text;
    }
    