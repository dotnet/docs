Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.ComponentModel


Friend Class Form1
	 Inherits Form


<STAThread()> _
Public Shared Sub Main()
    Application.EnableVisualStyles()
    Application.Run(New Form1())
End Sub

'<snippet1>
    Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs) 
     
        MessageBox.Show("You are in the Application.ApplicationExit event.")

    End Sub
'</snippet1>

'<snippet2>
    Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs) 
     
        MessageBox.Show("You are in the Application.Idle event.")

    End Sub
'</snippet2>

'<snippet3>
    Private Sub Application_EnterThreadModal(ByVal sender As Object, ByVal e As EventArgs) 
     

        MessageBox.Show("You are in the Application.EnterThreadModal event.")

    End Sub
'</snippet3>

'<snippet4>
    Private Sub Application_LeaveThreadModal(ByVal sender As Object, ByVal e As EventArgs) 

        MessageBox.Show("You are in the Application.LeaveThreadModal event.")

    End Sub
'</snippet4>

'<snippet5>
    Private Sub Application_ThreadException(ByVal sender As Object, _
    ByVal e As System.Threading.ThreadExceptionEventArgs)

        Dim messageBoxVB As New System.Text.StringBuilder()
        messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
        messageBoxVB.AppendLine()
        MessageBox.Show(messageBoxVB.ToString(), "ThreadException Event")

    End Sub
'</snippet5>

'<snippet6>
    Private Sub Application_ThreadExit(ByVal sender As Object, ByVal e As EventArgs) 
    
        MessageBox.Show("You are in the Application.ThreadExit event.")

    End Sub
'</snippet6>

Public WithEvents Control1 as Control
'<snippet7>
Private Sub Control1_BackColorChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.BackColorChanged

   MessageBox.Show("You are in the Control.BackColorChanged event.")

End Sub
'</snippet7>

'<snippet8>
Private Sub Control1_BackgroundImageChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.BackgroundImageChanged

   MessageBox.Show("You are in the Control.BackgroundImageChanged event.")

End Sub
'</snippet8>

'<snippet9>
Private Sub Control1_BackgroundImageLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.BackgroundImageLayoutChanged

   MessageBox.Show("You are in the Control.BackgroundImageLayoutChanged event.")

End Sub
'</snippet9>

'<snippet10>
Private Sub Control1_BindingContextChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.BindingContextChanged

   MessageBox.Show("You are in the Control.BindingContextChanged event.")

End Sub
'</snippet10>

'<snippet11>
Private Sub Control1_CausesValidationChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.CausesValidationChanged

   MessageBox.Show("You are in the Control.CausesValidationChanged event.")

End Sub
'</snippet11>

'<snippet12>
Private Sub Control1_ClientSizeChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.ClientSizeChanged

   MessageBox.Show("You are in the Control.ClientSizeChanged event.")

End Sub
'</snippet12>

'<snippet13>
Private Sub Control1_ContextMenuChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.ContextMenuChanged

   MessageBox.Show("You are in the Control.ContextMenuChanged event.")

End Sub
'</snippet13>

'<snippet14>
Private Sub Control1_ContextMenuStripChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.ContextMenuStripChanged

   MessageBox.Show("You are in the Control.ContextMenuStripChanged event.")

End Sub
'</snippet14>

'<snippet15>
Private Sub Control1_CursorChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.CursorChanged

   MessageBox.Show("You are in the Control.CursorChanged event.")

End Sub
'</snippet15>

'<snippet16>
Private Sub Control1_DockChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.DockChanged

   MessageBox.Show("You are in the Control.DockChanged event.")

End Sub
'</snippet16>

'<snippet17>
Private Sub Control1_EnabledChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.EnabledChanged

   MessageBox.Show("You are in the Control.EnabledChanged event.")

End Sub
'</snippet17>

'<snippet18>
Private Sub Control1_FontChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.FontChanged

   MessageBox.Show("You are in the Control.FontChanged event.")

End Sub
'</snippet18>

'<snippet19>
Private Sub Control1_ForeColorChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.ForeColorChanged

   MessageBox.Show("You are in the Control.ForeColorChanged event.")

End Sub
'</snippet19>

'<snippet20>
Private Sub Control1_LocationChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.LocationChanged

   MessageBox.Show("You are in the Control.LocationChanged event.")

End Sub
'</snippet20>

'<snippet21>
Private Sub Control1_MarginChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.MarginChanged

   MessageBox.Show("You are in the Control.MarginChanged event.")

End Sub
'</snippet21>

'<snippet22>
Private Sub Control1_RegionChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.RegionChanged

   MessageBox.Show("You are in the Control.RegionChanged event.")

End Sub
'</snippet22>

'<snippet23>
Private Sub Control1_RightToLeftChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.RightToLeftChanged

   MessageBox.Show("You are in the Control.RightToLeftChanged event.")

End Sub
'</snippet23>

'<snippet24>
Private Sub Control1_SizeChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.SizeChanged

   MessageBox.Show("You are in the Control.SizeChanged event.")

End Sub
'</snippet24>

'<snippet25>
Private Sub Control1_TabIndexChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.TabIndexChanged

   MessageBox.Show("You are in the Control.TabIndexChanged event.")

End Sub
'</snippet25>

'<snippet26>
Private Sub Control1_TabStopChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.TabStopChanged

   MessageBox.Show("You are in the Control.TabStopChanged event.")

End Sub
'</snippet26>

'<snippet27>
Private Sub Control1_TextChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.TextChanged

   MessageBox.Show("You are in the Control.TextChanged event.")

End Sub
'</snippet27>

'<snippet28>
Private Sub Control1_VisibleChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.VisibleChanged

   MessageBox.Show("You are in the Control.VisibleChanged event.")

End Sub
'</snippet28>

'<snippet29>
Private Sub Control1_Click(sender as Object, e as EventArgs) _ 
     Handles Control1.Click

   MessageBox.Show("You are in the Control.Click event.")

End Sub
'</snippet29>

'<snippet30>
Private Sub Control1_ControlAdded(sender as Object, e as ControlEventArgs) _ 
     Handles Control1.ControlAdded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ControlAdded Event")

End Sub
'</snippet30>

'<snippet31>
Private Sub Control1_ControlRemoved(sender as Object, e as ControlEventArgs) _ 
     Handles Control1.ControlRemoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ControlRemoved Event")

End Sub
'</snippet31>

'<snippet32>
Private Sub Control1_DragDrop(sender as Object, e as DragEventArgs) _ 
     Handles Control1.DragDrop

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragDrop Event")

End Sub
'</snippet32>

'<snippet33>
Private Sub Control1_DragEnter(sender as Object, e as DragEventArgs) _ 
     Handles Control1.DragEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragEnter Event")

End Sub
'</snippet33>

'<snippet34>
Private Sub Control1_DragOver(sender as Object, e as DragEventArgs) _ 
     Handles Control1.DragOver

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragOver Event")

End Sub
'</snippet34>

'<snippet35>
Private Sub Control1_DragLeave(sender as Object, e as EventArgs) _ 
     Handles Control1.DragLeave

   MessageBox.Show("You are in the Control.DragLeave event.")

End Sub
'</snippet35>

'<snippet36>
Private Sub Control1_GiveFeedback(sender as Object, e as GiveFeedbackEventArgs) _ 
     Handles Control1.GiveFeedback

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "UseDefaultCursors", e.UseDefaultCursors)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"GiveFeedback Event")

End Sub
'</snippet36>

'<snippet37>
Private Sub Control1_HandleCreated(sender as Object, e as EventArgs) _ 
     Handles Control1.HandleCreated

   MessageBox.Show("You are in the Control.HandleCreated event.")

End Sub
'</snippet37>

'<snippet38>
Private Sub Control1_HandleDestroyed(sender as Object, e as EventArgs) _ 
     Handles Control1.HandleDestroyed

   MessageBox.Show("You are in the Control.HandleDestroyed event.")

End Sub
'</snippet38>

'<snippet39>
Private Sub Control1_HelpRequested(sender as Object, e as HelpEventArgs) _ 
     Handles Control1.HelpRequested

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePos", e.MousePos)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"HelpRequested Event")

End Sub
'</snippet39>

'<snippet40>
Private Sub Control1_Invalidated(sender as Object, e as InvalidateEventArgs) _ 
     Handles Control1.Invalidated

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "InvalidRect", e.InvalidRect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Invalidated Event")

End Sub
'</snippet40>

'<snippet41>
Private Sub Control1_PaddingChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.PaddingChanged

   MessageBox.Show("You are in the Control.PaddingChanged event.")

End Sub
'</snippet41>

'<snippet42>
Private Sub Control1_Paint(sender as Object, e as PaintEventArgs) _ 
     Handles Control1.Paint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Paint Event")

End Sub
'</snippet42>

'<snippet43>
Private Sub Control1_QueryContinueDrag(sender as Object, e as QueryContinueDragEventArgs) _ 
     Handles Control1.QueryContinueDrag

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EscapePressed", e.EscapePressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"QueryContinueDrag Event")

End Sub
'</snippet43>

'<snippet44>
Private Sub Control1_QueryAccessibilityHelp(sender as Object, e as QueryAccessibilityHelpEventArgs) _ 
     Handles Control1.QueryAccessibilityHelp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpNamespace", e.HelpNamespace)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpString", e.HelpString)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpKeyword", e.HelpKeyword)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"QueryAccessibilityHelp Event")

End Sub
'</snippet44>

'<snippet45>
Private Sub Control1_DoubleClick(sender as Object, e as EventArgs) _ 
     Handles Control1.DoubleClick

   MessageBox.Show("You are in the Control.DoubleClick event.")

End Sub
'</snippet45>

'<snippet46>
Private Sub Control1_Enter(sender as Object, e as EventArgs) _ 
     Handles Control1.Enter

   MessageBox.Show("You are in the Control.Enter event.")

End Sub
'</snippet46>

'<snippet47>
Private Sub Control1_GotFocus(sender as Object, e as EventArgs) _ 
     Handles Control1.GotFocus

Console.WriteLine("You are in the Control.GotFocus event.")

End Sub
'</snippet47>

'<snippet48>
Private Sub Control1_KeyDown(sender as Object, e as KeyEventArgs) _ 
     Handles Control1.KeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyDown Event")

End Sub
'</snippet48>

'<snippet49>
Private Sub Control1_KeyPress(sender as Object, e as KeyPressEventArgs) _ 
     Handles Control1.KeyPress

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyPress Event")

End Sub
'</snippet49>

'<snippet50>
Private Sub Control1_KeyUp(sender as Object, e as KeyEventArgs) _ 
     Handles Control1.KeyUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyUp Event")

End Sub
'</snippet50>

'<snippet51>
Private Sub Control1_Layout(sender as Object, e as LayoutEventArgs) _ 
     Handles Control1.Layout

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedComponent", e.AffectedComponent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedControl", e.AffectedControl)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedProperty", e.AffectedProperty)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Layout Event")

End Sub
'</snippet51>

'<snippet52>
Private Sub Control1_Leave(sender as Object, e as EventArgs) _ 
     Handles Control1.Leave

   MessageBox.Show("You are in the Control.Leave event.")

End Sub
'</snippet52>

'<snippet53>
Private Sub Control1_LostFocus(sender as Object, e as EventArgs) _ 
     Handles Control1.LostFocus

Console.WriteLine("You are in the Control.LostFocus event.")

End Sub
'</snippet53>

'<snippet54>
Private Sub Control1_MouseClick(sender as Object, e as MouseEventArgs) _ 
     Handles Control1.MouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseClick Event")

End Sub
'</snippet54>

'<snippet55>
Private Sub Control1_MouseDoubleClick(sender as Object, e as MouseEventArgs) _ 
     Handles Control1.MouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDoubleClick Event")

End Sub
'</snippet55>

'<snippet56>
Private Sub Control1_MouseCaptureChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.MouseCaptureChanged

   MessageBox.Show("You are in the Control.MouseCaptureChanged event.")

End Sub
'</snippet56>

'<snippet57>
Private Sub Control1_MouseDown(sender as Object, e as MouseEventArgs) _ 
     Handles Control1.MouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDown Event")

End Sub
'</snippet57>

'<snippet58>
Private Sub Control1_MouseEnter(sender as Object, e as EventArgs) _ 
     Handles Control1.MouseEnter

   MessageBox.Show("You are in the Control.MouseEnter event.")

End Sub
'</snippet58>

'<snippet59>
Private Sub Control1_MouseLeave(sender as Object, e as EventArgs) _ 
     Handles Control1.MouseLeave

   MessageBox.Show("You are in the Control.MouseLeave event.")

End Sub
'</snippet59>

'<snippet60>
Private Sub Control1_MouseHover(sender as Object, e as EventArgs) _ 
     Handles Control1.MouseHover

   MessageBox.Show("You are in the Control.MouseHover event.")

End Sub
'</snippet60>

'<snippet61>
Private Sub Control1_MouseMove(sender as Object, e as MouseEventArgs) _ 
     Handles Control1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub
'</snippet61>

'<snippet62>
Private Sub Control1_MouseUp(sender as Object, e as MouseEventArgs) _ 
     Handles Control1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub
'</snippet62>

'<snippet63>
Private Sub Control1_MouseWheel(sender as Object, e as MouseEventArgs) _ 
     Handles Control1.MouseWheel

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseWheel Event")

End Sub
'</snippet63>

'<snippet64>
Private Sub Control1_Move(sender as Object, e as EventArgs) _ 
     Handles Control1.Move

   MessageBox.Show("You are in the Control.Move event.")

End Sub
'</snippet64>

'<snippet65>
Private Sub Control1_PreviewKeyDown(sender as Object, e as PreviewKeyDownEventArgs) _ 
     Handles Control1.PreviewKeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsInputKey", e.IsInputKey)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PreviewKeyDown Event")

End Sub
'</snippet65>

'<snippet66>
Private Sub Control1_Resize(sender as Object, e as EventArgs) _ 
     Handles Control1.Resize

   MessageBox.Show("You are in the Control.Resize event.")

End Sub
'</snippet66>

'<snippet67>
Private Sub Control1_ChangeUICues(sender as Object, e as UICuesEventArgs) _ 
     Handles Control1.ChangeUICues

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ShowFocus", e.ShowFocus)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShowKeyboard", e.ShowKeyboard)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangeFocus", e.ChangeFocus)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangeKeyboard", e.ChangeKeyboard)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Changed", e.Changed)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ChangeUICues Event")

End Sub
'</snippet67>

'<snippet68>
Private Sub Control1_StyleChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.StyleChanged

   MessageBox.Show("You are in the Control.StyleChanged event.")

End Sub
'</snippet68>

'<snippet69>
Private Sub Control1_SystemColorsChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.SystemColorsChanged

   MessageBox.Show("You are in the Control.SystemColorsChanged event.")

End Sub
'</snippet69>

'<snippet70>
Private Sub Control1_Validating(sender as Object, e as CancelEventArgs) _ 
     Handles Control1.Validating

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Validating Event")

End Sub
'</snippet70>

'<snippet71>
Private Sub Control1_Validated(sender as Object, e as EventArgs) _ 
     Handles Control1.Validated

   MessageBox.Show("You are in the Control.Validated event.")

End Sub
'</snippet71>

'<snippet72>
Private Sub Control1_ParentChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.ParentChanged

   MessageBox.Show("You are in the Control.ParentChanged event.")

End Sub
'</snippet72>

'<snippet73>
Private Sub Control1_ImeModeChanged(sender as Object, e as EventArgs) _ 
     Handles Control1.ImeModeChanged

   MessageBox.Show("You are in the Control.ImeModeChanged event.")

End Sub
'</snippet73>

Public WithEvents ScrollableControl1 as ScrollableControl
'<snippet74>
Private Sub ScrollableControl1_Scroll(sender as Object, e as ScrollEventArgs) _ 
     Handles ScrollableControl1.Scroll

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ScrollOrientation", e.ScrollOrientation)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Type", e.Type)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldValue", e.OldValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Scroll Event")

End Sub
'</snippet74>

Public WithEvents ContainerControl1 as ContainerControl
Public WithEvents ApplicationContext1 as ApplicationContext
'<snippet75>
Private Sub ApplicationContext1_ThreadExit(sender as Object, e as EventArgs) _ 
     Handles ApplicationContext1.ThreadExit

   MessageBox.Show("You are in the ApplicationContext.ThreadExit event.")

End Sub
'</snippet75>

Public WithEvents AutoCompleteStringCollection1 as AutoCompleteStringCollection
'<snippet76>
Private Sub AutoCompleteStringCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles AutoCompleteStringCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub
'</snippet76>

Public WithEvents AxHost1 as AxHost
Public WithEvents Binding1 as Binding
'<snippet77>
Private Sub Binding1_BindingComplete(sender as Object, e as BindingCompleteEventArgs) _ 
     Handles Binding1.BindingComplete

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Binding", e.Binding)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BindingComplete Event")

End Sub
'</snippet77>

'<snippet78>
Private Sub Binding1_Parse(sender as Object, e as ConvertEventArgs) _ 
     Handles Binding1.Parse

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Parse Event")

End Sub
'</snippet78>

'<snippet79>
Private Sub Binding1_Format(sender as Object, e as ConvertEventArgs) _ 
     Handles Binding1.Format

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Format Event")

End Sub
'</snippet79>

Public WithEvents BindingContext1 as BindingContext
Public WithEvents BindingManagerBase1 as BindingManagerBase
'<snippet80>
Private Sub BindingManagerBase1_BindingComplete(sender as Object, e as BindingCompleteEventArgs) _ 
     Handles BindingManagerBase1.BindingComplete

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Binding", e.Binding)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BindingComplete Event")

End Sub
'</snippet80>

'<snippet81>
Private Sub BindingManagerBase1_CurrentChanged(sender as Object, e as EventArgs) _ 
     Handles BindingManagerBase1.CurrentChanged

   MessageBox.Show("You are in the BindingManagerBase.CurrentChanged event.")

End Sub
'</snippet81>

'<snippet82>
Private Sub BindingManagerBase1_CurrentItemChanged(sender as Object, e as EventArgs) _ 
     Handles BindingManagerBase1.CurrentItemChanged

   MessageBox.Show("You are in the BindingManagerBase.CurrentItemChanged event.")

End Sub
'</snippet82>

'<snippet83>
Private Sub BindingManagerBase1_DataError(sender as Object, e as BindingManagerDataErrorEventArgs) _ 
     Handles BindingManagerBase1.DataError

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DataError Event")

End Sub
'</snippet83>

'<snippet84>
Private Sub BindingManagerBase1_PositionChanged(sender as Object, e as EventArgs) _ 
     Handles BindingManagerBase1.PositionChanged

   MessageBox.Show("You are in the BindingManagerBase.PositionChanged event.")

End Sub
'</snippet84>

Public WithEvents ToolStrip1 as ToolStrip
'<snippet85>
Private Sub ToolStrip1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.AutoSizeChanged

   MessageBox.Show("You are in the ToolStrip.AutoSizeChanged event.")

End Sub
'</snippet85>

