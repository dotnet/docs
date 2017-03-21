private void Control1_Paint(Object sender, PaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Paint Event" );
}