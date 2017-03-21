Private Sub ToolStripItem1_GiveFeedback(sender as Object, e as GiveFeedbackEventArgs) _ 
     Handles ToolStripItem1.GiveFeedback

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "UseDefaultCursors", e.UseDefaultCursors)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"GiveFeedback Event")

End Sub