'<snippet86>
Private Sub ToolStrip1_BeginDrag(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.BeginDrag

   MessageBox.Show("You are in the ToolStrip.BeginDrag event.")

End Sub
'</snippet86>

'<snippet87>
Private Sub ToolStrip1_CausesValidationChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.CausesValidationChanged

   MessageBox.Show("You are in the ToolStrip.CausesValidationChanged event.")

End Sub
'</snippet87>

'<snippet88>
Private Sub ToolStrip1_CursorChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.CursorChanged

   MessageBox.Show("You are in the ToolStrip.CursorChanged event.")

End Sub
'</snippet88>

'<snippet89>
Private Sub ToolStrip1_EndDrag(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.EndDrag

   MessageBox.Show("You are in the ToolStrip.EndDrag event.")

End Sub
'</snippet89>

'<snippet90>
Private Sub ToolStrip1_ForeColorChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.ForeColorChanged

   MessageBox.Show("You are in the ToolStrip.ForeColorChanged event.")

End Sub
'</snippet90>

'<snippet91>
Private Sub ToolStrip1_ItemAdded(sender as Object, e as ToolStripItemEventArgs) _ 
     Handles ToolStrip1.ItemAdded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemAdded Event")

End Sub
'</snippet91>

'<snippet92>
Private Sub ToolStrip1_ItemClicked(sender as Object, e as ToolStripItemClickedEventArgs) _ 
     Handles ToolStrip1.ItemClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClickedItem", e.ClickedItem)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemClicked Event")

End Sub
'</snippet92>

'<snippet93>
Private Sub ToolStrip1_ItemRemoved(sender as Object, e as ToolStripItemEventArgs) _ 
     Handles ToolStrip1.ItemRemoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemRemoved Event")

End Sub
'</snippet93>

'<snippet94>
Private Sub ToolStrip1_LayoutCompleted(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.LayoutCompleted

   MessageBox.Show("You are in the ToolStrip.LayoutCompleted event.")

End Sub
'</snippet94>

'<snippet95>
Private Sub ToolStrip1_LayoutStyleChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.LayoutStyleChanged

   MessageBox.Show("You are in the ToolStrip.LayoutStyleChanged event.")

End Sub
'</snippet95>

'<snippet96>
Private Sub ToolStrip1_PaintGrip(sender as Object, e as PaintEventArgs) _ 
     Handles ToolStrip1.PaintGrip

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PaintGrip Event")

End Sub
'</snippet96>

'<snippet97>
Private Sub ToolStrip1_RendererChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStrip1.RendererChanged

   MessageBox.Show("You are in the ToolStrip.RendererChanged event.")

End Sub
'</snippet97>

Public WithEvents ToolStripItem1 as ToolStripItem
'<snippet98>
Private Sub ToolStripItem1_AvailableChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.AvailableChanged

   MessageBox.Show("You are in the ToolStripItem.AvailableChanged event.")

End Sub
'</snippet98>

'<snippet99>
Private Sub ToolStripItem1_BackColorChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.BackColorChanged

   MessageBox.Show("You are in the ToolStripItem.BackColorChanged event.")

End Sub
'</snippet99>

'<snippet100>
Private Sub ToolStripItem1_Click(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.Click

   MessageBox.Show("You are in the ToolStripItem.Click event.")

End Sub
'</snippet100>

'<snippet101>
Private Sub ToolStripItem1_DisplayStyleChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.DisplayStyleChanged

   MessageBox.Show("You are in the ToolStripItem.DisplayStyleChanged event.")

End Sub
'</snippet101>

'<snippet102>
Private Sub ToolStripItem1_DoubleClick(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.DoubleClick

   MessageBox.Show("You are in the ToolStripItem.DoubleClick event.")

End Sub
'</snippet102>

'<snippet103>
Private Sub ToolStripItem1_DragDrop(sender as Object, e as DragEventArgs) _ 
     Handles ToolStripItem1.DragDrop

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragDrop Event")

End Sub
'</snippet103>

'<snippet104>
Private Sub ToolStripItem1_DragEnter(sender as Object, e as DragEventArgs) _ 
     Handles ToolStripItem1.DragEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragEnter Event")

End Sub
'</snippet104>

'<snippet105>
Private Sub ToolStripItem1_DragOver(sender as Object, e as DragEventArgs) _ 
     Handles ToolStripItem1.DragOver

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragOver Event")

End Sub
'</snippet105>

'<snippet106>
Private Sub ToolStripItem1_DragLeave(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.DragLeave

   MessageBox.Show("You are in the ToolStripItem.DragLeave event.")

End Sub
'</snippet106>

'<snippet107>
Private Sub ToolStripItem1_EnabledChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.EnabledChanged

   MessageBox.Show("You are in the ToolStripItem.EnabledChanged event.")

End Sub
'</snippet107>

'<snippet108>
Private Sub ToolStripItem1_ForeColorChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.ForeColorChanged

   MessageBox.Show("You are in the ToolStripItem.ForeColorChanged event.")

End Sub
'</snippet108>

'<snippet109>
Private Sub ToolStripItem1_GiveFeedback(sender as Object, e as GiveFeedbackEventArgs) _ 
     Handles ToolStripItem1.GiveFeedback

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "UseDefaultCursors", e.UseDefaultCursors)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"GiveFeedback Event")

End Sub
'</snippet109>

'<snippet110>
Private Sub ToolStripItem1_LocationChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.LocationChanged

   MessageBox.Show("You are in the ToolStripItem.LocationChanged event.")

End Sub
'</snippet110>

'<snippet111>
Private Sub ToolStripItem1_MouseDown(sender as Object, e as MouseEventArgs) _ 
     Handles ToolStripItem1.MouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDown Event")

End Sub
'</snippet111>

'<snippet112>
Private Sub ToolStripItem1_MouseEnter(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.MouseEnter

   MessageBox.Show("You are in the ToolStripItem.MouseEnter event.")

End Sub
'</snippet112>

'<snippet113>
Private Sub ToolStripItem1_MouseLeave(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.MouseLeave

   MessageBox.Show("You are in the ToolStripItem.MouseLeave event.")

End Sub
'</snippet113>

'<snippet114>
Private Sub ToolStripItem1_MouseHover(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.MouseHover

   MessageBox.Show("You are in the ToolStripItem.MouseHover event.")

End Sub
'</snippet114>

'<snippet115>
Private Sub ToolStripItem1_MouseMove(sender as Object, e as MouseEventArgs) _ 
     Handles ToolStripItem1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub
'</snippet115>

'<snippet116>
Private Sub ToolStripItem1_MouseUp(sender as Object, e as MouseEventArgs) _ 
     Handles ToolStripItem1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub
'</snippet116>

'<snippet117>
Private Sub ToolStripItem1_OwnerChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.OwnerChanged

   MessageBox.Show("You are in the ToolStripItem.OwnerChanged event.")

End Sub
'</snippet117>

'<snippet118>
Private Sub ToolStripItem1_Paint(sender as Object, e as PaintEventArgs) _ 
     Handles ToolStripItem1.Paint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Paint Event")

End Sub
'</snippet118>

'<snippet119>
Private Sub ToolStripItem1_QueryContinueDrag(sender as Object, e as QueryContinueDragEventArgs) _ 
     Handles ToolStripItem1.QueryContinueDrag

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EscapePressed", e.EscapePressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"QueryContinueDrag Event")

End Sub
'</snippet119>

'<snippet120>
Private Sub ToolStripItem1_QueryAccessibilityHelp(sender as Object, e as QueryAccessibilityHelpEventArgs) _ 
     Handles ToolStripItem1.QueryAccessibilityHelp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpNamespace", e.HelpNamespace)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpString", e.HelpString)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "HelpKeyword", e.HelpKeyword)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"QueryAccessibilityHelp Event")

End Sub
'</snippet120>

'<snippet121>
Private Sub ToolStripItem1_RightToLeftChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.RightToLeftChanged

   MessageBox.Show("You are in the ToolStripItem.RightToLeftChanged event.")

End Sub
'</snippet121>

'<snippet122>
Private Sub ToolStripItem1_TextChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.TextChanged

   MessageBox.Show("You are in the ToolStripItem.TextChanged event.")

End Sub
'</snippet122>

'<snippet123>
Private Sub ToolStripItem1_VisibleChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripItem1.VisibleChanged

   MessageBox.Show("You are in the ToolStripItem.VisibleChanged event.")

End Sub
'</snippet123>

Public WithEvents BindingNavigator1 as BindingNavigator
'<snippet124>
Private Sub BindingNavigator1_RefreshItems(sender as Object, e as EventArgs) _ 
     Handles BindingNavigator1.RefreshItems

   MessageBox.Show("You are in the BindingNavigator.RefreshItems event.")

End Sub
'</snippet124>

Public WithEvents BindingsCollection1 as BindingsCollection
'<snippet125>
Private Sub BindingsCollection1_CollectionChanging(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles BindingsCollection1.CollectionChanging

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanging Event")

End Sub
'</snippet125>

'<snippet126>
Private Sub BindingsCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles BindingsCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub
'</snippet126>

Public WithEvents BindingSource1 as BindingSource
'<snippet127>
Private Sub BindingSource1_AddingNew(sender as Object, e as AddingNewEventArgs) _ 
     Handles BindingSource1.AddingNew

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "NewObject", e.NewObject)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AddingNew Event")

End Sub
'</snippet127>

'<snippet128>
Private Sub BindingSource1_BindingComplete(sender as Object, e as BindingCompleteEventArgs) _ 
     Handles BindingSource1.BindingComplete

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Binding", e.Binding)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteState", e.BindingCompleteState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BindingCompleteContext", e.BindingCompleteContext)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BindingComplete Event")

End Sub
'</snippet128>

'<snippet129>
Private Sub BindingSource1_DataError(sender as Object, e as BindingManagerDataErrorEventArgs) _ 
     Handles BindingSource1.DataError

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DataError Event")

End Sub
'</snippet129>

'<snippet130>
Private Sub BindingSource1_DataSourceChanged(sender as Object, e as EventArgs) _ 
     Handles BindingSource1.DataSourceChanged

   MessageBox.Show("You are in the BindingSource.DataSourceChanged event.")

End Sub
'</snippet130>

'<snippet131>
Private Sub BindingSource1_DataMemberChanged(sender as Object, e as EventArgs) _ 
     Handles BindingSource1.DataMemberChanged

   MessageBox.Show("You are in the BindingSource.DataMemberChanged event.")

End Sub
'</snippet131>

'<snippet132>
Private Sub BindingSource1_CurrentChanged(sender as Object, e as EventArgs) _ 
     Handles BindingSource1.CurrentChanged

   MessageBox.Show("You are in the BindingSource.CurrentChanged event.")

End Sub
'</snippet132>

'<snippet133>
Private Sub BindingSource1_CurrentItemChanged(sender as Object, e as EventArgs) _ 
     Handles BindingSource1.CurrentItemChanged

   MessageBox.Show("You are in the BindingSource.CurrentItemChanged event.")

End Sub
'</snippet133>

'<snippet134>
Private Sub BindingSource1_ListChanged(sender as Object, e as ListChangedEventArgs) _ 
     Handles BindingSource1.ListChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewIndex", e.NewIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldIndex", e.OldIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PropertyDescriptor", e.PropertyDescriptor)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ListChanged Event")

End Sub
'</snippet134>

'<snippet135>
Private Sub BindingSource1_PositionChanged(sender as Object, e as EventArgs) _ 
     Handles BindingSource1.PositionChanged

   MessageBox.Show("You are in the BindingSource.PositionChanged event.")

End Sub
'</snippet135>

Public WithEvents ButtonBase1 as ButtonBase
'<snippet136>
Private Sub ButtonBase1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles ButtonBase1.AutoSizeChanged

   MessageBox.Show("You are in the ButtonBase.AutoSizeChanged event.")

End Sub
'</snippet136>

Public WithEvents Button1 as Button
'<snippet137>
Private Sub Button1_DoubleClick(sender as Object, e as EventArgs) _ 
     Handles Button1.DoubleClick

   MessageBox.Show("You are in the Button.DoubleClick event.")

End Sub
'</snippet137>

'<snippet138>
Private Sub Button1_MouseDoubleClick(sender as Object, e as MouseEventArgs) _ 
     Handles Button1.MouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDoubleClick Event")

End Sub
'</snippet138>

Public WithEvents CheckBox1 as CheckBox
'<snippet139>
Private Sub CheckBox1_AppearanceChanged(sender as Object, e as EventArgs) _ 
     Handles CheckBox1.AppearanceChanged

   MessageBox.Show("You are in the CheckBox.AppearanceChanged event.")

End Sub
'</snippet139>

'<snippet140>
Private Sub CheckBox1_CheckedChanged(sender as Object, e as EventArgs) _ 
     Handles CheckBox1.CheckedChanged

   MessageBox.Show("You are in the CheckBox.CheckedChanged event.")

End Sub
'</snippet140>

'<snippet141>
Private Sub CheckBox1_CheckStateChanged(sender as Object, e as EventArgs) _ 
     Handles CheckBox1.CheckStateChanged

   MessageBox.Show("You are in the CheckBox.CheckStateChanged event.")

End Sub
'</snippet141>

Public WithEvents ListControl1 as ListControl
'<snippet142>
Private Sub ListControl1_DataSourceChanged(sender as Object, e as EventArgs) _ 
     Handles ListControl1.DataSourceChanged

   MessageBox.Show("You are in the ListControl.DataSourceChanged event.")

End Sub
'</snippet142>

'<snippet143>
Private Sub ListControl1_DisplayMemberChanged(sender as Object, e as EventArgs) _ 
     Handles ListControl1.DisplayMemberChanged

   MessageBox.Show("You are in the ListControl.DisplayMemberChanged event.")

End Sub
'</snippet143>

'<snippet144>
Private Sub ListControl1_Format(sender as Object, e as ListControlConvertEventArgs) _ 
     Handles ListControl1.Format

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ListItem", e.ListItem)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Format Event")

End Sub
'</snippet144>

'<snippet145>
Private Sub ListControl1_FormatInfoChanged(sender as Object, e as EventArgs) _ 
     Handles ListControl1.FormatInfoChanged

   MessageBox.Show("You are in the ListControl.FormatInfoChanged event.")

End Sub
'</snippet145>

'<snippet146>
Private Sub ListControl1_FormatStringChanged(sender as Object, e as EventArgs) _ 
     Handles ListControl1.FormatStringChanged

   MessageBox.Show("You are in the ListControl.FormatStringChanged event.")

End Sub
'</snippet146>

'<snippet147>
Private Sub ListControl1_FormattingEnabledChanged(sender as Object, e as EventArgs) _ 
     Handles ListControl1.FormattingEnabledChanged

   MessageBox.Show("You are in the ListControl.FormattingEnabledChanged event.")

End Sub
'</snippet147>

'<snippet148>
Private Sub ListControl1_ValueMemberChanged(sender as Object, e as EventArgs) _ 
     Handles ListControl1.ValueMemberChanged

   MessageBox.Show("You are in the ListControl.ValueMemberChanged event.")

End Sub
'</snippet148>

'<snippet149>
Private Sub ListControl1_SelectedValueChanged(sender as Object, e as EventArgs) _ 
     Handles ListControl1.SelectedValueChanged

   MessageBox.Show("You are in the ListControl.SelectedValueChanged event.")

End Sub
'</snippet149>

Public WithEvents ListBox1 as ListBox
'<snippet150>
Private Sub ListBox1_TextChanged(sender as Object, e as EventArgs) _ 
     Handles ListBox1.TextChanged

   MessageBox.Show("You are in the ListBox.TextChanged event.")

End Sub
'</snippet150>

'<snippet151>
Private Sub ListBox1_Click(sender as Object, e as EventArgs) _ 
     Handles ListBox1.Click

   MessageBox.Show("You are in the ListBox.Click event.")

End Sub
'</snippet151>

'<snippet152>
Private Sub ListBox1_MouseClick(sender as Object, e as MouseEventArgs) _ 
     Handles ListBox1.MouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseClick Event")

End Sub
'</snippet152>

'<snippet153>
Private Sub ListBox1_DrawItem(sender as Object, e as DrawItemEventArgs) _ 
     Handles ListBox1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub
'</snippet153>

'<snippet154>
Private Sub ListBox1_MeasureItem(sender as Object, e as MeasureItemEventArgs) _ 
     Handles ListBox1.MeasureItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MeasureItem Event")

End Sub
'</snippet154>

'<snippet155>
Private Sub ListBox1_SelectedIndexChanged(sender as Object, e as EventArgs) _ 
     Handles ListBox1.SelectedIndexChanged

   MessageBox.Show("You are in the ListBox.SelectedIndexChanged event.")

End Sub
'</snippet155>

Public WithEvents CheckedListBox1 as CheckedListBox
'<snippet156>
Private Sub CheckedListBox1_ItemCheck(sender as Object, e as ItemCheckEventArgs) _ 
     Handles CheckedListBox1.ItemCheck

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemCheck Event")

End Sub
'</snippet156>

'<snippet157>
Private Sub CheckedListBox1_Click(sender as Object, e as EventArgs) _ 
     Handles CheckedListBox1.Click

   MessageBox.Show("You are in the CheckedListBox.Click event.")

End Sub
'</snippet157>

'<snippet158>
Private Sub CheckedListBox1_MouseClick(sender as Object, e as MouseEventArgs) _ 
     Handles CheckedListBox1.MouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseClick Event")

End Sub
'</snippet158>

Public WithEvents CommonDialog1 as CommonDialog
'<snippet159>
Private Sub CommonDialog1_HelpRequest(sender as Object, e as EventArgs) _ 
     Handles CommonDialog1.HelpRequest

   MessageBox.Show("You are in the CommonDialog.HelpRequest event.")

End Sub
'</snippet159>

Public WithEvents ColorDialog1 as ColorDialog
Public WithEvents ColumnHeader1 as ColumnHeader
Public WithEvents ImageList1 as ImageList
'<snippet160>
Private Sub ImageList1_RecreateHandle(sender as Object, e as EventArgs) _ 
     Handles ImageList1.RecreateHandle

   MessageBox.Show("You are in the ImageList.RecreateHandle event.")

End Sub
'</snippet160>

Public WithEvents ComboBox1 as ComboBox
'<snippet161>
Private Sub ComboBox1_DrawItem(sender as Object, e as DrawItemEventArgs) _ 
     Handles ComboBox1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub
'</snippet161>

'<snippet162>
Private Sub ComboBox1_DropDown(sender as Object, e as EventArgs) _ 
     Handles ComboBox1.DropDown

   MessageBox.Show("You are in the ComboBox.DropDown event.")

End Sub
'</snippet162>

'<snippet163>
Private Sub ComboBox1_MeasureItem(sender as Object, e as MeasureItemEventArgs) _ 
     Handles ComboBox1.MeasureItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MeasureItem Event")

End Sub
'</snippet163>

'<snippet164>
Private Sub ComboBox1_SelectedIndexChanged(sender as Object, e as EventArgs) _ 
     Handles ComboBox1.SelectedIndexChanged

   MessageBox.Show("You are in the ComboBox.SelectedIndexChanged event.")

End Sub
'</snippet164>

'<snippet165>
Private Sub ComboBox1_SelectionChangeCommitted(sender as Object, e as EventArgs) _ 
     Handles ComboBox1.SelectionChangeCommitted

   MessageBox.Show("You are in the ComboBox.SelectionChangeCommitted event.")

End Sub
'</snippet165>

'<snippet166>
Private Sub ComboBox1_DropDownStyleChanged(sender as Object, e as EventArgs) _ 
     Handles ComboBox1.DropDownStyleChanged

   MessageBox.Show("You are in the ComboBox.DropDownStyleChanged event.")

End Sub
'</snippet166>

'<snippet167>
Private Sub ComboBox1_TextUpdate(sender as Object, e as EventArgs) _ 
     Handles ComboBox1.TextUpdate

   MessageBox.Show("You are in the ComboBox.TextUpdate event.")

End Sub
'</snippet167>

'<snippet168>
Private Sub ComboBox1_DropDownClosed(sender as Object, e as EventArgs) _ 
     Handles ComboBox1.DropDownClosed

   MessageBox.Show("You are in the ComboBox.DropDownClosed event.")

End Sub
'</snippet168>

Public WithEvents Menu1 as Menu
Public WithEvents ContextMenu1 as ContextMenu
'<snippet169>
Private Sub ContextMenu1_Popup(sender as Object, e as EventArgs) _ 
     Handles ContextMenu1.Popup

   MessageBox.Show("You are in the ContextMenu.Popup event.")

End Sub
'</snippet169>

'<snippet170>
Private Sub ContextMenu1_Collapse(sender as Object, e as EventArgs) _ 
     Handles ContextMenu1.Collapse

   MessageBox.Show("You are in the ContextMenu.Collapse event.")

End Sub
'</snippet170>

Public WithEvents ToolStripDropDown1 as ToolStripDropDown
'<snippet171>
Private Sub ToolStripDropDown1_BackgroundImageChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.BackgroundImageChanged

   MessageBox.Show("You are in the ToolStripDropDown.BackgroundImageChanged event.")

End Sub
'</snippet171>

