Private Sub MaskedTextBox1_MaskInputRejected(sender as Object, e as MaskInputRejectedEventArgs) _ 
     Handles MaskedTextBox1.MaskInputRejected

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Position", e.Position)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RejectionHint", e.RejectionHint)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MaskInputRejected Event")

End Sub