Sub AllItems_Click(sender As Object, e As EventArgs)
    Dim dataListEnumerator As IEnumerator
    Dim currentItem As DataListItem 
    lblAllItems.Text = ""
    ' Get an enumerator to traverse the DataListItemCollection.
    dataListEnumerator = myDataList.Items.GetEnumerator()
    while(dataListEnumerator.MoveNext())
        currentItem = CType(dataListEnumerator.Current,DataListItem)
        ' Display the current DataListItem onto the label.
        lblAllItems.Text = lblAllItems.Text & CType((currentItem.Controls(1)), _
        Label).Text & "  "
    End While
End Sub