'<snippet172>
Private Sub ToolStripDropDown1_BackgroundImageLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.BackgroundImageLayoutChanged

   MessageBox.Show("You are in the ToolStripDropDown.BackgroundImageLayoutChanged event.")

End Sub
'</snippet172>

'<snippet173>
Private Sub ToolStripDropDown1_BindingContextChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.BindingContextChanged

   MessageBox.Show("You are in the ToolStripDropDown.BindingContextChanged event.")

End Sub
'</snippet173>

'<snippet174>
Private Sub ToolStripDropDown1_ChangeUICues(sender as Object, e as UICuesEventArgs) _ 
     Handles ToolStripDropDown1.ChangeUICues

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ShowFocus", e.ShowFocus)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShowKeyboard", e.ShowKeyboard)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangeFocus", e.ChangeFocus)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangeKeyboard", e.ChangeKeyboard)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Changed", e.Changed)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ChangeUICues Event")

End Sub
'</snippet174>

'<snippet175>
Private Sub ToolStripDropDown1_ContextMenuStripChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.ContextMenuStripChanged

   MessageBox.Show("You are in the ToolStripDropDown.ContextMenuStripChanged event.")

End Sub
'</snippet175>

'<snippet176>
Private Sub ToolStripDropDown1_DockChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.DockChanged

   MessageBox.Show("You are in the ToolStripDropDown.DockChanged event.")

End Sub
'</snippet176>

'<snippet177>
Private Sub ToolStripDropDown1_Closed(sender as Object, e as ToolStripDropDownClosedEventArgs) _ 
     Handles ToolStripDropDown1.Closed

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Closed Event")

End Sub
'</snippet177>

'<snippet178>
Private Sub ToolStripDropDown1_Closing(sender as Object, e as ToolStripDropDownClosingEventArgs) _ 
     Handles ToolStripDropDown1.Closing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Closing Event")

End Sub
'</snippet178>

'<snippet179>
Private Sub ToolStripDropDown1_Enter(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.Enter

   MessageBox.Show("You are in the ToolStripDropDown.Enter event.")

End Sub
'</snippet179>

'<snippet180>
Private Sub ToolStripDropDown1_FontChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.FontChanged

   MessageBox.Show("You are in the ToolStripDropDown.FontChanged event.")

End Sub
'</snippet180>

'<snippet181>
Private Sub ToolStripDropDown1_HelpRequested(sender as Object, e as HelpEventArgs) _ 
     Handles ToolStripDropDown1.HelpRequested

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePos", e.MousePos)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"HelpRequested Event")

End Sub
'</snippet181>

'<snippet182>
Private Sub ToolStripDropDown1_ImeModeChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.ImeModeChanged

   MessageBox.Show("You are in the ToolStripDropDown.ImeModeChanged event.")

End Sub
'</snippet182>

'<snippet183>
Private Sub ToolStripDropDown1_KeyDown(sender as Object, e as KeyEventArgs) _ 
     Handles ToolStripDropDown1.KeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyDown Event")

End Sub
'</snippet183>

'<snippet184>
Private Sub ToolStripDropDown1_KeyPress(sender as Object, e as KeyPressEventArgs) _ 
     Handles ToolStripDropDown1.KeyPress

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyPress Event")

End Sub
'</snippet184>

'<snippet185>
Private Sub ToolStripDropDown1_KeyUp(sender as Object, e as KeyEventArgs) _ 
     Handles ToolStripDropDown1.KeyUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyUp Event")

End Sub
'</snippet185>

'<snippet186>
Private Sub ToolStripDropDown1_Leave(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.Leave

   MessageBox.Show("You are in the ToolStripDropDown.Leave event.")

End Sub
'</snippet186>

'<snippet187>
Private Sub ToolStripDropDown1_Opening(sender as Object, e as CancelEventArgs) _ 
     Handles ToolStripDropDown1.Opening

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Opening Event")

End Sub
'</snippet187>

'<snippet188>
Private Sub ToolStripDropDown1_Opened(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.Opened

   MessageBox.Show("You are in the ToolStripDropDown.Opened event.")

End Sub
'</snippet188>

'<snippet189>
Private Sub ToolStripDropDown1_RegionChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.RegionChanged

   MessageBox.Show("You are in the ToolStripDropDown.RegionChanged event.")

End Sub
'</snippet189>

'<snippet190>
Private Sub ToolStripDropDown1_StyleChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDown1.StyleChanged

   MessageBox.Show("You are in the ToolStripDropDown.StyleChanged event.")

End Sub
'</snippet190>

Public WithEvents ToolStripDropDownMenu1 as ToolStripDropDownMenu
Public WithEvents ContextMenuStrip1 as ContextMenuStrip
Public WithEvents ControlBindingsCollection1 as ControlBindingsCollection
Public WithEvents CurrencyManager1 as CurrencyManager
'<snippet191>
Private Sub CurrencyManager1_ItemChanged(sender as Object, e as ItemChangedEventArgs) _ 
     Handles CurrencyManager1.ItemChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemChanged Event")

End Sub
'</snippet191>

'<snippet192>
Private Sub CurrencyManager1_ListChanged(sender as Object, e as ListChangedEventArgs) _ 
     Handles CurrencyManager1.ListChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewIndex", e.NewIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldIndex", e.OldIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PropertyDescriptor", e.PropertyDescriptor)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ListChanged Event")

End Sub
'</snippet192>

'<snippet193>
Private Sub CurrencyManager1_MetaDataChanged(sender as Object, e as EventArgs) _ 
     Handles CurrencyManager1.MetaDataChanged

   MessageBox.Show("You are in the CurrencyManager.MetaDataChanged event.")

End Sub
'</snippet193>

Public WithEvents DataGrid1 as DataGrid
'<snippet194>
Private Sub DataGrid1_BorderStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.BorderStyleChanged

   MessageBox.Show("You are in the DataGrid.BorderStyleChanged event.")

End Sub
'</snippet194>

'<snippet195>
Private Sub DataGrid1_CaptionVisibleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.CaptionVisibleChanged

   MessageBox.Show("You are in the DataGrid.CaptionVisibleChanged event.")

End Sub
'</snippet195>

'<snippet196>
Private Sub DataGrid1_CurrentCellChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.CurrentCellChanged

   MessageBox.Show("You are in the DataGrid.CurrentCellChanged event.")

End Sub
'</snippet196>

'<snippet197>
Private Sub DataGrid1_DataSourceChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.DataSourceChanged

   MessageBox.Show("You are in the DataGrid.DataSourceChanged event.")

End Sub
'</snippet197>

'<snippet198>
Private Sub DataGrid1_ParentRowsLabelStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.ParentRowsLabelStyleChanged

   MessageBox.Show("You are in the DataGrid.ParentRowsLabelStyleChanged event.")

End Sub
'</snippet198>

'<snippet199>
Private Sub DataGrid1_FlatModeChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.FlatModeChanged

   MessageBox.Show("You are in the DataGrid.FlatModeChanged event.")

End Sub
'</snippet199>

'<snippet200>
Private Sub DataGrid1_BackgroundColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.BackgroundColorChanged

   MessageBox.Show("You are in the DataGrid.BackgroundColorChanged event.")

End Sub
'</snippet200>

'<snippet201>
Private Sub DataGrid1_AllowNavigationChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.AllowNavigationChanged

   MessageBox.Show("You are in the DataGrid.AllowNavigationChanged event.")

End Sub
'</snippet201>

'<snippet202>
Private Sub DataGrid1_ReadOnlyChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.ReadOnlyChanged

   MessageBox.Show("You are in the DataGrid.ReadOnlyChanged event.")

End Sub
'</snippet202>

'<snippet203>
Private Sub DataGrid1_ParentRowsVisibleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.ParentRowsVisibleChanged

   MessageBox.Show("You are in the DataGrid.ParentRowsVisibleChanged event.")

End Sub
'</snippet203>

'<snippet204>
Private Sub DataGrid1_Navigate(sender as Object, e as NavigateEventArgs) _ 
     Handles DataGrid1.Navigate

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Forward", e.Forward)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Navigate Event")

End Sub
'</snippet204>

'<snippet205>
Private Sub DataGrid1_Scroll(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.Scroll

   MessageBox.Show("You are in the DataGrid.Scroll event.")

End Sub
'</snippet205>

'<snippet206>
Private Sub DataGrid1_BackButtonClick(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.BackButtonClick

   MessageBox.Show("You are in the DataGrid.BackButtonClick event.")

End Sub
'</snippet206>

'<snippet207>
Private Sub DataGrid1_ShowParentDetailsButtonClick(sender as Object, e as EventArgs) _ 
     Handles DataGrid1.ShowParentDetailsButtonClick

   MessageBox.Show("You are in the DataGrid.ShowParentDetailsButtonClick event.")

End Sub
'</snippet207>

Public WithEvents DataGridColumnStyle1 as DataGridColumnStyle
'<snippet208>
Private Sub DataGridColumnStyle1_AlignmentChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.AlignmentChanged

   MessageBox.Show("You are in the DataGridColumnStyle.AlignmentChanged event.")

End Sub
'</snippet208>

'<snippet209>
Private Sub DataGridColumnStyle1_PropertyDescriptorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.PropertyDescriptorChanged

   MessageBox.Show("You are in the DataGridColumnStyle.PropertyDescriptorChanged event.")

End Sub
'</snippet209>

'<snippet210>
Private Sub DataGridColumnStyle1_FontChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.FontChanged

   MessageBox.Show("You are in the DataGridColumnStyle.FontChanged event.")

End Sub
'</snippet210>

'<snippet211>
Private Sub DataGridColumnStyle1_HeaderTextChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.HeaderTextChanged

   MessageBox.Show("You are in the DataGridColumnStyle.HeaderTextChanged event.")

End Sub
'</snippet211>

'<snippet212>
Private Sub DataGridColumnStyle1_MappingNameChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.MappingNameChanged

   MessageBox.Show("You are in the DataGridColumnStyle.MappingNameChanged event.")

End Sub
'</snippet212>

'<snippet213>
Private Sub DataGridColumnStyle1_NullTextChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.NullTextChanged

   MessageBox.Show("You are in the DataGridColumnStyle.NullTextChanged event.")

End Sub
'</snippet213>

'<snippet214>
Private Sub DataGridColumnStyle1_ReadOnlyChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.ReadOnlyChanged

   MessageBox.Show("You are in the DataGridColumnStyle.ReadOnlyChanged event.")

End Sub
'</snippet214>

'<snippet215>
Private Sub DataGridColumnStyle1_WidthChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridColumnStyle1.WidthChanged

   MessageBox.Show("You are in the DataGridColumnStyle.WidthChanged event.")

End Sub
'</snippet215>

Public WithEvents DataGridBoolColumn1 as DataGridBoolColumn
'<snippet216>
Private Sub DataGridBoolColumn1_TrueValueChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridBoolColumn1.TrueValueChanged

   MessageBox.Show("You are in the DataGridBoolColumn.TrueValueChanged event.")

End Sub
'</snippet216>

'<snippet217>
Private Sub DataGridBoolColumn1_FalseValueChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridBoolColumn1.FalseValueChanged

   MessageBox.Show("You are in the DataGridBoolColumn.FalseValueChanged event.")

End Sub
'</snippet217>

'<snippet218>
Private Sub DataGridBoolColumn1_AllowNullChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridBoolColumn1.AllowNullChanged

   MessageBox.Show("You are in the DataGridBoolColumn.AllowNullChanged event.")

End Sub
'</snippet218>

Public WithEvents GridColumnStylesCollection1 as GridColumnStylesCollection
'<snippet219>
Private Sub GridColumnStylesCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles GridColumnStylesCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub
'</snippet219>

Public WithEvents DataGridTableStyle1 as DataGridTableStyle
'<snippet220>
Private Sub DataGridTableStyle1_AllowSortingChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.AllowSortingChanged

   MessageBox.Show("You are in the DataGridTableStyle.AllowSortingChanged event.")

End Sub
'</snippet220>

'<snippet221>
Private Sub DataGridTableStyle1_AlternatingBackColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.AlternatingBackColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.AlternatingBackColorChanged event.")

End Sub
'</snippet221>

'<snippet222>
Private Sub DataGridTableStyle1_BackColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.BackColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.BackColorChanged event.")

End Sub
'</snippet222>

'<snippet223>
Private Sub DataGridTableStyle1_ForeColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.ForeColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.ForeColorChanged event.")

End Sub
'</snippet223>

'<snippet224>
Private Sub DataGridTableStyle1_GridLineColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.GridLineColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.GridLineColorChanged event.")

End Sub
'</snippet224>

'<snippet225>
Private Sub DataGridTableStyle1_GridLineStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.GridLineStyleChanged

   MessageBox.Show("You are in the DataGridTableStyle.GridLineStyleChanged event.")

End Sub
'</snippet225>

'<snippet226>
Private Sub DataGridTableStyle1_HeaderBackColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.HeaderBackColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.HeaderBackColorChanged event.")

End Sub
'</snippet226>

'<snippet227>
Private Sub DataGridTableStyle1_HeaderFontChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.HeaderFontChanged

   MessageBox.Show("You are in the DataGridTableStyle.HeaderFontChanged event.")

End Sub
'</snippet227>

'<snippet228>
Private Sub DataGridTableStyle1_HeaderForeColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.HeaderForeColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.HeaderForeColorChanged event.")

End Sub
'</snippet228>

'<snippet229>
Private Sub DataGridTableStyle1_LinkColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.LinkColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.LinkColorChanged event.")

End Sub
'</snippet229>

'<snippet230>
Private Sub DataGridTableStyle1_LinkHoverColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.LinkHoverColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.LinkHoverColorChanged event.")

End Sub
'</snippet230>

'<snippet231>
Private Sub DataGridTableStyle1_PreferredColumnWidthChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.PreferredColumnWidthChanged

   MessageBox.Show("You are in the DataGridTableStyle.PreferredColumnWidthChanged event.")

End Sub
'</snippet231>

'<snippet232>
Private Sub DataGridTableStyle1_PreferredRowHeightChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.PreferredRowHeightChanged

   MessageBox.Show("You are in the DataGridTableStyle.PreferredRowHeightChanged event.")

End Sub
'</snippet232>

'<snippet233>
Private Sub DataGridTableStyle1_ColumnHeadersVisibleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.ColumnHeadersVisibleChanged

   MessageBox.Show("You are in the DataGridTableStyle.ColumnHeadersVisibleChanged event.")

End Sub
'</snippet233>

'<snippet234>
Private Sub DataGridTableStyle1_RowHeadersVisibleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.RowHeadersVisibleChanged

   MessageBox.Show("You are in the DataGridTableStyle.RowHeadersVisibleChanged event.")

End Sub
'</snippet234>

'<snippet235>
Private Sub DataGridTableStyle1_RowHeaderWidthChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.RowHeaderWidthChanged

   MessageBox.Show("You are in the DataGridTableStyle.RowHeaderWidthChanged event.")

End Sub
'</snippet235>

'<snippet236>
Private Sub DataGridTableStyle1_SelectionBackColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.SelectionBackColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.SelectionBackColorChanged event.")

End Sub
'</snippet236>

'<snippet237>
Private Sub DataGridTableStyle1_SelectionForeColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.SelectionForeColorChanged

   MessageBox.Show("You are in the DataGridTableStyle.SelectionForeColorChanged event.")

End Sub
'</snippet237>

'<snippet238>
Private Sub DataGridTableStyle1_MappingNameChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.MappingNameChanged

   MessageBox.Show("You are in the DataGridTableStyle.MappingNameChanged event.")

End Sub
'</snippet238>

'<snippet239>
Private Sub DataGridTableStyle1_ReadOnlyChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridTableStyle1.ReadOnlyChanged

   MessageBox.Show("You are in the DataGridTableStyle.ReadOnlyChanged event.")

End Sub
'</snippet239>

Public WithEvents GridTableStylesCollection1 as GridTableStylesCollection
'<snippet240>
Private Sub GridTableStylesCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles GridTableStylesCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub
'</snippet240>

Public WithEvents TextBoxBase1 as TextBoxBase
'<snippet241>
Private Sub TextBoxBase1_AcceptsTabChanged(sender as Object, e as EventArgs) _ 
     Handles TextBoxBase1.AcceptsTabChanged

   MessageBox.Show("You are in the TextBoxBase.AcceptsTabChanged event.")

End Sub
'</snippet241>

'<snippet242>
Private Sub TextBoxBase1_BorderStyleChanged(sender as Object, e as EventArgs) _ 
     Handles TextBoxBase1.BorderStyleChanged

   MessageBox.Show("You are in the TextBoxBase.BorderStyleChanged event.")

End Sub
'</snippet242>

'<snippet243>
Private Sub TextBoxBase1_Click(sender as Object, e as EventArgs) _ 
     Handles TextBoxBase1.Click

   MessageBox.Show("You are in the TextBoxBase.Click event.")

End Sub
'</snippet243>

'<snippet244>
Private Sub TextBoxBase1_MouseClick(sender as Object, e as MouseEventArgs) _ 
     Handles TextBoxBase1.MouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseClick Event")

End Sub
'</snippet244>

'<snippet245>
Private Sub TextBoxBase1_HideSelectionChanged(sender as Object, e as EventArgs) _ 
     Handles TextBoxBase1.HideSelectionChanged

   MessageBox.Show("You are in the TextBoxBase.HideSelectionChanged event.")

End Sub
'</snippet245>

'<snippet246>
Private Sub TextBoxBase1_ModifiedChanged(sender as Object, e as EventArgs) _ 
     Handles TextBoxBase1.ModifiedChanged

   MessageBox.Show("You are in the TextBoxBase.ModifiedChanged event.")

End Sub
'</snippet246>

'<snippet247>
Private Sub TextBoxBase1_MultilineChanged(sender as Object, e as EventArgs) _ 
     Handles TextBoxBase1.MultilineChanged

   MessageBox.Show("You are in the TextBoxBase.MultilineChanged event.")

End Sub
'</snippet247>

'<snippet248>
Private Sub TextBoxBase1_ReadOnlyChanged(sender as Object, e as EventArgs) _ 
     Handles TextBoxBase1.ReadOnlyChanged

   MessageBox.Show("You are in the TextBoxBase.ReadOnlyChanged event.")

End Sub
'</snippet248>

Public WithEvents TextBox1 as TextBox
'<snippet249>
Private Sub TextBox1_TextAlignChanged(sender as Object, e as EventArgs) _ 
     Handles TextBox1.TextAlignChanged

   MessageBox.Show("You are in the TextBox.TextAlignChanged event.")

End Sub
'</snippet249>

Public WithEvents DataGridTextBox1 as DataGridTextBox
Public WithEvents DataGridTextBoxColumn1 as DataGridTextBoxColumn
Public WithEvents DataGridView1 as DataGridView
'<snippet250>
Private Sub DataGridView1_AllowUserToAddRowsChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.AllowUserToAddRowsChanged

   MessageBox.Show("You are in the DataGridView.AllowUserToAddRowsChanged event.")

End Sub
'</snippet250>

'<snippet251>
Private Sub DataGridView1_AllowUserToDeleteRowsChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.AllowUserToDeleteRowsChanged

   MessageBox.Show("You are in the DataGridView.AllowUserToDeleteRowsChanged event.")

End Sub
'</snippet251>

'<snippet252>
Private Sub DataGridView1_AllowUserToOrderColumnsChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.AllowUserToOrderColumnsChanged

   MessageBox.Show("You are in the DataGridView.AllowUserToOrderColumnsChanged event.")

End Sub
'</snippet252>

'<snippet253>
Private Sub DataGridView1_AllowUserToResizeColumnsChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.AllowUserToResizeColumnsChanged

   MessageBox.Show("You are in the DataGridView.AllowUserToResizeColumnsChanged event.")

End Sub
'</snippet253>

'<snippet254>
Private Sub DataGridView1_AllowUserToResizeRowsChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.AllowUserToResizeRowsChanged

   MessageBox.Show("You are in the DataGridView.AllowUserToResizeRowsChanged event.")

End Sub
'</snippet254>

'<snippet255>
Private Sub DataGridView1_AlternatingRowsDefaultCellStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.AlternatingRowsDefaultCellStyleChanged

   MessageBox.Show("You are in the DataGridView.AlternatingRowsDefaultCellStyleChanged event.")

End Sub
'</snippet255>

'<snippet256>
Private Sub DataGridView1_AutoGenerateColumnsChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.AutoGenerateColumnsChanged

   MessageBox.Show("You are in the DataGridView.AutoGenerateColumnsChanged event.")

End Sub
'</snippet256>

'<snippet257>
Private Sub DataGridView1_AutoSizeColumnsModeChanged(sender as Object, e as DataGridViewAutoSizeColumnsModeEventArgs) _ 
     Handles DataGridView1.AutoSizeColumnsModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousModes", e.PreviousModes)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AutoSizeColumnsModeChanged Event")

End Sub
'</snippet257>

'<snippet258>
Private Sub DataGridView1_AutoSizeRowsModeChanged(sender as Object, e as DataGridViewAutoSizeModeEventArgs) _ 
     Handles DataGridView1.AutoSizeRowsModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AutoSizeRowsModeChanged Event")

End Sub
'</snippet258>

'<snippet259>
Private Sub DataGridView1_BackgroundColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.BackgroundColorChanged

   MessageBox.Show("You are in the DataGridView.BackgroundColorChanged event.")

End Sub
'</snippet259>

'<snippet260>
Private Sub DataGridView1_BorderStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.BorderStyleChanged

   MessageBox.Show("You are in the DataGridView.BorderStyleChanged event.")

End Sub
'</snippet260>

'<snippet261>
Private Sub DataGridView1_CellBorderStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.CellBorderStyleChanged

   MessageBox.Show("You are in the DataGridView.CellBorderStyleChanged event.")

End Sub
'</snippet261>

'<snippet262>
Private Sub DataGridView1_ColumnHeadersBorderStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.ColumnHeadersBorderStyleChanged

   MessageBox.Show("You are in the DataGridView.ColumnHeadersBorderStyleChanged event.")

End Sub
'</snippet262>

'<snippet263>
Private Sub DataGridView1_ColumnHeadersDefaultCellStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.ColumnHeadersDefaultCellStyleChanged

   MessageBox.Show("You are in the DataGridView.ColumnHeadersDefaultCellStyleChanged event.")

End Sub
'</snippet263>

'<snippet264>
Private Sub DataGridView1_ColumnHeadersHeightChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.ColumnHeadersHeightChanged

   MessageBox.Show("You are in the DataGridView.ColumnHeadersHeightChanged event.")

End Sub
'</snippet264>

'<snippet265>
Private Sub DataGridView1_ColumnHeadersHeightSizeModeChanged(sender as Object, e as DataGridViewAutoSizeModeEventArgs) _ 
     Handles DataGridView1.ColumnHeadersHeightSizeModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnHeadersHeightSizeModeChanged Event")

End Sub
'</snippet265>

'<snippet266>
Private Sub DataGridView1_DataMemberChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.DataMemberChanged

   MessageBox.Show("You are in the DataGridView.DataMemberChanged event.")

End Sub
'</snippet266>

'<snippet267>
Private Sub DataGridView1_DataSourceChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.DataSourceChanged

   MessageBox.Show("You are in the DataGridView.DataSourceChanged event.")

End Sub
'</snippet267>

'<snippet268>
Private Sub DataGridView1_DefaultCellStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.DefaultCellStyleChanged

   MessageBox.Show("You are in the DataGridView.DefaultCellStyleChanged event.")

End Sub
'</snippet268>

'<snippet269>
Private Sub DataGridView1_EditModeChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.EditModeChanged

   MessageBox.Show("You are in the DataGridView.EditModeChanged event.")

End Sub
'</snippet269>

'<snippet270>
Private Sub DataGridView1_ForeColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.ForeColorChanged

   MessageBox.Show("You are in the DataGridView.ForeColorChanged event.")

End Sub
'</snippet270>

'<snippet271>
Private Sub DataGridView1_FontChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.FontChanged

   MessageBox.Show("You are in the DataGridView.FontChanged event.")

End Sub
'</snippet271>

'<snippet272>
Private Sub DataGridView1_GridColorChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.GridColorChanged

   MessageBox.Show("You are in the DataGridView.GridColorChanged event.")

End Sub
'</snippet272>

'<snippet273>
Private Sub DataGridView1_MultiSelectChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.MultiSelectChanged

   MessageBox.Show("You are in the DataGridView.MultiSelectChanged event.")

End Sub
'</snippet273>

'<snippet274>
Private Sub DataGridView1_ReadOnlyChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.ReadOnlyChanged

   MessageBox.Show("You are in the DataGridView.ReadOnlyChanged event.")

End Sub
'</snippet274>

'<snippet275>
Private Sub DataGridView1_RowHeadersBorderStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.RowHeadersBorderStyleChanged

   MessageBox.Show("You are in the DataGridView.RowHeadersBorderStyleChanged event.")

End Sub
'</snippet275>

'<snippet276>
Private Sub DataGridView1_RowHeadersDefaultCellStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.RowHeadersDefaultCellStyleChanged

   MessageBox.Show("You are in the DataGridView.RowHeadersDefaultCellStyleChanged event.")

End Sub
'</snippet276>

'<snippet277>
Private Sub DataGridView1_RowHeadersWidthChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.RowHeadersWidthChanged

   MessageBox.Show("You are in the DataGridView.RowHeadersWidthChanged event.")

End Sub
'</snippet277>

'<snippet278>
Private Sub DataGridView1_RowHeadersWidthSizeModeChanged(sender as Object, e as DataGridViewAutoSizeModeEventArgs) _ 
     Handles DataGridView1.RowHeadersWidthSizeModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousModeAutoSized", e.PreviousModeAutoSized)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeadersWidthSizeModeChanged Event")

End Sub
'</snippet278>

'<snippet279>
Private Sub DataGridView1_RowsDefaultCellStyleChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.RowsDefaultCellStyleChanged

   MessageBox.Show("You are in the DataGridView.RowsDefaultCellStyleChanged event.")

End Sub
'</snippet279>

'<snippet280>
Private Sub DataGridView1_AutoSizeColumnModeChanged(sender as Object, e as DataGridViewAutoSizeColumnModeEventArgs) _ 
     Handles DataGridView1.AutoSizeColumnModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PreviousMode", e.PreviousMode)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AutoSizeColumnModeChanged Event")

