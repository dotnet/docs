  Protected Sub ContactsListView_ItemCreated(ByVal sender As Object, ByVal e As ListViewItemEventArgs)
    
    ' Retrieve the current item.
    Dim item As ListViewItem = e.Item
    
    ' Verify if the item is a data item.
    If item.ItemType = ListViewItemType.DataItem Then
            
      ' Get the EmailAddressLabel Label control in the item.      
      Dim EmailAddressLabel As Label = CType(item.FindControl("EmailAddressLabel"), Label)
      
      ' Display the e-mail address in italics.
      EmailAddressLabel.Font.Italic = True
            
    End If

  End Sub