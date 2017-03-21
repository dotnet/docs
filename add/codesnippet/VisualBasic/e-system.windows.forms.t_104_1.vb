Private Sub TreeView1_AfterExpand(sender as Object, e as TreeViewEventArgs) _ 
     Handles TreeView1.AfterExpand

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterExpand Event")

End Sub