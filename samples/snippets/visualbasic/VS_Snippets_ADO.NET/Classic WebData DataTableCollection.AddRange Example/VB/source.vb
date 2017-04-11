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
    Public Sub DataTableCollectionAddRange()
        ' create a DataSet with two tables
        Dim dataSet As DataSet = New DataSet()

        ' create Customer table
        Dim customersTable As DataTable = New DataTable("Customers")
        customersTable.Columns.Add("customerId", _
               Type.GetType("System.Int32")).AutoIncrement = True
        customersTable.Columns.Add("name", Type.GetType("System.String"))
        customersTable.PrimaryKey = New DataColumn() _
               {customersTable.Columns("customerId")}

        ' create Orders table
        Dim ordersTable As DataTable = New DataTable("Orders")
        ordersTable.Columns.Add("orderId", _
               Type.GetType("System.Int32")).AutoIncrement = True
        ordersTable.Columns.Add("customerId", _
               Type.GetType("System.Int32"))
        ordersTable.Columns.Add("amount", _
               Type.GetType("System.Double"))
        ordersTable.PrimaryKey = New DataColumn() _
               {ordersTable.Columns("orderId")}

        dataSet.Tables.AddRange(New DataTable() {customersTable, ordersTable})

        ' print the tables and their columns
        Dim table As DataTable
        Dim column As DataColumn
        For Each table In dataSet.Tables
            Console.WriteLine(table.TableName)
            For Each column In table.Columns
                Console.Write("{0}" & vbTab, column.ColumnName)
            Next
            Console.WriteLine()
        Next
    End Sub
    ' </Snippet1>
End Module
