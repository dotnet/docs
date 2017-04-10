using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


public class Form1 : Form {


[STAThread]
public static void Main(){ 
    Application.EnableVisualStyles();
    Application.Run(new Form1());  }
//<snippet1>
private void Application_ApplicationExit(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Application.ApplicationExit event.");

}
//</snippet1>

//<snippet2>
private void Application_Idle(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Application.Idle event.");

}
//</snippet2>

//<snippet3>
private void Application_EnterThreadModal(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Application.EnterThreadModal event.");

}
//</snippet3>

//<snippet4>
private void Application_LeaveThreadModal(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Application.LeaveThreadModal event.");

}
//</snippet4>

//<snippet5>
private void Application_ThreadException(Object sender, 
    System.Threading.ThreadExceptionEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ThreadException Event" );
}
//</snippet5>

//<snippet6>
private void Application_ThreadExit(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Application.ThreadExit event.");

}
//</snippet6>

//<snippet7>
private void Control1_BackColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.BackColorChanged event.");

}
//</snippet7>

//<snippet8>
private void Control1_BackgroundImageChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.BackgroundImageChanged event.");

}
//</snippet8>

//<snippet9>
private void Control1_BackgroundImageLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.BackgroundImageLayoutChanged event.");

}
//</snippet9>

//<snippet10>
private void Control1_BindingContextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.BindingContextChanged event.");

}
//</snippet10>

//<snippet11>
private void Control1_CausesValidationChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.CausesValidationChanged event.");

}
//</snippet11>

//<snippet12>
private void Control1_ClientSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.ClientSizeChanged event.");

}
//</snippet12>

//<snippet13>
private void Control1_ContextMenuChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.ContextMenuChanged event.");

}
//</snippet13>

//<snippet14>
private void Control1_ContextMenuStripChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.ContextMenuStripChanged event.");

}
//</snippet14>

//<snippet15>
private void Control1_CursorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.CursorChanged event.");

}
//</snippet15>

//<snippet16>
private void Control1_DockChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.DockChanged event.");

}
//</snippet16>

//<snippet17>
private void Control1_EnabledChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.EnabledChanged event.");

}
//</snippet17>

//<snippet18>
private void Control1_FontChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.FontChanged event.");

}
//</snippet18>

//<snippet19>
private void Control1_ForeColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.ForeColorChanged event.");

}
//</snippet19>

//<snippet20>
private void Control1_LocationChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.LocationChanged event.");

}
//</snippet20>

//<snippet21>
private void Control1_MarginChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.MarginChanged event.");

}
//</snippet21>

//<snippet22>
private void Control1_RegionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.RegionChanged event.");

}
//</snippet22>

//<snippet23>
private void Control1_RightToLeftChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.RightToLeftChanged event.");

}
//</snippet23>

//<snippet24>
private void Control1_SizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.SizeChanged event.");

}
//</snippet24>

//<snippet25>
private void Control1_TabIndexChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.TabIndexChanged event.");

}
//</snippet25>

//<snippet26>
private void Control1_TabStopChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.TabStopChanged event.");

}
//</snippet26>

//<snippet27>
private void Control1_TextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.TextChanged event.");

}
//</snippet27>

//<snippet28>
private void Control1_VisibleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.VisibleChanged event.");

}
//</snippet28>

//<snippet29>
private void Control1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.Click event.");

}
//</snippet29>

//<snippet30>
private void Control1_ControlAdded(Object sender, ControlEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ControlAdded Event" );
}
//</snippet30>

//<snippet31>
private void Control1_ControlRemoved(Object sender, ControlEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ControlRemoved Event" );
}
//</snippet31>

//<snippet32>
private void Control1_DragDrop(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragDrop Event" );
}
//</snippet32>

//<snippet33>
private void Control1_DragEnter(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragEnter Event" );
}
//</snippet33>

//<snippet34>
private void Control1_DragOver(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragOver Event" );
}
//</snippet34>

//<snippet35>
private void Control1_DragLeave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.DragLeave event.");

}
//</snippet35>

//<snippet36>
private void Control1_GiveFeedback(Object sender, GiveFeedbackEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "UseDefaultCursors", e.UseDefaultCursors );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "GiveFeedback Event" );
}
//</snippet36>

//<snippet37>
private void Control1_HandleCreated(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.HandleCreated event.");

}
//</snippet37>

//<snippet38>
private void Control1_HandleDestroyed(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.HandleDestroyed event.");

}
//</snippet38>

//<snippet39>
private void Control1_HelpRequested(Object sender, HelpEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "MousePos", e.MousePos );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "HelpRequested Event" );
}
//</snippet39>

//<snippet40>
private void Control1_Invalidated(Object sender, InvalidateEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "InvalidRect", e.InvalidRect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Invalidated Event" );
}
//</snippet40>

//<snippet41>
private void Control1_PaddingChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.PaddingChanged event.");

}
//</snippet41>

//<snippet42>
private void Control1_Paint(Object sender, PaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Paint Event" );
}
//</snippet42>

//<snippet43>
private void Control1_QueryContinueDrag(Object sender, QueryContinueDragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "EscapePressed", e.EscapePressed );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "QueryContinueDrag Event" );
}
//</snippet43>

//<snippet44>
private void Control1_QueryAccessibilityHelp(Object sender, QueryAccessibilityHelpEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "HelpNamespace", e.HelpNamespace );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "HelpString", e.HelpString );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "HelpKeyword", e.HelpKeyword );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "QueryAccessibilityHelp Event" );
}
//</snippet44>

//<snippet45>
private void Control1_DoubleClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.DoubleClick event.");

}
//</snippet45>

//<snippet46>
private void Control1_Enter(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.Enter event.");

}
//</snippet46>

//<snippet47>
private void Control1_GotFocus(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.GotFocus event.");

}
//</snippet47>

//<snippet48>
private void Control1_KeyDown(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event" );
}
//</snippet48>

//<snippet49>
private void Control1_KeyPress(Object sender, KeyPressEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyPress Event" );
}
//</snippet49>

//<snippet50>
private void Control1_KeyUp(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyUp Event" );
}
//</snippet50>

//<snippet51>
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
//</snippet51>

//<snippet52>
private void Control1_Leave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.Leave event.");

}
//</snippet52>

//<snippet53>
private void Control1_LostFocus(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.LostFocus event.");

}
//</snippet53>

//<snippet54>
private void Control1_MouseClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event" );
}
//</snippet54>

//<snippet55>
private void Control1_MouseDoubleClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDoubleClick Event" );
}
//</snippet55>

//<snippet56>
private void Control1_MouseCaptureChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.MouseCaptureChanged event.");

}
//</snippet56>

//<snippet57>
private void Control1_MouseDown(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDown Event" );
}
//</snippet57>

//<snippet58>
private void Control1_MouseEnter(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.MouseEnter event.");

}
//</snippet58>

//<snippet59>
private void Control1_MouseLeave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.MouseLeave event.");

}
//</snippet59>

//<snippet60>
private void Control1_MouseHover(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.MouseHover event.");

}
//</snippet60>

//<snippet61>
private void Control1_MouseMove(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event" );
}
//</snippet61>

//<snippet62>
private void Control1_MouseUp(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseUp Event" );
}
//</snippet62>

//<snippet63>
private void Control1_MouseWheel(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseWheel Event" );
}
//</snippet63>

//<snippet64>
private void Control1_Move(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.Move event.");

}
//</snippet64>

//<snippet65>
private void Control1_PreviewKeyDown(Object sender, PreviewKeyDownEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsInputKey", e.IsInputKey );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "PreviewKeyDown Event" );
}
//</snippet65>

//<snippet66>
private void Control1_Resize(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.Resize event.");

}
//</snippet66>

//<snippet67>
private void Control1_ChangeUICues(Object sender, UICuesEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ShowFocus", e.ShowFocus );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ShowKeyboard", e.ShowKeyboard );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ChangeFocus", e.ChangeFocus );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ChangeKeyboard", e.ChangeKeyboard );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Changed", e.Changed );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ChangeUICues Event" );
}
//</snippet67>

//<snippet68>
private void Control1_StyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.StyleChanged event.");

}
//</snippet68>

//<snippet69>
private void Control1_SystemColorsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.SystemColorsChanged event.");

}
//</snippet69>

//<snippet70>
private void Control1_Validating(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Validating Event" );
}
//</snippet70>

//<snippet71>
private void Control1_Validated(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.Validated event.");

}
//</snippet71>

//<snippet72>
private void Control1_ParentChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.ParentChanged event.");

}
//</snippet72>

//<snippet73>
private void Control1_ImeModeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Control.ImeModeChanged event.");

}
//</snippet73>

//<snippet74>
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
//</snippet74>

//<snippet75>
private void ApplicationContext1_ThreadExit(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ApplicationContext.ThreadExit event.");

}
//</snippet75>

//<snippet76>
private void AutoCompleteStringCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}
//</snippet76>

//<snippet77>
private void Binding1_BindingComplete(Object sender, BindingCompleteEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Binding", e.Binding );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BindingComplete Event" );
}
//</snippet77>

//<snippet78>
private void Binding1_Parse(Object sender, ConvertEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Parse Event" );
}
//</snippet78>

//<snippet79>
private void Binding1_Format(Object sender, ConvertEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Format Event" );
}
//</snippet79>

//<snippet80>
private void BindingManagerBase1_BindingComplete(Object sender, BindingCompleteEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Binding", e.Binding );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BindingComplete Event" );
}
//</snippet80>

//<snippet81>
private void BindingManagerBase1_CurrentChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingManagerBase.CurrentChanged event.");

}
//</snippet81>

//<snippet82>
private void BindingManagerBase1_CurrentItemChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingManagerBase.CurrentItemChanged event.");

}
//</snippet82>

//<snippet83>
private void BindingManagerBase1_DataError(Object sender, BindingManagerDataErrorEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DataError Event" );
}
//</snippet83>

//<snippet84>
private void BindingManagerBase1_PositionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingManagerBase.PositionChanged event.");

}
//</snippet84>

//<snippet85>
private void ToolStrip1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.AutoSizeChanged event.");

}
//</snippet85>

//<snippet86>
private void ToolStrip1_BeginDrag(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.BeginDrag event.");

}
//</snippet86>

//<snippet87>
private void ToolStrip1_CausesValidationChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.CausesValidationChanged event.");

}
//</snippet87>

//<snippet88>
private void ToolStrip1_CursorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.CursorChanged event.");

}
//</snippet88>

//<snippet89>
private void ToolStrip1_EndDrag(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.EndDrag event.");

}
//</snippet89>

//<snippet90>
private void ToolStrip1_ForeColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.ForeColorChanged event.");

}
//</snippet90>

//<snippet91>
private void ToolStrip1_ItemAdded(Object sender, ToolStripItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemAdded Event" );
}
//</snippet91>

//<snippet92>
private void ToolStrip1_ItemClicked(Object sender, ToolStripItemClickedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClickedItem", e.ClickedItem );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemClicked Event" );
}
//</snippet92>

//<snippet93>
private void ToolStrip1_ItemRemoved(Object sender, ToolStripItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemRemoved Event" );
}
//</snippet93>

//<snippet94>
private void ToolStrip1_LayoutCompleted(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.LayoutCompleted event.");

}
//</snippet94>

//<snippet95>
private void ToolStrip1_LayoutStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.LayoutStyleChanged event.");

}
//</snippet95>

