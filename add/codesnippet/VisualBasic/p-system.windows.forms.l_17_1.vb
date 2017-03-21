   Private Sub InitializeMyListBox()
      ' Add items to the ListBox.
      listBox1.Items.Add("A")
      listBox1.Items.Add("C")
      listBox1.Items.Add("E")
      listBox1.Items.Add("F")
      listBox1.Items.Add("G")
      listBox1.Items.Add("D")
      listBox1.Items.Add("B")

      ' Sort all items added previously.
      listBox1.Sorted = True

      ' Set the SelectionMode to select multiple items.
      listBox1.SelectionMode = SelectionMode.MultiExtended

      ' Select three initial items from the list.
      listBox1.SetSelected(0, True)
      listBox1.SetSelected(2, True)
      listBox1.SetSelected(4, True)

      ' Force the ListBox to scroll back to the top of the list.
      listBox1.TopIndex = 0
   End Sub

   Private Sub InvertMySelection()

      Dim x As Integer
      ' Loop through all items the ListBox.
      For x = 0 To listBox1.Items.Count - 1

         ' Determine if the item is selected.
         If listBox1.GetSelected(x) = True Then
            ' Deselect all items that are selected.
            listBox1.SetSelected(x, False)
         Else
            ' Select all items that are not selected.
            listBox1.SetSelected(x, True)
         End If
      Next x
      ' Force the ListBox to scroll back to the top of the list.
      listBox1.TopIndex = 0
   End Sub