End Sub
'</snippet280>

'<snippet281>
Private Sub DataGridView1_CancelRowEdit(sender as Object, e as QuestionEventArgs) _ 
     Handles DataGridView1.CancelRowEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Response", e.Response)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CancelRowEdit Event")

End Sub
'</snippet281>

'<snippet282>
Private Sub DataGridView1_CellBeginEdit(sender as Object, e as DataGridViewCellCancelEventArgs) _ 
     Handles DataGridView1.CellBeginEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellBeginEdit Event")

End Sub
'</snippet282>

'<snippet283>
Private Sub DataGridView1_CellClick(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellClick Event")

End Sub
'</snippet283>

'<snippet284>
Private Sub DataGridView1_CellContentClick(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellContentClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellContentClick Event")

End Sub
'</snippet284>

'<snippet285>
Private Sub DataGridView1_CellContentDoubleClick(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellContentDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellContentDoubleClick Event")

End Sub
'</snippet285>

'<snippet286>
Private Sub DataGridView1_CellContextMenuStripChanged(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellContextMenuStripChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellContextMenuStripChanged Event")

End Sub
'</snippet286>

'<snippet287>
Private Sub DataGridView1_CellContextMenuStripNeeded(sender as Object, e as DataGridViewCellContextMenuStripNeededEventArgs) _ 
     Handles DataGridView1.CellContextMenuStripNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ContextMenuStrip", e.ContextMenuStrip)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellContextMenuStripNeeded Event")

End Sub
'</snippet287>

'<snippet288>
Private Sub DataGridView1_CellDoubleClick(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellDoubleClick Event")

End Sub
'</snippet288>

'<snippet289>
Private Sub DataGridView1_CellEndEdit(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellEndEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellEndEdit Event")

End Sub
'</snippet289>

'<snippet290>
Private Sub DataGridView1_CellEnter(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellEnter Event")

End Sub
'</snippet290>

'<snippet291>
Private Sub DataGridView1_CellErrorTextChanged(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellErrorTextChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellErrorTextChanged Event")

End Sub
'</snippet291>

'<snippet292>
Private Sub DataGridView1_CellErrorTextNeeded(sender as Object, e as DataGridViewCellErrorTextNeededEventArgs) _ 
     Handles DataGridView1.CellErrorTextNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellErrorTextNeeded Event")

End Sub
'</snippet292>

'<snippet293>
Private Sub DataGridView1_CellFormatting(sender as Object, e as DataGridViewCellFormattingEventArgs) _ 
     Handles DataGridView1.CellFormatting

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FormattingApplied", e.FormattingApplied)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellFormatting Event")

End Sub
'</snippet293>

'<snippet294>
Private Sub DataGridView1_CellLeave(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellLeave

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellLeave Event")

End Sub
'</snippet294>

'<snippet295>
Private Sub DataGridView1_CellMouseClick(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.CellMouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellMouseClick Event")

End Sub
'</snippet295>

'<snippet296>
Private Sub DataGridView1_CellMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.CellMouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellMouseDoubleClick Event")

End Sub
'</snippet296>

'<snippet297>
Private Sub DataGridView1_CellMouseDown(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.CellMouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellMouseDown Event")

End Sub
'</snippet297>

'<snippet298>
Private Sub DataGridView1_CellMouseEnter(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellMouseEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellMouseEnter Event")

End Sub
'</snippet298>

'<snippet299>
Private Sub DataGridView1_CellMouseLeave(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellMouseLeave

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellMouseLeave Event")

End Sub
'</snippet299>

'<snippet300>
Private Sub DataGridView1_CellMouseMove(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.CellMouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellMouseMove Event")

End Sub
'</snippet300>

'<snippet301>
Private Sub DataGridView1_CellMouseUp(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.CellMouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellMouseUp Event")

End Sub
'</snippet301>

'<snippet302>
Private Sub DataGridView1_CellPainting(sender as Object, e as DataGridViewCellPaintingEventArgs) _ 
     Handles DataGridView1.CellPainting

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AdvancedBorderStyle", e.AdvancedBorderStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FormattedValue", e.FormattedValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PaintParts", e.PaintParts)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellPainting Event")

End Sub
'</snippet302>

'<snippet303>
Private Sub DataGridView1_CellParsing(sender as Object, e as DataGridViewCellParsingEventArgs) _ 
     Handles DataGridView1.CellParsing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "InheritedCellStyle", e.InheritedCellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ParsingApplied", e.ParsingApplied)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "DesiredType", e.DesiredType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellParsing Event")

End Sub
'</snippet303>

'<snippet304>
Private Sub DataGridView1_CellStateChanged(sender as Object, e as DataGridViewCellStateChangedEventArgs) _ 
     Handles DataGridView1.CellStateChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cell", e.Cell)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellStateChanged Event")

End Sub
'</snippet304>

'<snippet305>
Private Sub DataGridView1_CellStyleChanged(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellStyleChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellStyleChanged Event")

End Sub
'</snippet305>

'<snippet306>
Private Sub DataGridView1_CellStyleContentChanged(sender as Object, e as DataGridViewCellStyleContentChangedEventArgs) _ 
     Handles DataGridView1.CellStyleContentChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyleScope", e.CellStyleScope)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellStyleContentChanged Event")

End Sub
'</snippet306>

'<snippet307>
Private Sub DataGridView1_CellToolTipTextChanged(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellToolTipTextChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellToolTipTextChanged Event")

End Sub
'</snippet307>

'<snippet308>
Private Sub DataGridView1_CellToolTipTextNeeded(sender as Object, e as DataGridViewCellToolTipTextNeededEventArgs) _ 
     Handles DataGridView1.CellToolTipTextNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolTipText", e.ToolTipText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellToolTipTextNeeded Event")

End Sub
'</snippet308>

'<snippet309>
Private Sub DataGridView1_CellValidated(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellValidated

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellValidated Event")

End Sub
'</snippet309>

'<snippet310>
Private Sub DataGridView1_CellValidating(sender as Object, e as DataGridViewCellValidatingEventArgs) _ 
     Handles DataGridView1.CellValidating

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FormattedValue", e.FormattedValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellValidating Event")

End Sub
'</snippet310>

'<snippet311>
Private Sub DataGridView1_CellValueChanged(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.CellValueChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellValueChanged Event")

End Sub
'</snippet311>

'<snippet312>
Private Sub DataGridView1_CellValueNeeded(sender as Object, e as DataGridViewCellValueEventArgs) _ 
     Handles DataGridView1.CellValueNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellValueNeeded Event")

End Sub
'</snippet312>

'<snippet313>
Private Sub DataGridView1_CellValuePushed(sender as Object, e as DataGridViewCellValueEventArgs) _ 
     Handles DataGridView1.CellValuePushed

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Value", e.Value)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellValuePushed Event")

End Sub
'</snippet313>

'<snippet314>
Private Sub DataGridView1_ColumnAdded(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnAdded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnAdded Event")

End Sub
'</snippet314>

'<snippet315>
Private Sub DataGridView1_ColumnContextMenuStripChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnContextMenuStripChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnContextMenuStripChanged Event")

End Sub
'</snippet315>

'<snippet316>
Private Sub DataGridView1_ColumnDataPropertyNameChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnDataPropertyNameChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnDataPropertyNameChanged Event")

End Sub
'</snippet316>

'<snippet317>
Private Sub DataGridView1_ColumnDefaultCellStyleChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnDefaultCellStyleChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnDefaultCellStyleChanged Event")

End Sub
'</snippet317>

'<snippet318>
Private Sub DataGridView1_ColumnDisplayIndexChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnDisplayIndexChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnDisplayIndexChanged Event")

End Sub
'</snippet318>

'<snippet319>
Private Sub DataGridView1_ColumnDividerDoubleClick(sender as Object, e as DataGridViewColumnDividerDoubleClickEventArgs) _ 
     Handles DataGridView1.ColumnDividerDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnDividerDoubleClick Event")

End Sub
'</snippet319>

'<snippet320>
Private Sub DataGridView1_ColumnDividerWidthChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnDividerWidthChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnDividerWidthChanged Event")

End Sub
'</snippet320>

'<snippet321>
Private Sub DataGridView1_ColumnHeaderMouseClick(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.ColumnHeaderMouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnHeaderMouseClick Event")

End Sub
'</snippet321>

'<snippet322>
Private Sub DataGridView1_ColumnHeaderMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.ColumnHeaderMouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnHeaderMouseDoubleClick Event")

End Sub
'</snippet322>

'<snippet323>
Private Sub DataGridView1_ColumnHeaderCellChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnHeaderCellChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnHeaderCellChanged Event")

End Sub
'</snippet323>

'<snippet324>
Private Sub DataGridView1_ColumnMinimumWidthChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnMinimumWidthChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnMinimumWidthChanged Event")

End Sub
'</snippet324>

'<snippet325>
Private Sub DataGridView1_ColumnNameChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnNameChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnNameChanged Event")

End Sub
'</snippet325>

'<snippet326>
Private Sub DataGridView1_ColumnRemoved(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnRemoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnRemoved Event")

End Sub
'</snippet326>

'<snippet327>
Private Sub DataGridView1_ColumnSortModeChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnSortModeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnSortModeChanged Event")

End Sub
'</snippet327>

'<snippet328>
Private Sub DataGridView1_ColumnStateChanged(sender as Object, e as DataGridViewColumnStateChangedEventArgs) _ 
     Handles DataGridView1.ColumnStateChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnStateChanged Event")

End Sub
'</snippet328>

'<snippet329>
Private Sub DataGridView1_ColumnToolTipTextChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnToolTipTextChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnToolTipTextChanged Event")

End Sub
'</snippet329>

'<snippet330>
Private Sub DataGridView1_ColumnWidthChanged(sender as Object, e as DataGridViewColumnEventArgs) _ 
     Handles DataGridView1.ColumnWidthChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnWidthChanged Event")

End Sub
'</snippet330>

'<snippet331>
Private Sub DataGridView1_CurrentCellChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.CurrentCellChanged

   MessageBox.Show("You are in the DataGridView.CurrentCellChanged event.")

End Sub
'</snippet331>

'<snippet332>
Private Sub DataGridView1_CurrentCellDirtyStateChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.CurrentCellDirtyStateChanged

   MessageBox.Show("You are in the DataGridView.CurrentCellDirtyStateChanged event.")

End Sub
'</snippet332>

'<snippet333>
Private Sub DataGridView1_DataBindingComplete(sender as Object, e as DataGridViewBindingCompleteEventArgs) _ 
     Handles DataGridView1.DataBindingComplete

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ListChangedType", e.ListChangedType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DataBindingComplete Event")

End Sub
'</snippet333>

'<snippet334>
Private Sub DataGridView1_DataError(sender as Object, e as DataGridViewDataErrorEventArgs) _ 
     Handles DataGridView1.DataError

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Context", e.Context)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Exception", e.Exception)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ThrowException", e.ThrowException)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DataError Event")

End Sub
'</snippet334>

'<snippet335>
Private Sub DataGridView1_DefaultValuesNeeded(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.DefaultValuesNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DefaultValuesNeeded Event")

End Sub
'</snippet335>

'<snippet336>
Private Sub DataGridView1_EditingControlShowing(sender as Object, e as DataGridViewEditingControlShowingEventArgs) _ 
     Handles DataGridView1.EditingControlShowing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CellStyle", e.CellStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"EditingControlShowing Event")

End Sub
'</snippet336>

'<snippet337>
Private Sub DataGridView1_NewRowNeeded(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.NewRowNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"NewRowNeeded Event")

End Sub
'</snippet337>

'<snippet338>
Private Sub DataGridView1_RowContextMenuStripChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowContextMenuStripChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowContextMenuStripChanged Event")

End Sub
'</snippet338>

'<snippet339>
Private Sub DataGridView1_RowContextMenuStripNeeded(sender as Object, e as DataGridViewRowContextMenuStripNeededEventArgs) _ 
     Handles DataGridView1.RowContextMenuStripNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ContextMenuStrip", e.ContextMenuStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowContextMenuStripNeeded Event")

End Sub
'</snippet339>

'<snippet340>
Private Sub DataGridView1_RowDefaultCellStyleChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowDefaultCellStyleChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowDefaultCellStyleChanged Event")

End Sub
'</snippet340>

'<snippet341>
Private Sub DataGridView1_RowDirtyStateNeeded(sender as Object, e as QuestionEventArgs) _ 
     Handles DataGridView1.RowDirtyStateNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Response", e.Response)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowDirtyStateNeeded Event")

End Sub
'</snippet341>

'<snippet342>
Private Sub DataGridView1_RowDividerDoubleClick(sender as Object, e as DataGridViewRowDividerDoubleClickEventArgs) _ 
     Handles DataGridView1.RowDividerDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowDividerDoubleClick Event")

End Sub
'</snippet342>

'<snippet343>
Private Sub DataGridView1_RowDividerHeightChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowDividerHeightChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowDividerHeightChanged Event")

End Sub
'</snippet343>

'<snippet344>
Private Sub DataGridView1_RowEnter(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.RowEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowEnter Event")

End Sub
'</snippet344>

'<snippet345>
Private Sub DataGridView1_RowErrorTextChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowErrorTextChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowErrorTextChanged Event")

End Sub
'</snippet345>

'<snippet346>
Private Sub DataGridView1_RowErrorTextNeeded(sender as Object, e as DataGridViewRowErrorTextNeededEventArgs) _ 
     Handles DataGridView1.RowErrorTextNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowErrorTextNeeded Event")

End Sub
'</snippet346>

'<snippet347>
Private Sub DataGridView1_RowHeaderMouseClick(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.RowHeaderMouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeaderMouseClick Event")

End Sub
'</snippet347>

'<snippet348>
Private Sub DataGridView1_RowHeaderMouseDoubleClick(sender as Object, e as DataGridViewCellMouseEventArgs) _ 
     Handles DataGridView1.RowHeaderMouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeaderMouseDoubleClick Event")

End Sub
'</snippet348>

'<snippet349>
Private Sub DataGridView1_RowHeaderCellChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowHeaderCellChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeaderCellChanged Event")

End Sub
'</snippet349>

'<snippet350>
Private Sub DataGridView1_RowHeightChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowHeightChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeightChanged Event")

End Sub
'</snippet350>

'<snippet351>
Private Sub DataGridView1_RowHeightInfoNeeded(sender as Object, e as DataGridViewRowHeightInfoNeededEventArgs) _ 
     Handles DataGridView1.RowHeightInfoNeeded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Height", e.Height)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeightInfoNeeded Event")

End Sub
'</snippet351>

'<snippet352>
Private Sub DataGridView1_RowHeightInfoPushed(sender as Object, e as DataGridViewRowHeightInfoPushedEventArgs) _ 
     Handles DataGridView1.RowHeightInfoPushed

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Height", e.Height)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MinimumHeight", e.MinimumHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowHeightInfoPushed Event")

End Sub
'</snippet352>

'<snippet353>
Private Sub DataGridView1_RowLeave(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.RowLeave

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowLeave Event")

End Sub
'</snippet353>

'<snippet354>
Private Sub DataGridView1_RowMinimumHeightChanged(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowMinimumHeightChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowMinimumHeightChanged Event")

End Sub
'</snippet354>

'<snippet355>
Private Sub DataGridView1_RowPostPaint(sender as Object, e as DataGridViewRowPostPaintEventArgs) _ 
     Handles DataGridView1.RowPostPaint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "InheritedRowStyle", e.InheritedRowStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsFirstDisplayedRow", e.IsFirstDisplayedRow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsLastVisibleRow", e.IsLastVisibleRow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowBounds", e.RowBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowPostPaint Event")

End Sub
'</snippet355>

'<snippet356>
Private Sub DataGridView1_RowPrePaint(sender as Object, e as DataGridViewRowPrePaintEventArgs) _ 
     Handles DataGridView1.RowPrePaint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipBounds", e.ClipBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ErrorText", e.ErrorText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "InheritedRowStyle", e.InheritedRowStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsFirstDisplayedRow", e.IsFirstDisplayedRow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsLastVisibleRow", e.IsLastVisibleRow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "PaintParts", e.PaintParts)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowBounds", e.RowBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowPrePaint Event")

End Sub
'</snippet356>

'<snippet357>
Private Sub DataGridView1_RowsAdded(sender as Object, e as DataGridViewRowsAddedEventArgs) _ 
     Handles DataGridView1.RowsAdded

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowCount", e.RowCount)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowsAdded Event")

End Sub
'</snippet357>

'<snippet358>
Private Sub DataGridView1_RowsRemoved(sender as Object, e as DataGridViewRowsRemovedEventArgs) _ 
     Handles DataGridView1.RowsRemoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowCount", e.RowCount)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowsRemoved Event")

End Sub
'</snippet358>

'<snippet359>
Private Sub DataGridView1_RowStateChanged(sender as Object, e as DataGridViewRowStateChangedEventArgs) _ 
     Handles DataGridView1.RowStateChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StateChanged", e.StateChanged)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowStateChanged Event")

End Sub
'</snippet359>

'<snippet360>
Private Sub DataGridView1_RowUnshared(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.RowUnshared

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowUnshared Event")

End Sub
'</snippet360>

'<snippet361>
Private Sub DataGridView1_RowValidated(sender as Object, e as DataGridViewCellEventArgs) _ 
     Handles DataGridView1.RowValidated

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowValidated Event")

End Sub
'</snippet361>

'<snippet362>
Private Sub DataGridView1_RowValidating(sender as Object, e as DataGridViewCellCancelEventArgs) _ 
     Handles DataGridView1.RowValidating

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RowValidating Event")

End Sub
'</snippet362>

'<snippet363>
Private Sub DataGridView1_Scroll(sender as Object, e as ScrollEventArgs) _ 
     Handles DataGridView1.Scroll

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ScrollOrientation", e.ScrollOrientation)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Type", e.Type)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldValue", e.OldValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Scroll Event")

End Sub
'</snippet363>

'<snippet364>
Private Sub DataGridView1_SelectionChanged(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.SelectionChanged

   MessageBox.Show("You are in the DataGridView.SelectionChanged event.")

End Sub
'</snippet364>

'<snippet365>
Private Sub DataGridView1_SortCompare(sender as Object, e as DataGridViewSortCompareEventArgs) _ 
     Handles DataGridView1.SortCompare

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CellValue1", e.CellValue1)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CellValue2", e.CellValue2)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex1", e.RowIndex1)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RowIndex2", e.RowIndex2)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SortResult", e.SortResult)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SortCompare Event")

End Sub
'</snippet365>

'<snippet366>
Private Sub DataGridView1_Sorted(sender as Object, e as EventArgs) _ 
     Handles DataGridView1.Sorted

   MessageBox.Show("You are in the DataGridView.Sorted event.")

End Sub
'</snippet366>

'<snippet367>
Private Sub DataGridView1_UserAddedRow(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.UserAddedRow

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"UserAddedRow Event")

End Sub
'</snippet367>

'<snippet368>
Private Sub DataGridView1_UserDeletedRow(sender as Object, e as DataGridViewRowEventArgs) _ 
     Handles DataGridView1.UserDeletedRow

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"UserDeletedRow Event")

End Sub
'</snippet368>

'<snippet369>
Private Sub DataGridView1_UserDeletingRow(sender as Object, e as DataGridViewRowCancelEventArgs) _ 
     Handles DataGridView1.UserDeletingRow

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"UserDeletingRow Event")

End Sub
'</snippet369>

Public WithEvents DataGridViewColumn1 as DataGridViewColumn
'<snippet370>
Private Sub DataGridViewColumn1_Disposed(sender as Object, e as EventArgs) _ 
     Handles DataGridViewColumn1.Disposed

   MessageBox.Show("You are in the DataGridViewColumn.Disposed event.")

End Sub
'</snippet370>

Public WithEvents DataGridViewButtonColumn1 as DataGridViewButtonColumn
Public WithEvents DataGridViewCellCollection1 as DataGridViewCellCollection
'<snippet371>
Private Sub DataGridViewCellCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles DataGridViewCellCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub
'</snippet371>

Public WithEvents DataGridViewCheckBoxColumn1 as DataGridViewCheckBoxColumn
Public WithEvents DataGridViewColumnCollection1 as DataGridViewColumnCollection
'<snippet372>
Private Sub DataGridViewColumnCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles DataGridViewColumnCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub
'</snippet372>

Public WithEvents DataGridViewComboBoxColumn1 as DataGridViewComboBoxColumn
Public WithEvents DataGridViewComboBoxEditingControl1 as DataGridViewComboBoxEditingControl
Public WithEvents DataGridViewImageColumn1 as DataGridViewImageColumn
Public WithEvents DataGridViewLinkColumn1 as DataGridViewLinkColumn
Public WithEvents DataGridViewRowCollection1 as DataGridViewRowCollection
'<snippet373>
Private Sub DataGridViewRowCollection1_CollectionChanged(sender as Object, e as CollectionChangeEventArgs) _ 
     Handles DataGridViewRowCollection1.CollectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Element", e.Element)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CollectionChanged Event")

