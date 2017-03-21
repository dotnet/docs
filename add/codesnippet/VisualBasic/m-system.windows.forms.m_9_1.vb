      Private Sub button3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         monthCalendar1.RemoveAllBoldedDates()
         monthCalendar1.UpdateBoldedDates()
         listBox1.Items.Clear()
         button3.Enabled = False
      End Sub 'button3_Click