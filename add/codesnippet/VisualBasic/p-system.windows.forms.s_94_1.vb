Private Sub button1_Click(sender As Object, _
  e As EventArgs) Handles button1.Click
   ' Create a SelectionRange object and set its Start and End properties.
   Dim sr As New SelectionRange()
   sr.Start = DateTime.Parse(Me.textBox1.Text)
   sr.End = DateTime.Parse(Me.textBox2.Text)
   ' Assign the SelectionRange object to the
   ' SelectionRange property of the MonthCalendar control. 
   Me.monthCalendar1.SelectionRange = sr
End Sub 


Private Sub monthCalendar1_DateChanged(sender As Object, _
  e As DateRangeEventArgs) Handles monthCalendar1.DateChanged
   ' Display the Start and End property values of
   ' the SelectionRange object in the text boxes. 
   Me.textBox1.Text = monthCalendar1.SelectionRange.Start.Date.ToShortDateString()
   Me.textBox2.Text = monthCalendar1.SelectionRange.End.Date.ToShortDateString()
End Sub