private void SplitContainer1_SplitterMoved(Object sender, SplitterEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SplitX", e.SplitX );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SplitY", e.SplitY );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SplitterMoved Event" );
}