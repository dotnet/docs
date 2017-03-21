Private Sub ListBox1_DrawItem(sender as Object, e as DrawItemEventArgs) _ 
     Handles ListBox1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub