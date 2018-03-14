' <Snippet2>
Partial Class DefaultVB
    Inherits System.Web.UI.Page

    Public Sub ItemDetailsView_ItemCommand(ByVal sender As Object, ByVal e As DetailsViewCommandEventArgs)
        ' Use the CommandName property to determine which button
        ' was clicked. 
        If e.CommandName = "Add" Then
		
            ' Add the customer to the customer list. 

            ' Get the row that contains the company name. In this
            ' example, the company name is in the second row (index 1)  
            ' of the DetailsView control.
            Dim row As DetailsViewRow = ItemDetailsView.Rows(1)

            ' Get the company's name from the appropriate cell.
            ' In this example, the company name is in the second cell  
            ' (index 1) of the row.
            Dim name As String = row.Cells(1).Text

            ' Create a ListItem object with the company name.
            Dim item As ListItem = New ListItem(name)

            ' Add the ListItem object to the ListBox control, if the 
            ' item does not already exist.
            If Not CustomerListBox.Items.Contains(item) Then
                CustomerListBox.Items.Add(item)
            End If
        End If
    End Sub

End Class
' </Snippet2>