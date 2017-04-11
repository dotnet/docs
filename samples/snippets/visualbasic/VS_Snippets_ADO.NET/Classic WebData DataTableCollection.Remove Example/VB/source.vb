Imports System
Imports System.Data

Module DataTableCollectionRemove
' <Snippet1>
    Public Sub Main
	DataTableCollectionCanRemove
    End Sub

    Public Sub DataTableCollectionCanRemove()
        ' create a DataSet with two tables
        Dim dataSet As DataSet = New DataSet()

        ' create Customer table
        Dim customersTable As DataTable = New DataTable("Customers")
        customersTable.Columns.Add("customerId", _
            System.Type.GetType("System.Integer")).AutoIncrement = True
        customersTable.Columns.Add("name", _
            System.Type.GetType("System.String"))
        customersTable.PrimaryKey = New DataColumn() _
            {customersTable.Columns("customerId")}

        ' create Orders table
        Dim ordersTable As DataTable = New DataTable("Orders")
        ordersTable.Columns.Add("orderId", _
            System.Type.GetType("System.Integer")).AutoIncrement = True
        ordersTable.Columns.Add("customerId", _
            System.Type.GetType("System.Integer"))
        ordersTable.Columns.Add("amount", _
            System.Type.GetType("System.Double"))
        ordersTable.PrimaryKey = New DataColumn() _
            {ordersTable.Columns("orderId")}

        dataSet.Tables.AddRange(New DataTable() {customersTable, ordersTable})

        ' remove all tables
        ' check if table can be removed and then
        ' remove it, cannot use a foreach when
        ' removing items from a collection
        Do While (dataSet.Tables.Count > 0)
            Dim table As DataTable = dataSet.Tables(0)
            If (dataSet.Tables.CanRemove(table)) Then
                dataSet.Tables.Remove(table)
            End If
        Loop

	Console.WriteLine("dataSet has {0} tables", dataSet.Tables.Count)
    End Sub
' </Snippet1>
End Module
