private void Form1_FormClosed(Object sender, FormClosedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "FormClosed Event" );
}