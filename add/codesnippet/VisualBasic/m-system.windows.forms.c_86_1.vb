Public Sub ControlSetFocus(control As Control)
   ' Set focus to the control, if it can receive focus.
   If control.CanFocus Then
      control.Focus()
   End If
End Sub