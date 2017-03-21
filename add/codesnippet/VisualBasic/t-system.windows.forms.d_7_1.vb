    Private Function Populate(ByVal query As String, ByVal resetUnsharedCounter As Boolean) As DataTable

        If resetUnsharedCounter Then
            ResetCounter()
        End If

        ' Alter the data source as necessary
        Dim adapter As New SqlDataAdapter(query, _
            New SqlConnection("Integrated Security=SSPI;Persist Security Info=False;" & _
            "Initial Catalog=Northwind;Data Source=localhost"))

        Dim table As New DataTable()
        table.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter.Fill(table)
        Return table
    End Function

    Private count As New Label()
    Private unsharedRowCounter As Integer

    Private Sub ResetCounter()
        unsharedRowCounter = 0
        count.Text = unsharedRowCounter.ToString()
    End Sub

    Private Sub DataGridView1_CellToolTipTextNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellToolTipTextNeededEventArgs) _
        Handles dataGridView1.CellToolTipTextNeeded

        If theCellImHoveringOver.ColumnIndex = dataGridView1.Columns("ReportsTo").Index AndAlso _
                theCellImHoveringOver.RowIndex > -1 Then

            Dim reportsTo As String = dataGridView1.Rows(theCellImHoveringOver.RowIndex). _
                Cells(theCellImHoveringOver.ColumnIndex).Value.ToString()
            If String.IsNullOrEmpty(reportsTo) Then
                e.ToolTipText = "The buck stops here!"
            Else
                Dim table As DataTable = Populate( _
                    "select firstname, lastname from employees where employeeid = '" & _
                    dataGridView1.Rows(theCellImHoveringOver.RowIndex). _
                    Cells(theCellImHoveringOver.ColumnIndex).Value.ToString() & _
                    "'", False)

                e.ToolTipText = "Reports to " & table.Rows(0).Item(0).ToString() & " " & table.Rows(0).Item(1).ToString()
            End If
        End If
    End Sub