//<snippet96>
private void ToolStrip1_PaintGrip(Object sender, PaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "PaintGrip Event" );
}
//</snippet96>

//<snippet97>
private void ToolStrip1_RendererChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStrip.RendererChanged event.");

}
//</snippet97>

//<snippet98>
private void ToolStripItem1_AvailableChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.AvailableChanged event.");

}
//</snippet98>

//<snippet99>
private void ToolStripItem1_BackColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.BackColorChanged event.");

}
//</snippet99>

//<snippet100>
private void ToolStripItem1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.Click event.");

}
//</snippet100>

//<snippet101>
private void ToolStripItem1_DisplayStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.DisplayStyleChanged event.");

}
//</snippet101>

//<snippet102>
private void ToolStripItem1_DoubleClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.DoubleClick event.");

}
//</snippet102>

//<snippet103>
private void ToolStripItem1_DragDrop(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragDrop Event" );
}
//</snippet103>

//<snippet104>
private void ToolStripItem1_DragEnter(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragEnter Event" );
}
//</snippet104>

//<snippet105>
private void ToolStripItem1_DragOver(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragOver Event" );
}
//</snippet105>

//<snippet106>
private void ToolStripItem1_DragLeave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.DragLeave event.");

}
//</snippet106>

//<snippet107>
private void ToolStripItem1_EnabledChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.EnabledChanged event.");

}
//</snippet107>

//<snippet108>
private void ToolStripItem1_ForeColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.ForeColorChanged event.");

}
//</snippet108>

//<snippet109>
private void ToolStripItem1_GiveFeedback(Object sender, GiveFeedbackEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "UseDefaultCursors", e.UseDefaultCursors );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "GiveFeedback Event" );
}
//</snippet109>

//<snippet110>
private void ToolStripItem1_LocationChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.LocationChanged event.");

}
//</snippet110>

//<snippet111>
private void ToolStripItem1_MouseDown(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDown Event" );
}
//</snippet111>

//<snippet112>
private void ToolStripItem1_MouseEnter(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.MouseEnter event.");

}
//</snippet112>

//<snippet113>
private void ToolStripItem1_MouseLeave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.MouseLeave event.");

}
//</snippet113>

//<snippet114>
private void ToolStripItem1_MouseHover(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.MouseHover event.");

}
//</snippet114>

//<snippet115>
private void ToolStripItem1_MouseMove(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event" );
}
//</snippet115>

//<snippet116>
private void ToolStripItem1_MouseUp(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseUp Event" );
}
//</snippet116>

//<snippet117>
private void ToolStripItem1_OwnerChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.OwnerChanged event.");

}
//</snippet117>

//<snippet118>
private void ToolStripItem1_Paint(Object sender, PaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Paint Event" );
}
//</snippet118>

//<snippet119>
private void ToolStripItem1_QueryContinueDrag(Object sender, QueryContinueDragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "EscapePressed", e.EscapePressed );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "QueryContinueDrag Event" );
}
//</snippet119>

//<snippet120>
private void ToolStripItem1_QueryAccessibilityHelp(Object sender, QueryAccessibilityHelpEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "HelpNamespace", e.HelpNamespace );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "HelpString", e.HelpString );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "HelpKeyword", e.HelpKeyword );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "QueryAccessibilityHelp Event" );
}
//</snippet120>

//<snippet121>
private void ToolStripItem1_RightToLeftChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.RightToLeftChanged event.");

}
//</snippet121>

//<snippet122>
private void ToolStripItem1_TextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.TextChanged event.");

}
//</snippet122>

//<snippet123>
private void ToolStripItem1_VisibleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripItem.VisibleChanged event.");

}
//</snippet123>

//<snippet124>
private void BindingNavigator1_RefreshItems(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingNavigator.RefreshItems event.");

}
//</snippet124>

//<snippet125>
private void BindingsCollection1_CollectionChanging(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanging Event" );
}
//</snippet125>

//<snippet126>
private void BindingsCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}
//</snippet126>

//<snippet127>
private void BindingSource1_AddingNew(Object sender, AddingNewEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "NewObject", e.NewObject );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AddingNew Event" );
}
//</snippet127>

//<snippet128>
private void BindingSource1_BindingComplete(Object sender, BindingCompleteEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Binding", e.Binding );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BindingComplete Event" );
}
//</snippet128>

//<snippet129>
private void BindingSource1_DataError(Object sender, BindingManagerDataErrorEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DataError Event" );
}
//</snippet129>

//<snippet130>
private void BindingSource1_DataSourceChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingSource.DataSourceChanged event.");

}
//</snippet130>

//<snippet131>
private void BindingSource1_DataMemberChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingSource.DataMemberChanged event.");

}
//</snippet131>

//<snippet132>
private void BindingSource1_CurrentChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingSource.CurrentChanged event.");

}
//</snippet132>

//<snippet133>
private void BindingSource1_CurrentItemChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingSource.CurrentItemChanged event.");

}
//</snippet133>

//<snippet134>
private void BindingSource1_ListChanged(Object sender, ListChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewIndex", e.NewIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldIndex", e.OldIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PropertyDescriptor", e.PropertyDescriptor );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ListChanged Event" );
}
//</snippet134>

//<snippet135>
private void BindingSource1_PositionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the BindingSource.PositionChanged event.");

}
//</snippet135>

//<snippet136>
private void ButtonBase1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ButtonBase.AutoSizeChanged event.");

}
//</snippet136>

//<snippet137>
private void Button1_DoubleClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Button.DoubleClick event.");

}
//</snippet137>

//<snippet138>
private void Button1_MouseDoubleClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDoubleClick Event" );
}
//</snippet138>

//<snippet139>
private void CheckBox1_AppearanceChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the CheckBox.AppearanceChanged event.");

}
//</snippet139>

//<snippet140>
private void CheckBox1_CheckedChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the CheckBox.CheckedChanged event.");

}
//</snippet140>

//<snippet141>
private void CheckBox1_CheckStateChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the CheckBox.CheckStateChanged event.");

}
//</snippet141>

//<snippet142>
private void ListControl1_DataSourceChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListControl.DataSourceChanged event.");

}
//</snippet142>

//<snippet143>
private void ListControl1_DisplayMemberChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListControl.DisplayMemberChanged event.");

}
//</snippet143>

//<snippet144>
private void ListControl1_Format(Object sender, ListControlConvertEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ListItem", e.ListItem );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Format Event" );
}
//</snippet144>

//<snippet145>
private void ListControl1_FormatInfoChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListControl.FormatInfoChanged event.");

}
//</snippet145>

//<snippet146>
private void ListControl1_FormatStringChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListControl.FormatStringChanged event.");

}
//</snippet146>

//<snippet147>
private void ListControl1_FormattingEnabledChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListControl.FormattingEnabledChanged event.");

}
//</snippet147>

//<snippet148>
private void ListControl1_ValueMemberChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListControl.ValueMemberChanged event.");

}
//</snippet148>

//<snippet149>
private void ListControl1_SelectedValueChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListControl.SelectedValueChanged event.");

}
//</snippet149>

//<snippet150>
private void ListBox1_TextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListBox.TextChanged event.");

}
//</snippet150>

//<snippet151>
private void ListBox1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListBox.Click event.");

}
//</snippet151>

//<snippet152>
private void ListBox1_MouseClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event" );
}
//</snippet152>

//<snippet153>
private void ListBox1_DrawItem(Object sender, DrawItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}
//</snippet153>

//<snippet154>
private void ListBox1_MeasureItem(Object sender, MeasureItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MeasureItem Event" );
}
//</snippet154>

//<snippet155>
private void ListBox1_SelectedIndexChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListBox.SelectedIndexChanged event.");

}
//</snippet155>

//<snippet156>
private void CheckedListBox1_ItemCheck(Object sender, ItemCheckEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewValue", e.NewValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemCheck Event" );
}
//</snippet156>

//<snippet157>
private void CheckedListBox1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the CheckedListBox.Click event.");

}
//</snippet157>

//<snippet158>
private void CheckedListBox1_MouseClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event" );
}
//</snippet158>

//<snippet159>
private void CommonDialog1_HelpRequest(Object sender, EventArgs e) {

   MessageBox.Show("You are in the CommonDialog.HelpRequest event.");

}
//</snippet159>

//<snippet160>
private void ImageList1_RecreateHandle(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ImageList.RecreateHandle event.");

}
//</snippet160>

//<snippet161>
private void ComboBox1_DrawItem(Object sender, DrawItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}
//</snippet161>

//<snippet162>
private void ComboBox1_DropDown(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ComboBox.DropDown event.");

}
//</snippet162>

//<snippet163>
private void ComboBox1_MeasureItem(Object sender, MeasureItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MeasureItem Event" );
}
//</snippet163>

//<snippet164>
private void ComboBox1_SelectedIndexChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ComboBox.SelectedIndexChanged event.");

}
//</snippet164>

//<snippet165>
private void ComboBox1_SelectionChangeCommitted(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ComboBox.SelectionChangeCommitted event.");

}
//</snippet165>

//<snippet166>
private void ComboBox1_DropDownStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ComboBox.DropDownStyleChanged event.");

}
//</snippet166>

//<snippet167>
private void ComboBox1_TextUpdate(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ComboBox.TextUpdate event.");

}
//</snippet167>

//<snippet168>
private void ComboBox1_DropDownClosed(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ComboBox.DropDownClosed event.");

}
//</snippet168>

//<snippet169>
private void ContextMenu1_Popup(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ContextMenu.Popup event.");

}
//</snippet169>

//<snippet170>
private void ContextMenu1_Collapse(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ContextMenu.Collapse event.");

}
//</snippet170>

//<snippet171>
private void ToolStripDropDown1_BackgroundImageChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.BackgroundImageChanged event.");

}
//</snippet171>

//<snippet172>
private void ToolStripDropDown1_BackgroundImageLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.BackgroundImageLayoutChanged event.");

}
//</snippet172>

//<snippet173>
private void ToolStripDropDown1_BindingContextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.BindingContextChanged event.");

}
//</snippet173>

//<snippet174>
private void ToolStripDropDown1_ChangeUICues(Object sender, UICuesEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ShowFocus", e.ShowFocus );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ShowKeyboard", e.ShowKeyboard );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ChangeFocus", e.ChangeFocus );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ChangeKeyboard", e.ChangeKeyboard );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Changed", e.Changed );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ChangeUICues Event" );
}
//</snippet174>

//<snippet175>
private void ToolStripDropDown1_ContextMenuStripChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.ContextMenuStripChanged event.");

}
//</snippet175>

//<snippet176>
private void ToolStripDropDown1_DockChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.DockChanged event.");

}
//</snippet176>

//<snippet177>
private void ToolStripDropDown1_Closed(Object sender, ToolStripDropDownClosedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Closed Event" );
}
//</snippet177>

//<snippet178>
private void ToolStripDropDown1_Closing(Object sender, ToolStripDropDownClosingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Closing Event" );
}
//</snippet178>

//<snippet179>
private void ToolStripDropDown1_Enter(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.Enter event.");

}
//</snippet179>

//<snippet180>
private void ToolStripDropDown1_FontChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.FontChanged event.");

}
//</snippet180>

//<snippet181>
private void ToolStripDropDown1_HelpRequested(Object sender, HelpEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "MousePos", e.MousePos );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "HelpRequested Event" );
}
//</snippet181>

//<snippet182>
private void ToolStripDropDown1_ImeModeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.ImeModeChanged event.");

}
//</snippet182>

//<snippet183>
private void ToolStripDropDown1_KeyDown(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event" );
}
//</snippet183>

//<snippet184>
private void ToolStripDropDown1_KeyPress(Object sender, KeyPressEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyPress Event" );
}
//</snippet184>

//<snippet185>
private void ToolStripDropDown1_KeyUp(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyUp Event" );
}
//</snippet185>

//<snippet186>
private void ToolStripDropDown1_Leave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.Leave event.");

}
//</snippet186>

//<snippet187>
private void ToolStripDropDown1_Opening(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Opening Event" );
}
//</snippet187>

//<snippet188>
private void ToolStripDropDown1_Opened(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.Opened event.");

}
//</snippet188>

//<snippet189>
private void ToolStripDropDown1_RegionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.RegionChanged event.");

}
//</snippet189>

//<snippet190>
private void ToolStripDropDown1_StyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDown.StyleChanged event.");

}
//</snippet190>

//<snippet191>
private void CurrencyManager1_ItemChanged(Object sender, ItemChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemChanged Event" );
}
//</snippet191>

//<snippet192>
private void CurrencyManager1_ListChanged(Object sender, ListChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewIndex", e.NewIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldIndex", e.OldIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PropertyDescriptor", e.PropertyDescriptor );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ListChanged Event" );
}
//</snippet192>

//<snippet193>
private void CurrencyManager1_MetaDataChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the CurrencyManager.MetaDataChanged event.");

}
//</snippet193>

//<snippet194>
private void DataGrid1_BorderStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.BorderStyleChanged event.");

}
//</snippet194>

//<snippet195>
private void DataGrid1_CaptionVisibleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.CaptionVisibleChanged event.");

}
//</snippet195>

//<snippet196>
private void DataGrid1_CurrentCellChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.CurrentCellChanged event.");

}
//</snippet196>

//<snippet197>
private void DataGrid1_DataSourceChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.DataSourceChanged event.");

}
//</snippet197>

//<snippet198>
private void DataGrid1_ParentRowsLabelStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.ParentRowsLabelStyleChanged event.");

}
//</snippet198>

//<snippet199>
private void DataGrid1_FlatModeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.FlatModeChanged event.");

}
//</snippet199>

//<snippet200>
private void DataGrid1_BackgroundColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.BackgroundColorChanged event.");

}
//</snippet200>

//<snippet201>
private void DataGrid1_AllowNavigationChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.AllowNavigationChanged event.");

}
//</snippet201>

//<snippet202>
private void DataGrid1_ReadOnlyChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.ReadOnlyChanged event.");

}
//</snippet202>

//<snippet203>
private void DataGrid1_ParentRowsVisibleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.ParentRowsVisibleChanged event.");

}
//</snippet203>

//<snippet204>
private void DataGrid1_Navigate(Object sender, NavigateEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Forward", e.Forward );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Navigate Event" );
}
//</snippet204>

//<snippet205>
private void DataGrid1_Scroll(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.Scroll event.");

}
//</snippet205>

//<snippet206>
private void DataGrid1_BackButtonClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.BackButtonClick event.");

}
//</snippet206>

//<snippet207>
private void DataGrid1_ShowParentDetailsButtonClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGrid.ShowParentDetailsButtonClick event.");

}
//</snippet207>

//<snippet208>
private void DataGridColumnStyle1_AlignmentChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.AlignmentChanged event.");

}
//</snippet208>

//<snippet209>
private void DataGridColumnStyle1_PropertyDescriptorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.PropertyDescriptorChanged event.");

}
//</snippet209>

//<snippet210>
private void DataGridColumnStyle1_FontChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.FontChanged event.");

}
//</snippet210>

//<snippet211>
private void DataGridColumnStyle1_HeaderTextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.HeaderTextChanged event.");

}
//</snippet211>

//<snippet212>
private void DataGridColumnStyle1_MappingNameChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.MappingNameChanged event.");

}
//</snippet212>

//<snippet213>
private void DataGridColumnStyle1_NullTextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.NullTextChanged event.");

}
//</snippet213>

//<snippet214>
private void DataGridColumnStyle1_ReadOnlyChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.ReadOnlyChanged event.");

}
//</snippet214>

//<snippet215>
private void DataGridColumnStyle1_WidthChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridColumnStyle.WidthChanged event.");

}
//</snippet215>

//<snippet216>
private void DataGridBoolColumn1_TrueValueChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridBoolColumn.TrueValueChanged event.");

}
//</snippet216>

//<snippet217>
private void DataGridBoolColumn1_FalseValueChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridBoolColumn.FalseValueChanged event.");

}
//</snippet217>

//<snippet218>
private void DataGridBoolColumn1_AllowNullChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridBoolColumn.AllowNullChanged event.");

}
//</snippet218>

//<snippet219>
private void GridColumnStylesCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}
//</snippet219>

//<snippet220>
private void DataGridTableStyle1_AllowSortingChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.AllowSortingChanged event.");

}
//</snippet220>

//<snippet221>
private void DataGridTableStyle1_AlternatingBackColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.AlternatingBackColorChanged event.");

}
//</snippet221>

//<snippet222>
private void DataGridTableStyle1_BackColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.BackColorChanged event.");

}
//</snippet222>

//<snippet223>
private void DataGridTableStyle1_ForeColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.ForeColorChanged event.");

}
//</snippet223>

//<snippet224>
private void DataGridTableStyle1_GridLineColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.GridLineColorChanged event.");

}
//</snippet224>

//<snippet225>
private void DataGridTableStyle1_GridLineStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.GridLineStyleChanged event.");

}
//</snippet225>

//<snippet226>
private void DataGridTableStyle1_HeaderBackColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.HeaderBackColorChanged event.");

}
//</snippet226>

//<snippet227>
private void DataGridTableStyle1_HeaderFontChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.HeaderFontChanged event.");

}
//</snippet227>

//<snippet228>
private void DataGridTableStyle1_HeaderForeColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.HeaderForeColorChanged event.");

}
//</snippet228>

//<snippet229>
private void DataGridTableStyle1_LinkColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.LinkColorChanged event.");

}
//</snippet229>

//<snippet230>
private void DataGridTableStyle1_LinkHoverColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.LinkHoverColorChanged event.");

}
//</snippet230>

//<snippet231>
private void DataGridTableStyle1_PreferredColumnWidthChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.PreferredColumnWidthChanged event.");

}
//</snippet231>

//<snippet232>
private void DataGridTableStyle1_PreferredRowHeightChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.PreferredRowHeightChanged event.");

}
//</snippet232>

//<snippet233>
private void DataGridTableStyle1_ColumnHeadersVisibleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.ColumnHeadersVisibleChanged event.");

}
//</snippet233>

//<snippet234>
private void DataGridTableStyle1_RowHeadersVisibleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.RowHeadersVisibleChanged event.");

}
//</snippet234>

//<snippet235>
private void DataGridTableStyle1_RowHeaderWidthChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.RowHeaderWidthChanged event.");

}
//</snippet235>

//<snippet236>
private void DataGridTableStyle1_SelectionBackColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.SelectionBackColorChanged event.");

}
//</snippet236>

//<snippet237>
private void DataGridTableStyle1_SelectionForeColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.SelectionForeColorChanged event.");

}
//</snippet237>

//<snippet238>
private void DataGridTableStyle1_MappingNameChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.MappingNameChanged event.");

}
//</snippet238>

//<snippet239>
private void DataGridTableStyle1_ReadOnlyChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridTableStyle.ReadOnlyChanged event.");

}
//</snippet239>

//<snippet240>
private void GridTableStylesCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}
//</snippet240>

//<snippet241>
private void TextBoxBase1_AcceptsTabChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBoxBase.AcceptsTabChanged event.");

}
//</snippet241>

//<snippet242>
private void TextBoxBase1_BorderStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBoxBase.BorderStyleChanged event.");

}
//</snippet242>

//<snippet243>
private void TextBoxBase1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBoxBase.Click event.");

}
//</snippet243>

//<snippet244>
private void TextBoxBase1_MouseClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event" );
}
//</snippet244>

//<snippet245>
private void TextBoxBase1_HideSelectionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBoxBase.HideSelectionChanged event.");

}
//</snippet245>

//<snippet246>
private void TextBoxBase1_ModifiedChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBoxBase.ModifiedChanged event.");

}
//</snippet246>

//<snippet247>
private void TextBoxBase1_MultilineChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBoxBase.MultilineChanged event.");

}
//</snippet247>

//<snippet248>
private void TextBoxBase1_ReadOnlyChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBoxBase.ReadOnlyChanged event.");

}
//</snippet248>

//<snippet249>
private void TextBox1_TextAlignChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TextBox.TextAlignChanged event.");

}
//</snippet249>

//<snippet250>
private void DataGridView1_AllowUserToAddRowsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.AllowUserToAddRowsChanged event.");

}
//</snippet250>

//<snippet251>
private void DataGridView1_AllowUserToDeleteRowsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.AllowUserToDeleteRowsChanged event.");

}
//</snippet251>

//<snippet252>
private void DataGridView1_AllowUserToOrderColumnsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.AllowUserToOrderColumnsChanged event.");

}
//</snippet252>

//<snippet253>
private void DataGridView1_AllowUserToResizeColumnsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.AllowUserToResizeColumnsChanged event.");

}
//</snippet253>

//<snippet254>
private void DataGridView1_AllowUserToResizeRowsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.AllowUserToResizeRowsChanged event.");

}
//</snippet254>

//<snippet255>
private void DataGridView1_AlternatingRowsDefaultCellStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.AlternatingRowsDefaultCellStyleChanged event.");

}
//</snippet255>

//<snippet256>
private void DataGridView1_AutoGenerateColumnsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.AutoGenerateColumnsChanged event.");

}
//</snippet256>

//<snippet257>
private void DataGridView1_AutoSizeColumnsModeChanged(Object sender, DataGridViewAutoSizeColumnsModeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "PreviousModes", e.PreviousModes );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AutoSizeColumnsModeChanged Event" );
}
//</snippet257>

//<snippet258>
private void DataGridView1_AutoSizeRowsModeChanged(Object sender, DataGridViewAutoSizeModeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AutoSizeRowsModeChanged Event" );
}
//</snippet258>

//<snippet259>
private void DataGridView1_BackgroundColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.BackgroundColorChanged event.");

}
//</snippet259>

//<snippet260>
private void DataGridView1_BorderStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.BorderStyleChanged event.");

}
//</snippet260>

//<snippet261>
private void DataGridView1_CellBorderStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.CellBorderStyleChanged event.");

}
//</snippet261>

//<snippet262>
private void DataGridView1_ColumnHeadersBorderStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.ColumnHeadersBorderStyleChanged event.");

}
//</snippet262>

//<snippet263>
private void DataGridView1_ColumnHeadersDefaultCellStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.ColumnHeadersDefaultCellStyleChanged event.");

}
//</snippet263>

//<snippet264>
private void DataGridView1_ColumnHeadersHeightChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.ColumnHeadersHeightChanged event.");

}
//</snippet264>

//<snippet265>
private void DataGridView1_ColumnHeadersHeightSizeModeChanged(Object sender, DataGridViewAutoSizeModeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnHeadersHeightSizeModeChanged Event" );
}
//</snippet265>

//<snippet266>
private void DataGridView1_DataMemberChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.DataMemberChanged event.");

}
//</snippet266>

//<snippet267>
private void DataGridView1_DataSourceChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.DataSourceChanged event.");

}
//</snippet267>

//<snippet268>
private void DataGridView1_DefaultCellStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.DefaultCellStyleChanged event.");

}
//</snippet268>

//<snippet269>
private void DataGridView1_EditModeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.EditModeChanged event.");

}
//</snippet269>

//<snippet270>
private void DataGridView1_ForeColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.ForeColorChanged event.");

}
//</snippet270>

//<snippet271>
private void DataGridView1_FontChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.FontChanged event.");

}
//</snippet271>

//<snippet272>
private void DataGridView1_GridColorChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.GridColorChanged event.");

}
//</snippet272>

//<snippet273>
private void DataGridView1_MultiSelectChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.MultiSelectChanged event.");

}
//</snippet273>

//<snippet274>
private void DataGridView1_ReadOnlyChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.ReadOnlyChanged event.");

}
//</snippet274>

//<snippet275>
private void DataGridView1_RowHeadersBorderStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.RowHeadersBorderStyleChanged event.");

}
//</snippet275>

//<snippet276>
private void DataGridView1_RowHeadersDefaultCellStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.RowHeadersDefaultCellStyleChanged event.");

}
//</snippet276>

//<snippet277>
private void DataGridView1_RowHeadersWidthChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.RowHeadersWidthChanged event.");

}
//</snippet277>

//<snippet278>
private void DataGridView1_RowHeadersWidthSizeModeChanged(Object sender, DataGridViewAutoSizeModeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeadersWidthSizeModeChanged Event" );
}
//</snippet278>

//<snippet279>
private void DataGridView1_RowsDefaultCellStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.RowsDefaultCellStyleChanged event.");

}
//</snippet279>

//<snippet280>
private void DataGridView1_AutoSizeColumnModeChanged(Object sender, DataGridViewAutoSizeColumnModeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PreviousMode", e.PreviousMode );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AutoSizeColumnModeChanged Event" );
}
//</snippet280>

//<snippet281>
private void DataGridView1_CancelRowEdit(Object sender, QuestionEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Response", e.Response );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CancelRowEdit Event" );
}
//</snippet281>

//<snippet282>
private void DataGridView1_CellBeginEdit(Object sender, DataGridViewCellCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellBeginEdit Event" );
}
//</snippet282>

//<snippet283>
private void DataGridView1_CellClick(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellClick Event" );
}
//</snippet283>

//<snippet284>
private void DataGridView1_CellContentClick(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellContentClick Event" );
}
//</snippet284>

//<snippet285>
private void DataGridView1_CellContentDoubleClick(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellContentDoubleClick Event" );
}
//</snippet285>

//<snippet286>
private void DataGridView1_CellContextMenuStripChanged(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellContextMenuStripChanged Event" );
}
//</snippet286>

//<snippet287>
private void DataGridView1_CellContextMenuStripNeeded(Object sender, DataGridViewCellContextMenuStripNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ContextMenuStrip", e.ContextMenuStrip );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellContextMenuStripNeeded Event" );
}
//</snippet287>

//<snippet288>
private void DataGridView1_CellDoubleClick(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellDoubleClick Event" );
}
//</snippet288>

//<snippet289>
private void DataGridView1_CellEndEdit(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellEndEdit Event" );
}
//</snippet289>

//<snippet290>
private void DataGridView1_CellEnter(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellEnter Event" );
}
//</snippet290>

//<snippet291>
private void DataGridView1_CellErrorTextChanged(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellErrorTextChanged Event" );
}
//</snippet291>

//<snippet292>
private void DataGridView1_CellErrorTextNeeded(Object sender, DataGridViewCellErrorTextNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellErrorTextNeeded Event" );
}
//</snippet292>

//<snippet293>
private void DataGridView1_CellFormatting(Object sender, DataGridViewCellFormattingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "FormattingApplied", e.FormattingApplied );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellFormatting Event" );
}
//</snippet293>

//<snippet294>
private void DataGridView1_CellLeave(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellLeave Event" );
}
//</snippet294>

//<snippet295>
private void DataGridView1_CellMouseClick(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellMouseClick Event" );
}
//</snippet295>

//<snippet296>
private void DataGridView1_CellMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellMouseDoubleClick Event" );
}
//</snippet296>

//<snippet297>
private void DataGridView1_CellMouseDown(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellMouseDown Event" );
}
//</snippet297>

//<snippet298>
private void DataGridView1_CellMouseEnter(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellMouseEnter Event" );
}
//</snippet298>

//<snippet299>
private void DataGridView1_CellMouseLeave(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellMouseLeave Event" );
}
//</snippet299>

//<snippet300>
private void DataGridView1_CellMouseMove(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellMouseMove Event" );
}
//</snippet300>

//<snippet301>
private void DataGridView1_CellMouseUp(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellMouseUp Event" );
}
//</snippet301>

//<snippet302>
private void DataGridView1_CellPainting(Object sender, DataGridViewCellPaintingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AdvancedBorderStyle", e.AdvancedBorderStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "FormattedValue", e.FormattedValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PaintParts", e.PaintParts );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellPainting Event" );
}
//</snippet302>

//<snippet303>
private void DataGridView1_CellParsing(Object sender, DataGridViewCellParsingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "InheritedCellStyle", e.InheritedCellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ParsingApplied", e.ParsingApplied );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellParsing Event" );
}
//</snippet303>

//<snippet304>
private void DataGridView1_CellStateChanged(Object sender, DataGridViewCellStateChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cell", e.Cell );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellStateChanged Event" );
}
//</snippet304>

//<snippet305>
private void DataGridView1_CellStyleChanged(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellStyleChanged Event" );
}
//</snippet305>

//<snippet306>
private void DataGridView1_CellStyleContentChanged(Object sender, DataGridViewCellStyleContentChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyleScope", e.CellStyleScope );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellStyleContentChanged Event" );
}
//</snippet306>

//<snippet307>
private void DataGridView1_CellToolTipTextChanged(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellToolTipTextChanged Event" );
}
//</snippet307>

//<snippet308>
private void DataGridView1_CellToolTipTextNeeded(Object sender, DataGridViewCellToolTipTextNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ToolTipText", e.ToolTipText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellToolTipTextNeeded Event" );
}
//</snippet308>

//<snippet309>
private void DataGridView1_CellValidated(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellValidated Event" );
}
//</snippet309>

//<snippet310>
private void DataGridView1_CellValidating(Object sender, DataGridViewCellValidatingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "FormattedValue", e.FormattedValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellValidating Event" );
}
//</snippet310>

//<snippet311>
private void DataGridView1_CellValueChanged(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellValueChanged Event" );
}
//</snippet311>

//<snippet312>
private void DataGridView1_CellValueNeeded(Object sender, DataGridViewCellValueEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellValueNeeded Event" );
}
//</snippet312>

//<snippet313>
private void DataGridView1_CellValuePushed(Object sender, DataGridViewCellValueEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Value", e.Value );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellValuePushed Event" );
}
//</snippet313>

//<snippet314>
private void DataGridView1_ColumnAdded(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnAdded Event" );
}
//</snippet314>

//<snippet315>
private void DataGridView1_ColumnContextMenuStripChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnContextMenuStripChanged Event" );
}
//</snippet315>

//<snippet316>
private void DataGridView1_ColumnDataPropertyNameChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnDataPropertyNameChanged Event" );
}
//</snippet316>

//<snippet317>
private void DataGridView1_ColumnDefaultCellStyleChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnDefaultCellStyleChanged Event" );
}
//</snippet317>

//<snippet318>
private void DataGridView1_ColumnDisplayIndexChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnDisplayIndexChanged Event" );
}
//</snippet318>

//<snippet319>
private void DataGridView1_ColumnDividerDoubleClick(Object sender, DataGridViewColumnDividerDoubleClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnDividerDoubleClick Event" );
}
//</snippet319>

//<snippet320>
private void DataGridView1_ColumnDividerWidthChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnDividerWidthChanged Event" );
}
//</snippet320>

//<snippet321>
private void DataGridView1_ColumnHeaderMouseClick(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnHeaderMouseClick Event" );
}
//</snippet321>

//<snippet322>
private void DataGridView1_ColumnHeaderMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnHeaderMouseDoubleClick Event" );
}
//</snippet322>

//<snippet323>
private void DataGridView1_ColumnHeaderCellChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnHeaderCellChanged Event" );
}
//</snippet323>

//<snippet324>
private void DataGridView1_ColumnMinimumWidthChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnMinimumWidthChanged Event" );
}
//</snippet324>

//<snippet325>
private void DataGridView1_ColumnNameChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnNameChanged Event" );
}
//</snippet325>

//<snippet326>
private void DataGridView1_ColumnRemoved(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnRemoved Event" );
}
//</snippet326>

//<snippet327>
private void DataGridView1_ColumnSortModeChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnSortModeChanged Event" );
}
//</snippet327>

//<snippet328>
private void DataGridView1_ColumnStateChanged(Object sender, DataGridViewColumnStateChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnStateChanged Event" );
}
//</snippet328>

//<snippet329>
private void DataGridView1_ColumnToolTipTextChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnToolTipTextChanged Event" );
}
//</snippet329>

//<snippet330>
private void DataGridView1_ColumnWidthChanged(Object sender, DataGridViewColumnEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnWidthChanged Event" );
}
//</snippet330>

//<snippet331>
private void DataGridView1_CurrentCellChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.CurrentCellChanged event.");

}
//</snippet331>

//<snippet332>
private void DataGridView1_CurrentCellDirtyStateChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.CurrentCellDirtyStateChanged event.");

}
//</snippet332>

//<snippet333>
private void DataGridView1_DataBindingComplete(Object sender, DataGridViewBindingCompleteEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DataBindingComplete Event" );
}
//</snippet333>

//<snippet334>
private void DataGridView1_DataError(Object sender, DataGridViewDataErrorEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Context", e.Context );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Exception", e.Exception );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ThrowException", e.ThrowException );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DataError Event" );
}
//</snippet334>

//<snippet335>
private void DataGridView1_DefaultValuesNeeded(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DefaultValuesNeeded Event" );
}
//</snippet335>

//<snippet336>
private void DataGridView1_EditingControlShowing(Object sender, DataGridViewEditingControlShowingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "EditingControlShowing Event" );
}
//</snippet336>

//<snippet337>
private void DataGridView1_NewRowNeeded(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "NewRowNeeded Event" );
}
//</snippet337>

//<snippet338>
private void DataGridView1_RowContextMenuStripChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowContextMenuStripChanged Event" );
}
//</snippet338>

//<snippet339>
private void DataGridView1_RowContextMenuStripNeeded(Object sender, DataGridViewRowContextMenuStripNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ContextMenuStrip", e.ContextMenuStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowContextMenuStripNeeded Event" );
}
//</snippet339>

//<snippet340>
private void DataGridView1_RowDefaultCellStyleChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowDefaultCellStyleChanged Event" );
}
//</snippet340>

//<snippet341>
private void DataGridView1_RowDirtyStateNeeded(Object sender, QuestionEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Response", e.Response );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowDirtyStateNeeded Event" );
}
//</snippet341>

//<snippet342>
private void DataGridView1_RowDividerDoubleClick(Object sender, DataGridViewRowDividerDoubleClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowDividerDoubleClick Event" );
}
//</snippet342>

