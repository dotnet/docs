    Private Sub BindDataAndInitializeColumns()

        With dataGridView1
            .AutoGenerateColumns = True
            .DataSource = customersDataSet
            .Columns.Remove("Fax")
            .Columns("CustomerID").Visible = False
        End With

    End Sub