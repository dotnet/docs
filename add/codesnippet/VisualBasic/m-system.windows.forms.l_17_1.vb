   Private Sub FindMyString(ByVal searchString As String)
      ' Ensure we have a proper string to search for.
      If searchString <> String.Empty Then
         ' Find the item in the list and store the index to the item.
         Dim index As Integer = listBox1.FindString(searchString)
         ' Determine if a valid index is returned. Select the item if it is valid.
         If index <> -1 Then
            listBox1.SetSelected(index, True)
         Else
            MessageBox.Show("The search string did not match any items in the ListBox")
         End If
      End If
   End Sub