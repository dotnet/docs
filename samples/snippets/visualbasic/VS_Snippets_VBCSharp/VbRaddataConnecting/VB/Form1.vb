'<Snippet3>
Public Class Form1
    '<Snippet4>
    Private Sub LoadCustomers()
        Dim customerData As NorthwindDataSet.CustomersDataTable =
            CustomersTableAdapter1.GetTop5Customers()

        Dim customerRow As NorthwindDataSet.CustomersRow

        For Each customerRow In customerData
            Dim currentCustomer As New Customer()
            With currentCustomer

                .CustomerID = customerRow.CustomerID
                .CompanyName = customerRow.CompanyName

                If Not customerRow.IsAddressNull Then
                    .Address = customerRow.Address
                End If

                If Not customerRow.IsCityNull Then
                    .City = customerRow.City
                End If

                If Not customerRow.IsContactNameNull Then
                    .ContactName = customerRow.ContactName
                End If

                If Not customerRow.IsContactTitleNull Then
                    .ContactTitle = customerRow.ContactTitle
                End If

                If Not customerRow.IsCountryNull Then
                    .Country = customerRow.Country
                End If

                If Not customerRow.IsFaxNull Then
                    .Fax = customerRow.Fax
                End If

                If Not customerRow.IsPhoneNull Then
                    .Phone = customerRow.Phone
                End If

                If Not customerRow.IsPostalCodeNull Then
                    .PostalCode = customerRow.PostalCode
                End If

                If Not customerRow.Is_RegionNull Then
                    .Region = customerRow._Region
                End If

            End With

            LoadOrders(currentCustomer)
            CustomerBindingSource.Add(currentCustomer)
        Next
    End Sub
    '</Snippet4>

    Private Sub LoadOrders(ByRef currentCustomer As Customer)
        Dim orderData As NorthwindDataSet.OrdersDataTable =
            OrdersTableAdapter1.GetDataByCustomerID(currentCustomer.CustomerID)

        Dim orderRow As NorthwindDataSet.OrdersRow

        For Each orderRow In orderData
            Dim currentOrder As New Order()
            With currentOrder
                .OrderID = orderRow.OrderID
                .Customer = currentCustomer

                If Not orderRow.IsCustomerIDNull Then
                    .CustomerID = orderRow.CustomerID
                End If

                If Not orderRow.IsEmployeeIDNull Then
                    .EmployeeID = orderRow.EmployeeID
                End If

                If Not orderRow.IsFreightNull Then
                    .Freight = orderRow.Freight
                End If

                If Not orderRow.IsOrderDateNull Then
                    .OrderDate = orderRow.OrderDate
                End If

                If Not orderRow.IsRequiredDateNull Then
                    .RequiredDate = orderRow.RequiredDate
                End If

                If Not orderRow.IsShipAddressNull Then
                    .ShipAddress = orderRow.ShipAddress
                End If

                If Not orderRow.IsShipCityNull Then
                    .ShipCity = orderRow.ShipCity
                End If

                If Not orderRow.IsShipCountryNull Then
                    .ShipCountry = orderRow.ShipCountry
                End If

                If Not orderRow.IsShipNameNull Then
                    .ShipName = orderRow.ShipName
                End If

                If Not orderRow.IsShippedDateNull Then
                    .ShippedDate = orderRow.ShippedDate
                End If

                If Not orderRow.IsShipPostalCodeNull Then
                    .ShipPostalCode = orderRow.ShipPostalCode
                End If

                If Not orderRow.IsShipRegionNull Then
                    .ShipRegion = orderRow.ShipRegion
                End If

                If Not orderRow.IsShipViaNull Then
                    .ShipVia = orderRow.ShipVia
                End If
            End With
            currentCustomer.Orders.Add(currentOrder)
        Next

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, 
                           ByVal e As System.EventArgs) Handles MyBase.Load

        LoadCustomers()
    End Sub
End Class
'</Snippet3>
