private void MaskedTextBox1_MaskInputRejected(Object sender, MaskInputRejectedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Position", e.Position );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RejectionHint", e.RejectionHint );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MaskInputRejected Event" );
}