//<snippet343>
private void DataGridView1_RowDividerHeightChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowDividerHeightChanged Event" );
}
//</snippet343>

//<snippet344>
private void DataGridView1_RowEnter(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowEnter Event" );
}
//</snippet344>

//<snippet345>
private void DataGridView1_RowErrorTextChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowErrorTextChanged Event" );
}
//</snippet345>

//<snippet346>
private void DataGridView1_RowErrorTextNeeded(Object sender, DataGridViewRowErrorTextNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowErrorTextNeeded Event" );
}
//</snippet346>

//<snippet347>
private void DataGridView1_RowHeaderMouseClick(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeaderMouseClick Event" );
}
//</snippet347>

//<snippet348>
private void DataGridView1_RowHeaderMouseDoubleClick(Object sender, DataGridViewCellMouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeaderMouseDoubleClick Event" );
}
//</snippet348>

//<snippet349>
private void DataGridView1_RowHeaderCellChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeaderCellChanged Event" );
}
//</snippet349>

//<snippet350>
private void DataGridView1_RowHeightChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeightChanged Event" );
}
//</snippet350>

//<snippet351>
private void DataGridView1_RowHeightInfoNeeded(Object sender, DataGridViewRowHeightInfoNeededEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Height", e.Height );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeightInfoNeeded Event" );
}
//</snippet351>

//<snippet352>
private void DataGridView1_RowHeightInfoPushed(Object sender, DataGridViewRowHeightInfoPushedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Height", e.Height );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowHeightInfoPushed Event" );
}
//</snippet352>

//<snippet353>
private void DataGridView1_RowLeave(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowLeave Event" );
}
//</snippet353>

//<snippet354>
private void DataGridView1_RowMinimumHeightChanged(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowMinimumHeightChanged Event" );
}
//</snippet354>

//<snippet355>
private void DataGridView1_RowPostPaint(Object sender, DataGridViewRowPostPaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "InheritedRowStyle", e.InheritedRowStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsFirstDisplayedRow", e.IsFirstDisplayedRow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsLastVisibleRow", e.IsLastVisibleRow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowBounds", e.RowBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowPostPaint Event" );
}
//</snippet355>

//<snippet356>
private void DataGridView1_RowPrePaint(Object sender, DataGridViewRowPrePaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "InheritedRowStyle", e.InheritedRowStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsFirstDisplayedRow", e.IsFirstDisplayedRow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsLastVisibleRow", e.IsLastVisibleRow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "PaintParts", e.PaintParts );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowBounds", e.RowBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowPrePaint Event" );
}
//</snippet356>

//<snippet357>
private void DataGridView1_RowsAdded(Object sender, DataGridViewRowsAddedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowCount", e.RowCount );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowsAdded Event" );
}
//</snippet357>

//<snippet358>
private void DataGridView1_RowsRemoved(Object sender, DataGridViewRowsRemovedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowCount", e.RowCount );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowsRemoved Event" );
}
//</snippet358>

//<snippet359>
private void DataGridView1_RowStateChanged(Object sender, DataGridViewRowStateChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowStateChanged Event" );
}
//</snippet359>

//<snippet360>
private void DataGridView1_RowUnshared(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowUnshared Event" );
}
//</snippet360>

//<snippet361>
private void DataGridView1_RowValidated(Object sender, DataGridViewCellEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowValidated Event" );
}
//</snippet361>

//<snippet362>
private void DataGridView1_RowValidating(Object sender, DataGridViewCellCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RowValidating Event" );
}
//</snippet362>

//<snippet363>
private void DataGridView1_Scroll(Object sender, ScrollEventArgs e) {

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
//</snippet363>

//<snippet364>
private void DataGridView1_SelectionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.SelectionChanged event.");

}
//</snippet364>

//<snippet365>
private void DataGridView1_SortCompare(Object sender, DataGridViewSortCompareEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CellValue1", e.CellValue1 );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CellValue2", e.CellValue2 );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex1", e.RowIndex1 );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RowIndex2", e.RowIndex2 );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SortResult", e.SortResult );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SortCompare Event" );
}
//</snippet365>

//<snippet366>
private void DataGridView1_Sorted(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridView.Sorted event.");

}
//</snippet366>

//<snippet367>
private void DataGridView1_UserAddedRow(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "UserAddedRow Event" );
}
//</snippet367>

//<snippet368>
private void DataGridView1_UserDeletedRow(Object sender, DataGridViewRowEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "UserDeletedRow Event" );
}
//</snippet368>

//<snippet369>
private void DataGridView1_UserDeletingRow(Object sender, DataGridViewRowCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "UserDeletingRow Event" );
}
//</snippet369>

//<snippet370>
private void DataGridViewColumn1_Disposed(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DataGridViewColumn.Disposed event.");

}
//</snippet370>

//<snippet371>
private void DataGridViewCellCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}
//</snippet371>

//<snippet372>
private void DataGridViewColumnCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}
//</snippet372>

//<snippet373>
private void DataGridViewRowCollection1_CollectionChanged(Object sender, CollectionChangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Element", e.Element );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CollectionChanged Event" );
}
//</snippet373>

//<snippet374>
private void DateTimePicker1_FormatChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DateTimePicker.FormatChanged event.");

}
//</snippet374>

//<snippet375>
private void DateTimePicker1_TextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DateTimePicker.TextChanged event.");

}
//</snippet375>

//<snippet376>
private void DateTimePicker1_CloseUp(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DateTimePicker.CloseUp event.");

}
//</snippet376>

//<snippet377>
private void DateTimePicker1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DateTimePicker.RightToLeftLayoutChanged event.");

}
//</snippet377>

//<snippet378>
private void DateTimePicker1_ValueChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DateTimePicker.ValueChanged event.");

}
//</snippet378>

//<snippet379>
private void DateTimePicker1_DropDown(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DateTimePicker.DropDown event.");

}
//</snippet379>

//<snippet380>
private void UpDownBase1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the UpDownBase.AutoSizeChanged event.");

}
//</snippet380>

//<snippet381>
private void DomainUpDown1_SelectedItemChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the DomainUpDown.SelectedItemChanged event.");

}
//</snippet381>

//<snippet382>
private void ErrorProvider1_RightToLeftChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ErrorProvider.RightToLeftChanged event.");

}
//</snippet382>

//<snippet383>
private void FileDialog1_FileOk(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "FileOk Event" );
}
//</snippet383>

//<snippet384>
private void Panel1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Panel.AutoSizeChanged event.");

}
//</snippet384>

//<snippet385>
private void FontDialog1_Apply(Object sender, EventArgs e) {

   MessageBox.Show("You are in the FontDialog.Apply event.");

}
//</snippet385>

//<snippet386>
private void Form1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.AutoSizeChanged event.");

}
//</snippet386>

//<snippet387>
private void Form1_AutoValidateChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.AutoValidateChanged event.");

}
//</snippet387>

//<snippet388>
private void Form1_HelpButtonClicked(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "HelpButtonClicked Event" );
}
//</snippet388>

//<snippet389>
private void Form1_MaximizedBoundsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.MaximizedBoundsChanged event.");

}
//</snippet389>

//<snippet390>
private void Form1_MaximumSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.MaximumSizeChanged event.");

}
//</snippet390>

//<snippet391>
private void Form1_MinimumSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.MinimumSizeChanged event.");

}
//</snippet391>

//<snippet392>
private void Form1_Activated(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.Activated event.");

}
//</snippet392>

//<snippet393>
private void Form1_Deactivate(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.Deactivate event.");

}
//</snippet393>

//<snippet394>
private void Form1_FormClosing(Object sender, FormClosingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event" );
}
//</snippet394>

//<snippet395>
private void Form1_FormClosed(Object sender, FormClosedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "FormClosed Event" );
}
//</snippet395>

//<snippet396>
private void Form1_Load(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.Load event.");

}
//</snippet396>

//<snippet397>
private void Form1_MdiChildActivate(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.MdiChildActivate event.");

}
//</snippet397>

//<snippet398>
private void Form1_MenuComplete(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.MenuComplete event.");

}
//</snippet398>

//<snippet399>
private void Form1_MenuStart(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.MenuStart event.");

}
//</snippet399>

//<snippet400>
private void Form1_InputLanguageChanged(Object sender, InputLanguageChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Culture", e.Culture );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CharSet", e.CharSet );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "InputLanguageChanged Event" );
}
//</snippet400>

//<snippet401>
private void Form1_InputLanguageChanging(Object sender, InputLanguageChangingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Culture", e.Culture );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SysCharSet", e.SysCharSet );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "InputLanguageChanging Event" );
}
//</snippet401>

//<snippet402>
private void Form1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.RightToLeftLayoutChanged event.");

}
//</snippet402>

//<snippet403>
private void Form1_Shown(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.Shown event.");

}
//</snippet403>

//<snippet404>
private void Form1_ResizeBegin(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.ResizeBegin event.");

}
//</snippet404>

//<snippet405>
private void Form1_ResizeEnd(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Form.ResizeEnd event.");

}
//</snippet405>

//<snippet406>
private void GroupBox1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the GroupBox.AutoSizeChanged event.");

}
//</snippet406>

//<snippet407>
private void GroupBox1_TabStopChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the GroupBox.TabStopChanged event.");

}
//</snippet407>

//<snippet408>
private void GroupBox1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the GroupBox.Click event.");

}
//</snippet408>

//<snippet409>
private void GroupBox1_MouseClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event" );
}
//</snippet409>

//<snippet410>
private void GroupBox1_DoubleClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the GroupBox.DoubleClick event.");

}
//</snippet410>

//<snippet411>
private void GroupBox1_MouseDoubleClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDoubleClick Event" );
}
//</snippet411>

//<snippet412>
private void GroupBox1_KeyUp(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyUp Event" );
}
//</snippet412>

//<snippet413>
private void GroupBox1_KeyDown(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event" );
}
//</snippet413>

//<snippet414>
private void GroupBox1_KeyPress(Object sender, KeyPressEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyPress Event" );
}
//</snippet414>

//<snippet415>
private void GroupBox1_MouseDown(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDown Event" );
}
//</snippet415>

//<snippet416>
private void GroupBox1_MouseUp(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseUp Event" );
}
//</snippet416>

//<snippet417>
private void GroupBox1_MouseMove(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event" );
}
//</snippet417>

//<snippet418>
private void GroupBox1_MouseEnter(Object sender, EventArgs e) {

   MessageBox.Show("You are in the GroupBox.MouseEnter event.");

}
//</snippet418>

//<snippet419>
private void GroupBox1_MouseLeave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the GroupBox.MouseLeave event.");

}
//</snippet419>

//<snippet420>
private void ScrollBar1_Scroll(Object sender, ScrollEventArgs e) {

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
//</snippet420>

//<snippet421>
private void ScrollBar1_ValueChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ScrollBar.ValueChanged event.");

}
//</snippet421>

//<snippet422>
private void HtmlDocument1_Click(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Click Event" );
}
//</snippet422>

//<snippet423>
private void HtmlDocument1_ContextMenuShowing(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "ContextMenuShowing Event" );
}
//</snippet423>

//<snippet424>
private void HtmlDocument1_Focusing(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Focusing Event" );
}
//</snippet424>

//<snippet425>
private void HtmlDocument1_LosingFocus(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "LosingFocus Event" );
}
//</snippet425>

//<snippet426>
private void HtmlDocument1_MouseDown(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseDown Event" );
}
//</snippet426>

//<snippet427>
private void HtmlDocument1_MouseLeave(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseLeave Event" );
}
//</snippet427>

