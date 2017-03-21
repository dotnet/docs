    Private Sub showCheckedNodesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Disable redrawing of treeView1 to prevent flickering 
        ' while changes are made.
        treeView1.BeginUpdate()

        ' Collapse all nodes of treeView1.
        treeView1.CollapseAll()

        ' Add the CheckForCheckedChildren event handler to the BeforeExpand event.
        AddHandler treeView1.BeforeExpand, AddressOf CheckForCheckedChildren

        ' Expand all nodes of treeView1. Nodes without checked children are 
        ' prevented from expanding by the checkForCheckedChildren event handler.
        treeView1.ExpandAll()

        ' Remove the checkForCheckedChildren event handler from the BeforeExpand 
        ' event so manual node expansion will work correctly.
        RemoveHandler treeView1.BeforeExpand, AddressOf CheckForCheckedChildren

        ' Enable redrawing of treeView1.
        treeView1.EndUpdate()
    End Sub 'showCheckedNodesButton_Click

    ' Prevent expansion of a node that does not have any checked child nodes.
    Private Sub CheckForCheckedChildren(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
        If Not HasCheckedChildNodes(e.Node) Then
            e.Cancel = True
        End If
    End Sub 'CheckForCheckedChildren

    ' Returns a value indicating whether the specified 
    ' TreeNode has checked child nodes.
    Private Function HasCheckedChildNodes(ByVal node As TreeNode) As Boolean
        If node.Nodes.Count = 0 Then
            Return False
        End If
        Dim childNode As TreeNode
        For Each childNode In node.Nodes
            If childNode.Checked Then
                Return True
            End If
            ' Recursively check the children of the current child node.
            If HasCheckedChildNodes(childNode) Then
                Return True
            End If
        Next childNode
        Return False
    End Function 'HasCheckedChildNodes