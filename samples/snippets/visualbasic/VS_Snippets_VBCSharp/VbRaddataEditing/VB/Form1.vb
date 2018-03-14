Public Class Form1


    '--------------------------------------------------------------------------
    Sub Test1Typed()

        '<Snippet1>
        Dim newCustomersRow As NorthwindDataSet.CustomersRow
        newCustomersRow = NorthwindDataSet1.Customers.NewCustomersRow()

        newCustomersRow.CustomerID = "ALFKI"
        newCustomersRow.CompanyName = "Alfreds Futterkiste"

        NorthwindDataSet1.Customers.Rows.Add(newCustomersRow)
        '</Snippet1>


        '<Snippet3>
        '<Snippet18>
        Dim customersRow As NorthwindDataSet.CustomersRow
        customersRow = NorthwindDataSet1.Customers.FindByCustomerID("ALFKI")
        '</Snippet18>

        customersRow.CompanyName = "Updated Company Name"
        customersRow.City = "Seattle"
        '</Snippet3>


        '<Snippet5>
        NorthwindDataSet1.Customers(4).CompanyName = "Updated Company Name"
        NorthwindDataSet1.Customers(4).City = "Seattle"
        '</Snippet5>


        '<Snippet8>
        NorthwindDataSet1.Customers.Rows(0).Delete()
        '</Snippet8>


        '<Snippet11>
        NorthwindDataSet1.Customers.AcceptChanges()
        '</Snippet11>


        '<Snippet12>
        If NorthwindDataSet1.HasChanges() Then

            ' Changed rows were detected, add appropriate code.
        Else
            ' No changed rows were detected, add appropriate code. 
        End If
        '</Snippet12>


        '<Snippet13>
        If NorthwindDataSet1.HasChanges(DataRowState.Added) Then

            ' New rows have been added to the dataset, add appropriate code.
        Else
            ' No new rows have been added to the dataset, add appropriate code.
        End If
        '</Snippet13>


        '<Snippet21>
        Dim originalCompanyName = NorthwindDataSet1.Customers(0)(
           "CompanyName", DataRowVersion.Original).ToString()
        '</Snippet21>


        '<Snippet22>
        Dim currentCompanyName = NorthwindDataSet1.Customers(0)(
            "CompanyName", DataRowVersion.Current).ToString()
        '</Snippet22>
    End Sub


    '--------------------------------------------------------------------------
    Sub Test2Untyped()

        '<Snippet2>
        Dim newCustomersRow As DataRow = DataSet1.Tables("Customers").NewRow()

        newCustomersRow("CustomerID") = "ALFKI"
        newCustomersRow("CompanyName") = "Alfreds Futterkiste"

        DataSet1.Tables("Customers").Rows.Add(newCustomersRow)
        '</Snippet2>


        '<Snippet4>
        Dim customerRow() As Data.DataRow
        customerRow = DataSet1.Tables("Customers").Select("CustomerID = 'ALFKI'")

        customerRow(0)("CompanyName") = "Updated Company Name"
        customerRow(0)("City") = "Seattle"
        '</Snippet4>


        '<Snippet6>
        DataSet1.Tables(0).Rows(4).Item(0) = "Updated Company Name"
        DataSet1.Tables(0).Rows(4).Item(1) = "Seattle"
        '</Snippet6>


        '<Snippet7>
        DataSet1.Tables("Customers").Rows(4).Item("CompanyName") = "Updated Company Name"
        DataSet1.Tables("Customers").Rows(4).Item("City") = "Seattle"
        '</Snippet7>


        '<Snippet9>
        DataSet1.Tables("Customers").Rows(0).Delete()
        '</Snippet9>


        '<Snippet10>
        DataSet1.EnforceConstraints = False
        ' Perform some operations on the dataset
        DataSet1.EnforceConstraints = True
        '</Snippet10>


        '<Snippet19>
        Dim s As String = "primaryKeyValue"
        Dim foundRow As DataRow = DataSet1.Tables("AnyTable").Rows.Find(s)

        If foundRow IsNot Nothing Then
            MsgBox(foundRow(1).ToString())
        Else
            MsgBox("A row with the primary key of " & s & " could not be found")
        End If
        '</Snippet19>


        '<Snippet20>
        Dim foundRows() As Data.DataRow
        foundRows = DataSet1.Tables("Customers").Select("CompanyName Like 'A%'")
        '</Snippet20>
    End Sub


    '--------------------------------------------------------------------------
    Sub Test3Changed()

        Dim dataTable1 As DataTable = DataSet1.Tables(0)


        '<Snippet14>
        Dim changedRecords As DataSet = DataSet1.GetChanges()
        '</Snippet14>


        '<Snippet15>
        Dim changedRecordsTable As DataTable = dataTable1.GetChanges()
        '</Snippet15>


        '<Snippet16>
        Dim addedRecords As DataSet = DataSet1.GetChanges(DataRowState.Added)
        '</Snippet16>
    End Sub


    '--------------------------------------------------------------------------
    '<Snippet17>
    Private Function GetNewRecords() As NorthwindDataSet.CustomersDataTable

        Return CType(NorthwindDataSet1.Customers.GetChanges(Data.DataRowState.Added),
            NorthwindDataSet.CustomersDataTable)
    End Function
    '</Snippet17>


    '--------------------------------------------------------------------------
    '<Snippet23>
    Private Sub FindErrors()
        Dim table As Data.DataTable
        Dim row As Data.DataRow

        If DataSet1.HasErrors Then

            For Each table In DataSet1.Tables
                If table.HasErrors Then

                    For Each row In table.Rows
                        If row.HasErrors Then

                            ' Process error here.
                        End If
                    Next
                End If
            Next
        End If
    End Sub
    '</Snippet23>


End Class