//<snippet428>
private void HtmlDocument1_MouseMove(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event" );
}
//</snippet428>

//<snippet429>
private void HtmlDocument1_MouseOver(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseOver Event" );
}
//</snippet429>

//<snippet430>
private void HtmlDocument1_MouseUp(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseUp Event" );
}
//</snippet430>

//<snippet431>
private void HtmlDocument1_Stop(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Stop Event" );
}
//</snippet431>

//<snippet432>
private void HtmlElement1_Click(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Click Event" );
}
//</snippet432>

//<snippet433>
private void HtmlElement1_DoubleClick(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "DoubleClick Event" );
}
//</snippet433>

//<snippet434>
private void HtmlElement1_Drag(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Drag Event" );
}
//</snippet434>

//<snippet435>
private void HtmlElement1_DragEnd(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "DragEnd Event" );
}
//</snippet435>

//<snippet436>
private void HtmlElement1_DragLeave(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "DragLeave Event" );
}
//</snippet436>

//<snippet437>
private void HtmlElement1_DragOver(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "DragOver Event" );
}
//</snippet437>

//<snippet438>
private void HtmlElement1_Focusing(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Focusing Event" );
}
//</snippet438>

//<snippet439>
private void HtmlElement1_GotFocus(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "GotFocus Event" );
}
//</snippet439>

//<snippet440>
private void HtmlElement1_LosingFocus(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "LosingFocus Event" );
}
//</snippet440>

//<snippet441>
private void HtmlElement1_LostFocus(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "LostFocus Event" );
}
//</snippet441>

//<snippet442>
private void HtmlElement1_KeyDown(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event" );
}
//</snippet442>

//<snippet443>
private void HtmlElement1_KeyPress(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "KeyPress Event" );
}
//</snippet443>

//<snippet444>
private void HtmlElement1_KeyUp(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "KeyUp Event" );
}
//</snippet444>

//<snippet445>
private void HtmlElement1_MouseMove(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event" );
}
//</snippet445>

//<snippet446>
private void HtmlElement1_MouseDown(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseDown Event" );
}
//</snippet446>

//<snippet447>
private void HtmlElement1_MouseOver(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseOver Event" );
}
//</snippet447>

//<snippet448>
private void HtmlElement1_MouseUp(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseUp Event" );
}
//</snippet448>

//<snippet449>
private void HtmlElement1_MouseEnter(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseEnter Event" );
}
//</snippet449>

//<snippet450>
private void HtmlElement1_MouseLeave(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "MouseLeave Event" );
}
//</snippet450>

//<snippet451>
private void HtmlWindow1_Error(Object sender, HtmlElementErrorEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Description", e.Description );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "LineNumber", e.LineNumber );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Url", e.Url );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Error Event" );
}
//</snippet451>

//<snippet452>
private void HtmlWindow1_GotFocus(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "GotFocus Event" );
}
//</snippet452>

//<snippet453>
private void HtmlWindow1_Load(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Load Event" );
}
//</snippet453>

//<snippet454>
private void HtmlWindow1_LostFocus(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "LostFocus Event" );
}
//</snippet454>

//<snippet455>
private void HtmlWindow1_Resize(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Resize Event" );
}
//</snippet455>

//<snippet456>
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
//</snippet456>

//<snippet457>
private void HtmlWindow1_Unload(Object sender, HtmlElementEventArgs e) {

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
MessageBox.Show(messageBoxCS.ToString(), "Unload Event" );
}
//</snippet457>

//<snippet458>
private void Label1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Label.AutoSizeChanged event.");

}
//</snippet458>

//<snippet459>
private void Label1_TextAlignChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Label.TextAlignChanged event.");

}
//</snippet459>

//<snippet460>
private void LinkLabel1_TabStopChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the LinkLabel.TabStopChanged event.");

}
//</snippet460>

//<snippet461>
private void LinkLabel1_LinkClicked(Object sender, LinkLabelLinkClickedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Link", e.Link );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LinkClicked Event" );
}
//</snippet461>

//<snippet462>
private void ListView1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListView.RightToLeftLayoutChanged event.");

}
//</snippet462>

//<snippet463>
private void ListView1_AfterLabelEdit(Object sender, LabelEditEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Label", e.Label );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AfterLabelEdit Event" );
}
//</snippet463>

//<snippet464>
private void ListView1_BeforeLabelEdit(Object sender, LabelEditEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Label", e.Label );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BeforeLabelEdit Event" );
}
//</snippet464>

//<snippet465>
private void ListView1_CacheVirtualItems(Object sender, CacheVirtualItemsEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CacheVirtualItems Event" );
}
//</snippet465>

//<snippet466>
private void ListView1_ColumnClick(Object sender, ColumnClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnClick Event" );
}
//</snippet466>

//<snippet467>
private void ListView1_ColumnReordered(Object sender, ColumnReorderedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "OldDisplayIndex", e.OldDisplayIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewDisplayIndex", e.NewDisplayIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Header", e.Header );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnReordered Event" );
}
//</snippet467>

//<snippet468>
private void ListView1_ColumnWidthChanged(Object sender, ColumnWidthChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnWidthChanged Event" );
}
//</snippet468>

//<snippet469>
private void ListView1_ColumnWidthChanging(Object sender, ColumnWidthChangingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewWidth", e.NewWidth );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ColumnWidthChanging Event" );
}
//</snippet469>

//<snippet470>
private void ListView1_DrawColumnHeader(Object sender, DrawListViewColumnHeaderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Header", e.Header );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawColumnHeader Event" );
}
//</snippet470>

//<snippet471>
private void ListView1_DrawItem(Object sender, DrawListViewItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}
//</snippet471>

//<snippet472>
private void ListView1_DrawSubItem(Object sender, DrawListViewSubItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SubItem", e.SubItem );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Header", e.Header );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemState", e.ItemState );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawSubItem Event" );
}
//</snippet472>

//<snippet473>
private void ListView1_ItemActivate(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListView.ItemActivate event.");

}
//</snippet473>

//<snippet474>
private void ListView1_ItemCheck(Object sender, ItemCheckEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewValue", e.NewValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemCheck Event" );
}
//</snippet474>

//<snippet475>
private void ListView1_ItemChecked(Object sender, ItemCheckedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemChecked Event" );
}
//</snippet475>

//<snippet476>
private void ListView1_ItemDrag(Object sender, ItemDragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemDrag Event" );
}
//</snippet476>

//<snippet477>
private void ListView1_ItemMouseHover(Object sender, ListViewItemMouseHoverEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemMouseHover Event" );
}
//</snippet477>

//<snippet478>
private void ListView1_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemSelectionChanged Event" );
}
//</snippet478>

//<snippet479>
private void ListView1_RetrieveVirtualItem(Object sender, RetrieveVirtualItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RetrieveVirtualItem Event" );
}
//</snippet479>

//<snippet480>
private void ListView1_SearchForVirtualItem(Object sender, SearchForVirtualItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "IsTextSearch", e.IsTextSearch );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IncludeSubItemsInSearch", e.IncludeSubItemsInSearch );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsPrefixSearch", e.IsPrefixSearch );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Text", e.Text );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StartingPoint", e.StartingPoint );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Direction", e.Direction );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SearchForVirtualItem Event" );
}
//</snippet480>

//<snippet481>
private void ListView1_SelectedIndexChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ListView.SelectedIndexChanged event.");

}
//</snippet481>

//<snippet482>
private void ListView1_VirtualItemsSelectionRangeChanged(Object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "VirtualItemsSelectionRangeChanged Event" );
}
//</snippet482>

//<snippet483>
private void MainMenu1_Collapse(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MainMenu.Collapse event.");

}
//</snippet483>

//<snippet484>
private void MaskedTextBox1_IsOverwriteModeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MaskedTextBox.IsOverwriteModeChanged event.");

}
//</snippet484>

//<snippet485>
private void MaskedTextBox1_MaskChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MaskedTextBox.MaskChanged event.");

}
//</snippet485>

//<snippet486>
private void MaskedTextBox1_MaskInputRejected(Object sender, MaskInputRejectedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Position", e.Position );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "RejectionHint", e.RejectionHint );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MaskInputRejected Event" );
}
//</snippet486>

//<snippet487>
private void MaskedTextBox1_TextAlignChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MaskedTextBox.TextAlignChanged event.");

}
//</snippet487>

//<snippet488>
private void MaskedTextBox1_TypeValidationCompleted(Object sender, TypeValidationEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsValidInput", e.IsValidInput );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Message", e.Message );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ValidatingType", e.ValidatingType );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "TypeValidationCompleted Event" );
}
//</snippet488>

//<snippet489>
private void MenuStrip1_MenuActivate(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MenuStrip.MenuActivate event.");

}
//</snippet489>

//<snippet490>
private void MenuStrip1_MenuDeactivate(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MenuStrip.MenuDeactivate event.");

}
//</snippet490>

//<snippet491>
private void ToolStripDropDownItem1_DropDownClosed(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDownItem.DropDownClosed event.");

}
//</snippet491>

//<snippet492>
private void ToolStripDropDownItem1_DropDownOpening(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDownItem.DropDownOpening event.");

}
//</snippet492>

//<snippet493>
private void ToolStripDropDownItem1_DropDownOpened(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripDropDownItem.DropDownOpened event.");

}
//</snippet493>

//<snippet494>
private void ToolStripDropDownItem1_DropDownItemClicked(Object sender, ToolStripItemClickedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ClickedItem", e.ClickedItem );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DropDownItemClicked Event" );
}
//</snippet494>

//<snippet495>
private void ToolStripMenuItem1_CheckedChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripMenuItem.CheckedChanged event.");

}
//</snippet495>

//<snippet496>
private void ToolStripMenuItem1_CheckStateChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripMenuItem.CheckStateChanged event.");

}
//</snippet496>

//<snippet497>
private void MenuItem1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MenuItem.Click event.");

}
//</snippet497>

//<snippet498>
private void MenuItem1_DrawItem(Object sender, DrawItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}
//</snippet498>

//<snippet499>
private void MenuItem1_MeasureItem(Object sender, MeasureItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MeasureItem Event" );
}
//</snippet499>

//<snippet500>
private void MenuItem1_Popup(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MenuItem.Popup event.");

}
//</snippet500>

//<snippet501>
private void MenuItem1_Select(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MenuItem.Select event.");

}
//</snippet501>

//<snippet502>
private void MonthCalendar1_DateChanged(Object sender, DateRangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Start", e.Start );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "End", e.End );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DateChanged Event" );
}
//</snippet502>

//<snippet503>
private void MonthCalendar1_DateSelected(Object sender, DateRangeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Start", e.Start );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "End", e.End );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DateSelected Event" );
}
//</snippet503>

//<snippet504>
private void MonthCalendar1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the MonthCalendar.RightToLeftLayoutChanged event.");

}
//</snippet504>

//<snippet505>
private void NotifyIcon1_BalloonTipClicked(Object sender, EventArgs e) {

   MessageBox.Show("You are in the NotifyIcon.BalloonTipClicked event.");

}
//</snippet505>

//<snippet506>
private void NotifyIcon1_BalloonTipClosed(Object sender, EventArgs e) {

   MessageBox.Show("You are in the NotifyIcon.BalloonTipClosed event.");

}
//</snippet506>

//<snippet507>
private void NotifyIcon1_BalloonTipShown(Object sender, EventArgs e) {

   MessageBox.Show("You are in the NotifyIcon.BalloonTipShown event.");

}
//</snippet507>

