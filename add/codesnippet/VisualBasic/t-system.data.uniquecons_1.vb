    Public Sub CreateDataTable()
        Dim dataTable As DataTable = New DataTable
        dataTable.Columns.Add("CustomerID", Type.GetType("System.String"))
        dataTable.Columns.Add("CompanyName", Type.GetType("System.String"))

        Dim uniqueConstraint As UniqueConstraint = _
          New UniqueConstraint("CustConstraint", _
          New DataColumn() {dataTable.Columns("CustomerID"), _
          dataTable.Columns("CompanyName")})

        dataTable.Constraints.Add(uniqueConstraint)
    End Sub