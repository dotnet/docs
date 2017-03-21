Private Sub menuItemHelpAbout_Click(sender As Object, _
  e As EventArgs) Handles menuItemHelpAbout.Click
   ' Create and display a modless about dialog box.
   Dim about As New AboutDialog()
   about.Show()
   
   ' Draw a blue square on the form.
   ' NOTE: This is not a persistent object, it will no longer be
   ' visible after the next call to OnPaint. To make it persistent, 
   ' override the OnPaint method and draw the square there 
   Dim g As Graphics = about.CreateGraphics()
   g.FillRectangle(Brushes.Blue, 10, 10, 50, 50)
End Sub