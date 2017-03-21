' Copy the items in the ListListBox1.Items to an array before 
' deleting them.     
Dim myListItemArray(ListBox1.Items.Count - 1) As ListItem
ListBox1.Items.CopyTo(myListItemArray, 0)

' Delete all the items from the ListBox.
ListBox1.Items.Clear()
DeleteLabel.Text = "<b>All items in the ListBox were deleted successfully." & _
                   "</b><br /><b>The deleted items are:"
Dim listResults As [String] = ""
Dim myItem2 As ListItem
For Each myItem2 In myListItemArray
    listResults = listResults & myItem2.Text & "<br />"
Next myItem2
ResultsLabel.Text = listResults