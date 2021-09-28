Option Explicit On
Option Strict On

Imports System.Data
Module Module1

    Sub Main()
        ' <Snippet1>
        Dim customerOrders As New DataSet("CustomerOrders")

        Dim ordersTable As DataTable = customerOrders.Tables.Add("Orders")

        Dim pkOrderID As DataColumn = ordersTable.Columns.Add( _
            "OrderID", Type.GetType("System.Int32"))
        ordersTable.Columns.Add("OrderQuantity", Type.GetType("System.Int32"))
        ordersTable.Columns.Add("CompanyName", Type.GetType("System.String"))

        ordersTable.PrimaryKey = New DataColumn() {pkOrderID}
        ' </Snippet1>
    End Sub

End Module
