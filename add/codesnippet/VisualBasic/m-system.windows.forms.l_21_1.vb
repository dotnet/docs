   Private Sub FindMySpecificString(ByVal searchString As String)
      ' Ensure we have a proper string to search for.
      If searchString <> String.Empty Then
         ' Find the item in the list and store the index to the item.
         Dim index As Integer = listBox1.FindStringExact(searchString)
         ' Determine if a valid index is returned. Select the item if it is valid.
         If index <> ListBox.NoMatches Then
            listBox1.SetSelected(index, True)
         Else
            MessageBox.Show("The search string did not find any items in the ListBox that exactly match the specified search string")
         End If
      End If
   End Sub