private void SplitContainer1_SplitterMoving(Object sender, SplitterCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "MouseCursorX", e.MouseCursorX );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MouseCursorY", e.MouseCursorY );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SplitX", e.SplitX );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SplitY", e.SplitY );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SplitterMoving Event" );
}