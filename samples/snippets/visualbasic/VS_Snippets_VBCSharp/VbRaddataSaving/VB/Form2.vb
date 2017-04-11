Public Class Form2

    '--------------------------------------------------------------------------
    Sub Test()
        '<Snippet11>
        Using updateTransaction As New Transactions.TransactionScope

            ' Add code to save your data here.
            ' Throw an exception to roll back the transaction.

            ' Call the Complete method to commit the transaction
            updateTransaction.Complete()
        End Using
        '</Snippet11>
    End Sub


    '--------------------------------------------------------------------------
    '<Snippet4>
    Private Sub CustomersBindingNavigatorSaveItem_Click() Handles CustomersBindingNavigatorSaveItem.Click
        UpdateData()
    End Sub

    Private Sub UpdateData()
        Me.Validate()
        Me.CustomersBindingSource.EndEdit()
        Me.OrdersBindingSource.EndEdit()

        Using updateTransaction As New Transactions.TransactionScope

            DeleteOrders()
            DeleteCustomers()
            AddNewCustomers()
            AddNewOrders()

            updateTransaction.Complete()
            NorthwindDataSet.AcceptChanges()
        End Using
    End Sub
    '</Snippet4>


    '--------------------------------------------------------------------------
    '<Snippet5>
    Private Sub DeleteOrders()

        Dim deletedOrders As NorthwindDataSet.OrdersDataTable
        deletedOrders = CType(NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Deleted),
            NorthwindDataSet.OrdersDataTable)

        If Not IsNothing(deletedOrders) Then
            Try
                OrdersTableAdapter.Update(deletedOrders)

            Catch ex As Exception
                MessageBox.Show("DeleteOrders Failed")
            End Try
        End If
    End Sub
    '</Snippet5>


    '--------------------------------------------------------------------------
    '<Snippet6>
    Private Sub DeleteCustomers()

        Dim deletedCustomers As NorthwindDataSet.CustomersDataTable
        deletedCustomers = CType(NorthwindDataSet.Customers.GetChanges(Data.DataRowState.Deleted),
            NorthwindDataSet.CustomersDataTable)

        If Not IsNothing(deletedCustomers) Then
            Try
                CustomersTableAdapter.Update(deletedCustomers)

            Catch ex As Exception
                MessageBox.Show("DeleteCustomers Failed" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    '</Snippet6>


    '--------------------------------------------------------------------------
    '<Snippet7>
    Private Sub AddNewCustomers()

        Dim newCustomers As NorthwindDataSet.CustomersDataTable
        newCustomers = CType(NorthwindDataSet.Customers.GetChanges(Data.DataRowState.Added),
            NorthwindDataSet.CustomersDataTable)

        If Not IsNothing(newCustomers) Then
            Try
                CustomersTableAdapter.Update(newCustomers)

            Catch ex As Exception
                MessageBox.Show("AddNewCustomers Failed" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    '</Snippet7>


    '--------------------------------------------------------------------------
    '<Snippet8>
    Private Sub AddNewOrders()

        Dim newOrders As NorthwindDataSet.OrdersDataTable
        newOrders = CType(NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Added),
            NorthwindDataSet.OrdersDataTable)

        If Not IsNothing(newOrders) Then
            Try
                OrdersTableAdapter.Update(newOrders)

            Catch ex As Exception
                MessageBox.Show("AddNewOrders Failed" & vbCrLf & ex.Message)
            End Try
        End If
    End Sub
    '</Snippet8>


    '--------------------------------------------------------------------------
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'TODO: This line of code loads data into the 'NorthwindDataSet.Orders' table. You can move, or remove it, as needed.
        Me.OrdersTableAdapter.Fill(Me.NorthwindDataSet.Orders)

        'TODO: This line of code loads data into the 'NorthwindDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.NorthwindDataSet.Customers)
    End Sub


    '--------------------------------------------------------------------------
    '<Snippet27>
    Private Sub UpdateDB()
        Dim deletedChildRecords As NorthwindDataSet.OrdersDataTable =
            CType(NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Deleted), NorthwindDataSet.OrdersDataTable)

        Dim newChildRecords As NorthwindDataSet.OrdersDataTable =
            CType(NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Added), NorthwindDataSet.OrdersDataTable)

        Dim modifiedChildRecords As NorthwindDataSet.OrdersDataTable =
            CType(NorthwindDataSet.Orders.GetChanges(Data.DataRowState.Modified), NorthwindDataSet.OrdersDataTable)

        Try
            If deletedChildRecords IsNot Nothing Then
                OrdersTableAdapter.Update(deletedChildRecords)
            End If

            CustomersTableAdapter.Update(NorthwindDataSet.Customers)

            If newChildRecords IsNot Nothing Then
                OrdersTableAdapter.Update(newChildRecords)
            End If

            If modifiedChildRecords IsNot Nothing Then
                OrdersTableAdapter.Update(modifiedChildRecords)
            End If

            NorthwindDataSet.AcceptChanges()

        Catch ex As Exception
            MessageBox.Show("An error occurred during the update process")
            ' Add code to handle error here.

        Finally
            If deletedChildRecords IsNot Nothing Then
                deletedChildRecords.Dispose()
            End If

            If newChildRecords IsNot Nothing Then
                newChildRecords.Dispose()
            End If

            If modifiedChildRecords IsNot Nothing Then
                modifiedChildRecords.Dispose()
            End If

        End Try
    End Sub
    '</Snippet27>


End Class