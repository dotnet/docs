    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        ' Bind the DataGridView controls to the BindingSource
        ' components and load the data from the database.
        masterDataGridView.DataSource = masterBindingSource
        detailsDataGridView.DataSource = detailsBindingSource
        GetData()

        ' Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        detailsDataGridView.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells

    End Sub