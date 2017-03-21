    Private Sub Form1_Load( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs)

        ' Add a DemoCustomer to cause a row to be displayed.
        Me.customersBindingSource.AddNew()

        ' Bind the BindingSource to the DataGridView 
        ' control's DataSource.
        Me.customersDataGridView.DataSource = Me.customersBindingSource

    End Sub