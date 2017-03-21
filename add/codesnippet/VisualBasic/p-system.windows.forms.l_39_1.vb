   Private Sub SizeMyListBox()
      ' Add items to the ListBox.
      Dim x As Integer
      For x = 0 To 19
         listBox1.Items.Add(("Item " + x.ToString()))
      Next x
      ' Set the height of the ListBox to the preferred height to display all items.
      listBox1.Height = listBox1.PreferredHeight
   End Sub 'SizeMyListBox