    Private Sub BindData()

        With customersDataGridView
            .AutoGenerateColumns = True
            .DataSource = customersDataSet
            .DataMember = "Customers"
        End With

    End Sub