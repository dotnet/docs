Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Sub DataTableCollectionRemoveAt()
        ' Create a DataSet with two tables and then
        ' remove the tables from the collection using RemoveAt.
        Dim dataSet As DataSet = New DataSet()

        ' Create Customer table.
        Dim customerTable As DataTable = New DataTable("Customers")
        customerTable.Columns.Add("customerId", _
            GetType(Integer)).AutoIncrement = True
        customerTable.Columns.Add("name", GetType(String))
        customerTable.PrimaryKey = New DataColumn() _
            {customerTable.Columns("customerId")}

        ' Create Orders table.
        Dim ordersTable As DataTable = New DataTable("Orders")
        ordersTable.Columns.Add("orderId", _
            GetType(Integer)).AutoIncrement = True
        ordersTable.Columns.Add("customerId", GetType(Integer))
        ordersTable.Columns.Add("amount", GetType(Double))
        ordersTable.PrimaryKey = New DataColumn() _
            {ordersTable.Columns("orderId")}

        dataSet.Tables.AddRange(New DataTable() _
            {customerTable, ordersTable})

        ' Remove all tables.
        ' First check to see if the table can be removed,
        ' then remove it.
        '
        ' You cannot use a foreach when removing items
        ' from a collection.
        Do While (dataSet.Tables.Count > 0)
            Dim table As DataTable = dataSet.Tables(0)
            If (dataSet.Tables.CanRemove(table)) Then
                dataSet.Tables.RemoveAt(0)
            End If
            Console.WriteLine("dataSet has {0} tables", _
                dataSet.Tables.Count)
        Loop
    End Sub
    ' </Snippet1>
End Module
