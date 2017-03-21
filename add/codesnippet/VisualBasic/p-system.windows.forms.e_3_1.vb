    Private Sub InitializeComponent()
        ' Standard control setup.
        '....                  
        ' You set the DataSource to a data set, and the DataMember to a table.
        errorProvider1.DataSource = dataSet1
        errorProvider1.DataMember = dataTable1.TableName
        errorProvider1.ContainerControl = Me
        errorProvider1.BlinkRate = 200
    End Sub 'InitializeComponent
     '...
    ' Since the ErrorProvider control does not have a visible component,
    ' it does not need to be added to the form. 
    
    Private Sub buttonSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Checks for a bad post code.
        Dim CustomersTable As DataTable
        CustomersTable = dataSet1.Tables("Customers")
        Dim row As DataRow
        For Each row In CustomersTable.Rows
            If Convert.ToBoolean(row("PostalCodeIsNull")) Then
                row.RowError = "The Customer details contain errors"
                row.SetColumnError("PostalCode", "Postal Code required")
            End If
        Next row
    End Sub 'buttonSave_Click