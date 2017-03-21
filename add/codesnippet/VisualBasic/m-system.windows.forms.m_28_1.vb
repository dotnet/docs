      Private Sub PopupMyMenu(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEdit.Popup
         If textBox1.Enabled = False OrElse textBox1.Focused = False OrElse textBox1.SelectedText.Length = 0 Then
            menuCut.Enabled = False
            menuCopy.Enabled = False
            menuDelete.Enabled = False
         Else
            menuCut.Enabled = True
            menuCopy.Enabled = True
            menuDelete.Enabled = True
         End If
      End Sub