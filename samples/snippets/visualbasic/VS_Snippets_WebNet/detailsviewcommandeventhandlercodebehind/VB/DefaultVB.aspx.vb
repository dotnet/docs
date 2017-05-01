' <Snippet2>
Partial Class DefaultVB
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Create a new DetailsView object.
        Dim customerDetailsView As New DetailsView()

        ' Set the DetailsView object's properties.
        customerDetailsView.ID = "CustomerDetailsView"
        customerDetailsView.DataSourceID = "DetailsViewSource"
        customerDetailsView.AutoGenerateRows = True
        customerDetailsView.AllowPaging = True

        Dim keyArray() As String = {"CustomerID"}
        customerDetailsView.DataKeyNames = keyArray

        ' Add a button field to the DetailsView control.
        Dim field As New ButtonField()
        field.ButtonType = ButtonType.Link
        field.CausesValidation = False
        field.Text = "Add to List"
        field.CommandName = "Add"

        customerDetailsView.Fields.Add(field)

        ' Programmatically register the event-handling method
        ' for the ItemDeleting event of a DetailsView control.
        AddHandler customerDetailsView.ItemCommand, AddressOf CustomerDetailsView_ItemCommand

        ' Add the DetailsView object to the Controls collection
        ' of the PlaceHolder control.
        DetailsViewPlaceHolder.Controls.Add(customerDetailsView)

    End Sub

    Sub CustomerDetailsView_ItemCommand(ByVal sender As Object, ByVal e As DetailsViewCommandEventArgs)

        ' Use the CommandName property to determine which button
        ' was clicked. 
        If e.CommandName = "Add" Then

            ' Get the DetailsView control that raised the event.
            Dim customerDetailsView As DetailsView = CType(sender, DetailsView)

            ' Add the current customer to the customer list. 

            ' Get the row that contains the company name. In this
            ' example, the company name is in the second row (index 1)  
            ' of the DetailsView control.
            Dim row As DetailsViewRow = customerDetailsView.Rows(1)

            ' Get the company's name from the appropriate cell.
            ' In this example, the company name is in the second cell  
            ' (index 1) of the row.
            Dim name As String = row.Cells(1).Text

            ' Create a ListItem object with the company name.
            Dim item As New ListItem(name)

            ' Add the ListItem object to the ListBox, if the 
            ' item doesn't already exist.
            If Not CustomerListBox.Items.Contains(item) Then

                CustomerListBox.Items.Add(item)

            End If

        End If

    End Sub

End Class
' </Snippet2>
