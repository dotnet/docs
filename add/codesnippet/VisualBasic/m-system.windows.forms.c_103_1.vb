Private Sub myButton_MouseEnter(sender As Object, e As System.EventArgs) Handles myButton.MouseEnter
   ' Hide the cursor when the mouse pointer enters the button.
   Cursor.Hide()
End Sub 'myButton_MouseEnter
      
      
Private Sub myButton_MouseLeave(sender As Object, e As System.EventArgs) Handles myButton.MouseLeave
   ' Show the cursor when the mouse pointer leaves the button.
   Cursor.Show()
End Sub 'myButton_MouseLeave
      