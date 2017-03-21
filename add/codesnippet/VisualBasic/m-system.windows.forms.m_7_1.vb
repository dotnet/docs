      Private Sub button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         monthCalendar1.RemoveBoldedDate(DateTime.Parse(listBox1.SelectedItem.ToString().Substring(0, listBox1.SelectedItem.ToString().IndexOf(" "))))
         monthCalendar1.UpdateBoldedDates()
         listBox1.Items.RemoveAt(listBox1.SelectedIndex)
         If listBox1.Items.Count = 0 Then
            button3.Enabled = False
         End If
      End Sub 'button2_Click