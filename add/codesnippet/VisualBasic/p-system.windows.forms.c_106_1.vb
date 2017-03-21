Private Sub menuItemEdit_Popup(sender As Object, _
  e As EventArgs) Handles menuItemEdit.Popup
   ' Disable the menu item if the text box does not have focus.
   Me.menuItemEditInsertCustomerInfo.Enabled = Me.textBox1.Focused
End Sub