//<snippet508>
private void NotifyIcon1_Click(Object sender, EventArgs e) {

   MessageBox.Show("You are in the NotifyIcon.Click event.");

}
//</snippet508>

//<snippet509>
private void NotifyIcon1_DoubleClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the NotifyIcon.DoubleClick event.");

}
//</snippet509>

//<snippet510>
private void NotifyIcon1_MouseClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseClick Event" );
}
//</snippet510>

//<snippet511>
private void NotifyIcon1_MouseDoubleClick(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDoubleClick Event" );
}
//</snippet511>

//<snippet512>
private void NotifyIcon1_MouseDown(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDown Event" );
}
//</snippet512>

//<snippet513>
private void NotifyIcon1_MouseMove(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event" );
}
//</snippet513>

//<snippet514>
private void NotifyIcon1_MouseUp(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseUp Event" );
}
//</snippet514>

//<snippet515>
private void NumericUpDown1_ValueChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the NumericUpDown.ValueChanged event.");

}
//</snippet515>

//<snippet516>
private void PictureBox1_LoadCompleted(Object sender, AsyncCompletedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancelled", e.Cancelled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Error", e.Error );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "UserState", e.UserState );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LoadCompleted Event" );
}
//</snippet516>

//<snippet517>
private void PictureBox1_LoadProgressChanged(Object sender, ProgressChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ProgressPercentage", e.ProgressPercentage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "UserState", e.UserState );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LoadProgressChanged Event" );
}
//</snippet517>

//<snippet518>
private void PictureBox1_SizeModeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the PictureBox.SizeModeChanged event.");

}
//</snippet518>

//<snippet519>
private void ProgressBar1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ProgressBar.RightToLeftLayoutChanged event.");

}
//</snippet519>


//<snippet521>
private void PropertyGrid1_TextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the PropertyGrid.TextChanged event.");

}
//</snippet521>

//<snippet522>
private void PropertyGrid1_KeyDown(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event" );
}
//</snippet522>

//<snippet523>
private void PropertyGrid1_KeyPress(Object sender, KeyPressEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyPress Event" );
}
//</snippet523>

//<snippet524>
private void PropertyGrid1_KeyUp(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyUp Event" );
}
//</snippet524>

//<snippet525>
private void PropertyGrid1_MouseDown(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseDown Event" );
}
//</snippet525>

//<snippet526>
private void PropertyGrid1_MouseUp(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseUp Event" );
}
//</snippet526>

//<snippet527>
private void PropertyGrid1_MouseMove(Object sender, MouseEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "MouseMove Event" );
}
//</snippet527>

//<snippet528>
private void PropertyGrid1_MouseEnter(Object sender, EventArgs e) {

   MessageBox.Show("You are in the PropertyGrid.MouseEnter event.");

}
//</snippet528>

//<snippet529>
private void PropertyGrid1_MouseLeave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the PropertyGrid.MouseLeave event.");

}
//</snippet529>

//<snippet530>
private void PropertyGrid1_PropertyValueChanged(Object sender, PropertyValueChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ChangedItem", e.ChangedItem );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldValue", e.OldValue );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "PropertyValueChanged Event" );
}
//</snippet530>

//<snippet531>
private void PropertyGrid1_PropertyTabChanged(Object sender, PropertyTabChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "OldTab", e.OldTab );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "NewTab", e.NewTab );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "PropertyTabChanged Event" );
}
//</snippet531>

//<snippet532>
private void PropertyGrid1_PropertySortChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the PropertyGrid.PropertySortChanged event.");

}
//</snippet532>

//<snippet533>
private void PropertyGrid1_SelectedGridItemChanged(Object sender, SelectedGridItemChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "NewSelection", e.NewSelection );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "OldSelection", e.OldSelection );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SelectedGridItemChanged Event" );
}
//</snippet533>

//<snippet534>
private void PropertyGrid1_SelectedObjectsChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the PropertyGrid.SelectedObjectsChanged event.");

}
//</snippet534>

//<snippet535>
private void RadioButton1_AppearanceChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the RadioButton.AppearanceChanged event.");

}
//</snippet535>

//<snippet536>
private void RadioButton1_CheckedChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the RadioButton.CheckedChanged event.");

}
//</snippet536>

//<snippet537>
private void RichTextBox1_ContentsResized(Object sender, ContentsResizedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "NewRectangle", e.NewRectangle );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ContentsResized Event" );
}
//</snippet537>

//<snippet538>
private void RichTextBox1_DragDrop(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragDrop Event" );
}
//</snippet538>

//<snippet539>
private void RichTextBox1_DragEnter(Object sender, DragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Data", e.Data );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyState", e.KeyState );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Effect", e.Effect );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DragEnter Event" );
}
//</snippet539>

//<snippet540>
private void RichTextBox1_HScroll(Object sender, EventArgs e) {

   MessageBox.Show("You are in the RichTextBox.HScroll event.");

}
//</snippet540>

//<snippet541>
private void RichTextBox1_LinkClicked(Object sender, LinkClickedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "LinkText", e.LinkText );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "LinkClicked Event" );
}
//</snippet541>

//<snippet542>
private void RichTextBox1_ImeChange(Object sender, EventArgs e) {

   MessageBox.Show("You are in the RichTextBox.ImeChange event.");

}
//</snippet542>

//<snippet543>
private void RichTextBox1_Protected(Object sender, EventArgs e) {

   MessageBox.Show("You are in the RichTextBox.Protected event.");

}
//</snippet543>

//<snippet544>
private void RichTextBox1_SelectionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the RichTextBox.SelectionChanged event.");

}
//</snippet544>

//<snippet545>
private void RichTextBox1_VScroll(Object sender, EventArgs e) {

   MessageBox.Show("You are in the RichTextBox.VScroll event.");

}
//</snippet545>

//<snippet546>
private void SplitContainer1_BackgroundImageChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the SplitContainer.BackgroundImageChanged event.");

}
//</snippet546>

//<snippet547>
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
//</snippet547>

//<snippet548>
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
//</snippet548>

//<snippet549>
private void Splitter1_SplitterMoving(Object sender, SplitterEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SplitX", e.SplitX );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SplitY", e.SplitY );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "SplitterMoving Event" );
}
//</snippet549>

//<snippet550>
private void Splitter1_SplitterMoved(Object sender, SplitterEventArgs e) {

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
//</snippet550>

//<snippet551>
private void StatusBar1_DrawItem(Object sender, StatusBarDrawItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Panel", e.Panel );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}
//</snippet551>

//<snippet552>
private void StatusBar1_PanelClick(Object sender, StatusBarPanelClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "StatusBarPanel", e.StatusBarPanel );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "PanelClick Event" );
}
//</snippet552>

//<snippet553>
private void StatusStrip1_PaddingChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the StatusStrip.PaddingChanged event.");

}
//</snippet553>

//<snippet554>
private void TabControl1_DrawItem(Object sender, DrawItemEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Index", e.Index );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawItem Event" );
}
//</snippet554>

//<snippet555>
private void TabControl1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TabControl.RightToLeftLayoutChanged event.");

}
//</snippet555>

//<snippet556>
private void TabControl1_SelectedIndexChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TabControl.SelectedIndexChanged event.");

}
//</snippet556>

//<snippet557>
private void TabControl1_Selecting(Object sender, TabControlCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Selecting Event" );
}
//</snippet557>

//<snippet558>
private void TabControl1_Selected(Object sender, TabControlEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Selected Event" );
}
//</snippet558>

//<snippet559>
private void TabControl1_Deselecting(Object sender, TabControlCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Deselecting Event" );
}
//</snippet559>

//<snippet560>
private void TabControl1_Deselected(Object sender, TabControlEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Deselected Event" );
}
//</snippet560>

//<snippet561>
private void TableLayoutPanel1_CellPaint(Object sender, TableLayoutCellPaintEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Row", e.Row );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Column", e.Column );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "CellPaint Event" );
}
//</snippet561>

//<snippet562>
private void TabPage1_TextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TabPage.TextChanged event.");

}
//</snippet562>

//<snippet563>
private void Timer1_Tick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the Timer.Tick event.");

}
//</snippet563>

//<snippet564>
private void ToolBar1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolBar.AutoSizeChanged event.");

}
//</snippet564>

//<snippet565>
private void ToolBar1_ButtonClick(Object sender, ToolBarButtonClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ButtonClick Event" );
}
//</snippet565>

//<snippet566>
private void ToolBar1_ButtonDropDown(Object sender, ToolBarButtonClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ButtonDropDown Event" );
}
//</snippet566>

//<snippet567>
private void ToolStripButton1_CheckedChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripButton.CheckedChanged event.");

}
//</snippet567>

//<snippet568>
private void ToolStripButton1_CheckStateChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripButton.CheckStateChanged event.");

}
//</snippet568>

//<snippet569>
private void ToolStripControlHost1_Enter(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripControlHost.Enter event.");

}
//</snippet569>

//<snippet570>
private void ToolStripControlHost1_GotFocus(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripControlHost.GotFocus event.");

}
//</snippet570>

//<snippet571>
private void ToolStripControlHost1_Leave(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripControlHost.Leave event.");

}
//</snippet571>

//<snippet572>
private void ToolStripControlHost1_LostFocus(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripControlHost.LostFocus event.");

}
//</snippet572>

//<snippet573>
private void ToolStripControlHost1_KeyDown(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyDown Event" );
}
//</snippet573>

//<snippet574>
private void ToolStripControlHost1_KeyPress(Object sender, KeyPressEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyPress Event" );
}
//</snippet574>

//<snippet575>
private void ToolStripControlHost1_KeyUp(Object sender, KeyEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Alt", e.Alt );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Control", e.Control );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "KeyData", e.KeyData );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Shift", e.Shift );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "KeyUp Event" );
}
//</snippet575>

//<snippet576>
private void ToolStripControlHost1_Validating(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Validating Event" );
}
//</snippet576>

//<snippet577>
private void ToolStripControlHost1_Validated(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripControlHost.Validated event.");

}
//</snippet577>

//<snippet578>
private void ToolStripComboBox1_DropDown(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripComboBox.DropDown event.");

}
//</snippet578>

//<snippet579>
private void ToolStripComboBox1_DropDownClosed(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripComboBox.DropDownClosed event.");

}
//</snippet579>

//<snippet580>
private void ToolStripComboBox1_DropDownStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripComboBox.DropDownStyleChanged event.");

}
//</snippet580>

//<snippet581>
private void ToolStripComboBox1_SelectedIndexChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripComboBox.SelectedIndexChanged event.");

}
//</snippet581>

//<snippet582>
private void ToolStripComboBox1_TextUpdate(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripComboBox.TextUpdate event.");

}
//</snippet582>

//<snippet583>
private void ToolStripRenderer1_RenderArrow(Object sender, ToolStripArrowRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "ArrowRectangle", e.ArrowRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ArrowColor", e.ArrowColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Direction", e.Direction );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderArrow Event" );
}
//</snippet583>

//<snippet584>
private void ToolStripRenderer1_RenderToolStripBackground(Object sender, ToolStripRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripBackground Event" );
}
//</snippet584>

//<snippet585>
private void ToolStripRenderer1_RenderToolStripPanelBackground(Object sender, ToolStripPanelRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStripPanel", e.ToolStripPanel );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripPanelBackground Event" );
}
//</snippet585>

//<snippet586>
private void ToolStripRenderer1_RenderToolStripContentPanelBackground(Object sender, ToolStripContentPanelRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Handled", e.Handled );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStripContentPanel", e.ToolStripContentPanel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripContentPanelBackground Event" );
}
//</snippet586>

