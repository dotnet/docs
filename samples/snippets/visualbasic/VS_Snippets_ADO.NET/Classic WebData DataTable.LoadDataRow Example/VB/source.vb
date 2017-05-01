' <Snippet1>
Imports System.Data

Class MyDataSet
   Public Shared Sub Main()
      Dim dt As New DataTable()

      Dim dc1 As New DataColumn("col1")
      Dim dc2 As New DataColumn("col2")
      Dim dc3 As New DataColumn("col3")

      dt.Columns.Add(dc1)
      dt.Columns.Add(dc2)
      dt.Columns.Add(dc3)

      ' Create an array for the values.
      Dim newRow As Object() = New Object(2) {}

      ' Set the values of the array.
      newRow(0) = "Hello"
      newRow(1) = "World"
      newRow(2) = "two"
      Dim row As DataRow

      dt.BeginLoadData()

      ' Add the new row to the rows collection.
      row = dt.LoadDataRow(newRow, True)

      For Each dr As DataRow In dt.Rows
         Console.WriteLine([String].Format("Row: {0}, {1}, {2}", dr("col1"), dr("col2"), dr("col3")))
      Next

      dt.EndLoadData()
   End Sub
End Class
' </Snippet1>