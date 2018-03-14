' <Snippet1>
Imports System.Data

Public Class A

   Public Shared Sub Main()
      Dim table As New DataTable("Orders")
      table.Columns.Add("OrderID", GetType(Int32))
      table.Columns.Add("OrderQuantity", GetType(Int32))
      table.Columns.Add("CompanyName", GetType(String))
      table.Columns.Add("Date", GetType(DateTime))

      Dim newRow As DataRow = table.NewRow()
      newRow("OrderID") = 1
      newRow("OrderQuantity") = 3
      newRow("CompanyName") = "NewCompanyName"
      newRow("Date") = "1979, 1, 31"

      ' Add the row to the rows collection.
      table.Rows.Add(newRow)

      Dim newRow2 As DataRow = table.NewRow()
      newRow2("OrderID") = 2
      newRow2("OrderQuantity") = 2
      newRow2("CompanyName") = "NewCompanyName1"
      table.Rows.Add(newRow2)

      Dim newRow3 As DataRow = table.NewRow()
      newRow3("OrderID") = 3
      newRow3("OrderQuantity") = 2
      newRow3("CompanyName") = "NewCompanyName2"
      table.Rows.Add(newRow3)

      ' Presuming the DataTable has a column named Date.
      Dim expression As String = "Date = '1/31/1979' or OrderID = 2"
      ' Dim expression As String = "OrderQuantity = 2 and OrderID = 2"

      ' Sort descending by column named CompanyName.
      Dim sortOrder As String = "CompanyName ASC"
      Dim foundRows As DataRow()

      ' Use the Select method to find all rows matching the filter.
      foundRows = table.[Select](expression, sortOrder)

      ' Print column 0 of each returned row.
      For i As Integer = 0 To foundRows.Length - 1
         Console.WriteLine(foundRows(i)(2))
      Next
   End Sub
End Class
' </Snippet1>