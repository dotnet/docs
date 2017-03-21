Private Sub SplitContainer1_SplitterMoving(sender as Object, e as SplitterCancelEventArgs) _ 
     Handles SplitContainer1.SplitterMoving

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseCursorX", e.MouseCursorX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseCursorY", e.MouseCursorY)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitX", e.SplitX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitY", e.SplitY)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SplitterMoving Event")

End Sub