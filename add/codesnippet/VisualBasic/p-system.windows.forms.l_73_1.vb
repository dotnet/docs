   Private Sub FindAllOfMyString(ByVal searchString As String)
      ' Set the SelectionMode property of the ListBox to select multiple items.
      listBox1.SelectionMode = SelectionMode.MultiExtended

      ' Set our intial index variable to -1.
      Dim x As Integer = -1
      ' If the search string is empty exit.
      If searchString.Length <> 0 Then
         ' Loop through and find each item that matches the search string.
         Do
            ' Retrieve the item based on the previous index found. Starts with -1 which searches start.
            x = listBox1.FindString(searchString, x)
            ' If no item is found that matches exit.
            If x <> -1 Then
               ' Since the FindString loops infinitely, determine if we found first item again and exit.
               If ListBox1.SelectedIndices.Count > 0 Then
                  If x = ListBox1.SelectedIndices(0) Then
                     Return
                  End If
               End If
               ' Select the item in the ListBox once it is found.
               ListBox1.SetSelected(x, True)
            End If
         Loop While x <> -1
      End If
   End Sub