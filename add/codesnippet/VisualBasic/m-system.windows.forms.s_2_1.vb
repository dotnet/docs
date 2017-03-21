Private Sub button1_Click(sender As Object, e As EventArgs)
   ' Set the SelectionRange with start and end dates from text boxes.
   Try
      monthCalendar1.SelectionRange = New SelectionRange( _
        DateTime.Parse(textBox1.Text), _
        DateTime.Parse(textBox2.Text))
   Catch ex As Exception
      MessageBox.Show(ex.Message)
   End Try
End Sub