End Sub
'</snippet373>

Public WithEvents DataGridViewTextBoxColumn1 as DataGridViewTextBoxColumn
Public WithEvents DataGridViewTextBoxEditingControl1 as DataGridViewTextBoxEditingControl
Public WithEvents DateTimePicker1 as DateTimePicker
'<snippet374>
Private Sub DateTimePicker1_FormatChanged(sender as Object, e as EventArgs) _ 
     Handles DateTimePicker1.FormatChanged

   MessageBox.Show("You are in the DateTimePicker.FormatChanged event.")

End Sub
'</snippet374>

'<snippet375>
Private Sub DateTimePicker1_TextChanged(sender as Object, e as EventArgs) _ 
     Handles DateTimePicker1.TextChanged

   MessageBox.Show("You are in the DateTimePicker.TextChanged event.")

End Sub
'</snippet375>

'<snippet376>
Private Sub DateTimePicker1_CloseUp(sender as Object, e as EventArgs) _ 
     Handles DateTimePicker1.CloseUp

   MessageBox.Show("You are in the DateTimePicker.CloseUp event.")

End Sub
'</snippet376>

'<snippet377>
Private Sub DateTimePicker1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles DateTimePicker1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the DateTimePicker.RightToLeftLayoutChanged event.")

End Sub
'</snippet377>

'<snippet378>
Private Sub DateTimePicker1_ValueChanged(sender as Object, e as EventArgs) _ 
     Handles DateTimePicker1.ValueChanged

   MessageBox.Show("You are in the DateTimePicker.ValueChanged event.")

End Sub
'</snippet378>

'<snippet379>
Private Sub DateTimePicker1_DropDown(sender as Object, e as EventArgs) _ 
     Handles DateTimePicker1.DropDown

   MessageBox.Show("You are in the DateTimePicker.DropDown event.")

End Sub
'</snippet379>

Public WithEvents UpDownBase1 as UpDownBase
'<snippet380>
Private Sub UpDownBase1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles UpDownBase1.AutoSizeChanged

   MessageBox.Show("You are in the UpDownBase.AutoSizeChanged event.")

End Sub
'</snippet380>

Public WithEvents DomainUpDown1 as DomainUpDown
'<snippet381>
Private Sub DomainUpDown1_SelectedItemChanged(sender as Object, e as EventArgs) _ 
     Handles DomainUpDown1.SelectedItemChanged

   MessageBox.Show("You are in the DomainUpDown.SelectedItemChanged event.")

End Sub
'</snippet381>

Public WithEvents ErrorProvider1 as ErrorProvider
'<snippet382>
Private Sub ErrorProvider1_RightToLeftChanged(sender as Object, e as EventArgs) _ 
     Handles ErrorProvider1.RightToLeftChanged

   MessageBox.Show("You are in the ErrorProvider.RightToLeftChanged event.")

End Sub
'</snippet382>

Public WithEvents FileDialog1 as FileDialog
'<snippet383>
Private Sub FileDialog1_FileOk(sender as Object, e as CancelEventArgs) _ 
     Handles FileDialog1.FileOk

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"FileOk Event")

End Sub
'</snippet383>

Public WithEvents Panel1 as Panel
'<snippet384>
Private Sub Panel1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles Panel1.AutoSizeChanged

   MessageBox.Show("You are in the Panel.AutoSizeChanged event.")

End Sub
'</snippet384>

Public WithEvents FlowLayoutPanel1 as FlowLayoutPanel
Public WithEvents FolderBrowserDialog1 as FolderBrowserDialog
Public WithEvents FontDialog1 as FontDialog
'<snippet385>
Private Sub FontDialog1_Apply(sender as Object, e as EventArgs) _ 
     Handles FontDialog1.Apply

   MessageBox.Show("You are in the FontDialog.Apply event.")

End Sub
'</snippet385>

Public WithEvents Form1 as Form
'<snippet386>
Private Sub Form1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles Form1.AutoSizeChanged

   MessageBox.Show("You are in the Form.AutoSizeChanged event.")

End Sub
'</snippet386>

'<snippet387>
Private Sub Form1_AutoValidateChanged(sender as Object, e as EventArgs) _ 
     Handles Form1.AutoValidateChanged

   MessageBox.Show("You are in the Form.AutoValidateChanged event.")

End Sub
'</snippet387>

'<snippet388>
Private Sub Form1_HelpButtonClicked(sender as Object, e as CancelEventArgs) _ 
     Handles Form1.HelpButtonClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"HelpButtonClicked Event")

End Sub
'</snippet388>

'<snippet389>
Private Sub Form1_MaximizedBoundsChanged(sender as Object, e as EventArgs) _ 
     Handles Form1.MaximizedBoundsChanged

   MessageBox.Show("You are in the Form.MaximizedBoundsChanged event.")

End Sub
'</snippet389>

'<snippet390>
Private Sub Form1_MaximumSizeChanged(sender as Object, e as EventArgs) _ 
     Handles Form1.MaximumSizeChanged

   MessageBox.Show("You are in the Form.MaximumSizeChanged event.")

End Sub
'</snippet390>

'<snippet391>
Private Sub Form1_MinimumSizeChanged(sender as Object, e as EventArgs) _ 
     Handles Form1.MinimumSizeChanged

   MessageBox.Show("You are in the Form.MinimumSizeChanged event.")

End Sub
'</snippet391>

'<snippet392>
Private Sub Form1_Activated(sender as Object, e as EventArgs) _ 
     Handles Form1.Activated

   MessageBox.Show("You are in the Form.Activated event.")

End Sub
'</snippet392>

'<snippet393>
Private Sub Form1_Deactivate(sender as Object, e as EventArgs) _ 
     Handles Form1.Deactivate

   MessageBox.Show("You are in the Form.Deactivate event.")

End Sub
'</snippet393>

'<snippet394>
Private Sub Form1_FormClosing(sender as Object, e as FormClosingEventArgs) _ 
     Handles Form1.FormClosing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"FormClosing Event")

End Sub
'</snippet394>

'<snippet395>
Private Sub Form1_FormClosed(sender as Object, e as FormClosedEventArgs) _ 
     Handles Form1.FormClosed

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"FormClosed Event")

End Sub
'</snippet395>

'<snippet396>
Private Sub Form1_Load(sender as Object, e as EventArgs) _ 
     Handles Form1.Load

   MessageBox.Show("You are in the Form.Load event.")

End Sub
'</snippet396>

'<snippet397>
Private Sub Form1_MdiChildActivate(sender as Object, e as EventArgs) _ 
     Handles Form1.MdiChildActivate

   MessageBox.Show("You are in the Form.MdiChildActivate event.")

End Sub
'</snippet397>

'<snippet398>
Private Sub Form1_MenuComplete(sender as Object, e as EventArgs) _ 
     Handles Form1.MenuComplete

   MessageBox.Show("You are in the Form.MenuComplete event.")

End Sub
'</snippet398>

'<snippet399>
Private Sub Form1_MenuStart(sender as Object, e as EventArgs) _ 
     Handles Form1.MenuStart

   MessageBox.Show("You are in the Form.MenuStart event.")

End Sub
'</snippet399>

'<snippet400>
Private Sub Form1_InputLanguageChanged(sender as Object, e as InputLanguageChangedEventArgs) _ 
     Handles Form1.InputLanguageChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Culture", e.Culture)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CharSet", e.CharSet)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"InputLanguageChanged Event")

End Sub
'</snippet400>

'<snippet401>
Private Sub Form1_InputLanguageChanging(sender as Object, e as InputLanguageChangingEventArgs) _ 
     Handles Form1.InputLanguageChanging

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "InputLanguage", e.InputLanguage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Culture", e.Culture)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SysCharSet", e.SysCharSet)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"InputLanguageChanging Event")

End Sub
'</snippet401>

'<snippet402>
Private Sub Form1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles Form1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the Form.RightToLeftLayoutChanged event.")

End Sub
'</snippet402>

'<snippet403>
Private Sub Form1_Shown(sender as Object, e as EventArgs) _ 
     Handles Form1.Shown

   MessageBox.Show("You are in the Form.Shown event.")

End Sub
'</snippet403>

'<snippet404>
Private Sub Form1_ResizeBegin(sender as Object, e as EventArgs) _ 
     Handles Form1.ResizeBegin

   MessageBox.Show("You are in the Form.ResizeBegin event.")

End Sub
'</snippet404>

'<snippet405>
Private Sub Form1_ResizeEnd(sender as Object, e as EventArgs) _ 
     Handles Form1.ResizeEnd

   MessageBox.Show("You are in the Form.ResizeEnd event.")

End Sub
'</snippet405>

Public WithEvents GroupBox1 as GroupBox
'<snippet406>
Private Sub GroupBox1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles GroupBox1.AutoSizeChanged

   MessageBox.Show("You are in the GroupBox.AutoSizeChanged event.")

End Sub
'</snippet406>

'<snippet407>
Private Sub GroupBox1_TabStopChanged(sender as Object, e as EventArgs) _ 
     Handles GroupBox1.TabStopChanged

   MessageBox.Show("You are in the GroupBox.TabStopChanged event.")

End Sub
'</snippet407>

'<snippet408>
Private Sub GroupBox1_Click(sender as Object, e as EventArgs) _ 
     Handles GroupBox1.Click

   MessageBox.Show("You are in the GroupBox.Click event.")

End Sub
'</snippet408>

'<snippet409>
Private Sub GroupBox1_MouseClick(sender as Object, e as MouseEventArgs) _ 
     Handles GroupBox1.MouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseClick Event")

End Sub
'</snippet409>

'<snippet410>
Private Sub GroupBox1_DoubleClick(sender as Object, e as EventArgs) _ 
     Handles GroupBox1.DoubleClick

   MessageBox.Show("You are in the GroupBox.DoubleClick event.")

End Sub
'</snippet410>

'<snippet411>
Private Sub GroupBox1_MouseDoubleClick(sender as Object, e as MouseEventArgs) _ 
     Handles GroupBox1.MouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDoubleClick Event")

End Sub
'</snippet411>

'<snippet412>
Private Sub GroupBox1_KeyUp(sender as Object, e as KeyEventArgs) _ 
     Handles GroupBox1.KeyUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyUp Event")

End Sub
'</snippet412>

'<snippet413>
Private Sub GroupBox1_KeyDown(sender as Object, e as KeyEventArgs) _ 
     Handles GroupBox1.KeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyDown Event")

End Sub
'</snippet413>

'<snippet414>
Private Sub GroupBox1_KeyPress(sender as Object, e as KeyPressEventArgs) _ 
     Handles GroupBox1.KeyPress

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyPress Event")

End Sub
'</snippet414>

'<snippet415>
Private Sub GroupBox1_MouseDown(sender as Object, e as MouseEventArgs) _ 
     Handles GroupBox1.MouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDown Event")

End Sub
'</snippet415>

'<snippet416>
Private Sub GroupBox1_MouseUp(sender as Object, e as MouseEventArgs) _ 
     Handles GroupBox1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub
'</snippet416>

'<snippet417>
Private Sub GroupBox1_MouseMove(sender as Object, e as MouseEventArgs) _ 
     Handles GroupBox1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub
'</snippet417>

'<snippet418>
Private Sub GroupBox1_MouseEnter(sender as Object, e as EventArgs) _ 
     Handles GroupBox1.MouseEnter

   MessageBox.Show("You are in the GroupBox.MouseEnter event.")

End Sub
'</snippet418>

'<snippet419>
Private Sub GroupBox1_MouseLeave(sender as Object, e as EventArgs) _ 
     Handles GroupBox1.MouseLeave

   MessageBox.Show("You are in the GroupBox.MouseLeave event.")

End Sub
'</snippet419>

Public WithEvents HelpProvider1 as HelpProvider
Public WithEvents ScrollBar1 as ScrollBar
'<snippet420>
Private Sub ScrollBar1_Scroll(sender as Object, e as ScrollEventArgs) _ 
     Handles ScrollBar1.Scroll

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ScrollOrientation", e.ScrollOrientation)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Type", e.Type)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldValue", e.OldValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Scroll Event")

End Sub
'</snippet420>

'<snippet421>
Private Sub ScrollBar1_ValueChanged(sender as Object, e as EventArgs) _ 
     Handles ScrollBar1.ValueChanged

   MessageBox.Show("You are in the ScrollBar.ValueChanged event.")

End Sub
'</snippet421>

