    ' If a node is double-clicked, open the file indicated by the TreeNode.
    Sub treeView1_NodeMouseDoubleClick(ByVal sender As Object, _
        ByVal e As TreeNodeMouseClickEventArgs) _
        Handles treeView1.NodeMouseDoubleClick

        Try
            ' Look for a file extension, and open the file.
            If e.Node.Text.Contains(".") Then
                System.Diagnostics.Process.Start("c:\" + e.Node.Text)
            End If
            ' If the file is not found, handle the exception and inform the user.
        Catch
            MessageBox.Show("File not found.")
        End Try

    End Sub 'treeView1_NodeMouseDoubleClick
    