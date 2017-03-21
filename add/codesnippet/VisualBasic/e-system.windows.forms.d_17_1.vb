    Private Sub dataGridView1_DataBindingComplete(ByVal sender As Object, _
    ByVal e As DataGridViewBindingCompleteEventArgs) _
    Handles dataGridView1.DataBindingComplete

        ' Hide some of the columns.
        With dataGridView1
            .Columns("EmployeeID").Visible = False
            .Columns("Address").Visible = False
            .Columns("TitleOfCourtesy").Visible = False
            .Columns("BirthDate").Visible = False
            .Columns("HireDate").Visible = False
            .Columns("PostalCode").Visible = False
            .Columns("Photo").Visible = False
            .Columns("Notes").Visible = False
            .Columns("ReportsTo").Visible = False
            .Columns("PhotoPath").Visible = False
        End With

        ' Disable sorting for the DataGridView.
        Dim i As DataGridViewColumn
        For Each i In dataGridView1.Columns
            i.SortMode = DataGridViewColumnSortMode.NotSortable
        Next i

        dataGridView1.AutoResizeColumns()

    End Sub