Public WithEvents HScrollBar1 as HScrollBar
Public WithEvents HtmlDocument1 as HtmlDocument
'<snippet422>
Private Sub HtmlDocument1_Click(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.Click

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Click Event")

End Sub
'</snippet422>

'<snippet423>
Private Sub HtmlDocument1_ContextMenuShowing(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.ContextMenuShowing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ContextMenuShowing Event")

End Sub
'</snippet423>

'<snippet424>
Private Sub HtmlDocument1_Focusing(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.Focusing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Focusing Event")

End Sub
'</snippet424>

'<snippet425>
Private Sub HtmlDocument1_LosingFocus(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.LosingFocus

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LosingFocus Event")

End Sub
'</snippet425>

'<snippet426>
Private Sub HtmlDocument1_MouseDown(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.MouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDown Event")

End Sub
'</snippet426>

'<snippet427>
Private Sub HtmlDocument1_MouseLeave(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.MouseLeave

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseLeave Event")

End Sub
'</snippet427>

'<snippet428>
Private Sub HtmlDocument1_MouseMove(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub
'</snippet428>

'<snippet429>
Private Sub HtmlDocument1_MouseOver(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.MouseOver

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseOver Event")

End Sub
'</snippet429>

'<snippet430>
Private Sub HtmlDocument1_MouseUp(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub
'</snippet430>

'<snippet431>
Private Sub HtmlDocument1_Stop(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlDocument1.Stop

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Stop Event")

End Sub
'</snippet431>

Public WithEvents HtmlElement1 as HtmlElement
'<snippet432>
Private Sub HtmlElement1_Click(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.Click

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Click Event")

End Sub
'</snippet432>

'<snippet433>
Private Sub HtmlElement1_DoubleClick(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.DoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DoubleClick Event")

End Sub
'</snippet433>

'<snippet434>
Private Sub HtmlElement1_Drag(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.Drag

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Drag Event")

End Sub
'</snippet434>

'<snippet435>
Private Sub HtmlElement1_DragEnd(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.DragEnd

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragEnd Event")

End Sub
'</snippet435>

'<snippet436>
Private Sub HtmlElement1_DragLeave(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.DragLeave

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragLeave Event")

End Sub
'</snippet436>

'<snippet437>
Private Sub HtmlElement1_DragOver(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.DragOver

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragOver Event")

End Sub
'</snippet437>

'<snippet438>
Private Sub HtmlElement1_Focusing(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.Focusing

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Focusing Event")

End Sub
'</snippet438>

'<snippet439>
Private Sub HtmlElement1_GotFocus(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.GotFocus

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"GotFocus Event")

End Sub
'</snippet439>

'<snippet440>
Private Sub HtmlElement1_LosingFocus(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.LosingFocus

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LosingFocus Event")

End Sub
'</snippet440>

'<snippet441>
Private Sub HtmlElement1_LostFocus(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.LostFocus

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LostFocus Event")

End Sub
'</snippet441>

'<snippet442>
Private Sub HtmlElement1_KeyDown(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.KeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyDown Event")

End Sub
'</snippet442>

'<snippet443>
Private Sub HtmlElement1_KeyPress(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.KeyPress

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyPress Event")

End Sub
'</snippet443>

'<snippet444>
Private Sub HtmlElement1_KeyUp(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.KeyUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyUp Event")

End Sub
'</snippet444>

'<snippet445>
Private Sub HtmlElement1_MouseMove(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub
'</snippet445>

'<snippet446>
Private Sub HtmlElement1_MouseDown(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.MouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDown Event")

End Sub
'</snippet446>

'<snippet447>
Private Sub HtmlElement1_MouseOver(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.MouseOver

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseOver Event")

End Sub
'</snippet447>

'<snippet448>
Private Sub HtmlElement1_MouseUp(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub
'</snippet448>

'<snippet449>
Private Sub HtmlElement1_MouseEnter(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.MouseEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseEnter Event")

End Sub
'</snippet449>

'<snippet450>
Private Sub HtmlElement1_MouseLeave(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlElement1.MouseLeave

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseLeave Event")

End Sub
'</snippet450>

Public WithEvents HtmlWindow1 as HtmlWindow
'<snippet451>
Private Sub HtmlWindow1_Error(sender as Object, e as HtmlElementErrorEventArgs) _ 
     Handles HtmlWindow1.Error

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Description", e.Description)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "LineNumber", e.LineNumber)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Error Event")

End Sub
'</snippet451>

'<snippet452>
Private Sub HtmlWindow1_GotFocus(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlWindow1.GotFocus

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"GotFocus Event")

End Sub
'</snippet452>

'<snippet453>
Private Sub HtmlWindow1_Load(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlWindow1.Load

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Load Event")

End Sub
'</snippet453>

'<snippet454>
Private Sub HtmlWindow1_LostFocus(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlWindow1.LostFocus

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LostFocus Event")

End Sub
'</snippet454>

'<snippet455>
Private Sub HtmlWindow1_Resize(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlWindow1.Resize

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Resize Event")

End Sub
'</snippet455>

'<snippet456>
Private Sub HtmlWindow1_Scroll(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlWindow1.Scroll

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Scroll Event")

End Sub
'</snippet456>

'<snippet457>
Private Sub HtmlWindow1_Unload(sender as Object, e as HtmlElementEventArgs) _ 
     Handles HtmlWindow1.Unload

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseButtonsPressed", e.MouseButtonsPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClientMousePosition", e.ClientMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OffsetMousePosition", e.OffsetMousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MousePosition", e.MousePosition)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BubbleEvent", e.BubbleEvent)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyPressedCode", e.KeyPressedCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AltKeyPressed", e.AltKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CtrlKeyPressed", e.CtrlKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ShiftKeyPressed", e.ShiftKeyPressed)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EventType", e.EventType)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "FromElement", e.FromElement)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToElement", e.ToElement)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Unload Event")

End Sub
'</snippet457>

Public WithEvents Label1 as Label
'<snippet458>
Private Sub Label1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles Label1.AutoSizeChanged

   MessageBox.Show("You are in the Label.AutoSizeChanged event.")

End Sub
'</snippet458>

'<snippet459>
Private Sub Label1_TextAlignChanged(sender as Object, e as EventArgs) _ 
     Handles Label1.TextAlignChanged

   MessageBox.Show("You are in the Label.TextAlignChanged event.")

End Sub
'</snippet459>

Public WithEvents LinkLabel1 as LinkLabel
'<snippet460>
Private Sub LinkLabel1_TabStopChanged(sender as Object, e as EventArgs) _ 
     Handles LinkLabel1.TabStopChanged

   MessageBox.Show("You are in the LinkLabel.TabStopChanged event.")

End Sub
'</snippet460>

'<snippet461>
Private Sub LinkLabel1_LinkClicked(sender as Object, e as LinkLabelLinkClickedEventArgs) _ 
     Handles LinkLabel1.LinkClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Link", e.Link)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LinkClicked Event")

End Sub
'</snippet461>

Public WithEvents ListView1 as ListView
'<snippet462>
Private Sub ListView1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles ListView1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the ListView.RightToLeftLayoutChanged event.")

End Sub
'</snippet462>

'<snippet463>
Private Sub ListView1_AfterLabelEdit(sender as Object, e as LabelEditEventArgs) _ 
     Handles ListView1.AfterLabelEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Label", e.Label)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterLabelEdit Event")

End Sub
'</snippet463>

'<snippet464>
Private Sub ListView1_BeforeLabelEdit(sender as Object, e as LabelEditEventArgs) _ 
     Handles ListView1.BeforeLabelEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Label", e.Label)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BeforeLabelEdit Event")

End Sub
'</snippet464>

'<snippet465>
Private Sub ListView1_CacheVirtualItems(sender as Object, e as CacheVirtualItemsEventArgs) _ 
     Handles ListView1.CacheVirtualItems

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CacheVirtualItems Event")

End Sub
'</snippet465>

'<snippet466>
Private Sub ListView1_ColumnClick(sender as Object, e as ColumnClickEventArgs) _ 
     Handles ListView1.ColumnClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnClick Event")

End Sub
'</snippet466>

'<snippet467>
Private Sub ListView1_ColumnReordered(sender as Object, e as ColumnReorderedEventArgs) _ 
     Handles ListView1.ColumnReordered

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "OldDisplayIndex", e.OldDisplayIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewDisplayIndex", e.NewDisplayIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Header", e.Header)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnReordered Event")

End Sub
'</snippet467>

'<snippet468>
Private Sub ListView1_ColumnWidthChanged(sender as Object, e as ColumnWidthChangedEventArgs) _ 
     Handles ListView1.ColumnWidthChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnWidthChanged Event")

End Sub
'</snippet468>

'<snippet469>
Private Sub ListView1_ColumnWidthChanging(sender as Object, e as ColumnWidthChangingEventArgs) _ 
     Handles ListView1.ColumnWidthChanging

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewWidth", e.NewWidth)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ColumnWidthChanging Event")

End Sub
'</snippet469>

'<snippet470>
Private Sub ListView1_DrawColumnHeader(sender as Object, e as DrawListViewColumnHeaderEventArgs) _ 
     Handles ListView1.DrawColumnHeader

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Header", e.Header)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawColumnHeader Event")

End Sub
'</snippet470>

'<snippet471>
Private Sub ListView1_DrawItem(sender as Object, e as DrawListViewItemEventArgs) _ 
     Handles ListView1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub
'</snippet471>

'<snippet472>
Private Sub ListView1_DrawSubItem(sender as Object, e as DrawListViewSubItemEventArgs) _ 
     Handles ListView1.DrawSubItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SubItem", e.SubItem)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Header", e.Header)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemState", e.ItemState)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawSubItem Event")

End Sub
'</snippet472>

'<snippet473>
Private Sub ListView1_ItemActivate(sender as Object, e as EventArgs) _ 
     Handles ListView1.ItemActivate

   MessageBox.Show("You are in the ListView.ItemActivate event.")

End Sub
'</snippet473>

'<snippet474>
Private Sub ListView1_ItemCheck(sender as Object, e as ItemCheckEventArgs) _ 
     Handles ListView1.ItemCheck

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewValue", e.NewValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "CurrentValue", e.CurrentValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemCheck Event")

End Sub
'</snippet474>

'<snippet475>
Private Sub ListView1_ItemChecked(sender as Object, e as ItemCheckedEventArgs) _ 
     Handles ListView1.ItemChecked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemChecked Event")

End Sub
'</snippet475>

'<snippet476>
Private Sub ListView1_ItemDrag(sender as Object, e as ItemDragEventArgs) _ 
     Handles ListView1.ItemDrag

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemDrag Event")

End Sub
'</snippet476>

'<snippet477>
Private Sub ListView1_ItemMouseHover(sender as Object, e as ListViewItemMouseHoverEventArgs) _ 
     Handles ListView1.ItemMouseHover

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemMouseHover Event")

End Sub
'</snippet477>

'<snippet478>
Private Sub ListView1_ItemSelectionChanged(sender as Object, e as ListViewItemSelectionChangedEventArgs) _ 
     Handles ListView1.ItemSelectionChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemSelectionChanged Event")

End Sub
'</snippet478>

'<snippet479>
Private Sub ListView1_RetrieveVirtualItem(sender as Object, e as RetrieveVirtualItemEventArgs) _ 
     Handles ListView1.RetrieveVirtualItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemIndex", e.ItemIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RetrieveVirtualItem Event")

End Sub
'</snippet479>

'<snippet480>
Private Sub ListView1_SearchForVirtualItem(sender as Object, e as SearchForVirtualItemEventArgs) _ 
     Handles ListView1.SearchForVirtualItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "IsTextSearch", e.IsTextSearch)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IncludeSubItemsInSearch", e.IncludeSubItemsInSearch)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsPrefixSearch", e.IsPrefixSearch)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Text", e.Text)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StartingPoint", e.StartingPoint)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Direction", e.Direction)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SearchForVirtualItem Event")

End Sub
'</snippet480>

'<snippet481>
Private Sub ListView1_SelectedIndexChanged(sender as Object, e as EventArgs) _ 
     Handles ListView1.SelectedIndexChanged

   MessageBox.Show("You are in the ListView.SelectedIndexChanged event.")

End Sub
'</snippet481>

'<snippet482>
Private Sub ListView1_VirtualItemsSelectionRangeChanged(sender as Object, e as ListViewVirtualItemsSelectionRangeChangedEventArgs) _ 
     Handles ListView1.VirtualItemsSelectionRangeChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "EndIndex", e.EndIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsSelected", e.IsSelected)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "StartIndex", e.StartIndex)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"VirtualItemsSelectionRangeChanged Event")

End Sub
'</snippet482>

Public WithEvents MainMenu1 as MainMenu
'<snippet483>
Private Sub MainMenu1_Collapse(sender as Object, e as EventArgs) _ 
     Handles MainMenu1.Collapse

   MessageBox.Show("You are in the MainMenu.Collapse event.")

End Sub
'</snippet483>

Public WithEvents MaskedTextBox1 as MaskedTextBox
'<snippet484>
Private Sub MaskedTextBox1_IsOverwriteModeChanged(sender as Object, e as EventArgs) _ 
     Handles MaskedTextBox1.IsOverwriteModeChanged

   MessageBox.Show("You are in the MaskedTextBox.IsOverwriteModeChanged event.")

End Sub
'</snippet484>

'<snippet485>
Private Sub MaskedTextBox1_MaskChanged(sender as Object, e as EventArgs) _ 
     Handles MaskedTextBox1.MaskChanged

   MessageBox.Show("You are in the MaskedTextBox.MaskChanged event.")

End Sub
'</snippet485>

'<snippet486>
Private Sub MaskedTextBox1_MaskInputRejected(sender as Object, e as MaskInputRejectedEventArgs) _ 
     Handles MaskedTextBox1.MaskInputRejected

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Position", e.Position)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "RejectionHint", e.RejectionHint)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MaskInputRejected Event")

End Sub
'</snippet486>

'<snippet487>
Private Sub MaskedTextBox1_TextAlignChanged(sender as Object, e as EventArgs) _ 
     Handles MaskedTextBox1.TextAlignChanged

   MessageBox.Show("You are in the MaskedTextBox.TextAlignChanged event.")

End Sub
'</snippet487>

'<snippet488>
Private Sub MaskedTextBox1_TypeValidationCompleted(sender as Object, e as TypeValidationEventArgs) _ 
     Handles MaskedTextBox1.TypeValidationCompleted

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsValidInput", e.IsValidInput)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Message", e.Message)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ReturnValue", e.ReturnValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ValidatingType", e.ValidatingType)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"TypeValidationCompleted Event")

End Sub
'</snippet488>

Public WithEvents MdiClient1 as MdiClient
Public WithEvents MenuStrip1 as MenuStrip
'<snippet489>
Private Sub MenuStrip1_MenuActivate(sender as Object, e as EventArgs) _ 
     Handles MenuStrip1.MenuActivate

   MessageBox.Show("You are in the MenuStrip.MenuActivate event.")

End Sub
'</snippet489>

'<snippet490>
Private Sub MenuStrip1_MenuDeactivate(sender as Object, e as EventArgs) _ 
     Handles MenuStrip1.MenuDeactivate

   MessageBox.Show("You are in the MenuStrip.MenuDeactivate event.")

End Sub
'</snippet490>

Public WithEvents ToolStripDropDownItem1 as ToolStripDropDownItem
'<snippet491>
Private Sub ToolStripDropDownItem1_DropDownClosed(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDownItem1.DropDownClosed

   MessageBox.Show("You are in the ToolStripDropDownItem.DropDownClosed event.")

End Sub
'</snippet491>

'<snippet492>
Private Sub ToolStripDropDownItem1_DropDownOpening(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDownItem1.DropDownOpening

   MessageBox.Show("You are in the ToolStripDropDownItem.DropDownOpening event.")

End Sub
'</snippet492>

'<snippet493>
Private Sub ToolStripDropDownItem1_DropDownOpened(sender as Object, e as EventArgs) _ 
     Handles ToolStripDropDownItem1.DropDownOpened

   MessageBox.Show("You are in the ToolStripDropDownItem.DropDownOpened event.")

End Sub
'</snippet493>

'<snippet494>
Private Sub ToolStripDropDownItem1_DropDownItemClicked(sender as Object, e as ToolStripItemClickedEventArgs) _ 
     Handles ToolStripDropDownItem1.DropDownItemClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ClickedItem", e.ClickedItem)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DropDownItemClicked Event")

End Sub
'</snippet494>

Public WithEvents ToolStripMenuItem1 as ToolStripMenuItem
'<snippet495>
Private Sub ToolStripMenuItem1_CheckedChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripMenuItem1.CheckedChanged

   MessageBox.Show("You are in the ToolStripMenuItem.CheckedChanged event.")

End Sub
'</snippet495>

'<snippet496>
Private Sub ToolStripMenuItem1_CheckStateChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripMenuItem1.CheckStateChanged

   MessageBox.Show("You are in the ToolStripMenuItem.CheckStateChanged event.")

End Sub
'</snippet496>

Public WithEvents MenuItem1 as MenuItem
'<snippet497>
Private Sub MenuItem1_Click(sender as Object, e as EventArgs) _ 
     Handles MenuItem1.Click

   MessageBox.Show("You are in the MenuItem.Click event.")

End Sub
'</snippet497>

'<snippet498>
Private Sub MenuItem1_DrawItem(sender as Object, e as DrawItemEventArgs) _ 
     Handles MenuItem1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub
'</snippet498>

'<snippet499>
Private Sub MenuItem1_MeasureItem(sender as Object, e as MeasureItemEventArgs) _ 
     Handles MenuItem1.MeasureItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemHeight", e.ItemHeight)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ItemWidth", e.ItemWidth)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MeasureItem Event")

End Sub
'</snippet499>

'<snippet500>
Private Sub MenuItem1_Popup(sender as Object, e as EventArgs) _ 
     Handles MenuItem1.Popup

   MessageBox.Show("You are in the MenuItem.Popup event.")

End Sub
'</snippet500>

'<snippet501>
Private Sub MenuItem1_Select(sender as Object, e as EventArgs) _ 
     Handles MenuItem1.Select

   MessageBox.Show("You are in the MenuItem.Select event.")

End Sub
'</snippet501>

Public WithEvents MonthCalendar1 as MonthCalendar
'<snippet502>
Private Sub MonthCalendar1_DateChanged(sender as Object, e as DateRangeEventArgs) _ 
     Handles MonthCalendar1.DateChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Start", e.Start)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "End", e.End)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DateChanged Event")

End Sub
'</snippet502>

'<snippet503>
Private Sub MonthCalendar1_DateSelected(sender as Object, e as DateRangeEventArgs) _ 
     Handles MonthCalendar1.DateSelected

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Start", e.Start)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "End", e.End)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DateSelected Event")

End Sub
'</snippet503>

'<snippet504>
Private Sub MonthCalendar1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles MonthCalendar1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the MonthCalendar.RightToLeftLayoutChanged event.")

End Sub
'</snippet504>

Public WithEvents NotifyIcon1 as NotifyIcon
'<snippet505>
Private Sub NotifyIcon1_BalloonTipClicked(sender as Object, e as EventArgs) _ 
     Handles NotifyIcon1.BalloonTipClicked

   MessageBox.Show("You are in the NotifyIcon.BalloonTipClicked event.")

End Sub
'</snippet505>

'<snippet506>
Private Sub NotifyIcon1_BalloonTipClosed(sender as Object, e as EventArgs) _ 
     Handles NotifyIcon1.BalloonTipClosed

   MessageBox.Show("You are in the NotifyIcon.BalloonTipClosed event.")

End Sub
'</snippet506>

'<snippet507>
Private Sub NotifyIcon1_BalloonTipShown(sender as Object, e as EventArgs) _ 
     Handles NotifyIcon1.BalloonTipShown

   MessageBox.Show("You are in the NotifyIcon.BalloonTipShown event.")

End Sub
'</snippet507>

'<snippet508>
Private Sub NotifyIcon1_Click(sender as Object, e as EventArgs) _ 
     Handles NotifyIcon1.Click

   MessageBox.Show("You are in the NotifyIcon.Click event.")

End Sub
'</snippet508>

'<snippet509>
Private Sub NotifyIcon1_DoubleClick(sender as Object, e as EventArgs) _ 
     Handles NotifyIcon1.DoubleClick

   MessageBox.Show("You are in the NotifyIcon.DoubleClick event.")

End Sub
'</snippet509>

'<snippet510>
Private Sub NotifyIcon1_MouseClick(sender as Object, e as MouseEventArgs) _ 
     Handles NotifyIcon1.MouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseClick Event")

End Sub
'</snippet510>

'<snippet511>
Private Sub NotifyIcon1_MouseDoubleClick(sender as Object, e as MouseEventArgs) _ 
     Handles NotifyIcon1.MouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDoubleClick Event")

End Sub
'</snippet511>

'<snippet512>
Private Sub NotifyIcon1_MouseDown(sender as Object, e as MouseEventArgs) _ 
     Handles NotifyIcon1.MouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDown Event")

End Sub
'</snippet512>

'<snippet513>
Private Sub NotifyIcon1_MouseMove(sender as Object, e as MouseEventArgs) _ 
     Handles NotifyIcon1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub
'</snippet513>

'<snippet514>
Private Sub NotifyIcon1_MouseUp(sender as Object, e as MouseEventArgs) _ 
     Handles NotifyIcon1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub
'</snippet514>

Public WithEvents NumericUpDown1 as NumericUpDown
'<snippet515>
Private Sub NumericUpDown1_ValueChanged(sender as Object, e as EventArgs) _ 
     Handles NumericUpDown1.ValueChanged

   MessageBox.Show("You are in the NumericUpDown.ValueChanged event.")

End Sub
'</snippet515>

Public WithEvents OpenFileDialog1 as OpenFileDialog
Public WithEvents PictureBox1 as PictureBox
'<snippet516>
Private Sub PictureBox1_LoadCompleted(sender as Object, e as AsyncCompletedEventArgs) _ 
     Handles PictureBox1.LoadCompleted

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancelled", e.Cancelled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Error", e.Error)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "UserState", e.UserState)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LoadCompleted Event")

End Sub
'</snippet516>

'<snippet517>
Private Sub PictureBox1_LoadProgressChanged(sender as Object, e as ProgressChangedEventArgs) _ 
     Handles PictureBox1.LoadProgressChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ProgressPercentage", e.ProgressPercentage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "UserState", e.UserState)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LoadProgressChanged Event")

End Sub
'</snippet517>

'<snippet518>
Private Sub PictureBox1_SizeModeChanged(sender as Object, e as EventArgs) _ 
     Handles PictureBox1.SizeModeChanged

   MessageBox.Show("You are in the PictureBox.SizeModeChanged event.")

End Sub
'</snippet518>

Public WithEvents ProgressBar1 as ProgressBar
'<snippet519>
Private Sub ProgressBar1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles ProgressBar1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the ProgressBar.RightToLeftLayoutChanged event.")

End Sub
'</snippet519>

    Public WithEvents PropertyGrid1 As PropertyGrid
'<snippet521>
Private Sub PropertyGrid1_TextChanged(sender as Object, e as EventArgs) _ 
     Handles PropertyGrid1.TextChanged

   MessageBox.Show("You are in the PropertyGrid.TextChanged event.")

End Sub
'</snippet521>

'<snippet522>
Private Sub PropertyGrid1_KeyDown(sender as Object, e as KeyEventArgs) _ 
     Handles PropertyGrid1.KeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyDown Event")

End Sub
'</snippet522>

'<snippet523>
Private Sub PropertyGrid1_KeyPress(sender as Object, e as KeyPressEventArgs) _ 
     Handles PropertyGrid1.KeyPress

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyPress Event")

End Sub
'</snippet523>

'<snippet524>
Private Sub PropertyGrid1_KeyUp(sender as Object, e as KeyEventArgs) _ 
     Handles PropertyGrid1.KeyUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyUp Event")

End Sub
'</snippet524>

'<snippet525>
Private Sub PropertyGrid1_MouseDown(sender as Object, e as MouseEventArgs) _ 
     Handles PropertyGrid1.MouseDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseDown Event")

End Sub
'</snippet525>

'<snippet526>
Private Sub PropertyGrid1_MouseUp(sender as Object, e as MouseEventArgs) _ 
     Handles PropertyGrid1.MouseUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseUp Event")

End Sub
'</snippet526>

'<snippet527>
Private Sub PropertyGrid1_MouseMove(sender as Object, e as MouseEventArgs) _ 
     Handles PropertyGrid1.MouseMove

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"MouseMove Event")

End Sub
'</snippet527>

'<snippet528>
Private Sub PropertyGrid1_MouseEnter(sender as Object, e as EventArgs) _ 
     Handles PropertyGrid1.MouseEnter

   MessageBox.Show("You are in the PropertyGrid.MouseEnter event.")

End Sub
'</snippet528>

'<snippet529>
Private Sub PropertyGrid1_MouseLeave(sender as Object, e as EventArgs) _ 
     Handles PropertyGrid1.MouseLeave

   MessageBox.Show("You are in the PropertyGrid.MouseLeave event.")

End Sub
'</snippet529>

'<snippet530>
Private Sub PropertyGrid1_PropertyValueChanged(sender as Object, e as PropertyValueChangedEventArgs) _ 
     Handles PropertyGrid1.PropertyValueChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ChangedItem", e.ChangedItem)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldValue", e.OldValue)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PropertyValueChanged Event")

End Sub
'</snippet530>

'<snippet531>
Private Sub PropertyGrid1_PropertyTabChanged(sender as Object, e as PropertyTabChangedEventArgs) _ 
     Handles PropertyGrid1.PropertyTabChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "OldTab", e.OldTab)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "NewTab", e.NewTab)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PropertyTabChanged Event")

