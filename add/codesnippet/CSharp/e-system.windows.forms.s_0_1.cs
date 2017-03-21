private void ScrollableControl1_Scroll(Object sender, ScrollEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ScrollOrientation", e.ScrollOrientation );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Type", e.Type );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewValue", e.NewValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldValue", e.OldValue );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Scroll Event" );
}