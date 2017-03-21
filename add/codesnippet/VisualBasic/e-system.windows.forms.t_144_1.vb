Private Sub TreeView1_NodeMouseHover(sender as Object, e as TreeNodeMouseHoverEventArgs) _ 
     Handles TreeView1.NodeMouseHover

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"NodeMouseHover Event")

End Sub