//<snippet587>
private void ToolStripRenderer1_RenderToolStripBorder(Object sender, ToolStripRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripBorder Event" );
}
//</snippet587>

//<snippet588>
private void ToolStripRenderer1_RenderButtonBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderButtonBackground Event" );
}
//</snippet588>

//<snippet589>
private void ToolStripRenderer1_RenderDropDownButtonBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderDropDownButtonBackground Event" );
}
//</snippet589>

//<snippet590>
private void ToolStripRenderer1_RenderOverflowButtonBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderOverflowButtonBackground Event" );
}
//</snippet590>

//<snippet591>
private void ToolStripRenderer1_RenderGrip(Object sender, ToolStripGripRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "GripBounds", e.GripBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "GripDisplayStyle", e.GripDisplayStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "GripStyle", e.GripStyle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderGrip Event" );
}
//</snippet591>

//<snippet592>
private void ToolStripRenderer1_RenderItemBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderItemBackground Event" );
}
//</snippet592>

//<snippet593>
private void ToolStripRenderer1_RenderItemImage(Object sender, ToolStripItemImageRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Image", e.Image );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ImageRectangle", e.ImageRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderItemImage Event" );
}
//</snippet593>

//<snippet594>
private void ToolStripRenderer1_RenderItemCheck(Object sender, ToolStripItemImageRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Image", e.Image );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ImageRectangle", e.ImageRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderItemCheck Event" );
}
//</snippet594>

//<snippet595>
private void ToolStripRenderer1_RenderItemText(Object sender, ToolStripItemTextRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Text", e.Text );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextColor", e.TextColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextFont", e.TextFont );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextRectangle", e.TextRectangle );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextFormat", e.TextFormat );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TextDirection", e.TextDirection );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderItemText Event" );
}
//</snippet595>

//<snippet596>
private void ToolStripRenderer1_RenderImageMargin(Object sender, ToolStripRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderImageMargin Event" );
}
//</snippet596>

//<snippet597>
private void ToolStripRenderer1_RenderLabelBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderLabelBackground Event" );
}
//</snippet597>

//<snippet598>
private void ToolStripRenderer1_RenderMenuItemBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderMenuItemBackground Event" );
}
//</snippet598>

//<snippet599>
private void ToolStripRenderer1_RenderToolStripStatusLabelBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderToolStripStatusLabelBackground Event" );
}
//</snippet599>

//<snippet600>
private void ToolStripRenderer1_RenderStatusStripSizingGrip(Object sender, ToolStripRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "BackColor", e.BackColor );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderStatusStripSizingGrip Event" );
}
//</snippet600>

//<snippet601>
private void ToolStripRenderer1_RenderSplitButtonBackground(Object sender, ToolStripItemRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderSplitButtonBackground Event" );
}
//</snippet601>

//<snippet602>
private void ToolStripRenderer1_RenderSeparator(Object sender, ToolStripSeparatorRenderEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Vertical", e.Vertical );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "RenderSeparator Event" );
}
//</snippet602>

//<snippet603>
private void ToolStripManager1_RendererChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripManager.RendererChanged event.");

}
//</snippet603>

//<snippet604>
private void ToolStripContentPanel1_Load(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripContentPanel.Load event.");

}
//</snippet604>

//<snippet605>
private void ToolStripContentPanel1_RendererChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripContentPanel.RendererChanged event.");

}
//</snippet605>

//<snippet606>
private void ToolStripPanel1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripPanel.AutoSizeChanged event.");

}
//</snippet606>

//<snippet607>
private void ToolStripPanel1_RendererChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripPanel.RendererChanged event.");

}
//</snippet607>

//<snippet608>
private void ToolStripProgressBar1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripProgressBar.RightToLeftLayoutChanged event.");

}
//</snippet608>

//<snippet609>
private void ToolStripSplitButton1_ButtonClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripSplitButton.ButtonClick event.");

}
//</snippet609>

//<snippet610>
private void ToolStripSplitButton1_ButtonDoubleClick(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripSplitButton.ButtonDoubleClick event.");

}
//</snippet610>

//<snippet611>
private void ToolStripSplitButton1_DefaultItemChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripSplitButton.DefaultItemChanged event.");

}
//</snippet611>

//<snippet612>
private void ToolStripTextBox1_AcceptsTabChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripTextBox.AcceptsTabChanged event.");

}
//</snippet612>

//<snippet613>
private void ToolStripTextBox1_BorderStyleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripTextBox.BorderStyleChanged event.");

}
//</snippet613>

//<snippet614>
private void ToolStripTextBox1_HideSelectionChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripTextBox.HideSelectionChanged event.");

}
//</snippet614>

//<snippet615>
private void ToolStripTextBox1_ModifiedChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripTextBox.ModifiedChanged event.");

}
//</snippet615>

//<snippet616>
private void ToolStripTextBox1_ReadOnlyChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripTextBox.ReadOnlyChanged event.");

}
//</snippet616>

//<snippet617>
private void ToolStripTextBox1_TextBoxTextAlignChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the ToolStripTextBox.TextBoxTextAlignChanged event.");

}
//</snippet617>

//<snippet618>
private void ToolTip1_Draw(Object sender, DrawToolTipEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolTipText", e.ToolTipText );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Font", e.Font );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Draw Event" );
}
//</snippet618>

//<snippet619>
private void ToolTip1_Popup(Object sender, PopupEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "IsBalloon", e.IsBalloon );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "ToolTipSize", e.ToolTipSize );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Popup Event" );
}
//</snippet619>

//<snippet620>
private void TrackBar1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TrackBar.AutoSizeChanged event.");

}
//</snippet620>

//<snippet621>
private void TrackBar1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TrackBar.RightToLeftLayoutChanged event.");

}
//</snippet621>

//<snippet622>
private void TrackBar1_Scroll(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TrackBar.Scroll event.");

}
//</snippet622>

//<snippet623>
private void TrackBar1_ValueChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TrackBar.ValueChanged event.");

}
//</snippet623>

//<snippet624>
private void TreeView1_BeforeLabelEdit(Object sender, NodeLabelEditEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Label", e.Label );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BeforeLabelEdit Event" );
}
//</snippet624>

//<snippet625>
private void TreeView1_AfterLabelEdit(Object sender, NodeLabelEditEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Label", e.Label );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AfterLabelEdit Event" );
}
//</snippet625>

//<snippet626>
private void TreeView1_BeforeCheck(Object sender, TreeViewCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BeforeCheck Event" );
}
//</snippet626>

//<snippet627>
private void TreeView1_AfterCheck(Object sender, TreeViewEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AfterCheck Event" );
}
//</snippet627>

//<snippet628>
private void TreeView1_BeforeCollapse(Object sender, TreeViewCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BeforeCollapse Event" );
}
//</snippet628>

//<snippet629>
private void TreeView1_AfterCollapse(Object sender, TreeViewEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AfterCollapse Event" );
}
//</snippet629>

//<snippet630>
private void TreeView1_BeforeExpand(Object sender, TreeViewCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BeforeExpand Event" );
}
//</snippet630>

//<snippet631>
private void TreeView1_AfterExpand(Object sender, TreeViewEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AfterExpand Event" );
}
//</snippet631>

//<snippet632>
private void TreeView1_DrawNode(Object sender, DrawTreeNodeEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Graphics", e.Graphics );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Bounds", e.Bounds );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "State", e.State );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DrawNode Event" );
}
//</snippet632>

//<snippet633>
private void TreeView1_ItemDrag(Object sender, ItemDragEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Item", e.Item );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ItemDrag Event" );
}
//</snippet633>

//<snippet634>
private void TreeView1_NodeMouseHover(Object sender, TreeNodeMouseHoverEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "NodeMouseHover Event" );
}
//</snippet634>

//<snippet635>
private void TreeView1_BeforeSelect(Object sender, TreeViewCancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "BeforeSelect Event" );
}
//</snippet635>

//<snippet636>
private void TreeView1_AfterSelect(Object sender, TreeViewEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "AfterSelect Event" );
}
//</snippet636>

//<snippet637>
private void TreeView1_NodeMouseClick(Object sender, TreeNodeMouseClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "NodeMouseClick Event" );
}
//</snippet637>

//<snippet638>
private void TreeView1_NodeMouseDoubleClick(Object sender, TreeNodeMouseClickEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Node", e.Node );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "X", e.X );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "NodeMouseDoubleClick Event" );
}
//</snippet638>

//<snippet639>
private void TreeView1_RightToLeftLayoutChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the TreeView.RightToLeftLayoutChanged event.");

}
//</snippet639>

//<snippet640>
private void UserControl1_AutoSizeChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the UserControl.AutoSizeChanged event.");

}
//</snippet640>

//<snippet641>
private void UserControl1_AutoValidateChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the UserControl.AutoValidateChanged event.");

}
//</snippet641>

//<snippet642>
private void UserControl1_Load(Object sender, EventArgs e) {

   MessageBox.Show("You are in the UserControl.Load event.");

}
//</snippet642>

//<snippet643>
private void WebBrowser1_CanGoBackChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the WebBrowser.CanGoBackChanged event.");

}
//</snippet643>

//<snippet644>
private void WebBrowser1_CanGoForwardChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the WebBrowser.CanGoForwardChanged event.");

}
//</snippet644>

//<snippet645>
private void WebBrowser1_DocumentCompleted(Object sender, WebBrowserDocumentCompletedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Url", e.Url );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "DocumentCompleted Event" );
}
//</snippet645>

//<snippet646>
private void WebBrowser1_DocumentTitleChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the WebBrowser.DocumentTitleChanged event.");

}
//</snippet646>

//<snippet647>
private void WebBrowser1_EncryptionLevelChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the WebBrowser.EncryptionLevelChanged event.");

}
//</snippet647>

//<snippet648>
private void WebBrowser1_FileDownload(Object sender, EventArgs e) {

   MessageBox.Show("You are in the WebBrowser.FileDownload event.");

}
//</snippet648>

//<snippet649>
private void WebBrowser1_Navigated(Object sender, WebBrowserNavigatedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Url", e.Url );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Navigated Event" );
}
//</snippet649>

//<snippet650>
private void WebBrowser1_Navigating(Object sender, WebBrowserNavigatingEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Url", e.Url );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "TargetFrameName", e.TargetFrameName );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "Navigating Event" );
}
//</snippet650>

//<snippet651>
private void WebBrowser1_NewWindow(Object sender, CancelEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "NewWindow Event" );
}
//</snippet651>

//<snippet652>
private void WebBrowser1_ProgressChanged(Object sender, WebBrowserProgressChangedEventArgs e) {

System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
messageBoxCS.AppendFormat("{0} = {1}", "CurrentProgress", e.CurrentProgress );
messageBoxCS.AppendLine();
messageBoxCS.AppendFormat("{0} = {1}", "MaximumProgress", e.MaximumProgress );
messageBoxCS.AppendLine();
MessageBox.Show(messageBoxCS.ToString(), "ProgressChanged Event" );
}
//</snippet652>

//<snippet653>
private void WebBrowser1_StatusTextChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the WebBrowser.StatusTextChanged event.");

}
//</snippet653>

//<snippet654>
private void PrintPreviewControl1_StartPageChanged(Object sender, EventArgs e) {

   MessageBox.Show("You are in the PrintPreviewControl.StartPageChanged event.");

}
//</snippet654>

}
