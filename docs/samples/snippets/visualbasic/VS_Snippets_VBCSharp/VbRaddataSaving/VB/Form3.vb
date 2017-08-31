Public Class Form3


    '--------------------------------------------------------------------------
    '<Snippet23>
    Private Sub AddNewCustomer(ByVal currentCustomer As Customer)

        CustomersTableAdapter.Insert(
            currentCustomer.CustomerID,
            currentCustomer.CompanyName,
            currentCustomer.ContactName,
            currentCustomer.ContactTitle,
            currentCustomer.Address,
            currentCustomer.City,
            currentCustomer.Region,
            currentCustomer.PostalCode,
            currentCustomer.Country,
            currentCustomer.Phone,
            currentCustomer.Fax)
    End Sub
    '</Snippet23>


    '--------------------------------------------------------------------------
    '<Snippet24>
    Private Sub UpdateCustomer(ByVal cust As Customer)

            CustomersTableAdapter.Update(
            cust.CustomerID,
            cust.CompanyName,
            cust.ContactName,
            cust.ContactTitle,
            cust.Address,
            cust.City,
            cust.Region,
            cust.PostalCode,
            cust.Country,
            cust.Phone,
            cust.Fax,
            cust.origCustomerID,
            cust.origCompanyName,
            cust.origContactName,
            cust.origContactTitle,
            cust.origAddress,
            cust.origCity,
            cust.origRegion,
            cust.origPostalCode,
            cust.origCountry,
            cust.origPhone,
            cust.origFax)
    End Sub
    '</Snippet24>


    '--------------------------------------------------------------------------
    '<Snippet25>
    Private Sub DeleteCustomer(ByVal cust As Customer)

        CustomersTableAdapter.Delete(
            cust.origCustomerID,
            cust.origCompanyName,
            cust.origContactName,
            cust.origContactTitle,
            cust.origAddress,
            cust.origCity,
            cust.origRegion,
            cust.origPostalCode,
            cust.origCountry,
            cust.origPhone,
            cust.origFax)
    End Sub
    '</Snippet25>


    '--------------------------------------------------------------------------
    Private Sub CustomersBindingNavigatorSaveItem_Click() Handles CustomersBindingNavigatorSaveItem.Click

        '<Snippet9>
        Try
            Me.Validate()
            Me.CustomersBindingSource.EndEdit()
            Me.CustomersTableAdapter.Update(Me.NorthwindDataSet.Customers)
            MsgBox("Update successful")

        Catch ex As Exception
            MsgBox("Update failed")
        End Try
        '</Snippet9>
    End Sub


    '--------------------------------------------------------------------------
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwindDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
    End Sub
End Class