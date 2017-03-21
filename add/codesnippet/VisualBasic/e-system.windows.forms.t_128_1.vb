    Sub treeView1_NodeMouseClick(ByVal sender As Object, _
        ByVal e As TreeNodeMouseClickEventArgs) _
        Handles treeView1.NodeMouseClick

        textBox1.Text = e.Node.Text

    End Sub 'treeView1_NodeMouseClick
    
    