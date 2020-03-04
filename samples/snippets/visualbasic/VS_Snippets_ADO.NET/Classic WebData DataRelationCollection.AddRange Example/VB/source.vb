Imports System.Data

Public Class SamPle

    Shared Sub Main()

        ' Create a DataSet with two tables.
        Dim dataSet As New DataSet()

        ' Create Customer table.
        Dim customersTable As New DataTable("Customers")
        customersTable.Columns.Add("customerId", _
            Type.GetType("System.Int32")).AutoIncrement = True
        customersTable.Columns.Add("name",       _
            Type.GetType("System.String"))
        customersTable.PrimaryKey = New DataColumn() _
            { customersTable.Columns("customerId") }

        ' Create Orders table.
        Dim ordersTable As New DataTable("Orders")
        ordersTable.Columns.Add("orderId",    _
            Type.GetType("System.Int32")).AutoIncrement = True
        ordersTable.Columns.Add("customerId", _
            Type.GetType("System.Int32"))
        ordersTable.Columns.Add("amount",     _
            Type.GetType("System.Double"))
        ordersTable.PrimaryKey = New DataColumn() _
            { customersTable.Columns("orderId") }

        ' Create Order Details table.
        Dim orderDetailsTable As New DataTable("OrderDetails")
        orderDetailsTable.Columns.Add("orderId",    _
            Type.GetType("System.Int32"))
        orderDetailsTable.Columns.Add("productId",     _
            Type.GetType("System.Int32"))
        orderDetailsTable.Columns.Add("quantity",     _
            Type.GetType("System.Double"))

        dataSet.Tables.AddRange(New DataTable() _
            {customersTable, ordersTable, orderDetailsTable} )

        ' Print the tables and their columns.
        Dim table As DataTable
        Dim column As DataColumn
        For Each table in dataSet.Tables 
            Console.WriteLine(table.TableName)
            For Each column In table.Columns 
                Console.WriteLine($"{column.ColumnName} ")
            Next
            Console.WriteLine()
        Next

        AddRelations(dataSet)
    End Sub

    ' <Snippet1>
    Public Shared Sub AddRelations(dataSet As DataSet)
        Dim customerOrders As New DataRelation("CustomerOrders", _
            dataSet.Tables("Customers").Columns("customerId"), _
            dataSet.Tables("Orders").Columns("customerId"))
        Dim orderDetails As New DataRelation("OrderDetail", _
            dataSet.Tables("Orders").Columns("orderId"), _
            dataSet.Tables("OrderDetails").Columns("orderId"))

        dataSet.Relations.AddRange(New DataRelation() _
            {customerOrders, orderDetails})

        ' Display names of all relations.
        Dim relation As DataRelation
        For Each relation In dataSet.Relations
            Console.WriteLine(relation.RelationName.ToString())
        Next
    End Sub
    ' </Snippet1>

End Class
