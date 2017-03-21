Private Sub SplitContainer1_SplitterMoved(sender as Object, e as SplitterEventArgs) _ 
     Handles SplitContainer1.SplitterMoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitX", e.SplitX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitY", e.SplitY)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SplitterMoved Event")

End Sub