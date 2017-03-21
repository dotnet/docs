   ' Handle event to show the state of 'IsInEditOrNavigateMode'.
   Private Sub Button_ClickEvent(sender As Object, e As EventArgs)
      
      If myDataGridTextBox.IsInEditOrNavigateMode Then
         ' DataGridTextBox has not been edited.
         MessageBox.Show("Editing of DataGridTextBox not begun,IsInEditOrNavigateMode = True")
      Else
         ' DataGridTextBox has been edited.
         MessageBox.Show("Editing of DataGridTextBox begun,IsInEditOrNavigateMode = False")
      End If
   End Sub 'Button_ClickEvent