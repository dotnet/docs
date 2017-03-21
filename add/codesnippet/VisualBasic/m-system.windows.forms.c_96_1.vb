Public Sub ControlSelect(control As Control)
   ' Select the control, if it can be selected.
   If control.CanSelect Then
      control.Select()
   End If
End Sub