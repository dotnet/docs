   Private Sub RemoveTopItems()
      ' Determine if the currently selected item in the ListBox 
      ' is the item displayed at the top in the ListBox.
      If listBox1.TopIndex <> listBox1.SelectedIndex Then
         ' Make the currently selected item the top item in the ListBox.
         listBox1.TopIndex = listBox1.SelectedIndex
      End If
      ' Remove all items before the top item in the ListBox.
      Dim x As Integer
      For x = listBox1.SelectedIndex - 1 To 0 Step -1
         listBox1.Items.RemoveAt(x)
      Next x

      ' Clear all selections in the ListBox.
      listBox1.ClearSelected()
   End Sub 'RemoveTopItems