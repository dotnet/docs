' Reset all the controls to the user's default Control color. 
Private Sub ResetAllControlsBackColor(control As Control)
   control.BackColor = SystemColors.Control
   control.ForeColor = SystemColors.ControlText
   If control.HasChildren Then
      ' Recursively call this method for each child control.
      Dim childControl As Control
      For Each childControl In  control.Controls
         ResetAllControlsBackColor(childControl)
      Next childControl
   End If
End Sub