  Protected Sub ContactsListView_ItemDataBound(ByVal sender As Object, ByVal e As ListViewItemEventArgs) 
      
    'Verify there is an item being edited.
    If ContactsListView.EditIndex >= 0 Then
      
      'Get the item object.
      Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
      
      ' Check for an item in edit mode.
      If dataItem.DisplayIndex = ContactsListView.EditIndex Then
          
        ' Preselect the DropDownList control with the Title value
        ' for the current item.
        ' Retrieve the underlying data item. In this example
        ' the underlying data item is a DataRowView object.        
        Dim rowView As DataRowView = CType(dataItem.DataItem, DataRowView)
        
        ' Retrieve the Title value for the current item. 
        Dim title As String = rowView("Title").ToString()
        
        ' Retrieve the DropDownList control from the current row. 
        Dim list As DropDownList = CType(dataItem.FindControl("TitlesList"), DropDownList)
        
        ' Find the ListItem object in the DropDownList control with the 
        ' title value and select the item.
        Dim item As ListItem = list.Items.FindByText(title)
        list.SelectedIndex = list.Items.IndexOf(item)
      End If 
    End If

  End Sub