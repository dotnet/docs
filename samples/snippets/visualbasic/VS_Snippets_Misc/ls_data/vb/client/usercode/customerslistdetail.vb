
Namespace LightSwitchApplication

    Public Class CustomersListDetail

        '<Snippet3>
        Private Sub Customers_Validate _
            (results As Microsoft.LightSwitch.Framework.Client.ScreenValidationResultsBuilder)
            If Me.DataWorkspace.NorthwindData.Details.HasChanges Then
                Dim changeSet As EntityChangeSet = _
                    Me.DataWorkspace.NorthwindData.Details.GetChanges()

                Dim entity As IEntityObject

                For Each entity In changeSet.DeletedEntities.OfType(Of Customer)()

                    Dim cust As Customer = CType(entity, Customer)
                    If cust.Country = "USA" Then
                        entity.Details.DiscardChanges()
                        results.AddScreenResult("Unable to remove this customer." & _
                            "Cannot delete customers that are located in the USA.", _
                             ValidationSeverity.Informational)
                    End If

                Next
            End If

        End Sub
        '</Snippet3>

        '<Snippet5>
        Private Sub RetrieveCustomer_Execute()
            Dim cust As Customer = Me.Customers.SelectedItem
            If cust.ContactName = "Bob" Then
                'Perform some task on the customer entity.
            End If
        End Sub
        '</Snippet5>
        '<Snippet6>
        Private Sub RetrieveCustomers_Execute()
            For Each cust As Customer In Me.DataWorkspace.NorthwindData.Customers
                If cust.ContactName = "Bob" Then
                    'Perform some task on the customer entity.
                End If
            Next

        End Sub
        '</Snippet6>
        '<Snippet7>
        Private Sub RetrieveSalesOrders_Execute()
            Dim cust As Customer = Me.Customers.SelectedItem
            For Each myOrder As Order In cust.Orders
                If myOrder.OrderDate = Today Then
                    'Perform some task on the order entity.
                End If
            Next
        End Sub
        '</Snippet7>
        '<Snippet10>
        Private Sub DeleteCustomer_Execute()
            Dim cust As Customer
            cust = Me.Customers.SelectedItem
            If Customers.CanDelete Then
                cust.Delete()
            End If

        End Sub
        '</Snippet10>
        '<Snippet11>
        Private Sub ImportCustomers_Execute()
            For Each spCust As SharePointCustomer In _
                Me.DataWorkspace.SharePointData.NewCustomersInSharePoint
                Dim newCust As Customer = New Customer()
                With newCust

                    .ContactName = spCust.FirstName & " " & spCust.LastName
                    .Address = spCust.Address
                    .City = spCust.City
                    .PostalCode = spCust.PostalCode
                    .Region = spCust.Region

                    'Set the CopiedToDatabase field of the item in SharePoint.
                    spCust.CopiedToDatabase = "Yes"
                End With

            Next
            Me.DataWorkspace.SharePointData.SaveChanges()



        End Sub
        '</Snippet11>

        '<Snippet12>
        Private Sub CustomersListDetail_Saving(ByRef handled As Boolean)
            Try
                Me.DataWorkspace.SharePointData.SaveChanges()

            Catch ex As DataServiceOperationException

                If ex.ErrorInfo = "DTSException" Then
                    Me.ShowMessageBox(ex.Message)
                Else
                    Throw ex

                End If

            End Try

            handled = True


        End Sub
        '</Snippet12>
        '<Snippet14>
        Private Sub UndoAllCustomerUpdates_Execute()
            For Each Cust As Customer In _
                Me.DataWorkspace.NorthwindData.Details. _
                GetChanges().OfType(Of Customer)()

                Cust.Details.DiscardChanges()

            Next
        End Sub

        Private Sub UndoAllUpdates_Execute()
            Me.DataWorkspace.NorthwindData.Details.DiscardChanges()
        End Sub

        Private Sub UnduCustomerEdit_Execute()
            Customers.SelectedItem.Details.DiscardChanges()
        End Sub
        '</Snippet14>
        '<Snippet15>
        Private Sub HandleConflicts(ByVal entity As Order)
            For Each detail In entity.Order_Details
                detail.Product.UnitsInStock = (detail.Product.UnitsInStock) - detail.Quantity
            Next
            Try
                Me.DataWorkspace.ProductDataSource.SaveChanges()
            Catch ex As ConcurrencyException
                For Each conflict As IEntityObject In ex.EntitiesWithConflicts
                    If conflict.Details.EntityConflict.IsDeletedOnServer Then
                        conflict.Details.EntityConflict.ResolveConflicts _
                        (Microsoft.LightSwitch.Details.ConflictResolution.ServerWins)
                    Else
                        conflict.Details.EntityConflict.ResolveConflicts _
                       (Microsoft.LightSwitch.Details.ConflictResolution.ClientWins)
                    End If
                Next
            End Try
        End Sub
        '</Snippet15>
    End Class

End Namespace
