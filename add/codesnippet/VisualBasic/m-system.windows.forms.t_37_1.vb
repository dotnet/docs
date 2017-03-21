    Sub treeView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) 
        Dim info As TreeViewHitTestInfo = treeView1.HitTest(e.X, e.Y)
        Dim hitNode As TreeNode
        If (info.Node IsNot Nothing) Then
            hitNode = info.Node
            MessageBox.Show(hitNode.Level.ToString())
        End If
    
    End Sub 'treeView1_MouseDown
    