  Protected Sub PreferredCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) 
  
    ' Gets the CheckBox object that fired the event.
    Dim chkBox As CheckBox = CType(sender, CheckBox)
    
    ' Gets the item that contains the CheckBox object. 
    Dim item As ListViewDataItem = CType(chkBox.Parent.Parent, ListViewDataItem)
    
    ' Update the database with the changes.
    VendorsListView.UpdateItem(item.DisplayIndex, False)    

  End Sub