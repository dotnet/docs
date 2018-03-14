Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data
Imports System

Class MyGridForm 
 Inherits Form

 Shared Sub Main()
  Application.Run(New MyGridForm())
 End Sub

 Private grid As DataGrid = New DataGrid()

 Sub New()
  grid.Size = Size
  Dim connstr As String = "Data Source=localhost;Initial Catalog=NORTHWIND;Integrated Security=SSPI"
  Dim custAdapter, orderAdapter As SqlDataAdapter 
  custAdapter = new SqlDataAdapter("select * from customers", connstr)
  orderAdapter = new SqlDataAdapter("select * from orders", connstr)

  Dim ds As DataSet = new DataSet()
  custAdapter.Fill(ds, "Customers")
  orderAdapter.Fill(ds, "Orders")
  ds.Relations.Add("CustOrders", ds.Tables("Customers").Columns("CustomerID"), ds.Tables("Orders").Columns("CustomerID"))
  
  Controls.Add(grid)
  grid.SetDataBinding(ds, "Customers")
  AddHandler grid.Navigate, New NavigateEventHandler(AddressOf Grid_Navigate)
 End Sub
'<Snippet1>
Private Sub Grid_Navigate(sender As Object, e As NavigateEventArgs)
   If e.Forward Then
      Dim ds As DataSet = CType(grid.DataSource, DataSet)
      Dim cm As CurrencyManager = _
      CType(BindingContext(ds,"Customers.CustOrders"), CurrencyManager)
      ' Cast the IList to a DataView to set the AllowNew property.
      Dim dv As DataView = CType(cm.List, DataView)
      dv.AllowNew = false
   End If
End Sub
 '</Snippet1>
End Class
