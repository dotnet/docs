Private Sub button1_Click(sender As Object, _
   e As EventArgs) Handles button1.Click
   ' Add a button to top left corner of the 
   ' scrollable area, allowing for the offset. 
   panel1.AutoScroll = True
   Dim myButton As New Button()
   myButton.Location = New Point( _
      0 + panel1.AutoScrollPosition.X, _
      0 + panel1.AutoScrollPosition.Y)
   panel1.Controls.Add(myButton)
End Sub