Private Sub Splitter1_SplitterMoving(sender as Object, e as SplitterEventArgs) _ 
     Handles Splitter1.SplitterMoving

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitX", e.SplitX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitY", e.SplitY)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SplitterMoving Event")

End Sub