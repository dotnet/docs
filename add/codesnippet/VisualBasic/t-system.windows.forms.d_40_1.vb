    Private WithEvents wholeTable As New ToolStripMenuItem()
    Private WithEvents lookUp As New ToolStripMenuItem()
    Private strip As ContextMenuStrip
    Private cellErrorText As String

    Private Sub dataGridView1_CellContextMenuStripNeeded(ByVal sender As Object, _
        ByVal e As DataGridViewCellContextMenuStripNeededEventArgs) _
        Handles dataGridView1.CellContextMenuStripNeeded

        cellErrorText = String.Empty

        If strip Is Nothing Then
            strip = New ContextMenuStrip()
            lookUp.Text = "Look Up"
            wholeTable.Text = "See Whole Table"
            strip.Items.Add(lookUp)
            strip.Items.Add(wholeTable)
        End If
        e.ContextMenuStrip = strip
    End Sub

    Private Sub wholeTable_Click(ByVal sender As Object, ByVal e As EventArgs) Handles wholeTable.Click
        dataGridView1.DataSource = Populate("Select * from employees", True)
    End Sub

    Private theCellImHoveringOver As DataGridViewCellEventArgs

    Private Sub dataGridView1_CellMouseEnter(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles dataGridView1.CellMouseEnter

        theCellImHoveringOver = e
    End Sub

    Private cellErrorLocation As DataGridViewCellEventArgs

    Private Sub lookUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lookUp.Click
        Try
            dataGridView1.DataSource = Populate("Select * from employees where " & _
                dataGridView1.Columns(theCellImHoveringOver.ColumnIndex).Name & " = '" & _
                dataGridView1.Rows(theCellImHoveringOver.RowIndex).Cells(theCellImHoveringOver.ColumnIndex).Value.ToString() & _
                "'", True)
        Catch ex As SqlException
            cellErrorText = "Can't look this cell up"
            cellErrorLocation = theCellImHoveringOver
        End Try
    End Sub

    Private Sub dataGridView1_CellErrorTextNeeded(ByVal sender As Object, _
                ByVal e As DataGridViewCellErrorTextNeededEventArgs) _
                Handles dataGridView1.CellErrorTextNeeded
        If (Not cellErrorLocation Is Nothing) Then
            If e.ColumnIndex = cellErrorLocation.ColumnIndex AndAlso _
                e.RowIndex = cellErrorLocation.RowIndex Then
                e.ErrorText = cellErrorText
            End If
        End If
    End Sub

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