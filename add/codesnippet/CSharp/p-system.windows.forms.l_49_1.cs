private void Control1_Layout(Object sender, LayoutEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedComponent", e.AffectedComponent );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedControl", e.AffectedControl );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedProperty", e.AffectedProperty );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Layout Event" );
}