End Sub
'</snippet531>

'<snippet532>
Private Sub PropertyGrid1_PropertySortChanged(sender as Object, e as EventArgs) _ 
     Handles PropertyGrid1.PropertySortChanged

   MessageBox.Show("You are in the PropertyGrid.PropertySortChanged event.")

End Sub
'</snippet532>

'<snippet533>
Private Sub PropertyGrid1_SelectedGridItemChanged(sender as Object, e as SelectedGridItemChangedEventArgs) _ 
     Handles PropertyGrid1.SelectedGridItemChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "NewSelection", e.NewSelection)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "OldSelection", e.OldSelection)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SelectedGridItemChanged Event")

End Sub
'</snippet533>

'<snippet534>
Private Sub PropertyGrid1_SelectedObjectsChanged(sender as Object, e as EventArgs) _ 
     Handles PropertyGrid1.SelectedObjectsChanged

   MessageBox.Show("You are in the PropertyGrid.SelectedObjectsChanged event.")

End Sub
'</snippet534>

Public WithEvents PropertyManager1 as PropertyManager
Public WithEvents RadioButton1 as RadioButton
'<snippet535>
Private Sub RadioButton1_AppearanceChanged(sender as Object, e as EventArgs) _ 
     Handles RadioButton1.AppearanceChanged

   MessageBox.Show("You are in the RadioButton.AppearanceChanged event.")

End Sub
'</snippet535>

'<snippet536>
Private Sub RadioButton1_CheckedChanged(sender as Object, e as EventArgs) _ 
     Handles RadioButton1.CheckedChanged

   MessageBox.Show("You are in the RadioButton.CheckedChanged event.")

End Sub
'</snippet536>

Public WithEvents RichTextBox1 as RichTextBox
'<snippet537>
Private Sub RichTextBox1_ContentsResized(sender as Object, e as ContentsResizedEventArgs) _ 
     Handles RichTextBox1.ContentsResized

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "NewRectangle", e.NewRectangle)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ContentsResized Event")

End Sub
'</snippet537>

'<snippet538>
Private Sub RichTextBox1_DragDrop(sender as Object, e as DragEventArgs) _ 
     Handles RichTextBox1.DragDrop

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragDrop Event")

End Sub
'</snippet538>

'<snippet539>
Private Sub RichTextBox1_DragEnter(sender as Object, e as DragEventArgs) _ 
     Handles RichTextBox1.DragEnter

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Data", e.Data)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyState", e.KeyState)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AllowedEffect", e.AllowedEffect)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Effect", e.Effect)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DragEnter Event")

End Sub
'</snippet539>

'<snippet540>
Private Sub RichTextBox1_HScroll(sender as Object, e as EventArgs) _ 
     Handles RichTextBox1.HScroll

   MessageBox.Show("You are in the RichTextBox.HScroll event.")

End Sub
'</snippet540>

'<snippet541>
Private Sub RichTextBox1_LinkClicked(sender as Object, e as LinkClickedEventArgs) _ 
     Handles RichTextBox1.LinkClicked

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "LinkText", e.LinkText)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"LinkClicked Event")

End Sub
'</snippet541>

'<snippet542>
Private Sub RichTextBox1_ImeChange(sender as Object, e as EventArgs) _ 
     Handles RichTextBox1.ImeChange

   MessageBox.Show("You are in the RichTextBox.ImeChange event.")

End Sub
'</snippet542>

'<snippet543>
Private Sub RichTextBox1_Protected(sender as Object, e as EventArgs) _ 
     Handles RichTextBox1.Protected

   MessageBox.Show("You are in the RichTextBox.Protected event.")

End Sub
'</snippet543>

'<snippet544>
Private Sub RichTextBox1_SelectionChanged(sender as Object, e as EventArgs) _ 
     Handles RichTextBox1.SelectionChanged

   MessageBox.Show("You are in the RichTextBox.SelectionChanged event.")

End Sub
'</snippet544>

'<snippet545>
Private Sub RichTextBox1_VScroll(sender as Object, e as EventArgs) _ 
     Handles RichTextBox1.VScroll

   MessageBox.Show("You are in the RichTextBox.VScroll event.")

End Sub
'</snippet545>

Public WithEvents SaveFileDialog1 as SaveFileDialog
Public WithEvents SplitContainer1 as SplitContainer
'<snippet546>
Private Sub SplitContainer1_BackgroundImageChanged(sender as Object, e as EventArgs) _ 
     Handles SplitContainer1.BackgroundImageChanged

   MessageBox.Show("You are in the SplitContainer.BackgroundImageChanged event.")

End Sub
'</snippet546>

'<snippet547>
Private Sub SplitContainer1_SplitterMoving(sender as Object, e as SplitterCancelEventArgs) _ 
     Handles SplitContainer1.SplitterMoving

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseCursorX", e.MouseCursorX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MouseCursorY", e.MouseCursorY)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitX", e.SplitX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitY", e.SplitY)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SplitterMoving Event")

End Sub
'</snippet547>

'<snippet548>
Private Sub SplitContainer1_SplitterMoved(sender as Object, e as SplitterEventArgs) _ 
     Handles SplitContainer1.SplitterMoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitX", e.SplitX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitY", e.SplitY)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SplitterMoved Event")

End Sub
'</snippet548>

Public WithEvents Splitter1 as Splitter
'<snippet549>
Private Sub Splitter1_SplitterMoving(sender as Object, e as SplitterEventArgs) _ 
     Handles Splitter1.SplitterMoving

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitX", e.SplitX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitY", e.SplitY)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SplitterMoving Event")

End Sub
'</snippet549>

'<snippet550>
Private Sub Splitter1_SplitterMoved(sender as Object, e as SplitterEventArgs) _ 
     Handles Splitter1.SplitterMoved

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitX", e.SplitX)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SplitY", e.SplitY)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"SplitterMoved Event")

End Sub
'</snippet550>

Public WithEvents SplitterPanel1 as SplitterPanel
Public WithEvents StatusBar1 as StatusBar
'<snippet551>
Private Sub StatusBar1_DrawItem(sender as Object, e as StatusBarDrawItemEventArgs) _ 
     Handles StatusBar1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Panel", e.Panel)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub
'</snippet551>

'<snippet552>
Private Sub StatusBar1_PanelClick(sender as Object, e as StatusBarPanelClickEventArgs) _ 
     Handles StatusBar1.PanelClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "StatusBarPanel", e.StatusBarPanel)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"PanelClick Event")

End Sub
'</snippet552>

Public WithEvents StatusBarPanel1 as StatusBarPanel
Public WithEvents StatusStrip1 as StatusStrip
'<snippet553>
Private Sub StatusStrip1_PaddingChanged(sender as Object, e as EventArgs) _ 
     Handles StatusStrip1.PaddingChanged

   MessageBox.Show("You are in the StatusStrip.PaddingChanged event.")

End Sub
'</snippet553>

Public WithEvents TabControl1 as TabControl
'<snippet554>
Private Sub TabControl1_DrawItem(sender as Object, e as DrawItemEventArgs) _ 
     Handles TabControl1.DrawItem

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ForeColor", e.ForeColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Index", e.Index)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawItem Event")

End Sub
'</snippet554>

'<snippet555>
Private Sub TabControl1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles TabControl1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the TabControl.RightToLeftLayoutChanged event.")

End Sub
'</snippet555>

'<snippet556>
Private Sub TabControl1_SelectedIndexChanged(sender as Object, e as EventArgs) _ 
     Handles TabControl1.SelectedIndexChanged

   MessageBox.Show("You are in the TabControl.SelectedIndexChanged event.")

End Sub
'</snippet556>

'<snippet557>
Private Sub TabControl1_Selecting(sender as Object, e as TabControlCancelEventArgs) _ 
     Handles TabControl1.Selecting

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Selecting Event")

End Sub
'</snippet557>

'<snippet558>
Private Sub TabControl1_Selected(sender as Object, e as TabControlEventArgs) _ 
     Handles TabControl1.Selected

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Selected Event")

End Sub
'</snippet558>

'<snippet559>
Private Sub TabControl1_Deselecting(sender as Object, e as TabControlCancelEventArgs) _ 
     Handles TabControl1.Deselecting

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Deselecting Event")

End Sub
'</snippet559>

'<snippet560>
Private Sub TabControl1_Deselected(sender as Object, e as TabControlEventArgs) _ 
     Handles TabControl1.Deselected

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Deselected Event")

End Sub
'</snippet560>

Public WithEvents TableLayoutPanel1 as TableLayoutPanel
'<snippet561>
Private Sub TableLayoutPanel1_CellPaint(sender as Object, e as TableLayoutCellPaintEventArgs) _ 
     Handles TableLayoutPanel1.CellPaint

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CellBounds", e.CellBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Row", e.Row)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Column", e.Column)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ClipRectangle", e.ClipRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"CellPaint Event")

End Sub
'</snippet561>

Public WithEvents TabPage1 as TabPage
'<snippet562>
Private Sub TabPage1_TextChanged(sender as Object, e as EventArgs) _ 
     Handles TabPage1.TextChanged

   MessageBox.Show("You are in the TabPage.TextChanged event.")

End Sub
'</snippet562>

Public WithEvents ThreadExceptionDialog1 as ThreadExceptionDialog
Public WithEvents Timer1 as Timer
'<snippet563>
Private Sub Timer1_Tick(sender as Object, e as EventArgs) _ 
     Handles Timer1.Tick

   MessageBox.Show("You are in the Timer.Tick event.")

End Sub
'</snippet563>

Public WithEvents ToolBar1 as ToolBar
'<snippet564>
Private Sub ToolBar1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles ToolBar1.AutoSizeChanged

   MessageBox.Show("You are in the ToolBar.AutoSizeChanged event.")

End Sub
'</snippet564>

'<snippet565>
Private Sub ToolBar1_ButtonClick(sender as Object, e as ToolBarButtonClickEventArgs) _ 
     Handles ToolBar1.ButtonClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ButtonClick Event")

End Sub
'</snippet565>

'<snippet566>
Private Sub ToolBar1_ButtonDropDown(sender as Object, e as ToolBarButtonClickEventArgs) _ 
     Handles ToolBar1.ButtonDropDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ButtonDropDown Event")

End Sub
'</snippet566>

Public WithEvents ToolBarButton1 as ToolBarButton
Public WithEvents ToolStripButton1 as ToolStripButton
'<snippet567>
Private Sub ToolStripButton1_CheckedChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripButton1.CheckedChanged

   MessageBox.Show("You are in the ToolStripButton.CheckedChanged event.")

End Sub
'</snippet567>

'<snippet568>
Private Sub ToolStripButton1_CheckStateChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripButton1.CheckStateChanged

   MessageBox.Show("You are in the ToolStripButton.CheckStateChanged event.")

End Sub
'</snippet568>

Public WithEvents ToolStripControlHost1 as ToolStripControlHost
'<snippet569>
Private Sub ToolStripControlHost1_Enter(sender as Object, e as EventArgs) _ 
     Handles ToolStripControlHost1.Enter

   MessageBox.Show("You are in the ToolStripControlHost.Enter event.")

End Sub
'</snippet569>

'<snippet570>
Private Sub ToolStripControlHost1_GotFocus(sender as Object, e as EventArgs) _ 
     Handles ToolStripControlHost1.GotFocus

Console.WriteLine("You are in the ToolStripControlHost.GotFocus event.")

End Sub
'</snippet570>

'<snippet571>
Private Sub ToolStripControlHost1_Leave(sender as Object, e as EventArgs) _ 
     Handles ToolStripControlHost1.Leave

   MessageBox.Show("You are in the ToolStripControlHost.Leave event.")

End Sub
'</snippet571>

'<snippet572>
Private Sub ToolStripControlHost1_LostFocus(sender as Object, e as EventArgs) _ 
     Handles ToolStripControlHost1.LostFocus

Console.WriteLine("You are in the ToolStripControlHost.LostFocus event.")

End Sub
'</snippet572>

'<snippet573>
Private Sub ToolStripControlHost1_KeyDown(sender as Object, e as KeyEventArgs) _ 
     Handles ToolStripControlHost1.KeyDown

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyDown Event")

End Sub
'</snippet573>

'<snippet574>
Private Sub ToolStripControlHost1_KeyPress(sender as Object, e as KeyPressEventArgs) _ 
     Handles ToolStripControlHost1.KeyPress

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyChar", e.KeyChar)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyPress Event")

End Sub
'</snippet574>

'<snippet575>
Private Sub ToolStripControlHost1_KeyUp(sender as Object, e as KeyEventArgs) _ 
     Handles ToolStripControlHost1.KeyUp

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Alt", e.Alt)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Control", e.Control)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyCode", e.KeyCode)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyValue", e.KeyValue)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "KeyData", e.KeyData)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Modifiers", e.Modifiers)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Shift", e.Shift)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "SuppressKeyPress", e.SuppressKeyPress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"KeyUp Event")

End Sub
'</snippet575>

'<snippet576>
Private Sub ToolStripControlHost1_Validating(sender as Object, e as CancelEventArgs) _ 
     Handles ToolStripControlHost1.Validating

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Validating Event")

End Sub
'</snippet576>

'<snippet577>
Private Sub ToolStripControlHost1_Validated(sender as Object, e as EventArgs) _ 
     Handles ToolStripControlHost1.Validated

   MessageBox.Show("You are in the ToolStripControlHost.Validated event.")

End Sub
'</snippet577>

Public WithEvents ToolStripComboBox1 as ToolStripComboBox
'<snippet578>
Private Sub ToolStripComboBox1_DropDown(sender as Object, e as EventArgs) _ 
     Handles ToolStripComboBox1.DropDown

   MessageBox.Show("You are in the ToolStripComboBox.DropDown event.")

End Sub
'</snippet578>

'<snippet579>
Private Sub ToolStripComboBox1_DropDownClosed(sender as Object, e as EventArgs) _ 
     Handles ToolStripComboBox1.DropDownClosed

   MessageBox.Show("You are in the ToolStripComboBox.DropDownClosed event.")

End Sub
'</snippet579>

'<snippet580>
Private Sub ToolStripComboBox1_DropDownStyleChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripComboBox1.DropDownStyleChanged

   MessageBox.Show("You are in the ToolStripComboBox.DropDownStyleChanged event.")

End Sub
'</snippet580>

'<snippet581>
Private Sub ToolStripComboBox1_SelectedIndexChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripComboBox1.SelectedIndexChanged

   MessageBox.Show("You are in the ToolStripComboBox.SelectedIndexChanged event.")

End Sub
'</snippet581>

'<snippet582>
Private Sub ToolStripComboBox1_TextUpdate(sender as Object, e as EventArgs) _ 
     Handles ToolStripComboBox1.TextUpdate

   MessageBox.Show("You are in the ToolStripComboBox.TextUpdate event.")

End Sub
'</snippet582>

Public WithEvents ToolStripDropDownButton1 as ToolStripDropDownButton
Public WithEvents ToolStripRenderer1 as ToolStripRenderer
'<snippet583>
Private Sub ToolStripRenderer1_RenderArrow(sender as Object, e as ToolStripArrowRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderArrow

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "ArrowRectangle", e.ArrowRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ArrowColor", e.ArrowColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Direction", e.Direction)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderArrow Event")

