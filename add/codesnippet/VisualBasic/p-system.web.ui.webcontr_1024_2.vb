   ' To support basic filtering, the employees cannot
   ' be returned as an array of objects, rather as a
   ' DataSet of the raw data values.
   Public Shared Function GetAllEmployeesAsDataSet() As DataSet
      Dim employees As ICollection = GetAllEmployees()

      Dim ds As New DataSet("Table")

      ' Create the schema of the DataTable.
      Dim dt As New DataTable()
      Dim dc As DataColumn
      dc = New DataColumn("FirstName", GetType(String))
      dt.Columns.Add(dc)
      dc = New DataColumn("LastName", GetType(String))
      dt.Columns.Add(dc)
      dc = New DataColumn("Title", GetType(String))
      dt.Columns.Add(dc)
      dc = New DataColumn("Courtesy", GetType(String))
      dt.Columns.Add(dc)
      dc = New DataColumn("Supervisor", GetType(Int32))
      dt.Columns.Add(dc)

      ' Add rows to the DataTable.
      Dim emplEnum As IEnumerator = employees.GetEnumerator()
      Dim row As DataRow
      Dim ne As NorthwindEmployee
      While emplEnum.MoveNext()
         ne = CType(emplEnum.Current, NorthwindEmployee)
         row = dt.NewRow()
         row("FirstName") = ne.FirstName
         row("LastName") = ne.LastName
         row("Title") = ne.Title
         row("Courtesy") = ne.Courtesy
         row("Supervisor") = ne.Supervisor
         dt.Rows.Add(row)
      End While
      ' Add the complete DataTable to the DataSet.
      ds.Tables.Add(dt)

      Return ds
   End Function 'GetAllEmployeesAsDataSet