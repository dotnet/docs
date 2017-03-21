   Private Sub CreateMyTopMostForm()
      ' Create lower form to display.
      Dim bottomForm As New Form()
      ' Display the lower form Maximized to demonstrate effect of TopMost property.
      bottomForm.WindowState = FormWindowState.Maximized
      ' Display the bottom form.
      bottomForm.Show()
      ' Create the top most form.
      Dim topMostForm As New Form()
      ' Set the size of the form larger than the default size.
      topMostForm.Size = New Size(300, 300)
      ' Set the position of the top most form to center of screen.
      topMostForm.StartPosition = FormStartPosition.CenterScreen
      ' Display the form as top most form.
      topMostForm.TopMost = True
      topMostForm.Show()
   End Sub 'CreateMyTopMostForm