   Private Sub listBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles listBox1.SelectedIndexChanged
      ' Get the currently selected item in the ListBox.
      Dim curItem As String = listBox1.SelectedItem.ToString()

      ' Find the string in ListBox2.
      Dim index As Integer = listBox2.FindString(curItem)
      ' If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
      If index = -1 Then
         MessageBox.Show("Item is not available in ListBox2")
      Else
         listBox2.SetSelected(index, True)
      End If
   End Sub