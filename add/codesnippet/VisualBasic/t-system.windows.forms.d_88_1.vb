Private Sub DataGridView1_DataBindingComplete(sender as Object, e as DataGridViewBindingCompleteEventArgs) _ 
     Handles DataGridView1.DataBindingComplete

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DataBindingComplete Event")

End Sub