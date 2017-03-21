    Protected Sub ContactsListView_ItemDataBound(ByVal sender As Object, _
                                                 ByVal e As ListViewItemEventArgs)
  
        If e.Item.ItemType = ListViewItemType.DataItem Then
            ' Display the e-mail address in italics.
            Dim EmailAddressLabel As Label = _
              CType(e.Item.FindControl("EmailAddressLabel"), Label)
            EmailAddressLabel.Font.Italic = True

            Dim rowView As System.Data.DataRowView
            rowView = CType(e.Item.DataItem, System.Data.DataRowView)
            Dim currentEmailAddress As String = rowView("EmailAddress").ToString()
            If currentEmailAddress = "orlando0@adventure-works.com" Then
                EmailAddressLabel.Font.Bold = True
            End If
        End If
        
    End Sub