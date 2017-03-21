Private Sub ListView1_DrawColumnHeader(sender as Object, e as DrawListViewColumnHeaderEventArgs) _ 
     Handles ListView1.DrawColumnHeader

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Header", e.Header)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawColumnHeader Event")

End Sub