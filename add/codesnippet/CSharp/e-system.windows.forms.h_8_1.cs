private void HtmlWindow1_Scroll(Object sender, HtmlElementEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "EventType", e.EventType );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "FromElement", e.FromElement );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToElement", e.ToElement );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Scroll Event" );
}