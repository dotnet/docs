'<snippet1>
Imports System.Console
Module Module1
   Public Sub DisplayProducts(ByVal table As DataTable)
      Dim productNames = From products In table.AsEnumerable() Select products("ProductName")
      WriteLine("Product Names: ")
      For Each productName In productNames
         WriteLine(productName)
       Next
   End Sub

   Sub Main()
      Dim table As DataTable = New DataTable()
      table.Columns.Add("ID")
      table.Columns.Add("ProductName")

      table.Rows.Add("1", "Chai")
      table.Rows.Add("2", "Queso Cabrales")
      table.Rows.Add("3", "Tofu")

      DisplayProducts(table)
   End Sub
End Module
'</snippet1>