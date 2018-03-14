Public Class Class1


    '--------------------------------------------------------------------------
    Sub Test2()

        '<Snippet7>
        Dim northwindDataSet As New NorthwindDataSet()
        Dim customersTableAdapter As New NorthwindDataSetTableAdapters.CustomersTableAdapter()

        customersTableAdapter.Fill(northwindDataSet.Customers)
        '</Snippet7>
    End Sub


    '--------------------------------------------------------------------------
    Sub Test()
        Dim NorthwindDataSet1 As New NorthwindDataSet()


        '<Snippet3>
        Dim CustomersTableAdapter1 As NorthwindDataSetTableAdapters.CustomersTableAdapter
        CustomersTableAdapter1 = New NorthwindDataSetTableAdapters.CustomersTableAdapter()
        '</Snippet3>


        '<Snippet4>
        CustomersTableAdapter1.Fill(NorthwindDataSet1.Customers)
        '</Snippet4>


        '<Snippet5>
        Dim newCustomersTable As NorthwindDataSet.CustomersDataTable
        newCustomersTable = CustomersTableAdapter1.GetData()
        '</Snippet5>


        '<Snippet6>
        Dim scalarQueriesTableAdapter As NorthwindDataSetTableAdapters.QueriesTableAdapter
        scalarQueriesTableAdapter = New NorthwindDataSetTableAdapters.QueriesTableAdapter()

        Dim returnValue As Integer
        returnValue = CType(scalarQueriesTableAdapter.CustomerCount(), Integer)
        '</Snippet6>

    End Sub

End Class
