    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, _
        ByVal e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellContentClick

        If IsANonHeaderLinkCell(e) Then
            MoveToLinked(e)
        ElseIf IsANonHeaderButtonCell(e) Then
            PopulateSales(e)
        End If
    End Sub

    Private Sub MoveToLinked(ByVal e As DataGridViewCellEventArgs)
        Dim employeeId As String
        Dim value As Object = DataGridView1.Rows(e.RowIndex). _
            Cells(e.ColumnIndex).Value
        If value.GetType Is GetType(DBNull) Then Return

        employeeId = CType(value, String)
        Dim boss As DataGridViewCell = _
            RetrieveSuperiorsLastNameCell(employeeId)
        If boss IsNot Nothing Then
            DataGridView1.CurrentCell = boss
        End If
    End Sub

    Private Function IsANonHeaderLinkCell(ByVal cellEvent As _
        DataGridViewCellEventArgs) As Boolean

        If TypeOf DataGridView1.Columns(cellEvent.ColumnIndex) _
            Is DataGridViewLinkColumn _
            AndAlso Not cellEvent.RowIndex = -1 Then _
            Return True Else Return False

    End Function

    Private Function IsANonHeaderButtonCell(ByVal cellEvent As _
        DataGridViewCellEventArgs) As Boolean

        If TypeOf DataGridView1.Columns(cellEvent.ColumnIndex) _
            Is DataGridViewButtonColumn _
            AndAlso Not cellEvent.RowIndex = -1 Then _
            Return True Else Return (False)

    End Function

    Private Function RetrieveSuperiorsLastNameCell( _
        ByVal employeeId As String) As DataGridViewCell

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Return Nothing
            If row.Cells(ColumnName.EmployeeId.ToString()). _
                Value.ToString().Equals(employeeId) Then
                Return row.Cells(ColumnName.LastName.ToString())
            End If
        Next
        Return Nothing
    End Function