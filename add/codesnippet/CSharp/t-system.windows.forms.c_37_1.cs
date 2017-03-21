private void RichTextBox1_ContentsResized(Object sender, ContentsResizedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "NewRectangle", e.NewRectangle );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ContentsResized Event" );
}