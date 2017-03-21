Private Sub button1_Click(sender As Object, _
  e As EventArgs) Handles button1.Click
   ' If the CTRL key is pressed when the 
   ' control is clicked, hide the control. 
   If Control.ModifierKeys = Keys.Control Then
      CType(sender, Control).Hide()
   End If
End Sub