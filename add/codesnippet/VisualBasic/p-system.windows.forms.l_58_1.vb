Private Sub LinkLabel1_LinkClicked(sender as Object, e as LinkLabelLinkClickedEventArgs) _ 
     Handles LinkLabel1.LinkClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Link", e.Link)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LinkClicked Event")

End Sub