End Sub
'</snippet583>

'<snippet584>
Private Sub ToolStripRenderer1_RenderToolStripBackground(sender as Object, e as ToolStripRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripBackground Event")

End Sub
'</snippet584>

'<snippet585>
Private Sub ToolStripRenderer1_RenderToolStripPanelBackground(sender as Object, e as ToolStripPanelRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripPanelBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStripPanel", e.ToolStripPanel)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripPanelBackground Event")

End Sub
'</snippet585>

'<snippet586>
Private Sub ToolStripRenderer1_RenderToolStripContentPanelBackground(sender as Object, e as ToolStripContentPanelRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripContentPanelBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Handled", e.Handled)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStripContentPanel", e.ToolStripContentPanel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripContentPanelBackground Event")

End Sub
'</snippet586>

'<snippet587>
Private Sub ToolStripRenderer1_RenderToolStripBorder(sender as Object, e as ToolStripRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripBorder

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripBorder Event")

End Sub
'</snippet587>

'<snippet588>
Private Sub ToolStripRenderer1_RenderButtonBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderButtonBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderButtonBackground Event")

End Sub
'</snippet588>

'<snippet589>
Private Sub ToolStripRenderer1_RenderDropDownButtonBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderDropDownButtonBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderDropDownButtonBackground Event")

End Sub
'</snippet589>

'<snippet590>
Private Sub ToolStripRenderer1_RenderOverflowButtonBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderOverflowButtonBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderOverflowButtonBackground Event")

End Sub
'</snippet590>

'<snippet591>
Private Sub ToolStripRenderer1_RenderGrip(sender as Object, e as ToolStripGripRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderGrip

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "GripBounds", e.GripBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "GripDisplayStyle", e.GripDisplayStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "GripStyle", e.GripStyle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderGrip Event")

End Sub
'</snippet591>

'<snippet592>
Private Sub ToolStripRenderer1_RenderItemBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderItemBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderItemBackground Event")

End Sub
'</snippet592>

'<snippet593>
Private Sub ToolStripRenderer1_RenderItemImage(sender as Object, e as ToolStripItemImageRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderItemImage

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Image", e.Image)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ImageRectangle", e.ImageRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderItemImage Event")

End Sub
'</snippet593>

'<snippet594>
Private Sub ToolStripRenderer1_RenderItemCheck(sender as Object, e as ToolStripItemImageRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderItemCheck

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Image", e.Image)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ImageRectangle", e.ImageRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderItemCheck Event")

End Sub
'</snippet594>

'<snippet595>
Private Sub ToolStripRenderer1_RenderItemText(sender as Object, e as ToolStripItemTextRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderItemText

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Text", e.Text)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextColor", e.TextColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextFont", e.TextFont)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextRectangle", e.TextRectangle)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextFormat", e.TextFormat)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TextDirection", e.TextDirection)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderItemText Event")

End Sub
'</snippet595>

'<snippet596>
Private Sub ToolStripRenderer1_RenderImageMargin(sender as Object, e as ToolStripRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderImageMargin

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderImageMargin Event")

End Sub
'</snippet596>

'<snippet597>
Private Sub ToolStripRenderer1_RenderLabelBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderLabelBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderLabelBackground Event")

End Sub
'</snippet597>

'<snippet598>
Private Sub ToolStripRenderer1_RenderMenuItemBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderMenuItemBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderMenuItemBackground Event")

End Sub
'</snippet598>

'<snippet599>
Private Sub ToolStripRenderer1_RenderToolStripStatusLabelBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderToolStripStatusLabelBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderToolStripStatusLabelBackground Event")

End Sub
'</snippet599>

'<snippet600>
Private Sub ToolStripRenderer1_RenderStatusStripSizingGrip(sender as Object, e as ToolStripRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderStatusStripSizingGrip

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AffectedBounds", e.AffectedBounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "BackColor", e.BackColor)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ConnectedArea", e.ConnectedArea)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderStatusStripSizingGrip Event")

End Sub
'</snippet600>

'<snippet601>
Private Sub ToolStripRenderer1_RenderSplitButtonBackground(sender as Object, e as ToolStripItemRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderSplitButtonBackground

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderSplitButtonBackground Event")

End Sub
'</snippet601>

'<snippet602>
Private Sub ToolStripRenderer1_RenderSeparator(sender as Object, e as ToolStripSeparatorRenderEventArgs) _ 
     Handles ToolStripRenderer1.RenderSeparator

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Vertical", e.Vertical)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolStrip", e.ToolStrip)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"RenderSeparator Event")

End Sub
'</snippet602>

Public WithEvents ToolStripSystemRenderer1 as ToolStripSystemRenderer
Public WithEvents ToolStripLabel1 as ToolStripLabel
Public WithEvents ToolStripManager1 as ToolStripManager
'<snippet603>
Private Sub ToolStripManager1_RendererChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripManager1.RendererChanged

   MessageBox.Show("You are in the ToolStripManager.RendererChanged event.")

End Sub
'</snippet603>

Public WithEvents ToolStripOverflow1 as ToolStripOverflow
Public WithEvents ToolStripOverflowButton1 as ToolStripOverflowButton
Public WithEvents ToolStripContainer1 as ToolStripContainer
Public WithEvents ToolStripContentPanel1 as ToolStripContentPanel
'<snippet604>
Private Sub ToolStripContentPanel1_Load(sender as Object, e as EventArgs) _ 
     Handles ToolStripContentPanel1.Load

   MessageBox.Show("You are in the ToolStripContentPanel.Load event.")

End Sub
'</snippet604>

'<snippet605>
Private Sub ToolStripContentPanel1_RendererChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripContentPanel1.RendererChanged

   MessageBox.Show("You are in the ToolStripContentPanel.RendererChanged event.")

End Sub
'</snippet605>

Public WithEvents ToolStripPanel1 as ToolStripPanel
'<snippet606>
Private Sub ToolStripPanel1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripPanel1.AutoSizeChanged

   MessageBox.Show("You are in the ToolStripPanel.AutoSizeChanged event.")

End Sub
'</snippet606>

'<snippet607>
Private Sub ToolStripPanel1_RendererChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripPanel1.RendererChanged

   MessageBox.Show("You are in the ToolStripPanel.RendererChanged event.")

End Sub
'</snippet607>

Public WithEvents ToolStripPanelRow1 as ToolStripPanelRow
Public WithEvents ToolStripProfessionalRenderer1 as ToolStripProfessionalRenderer
Public WithEvents ToolStripProgressBar1 as ToolStripProgressBar
'<snippet608>
Private Sub ToolStripProgressBar1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripProgressBar1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the ToolStripProgressBar.RightToLeftLayoutChanged event.")

End Sub
'</snippet608>

Public WithEvents ToolStripSeparator1 as ToolStripSeparator
Public WithEvents ToolStripSplitButton1 as ToolStripSplitButton
'<snippet609>
Private Sub ToolStripSplitButton1_ButtonClick(sender as Object, e as EventArgs) _ 
     Handles ToolStripSplitButton1.ButtonClick

   MessageBox.Show("You are in the ToolStripSplitButton.ButtonClick event.")

End Sub
'</snippet609>

'<snippet610>
Private Sub ToolStripSplitButton1_ButtonDoubleClick(sender as Object, e as EventArgs) _ 
     Handles ToolStripSplitButton1.ButtonDoubleClick

   MessageBox.Show("You are in the ToolStripSplitButton.ButtonDoubleClick event.")

End Sub
'</snippet610>

'<snippet611>
Private Sub ToolStripSplitButton1_DefaultItemChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripSplitButton1.DefaultItemChanged

   MessageBox.Show("You are in the ToolStripSplitButton.DefaultItemChanged event.")

End Sub
'</snippet611>

Public WithEvents ToolStripStatusLabel1 as ToolStripStatusLabel
Public WithEvents ToolStripTextBox1 as ToolStripTextBox
'<snippet612>
Private Sub ToolStripTextBox1_AcceptsTabChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripTextBox1.AcceptsTabChanged

   MessageBox.Show("You are in the ToolStripTextBox.AcceptsTabChanged event.")

End Sub
'</snippet612>

'<snippet613>
Private Sub ToolStripTextBox1_BorderStyleChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripTextBox1.BorderStyleChanged

   MessageBox.Show("You are in the ToolStripTextBox.BorderStyleChanged event.")

End Sub
'</snippet613>

'<snippet614>
Private Sub ToolStripTextBox1_HideSelectionChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripTextBox1.HideSelectionChanged

   MessageBox.Show("You are in the ToolStripTextBox.HideSelectionChanged event.")

End Sub
'</snippet614>

'<snippet615>
Private Sub ToolStripTextBox1_ModifiedChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripTextBox1.ModifiedChanged

   MessageBox.Show("You are in the ToolStripTextBox.ModifiedChanged event.")

End Sub
'</snippet615>

'<snippet616>
Private Sub ToolStripTextBox1_ReadOnlyChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripTextBox1.ReadOnlyChanged

   MessageBox.Show("You are in the ToolStripTextBox.ReadOnlyChanged event.")

End Sub
'</snippet616>

'<snippet617>
Private Sub ToolStripTextBox1_TextBoxTextAlignChanged(sender as Object, e as EventArgs) _ 
     Handles ToolStripTextBox1.TextBoxTextAlignChanged

   MessageBox.Show("You are in the ToolStripTextBox.TextBoxTextAlignChanged event.")

End Sub
'</snippet617>

Public WithEvents ToolTip1 as ToolTip
'<snippet618>
Private Sub ToolTip1_Draw(sender as Object, e as DrawToolTipEventArgs) _ 
     Handles ToolTip1.Draw

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolTipText", e.ToolTipText)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Font", e.Font)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Draw Event")

End Sub
'</snippet618>

'<snippet619>
Private Sub ToolTip1_Popup(sender as Object, e as PopupEventArgs) _ 
     Handles ToolTip1.Popup

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedWindow", e.AssociatedWindow)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "AssociatedControl", e.AssociatedControl)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "IsBalloon", e.IsBalloon)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "ToolTipSize", e.ToolTipSize)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Popup Event")

End Sub
'</snippet619>

Public WithEvents TrackBar1 as TrackBar
'<snippet620>
Private Sub TrackBar1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles TrackBar1.AutoSizeChanged

   MessageBox.Show("You are in the TrackBar.AutoSizeChanged event.")

End Sub
'</snippet620>

'<snippet621>
Private Sub TrackBar1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles TrackBar1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the TrackBar.RightToLeftLayoutChanged event.")

End Sub
'</snippet621>

'<snippet622>
Private Sub TrackBar1_Scroll(sender as Object, e as EventArgs) _ 
     Handles TrackBar1.Scroll

   MessageBox.Show("You are in the TrackBar.Scroll event.")

End Sub
'</snippet622>

'<snippet623>
Private Sub TrackBar1_ValueChanged(sender as Object, e as EventArgs) _ 
     Handles TrackBar1.ValueChanged

   MessageBox.Show("You are in the TrackBar.ValueChanged event.")

End Sub
'</snippet623>

Public WithEvents TreeView1 as TreeView
'<snippet624>
Private Sub TreeView1_BeforeLabelEdit(sender as Object, e as NodeLabelEditEventArgs) _ 
     Handles TreeView1.BeforeLabelEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Label", e.Label)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BeforeLabelEdit Event")

End Sub
'</snippet624>

'<snippet625>
Private Sub TreeView1_AfterLabelEdit(sender as Object, e as NodeLabelEditEventArgs) _ 
     Handles TreeView1.AfterLabelEdit

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CancelEdit", e.CancelEdit)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Label", e.Label)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterLabelEdit Event")

End Sub
'</snippet625>

'<snippet626>
Private Sub TreeView1_BeforeCheck(sender as Object, e as TreeViewCancelEventArgs) _ 
     Handles TreeView1.BeforeCheck

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BeforeCheck Event")

End Sub
'</snippet626>

'<snippet627>
Private Sub TreeView1_AfterCheck(sender as Object, e as TreeViewEventArgs) _ 
     Handles TreeView1.AfterCheck

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterCheck Event")

End Sub
'</snippet627>

'<snippet628>
Private Sub TreeView1_BeforeCollapse(sender as Object, e as TreeViewCancelEventArgs) _ 
     Handles TreeView1.BeforeCollapse

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BeforeCollapse Event")

End Sub
'</snippet628>

'<snippet629>
Private Sub TreeView1_AfterCollapse(sender as Object, e as TreeViewEventArgs) _ 
     Handles TreeView1.AfterCollapse

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterCollapse Event")

End Sub
'</snippet629>

'<snippet630>
Private Sub TreeView1_BeforeExpand(sender as Object, e as TreeViewCancelEventArgs) _ 
     Handles TreeView1.BeforeExpand

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BeforeExpand Event")

End Sub
'</snippet630>

'<snippet631>
Private Sub TreeView1_AfterExpand(sender as Object, e as TreeViewEventArgs) _ 
     Handles TreeView1.AfterExpand

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterExpand Event")

End Sub
'</snippet631>

'<snippet632>
Private Sub TreeView1_DrawNode(sender as Object, e as DrawTreeNodeEventArgs) _ 
     Handles TreeView1.DrawNode

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "DrawDefault", e.DrawDefault)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Graphics", e.Graphics)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Bounds", e.Bounds)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "State", e.State)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DrawNode Event")

End Sub
'</snippet632>

'<snippet633>
Private Sub TreeView1_ItemDrag(sender as Object, e as ItemDragEventArgs) _ 
     Handles TreeView1.ItemDrag

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Item", e.Item)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ItemDrag Event")

End Sub
'</snippet633>

'<snippet634>
Private Sub TreeView1_NodeMouseHover(sender as Object, e as TreeNodeMouseHoverEventArgs) _ 
     Handles TreeView1.NodeMouseHover

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"NodeMouseHover Event")

End Sub
'</snippet634>

'<snippet635>
Private Sub TreeView1_BeforeSelect(sender as Object, e as TreeViewCancelEventArgs) _ 
     Handles TreeView1.BeforeSelect

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"BeforeSelect Event")

End Sub
'</snippet635>

'<snippet636>
Private Sub TreeView1_AfterSelect(sender as Object, e as TreeViewEventArgs) _ 
     Handles TreeView1.AfterSelect

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"AfterSelect Event")

End Sub
'</snippet636>

'<snippet637>
Private Sub TreeView1_NodeMouseClick(sender as Object, e as TreeNodeMouseClickEventArgs) _ 
     Handles TreeView1.NodeMouseClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"NodeMouseClick Event")

End Sub
'</snippet637>

'<snippet638>
Private Sub TreeView1_NodeMouseDoubleClick(sender as Object, e as TreeNodeMouseClickEventArgs) _ 
     Handles TreeView1.NodeMouseDoubleClick

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Node", e.Node)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Button", e.Button)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Clicks", e.Clicks)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "X", e.X)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Y", e.Y)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Delta", e.Delta)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Location", e.Location)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"NodeMouseDoubleClick Event")

End Sub
'</snippet638>

'<snippet639>
Private Sub TreeView1_RightToLeftLayoutChanged(sender as Object, e as EventArgs) _ 
     Handles TreeView1.RightToLeftLayoutChanged

   MessageBox.Show("You are in the TreeView.RightToLeftLayoutChanged event.")

End Sub
'</snippet639>

Public WithEvents UserControl1 as UserControl
'<snippet640>
Private Sub UserControl1_AutoSizeChanged(sender as Object, e as EventArgs) _ 
     Handles UserControl1.AutoSizeChanged

   MessageBox.Show("You are in the UserControl.AutoSizeChanged event.")

End Sub
'</snippet640>

'<snippet641>
Private Sub UserControl1_AutoValidateChanged(sender as Object, e as EventArgs) _ 
     Handles UserControl1.AutoValidateChanged

   MessageBox.Show("You are in the UserControl.AutoValidateChanged event.")

End Sub
'</snippet641>

'<snippet642>
Private Sub UserControl1_Load(sender as Object, e as EventArgs) _ 
     Handles UserControl1.Load

   MessageBox.Show("You are in the UserControl.Load event.")

End Sub
'</snippet642>

Public WithEvents VScrollBar1 as VScrollBar
Public WithEvents WebBrowserBase1 as WebBrowserBase
Public WithEvents WebBrowser1 as WebBrowser
'<snippet643>
Private Sub WebBrowser1_CanGoBackChanged(sender as Object, e as EventArgs) _ 
     Handles WebBrowser1.CanGoBackChanged

   MessageBox.Show("You are in the WebBrowser.CanGoBackChanged event.")

End Sub
'</snippet643>

'<snippet644>
Private Sub WebBrowser1_CanGoForwardChanged(sender as Object, e as EventArgs) _ 
     Handles WebBrowser1.CanGoForwardChanged

   MessageBox.Show("You are in the WebBrowser.CanGoForwardChanged event.")

End Sub
'</snippet644>

'<snippet645>
Private Sub WebBrowser1_DocumentCompleted(sender as Object, e as WebBrowserDocumentCompletedEventArgs) _ 
     Handles WebBrowser1.DocumentCompleted

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"DocumentCompleted Event")

End Sub
'</snippet645>

'<snippet646>
Private Sub WebBrowser1_DocumentTitleChanged(sender as Object, e as EventArgs) _ 
     Handles WebBrowser1.DocumentTitleChanged

   MessageBox.Show("You are in the WebBrowser.DocumentTitleChanged event.")

End Sub
'</snippet646>

'<snippet647>
Private Sub WebBrowser1_EncryptionLevelChanged(sender as Object, e as EventArgs) _ 
     Handles WebBrowser1.EncryptionLevelChanged

   MessageBox.Show("You are in the WebBrowser.EncryptionLevelChanged event.")

End Sub
'</snippet647>

'<snippet648>
Private Sub WebBrowser1_FileDownload(sender as Object, e as EventArgs) _ 
     Handles WebBrowser1.FileDownload

   MessageBox.Show("You are in the WebBrowser.FileDownload event.")

End Sub
'</snippet648>

'<snippet649>
Private Sub WebBrowser1_Navigated(sender as Object, e as WebBrowserNavigatedEventArgs) _ 
     Handles WebBrowser1.Navigated

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Navigated Event")

End Sub
'</snippet649>

'<snippet650>
Private Sub WebBrowser1_Navigating(sender as Object, e as WebBrowserNavigatingEventArgs) _ 
     Handles WebBrowser1.Navigating

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Url", e.Url)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "TargetFrameName", e.TargetFrameName)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"Navigating Event")

End Sub
'</snippet650>

'<snippet651>
Private Sub WebBrowser1_NewWindow(sender as Object, e as CancelEventArgs) _ 
     Handles WebBrowser1.NewWindow

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"NewWindow Event")

End Sub
'</snippet651>

'<snippet652>
Private Sub WebBrowser1_ProgressChanged(sender as Object, e as WebBrowserProgressChangedEventArgs) _ 
     Handles WebBrowser1.ProgressChanged

    Dim messageBoxVB as New System.Text.StringBuilder()
    messageBoxVB.AppendFormat("{0} = {1}", "CurrentProgress", e.CurrentProgress)
    messageBoxVB.AppendLine()
    messageBoxVB.AppendFormat("{0} = {1}", "MaximumProgress", e.MaximumProgress)
    messageBoxVB.AppendLine()
    MessageBox.Show(messageBoxVB.ToString(),"ProgressChanged Event")

End Sub
'</snippet652>

'<snippet653>
Private Sub WebBrowser1_StatusTextChanged(sender as Object, e as EventArgs) _ 
     Handles WebBrowser1.StatusTextChanged

   MessageBox.Show("You are in the WebBrowser.StatusTextChanged event.")

End Sub
'</snippet653>
    Public WithEvents PrintPreviewControl1 As PrintPreviewControl
'<snippet654>
Private Sub PrintPreviewControl1_StartPageChanged(sender as Object, e as EventArgs) _ 
     Handles PrintPreviewControl1.StartPageChanged

   MessageBox.Show("You are in the PrintPreviewControl.StartPageChanged event.")

End Sub
'</snippet654>


End Class
