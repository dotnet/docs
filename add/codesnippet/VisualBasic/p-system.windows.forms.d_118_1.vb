    Private Sub dataGridView1_CellValueNeeded(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DataGridViewCellValueEventArgs) _
        Handles dataGridView1.CellValueNeeded

        ' If this is the row for new records, no values are needed.
        If e.RowIndex = Me.dataGridView1.RowCount - 1 Then
            Return
        End If

        Dim customerTmp As Customer = Nothing

        ' Store a reference to the Customer object for the row being painted.
        If e.RowIndex = rowInEdit Then
            customerTmp = Me.customerInEdit
        Else
            customerTmp = CType(Me.customers(e.RowIndex), Customer)
        End If

        ' Set the cell value to paint using the Customer object retrieved.
        Select Case Me.dataGridView1.Columns(e.ColumnIndex).Name
            Case "Company Name"
                e.Value = customerTmp.CompanyName

            Case "Contact Name"
                e.Value = customerTmp.ContactName
        End Select

    End Sub