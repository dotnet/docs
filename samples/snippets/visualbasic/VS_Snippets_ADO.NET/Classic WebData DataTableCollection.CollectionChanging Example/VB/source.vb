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
    Public Sub TableCollectionCollectionChanging()
        ' Create a DataSet with two tables
        Dim dataSet As DataSet = New DataSet()

        AddHandler dataSet.Tables.CollectionChanging, _
            AddressOf Collection_Changing

        ' Create Customer table
        Dim customersTable As DataTable = New DataTable("Customers")
        customersTable.Columns.Add("customerId", _
            System.Type.GetType("System.Integer")).AutoIncrement = True
        customersTable.Columns.Add("name", _
            System.Type.GetType("System.String"))
        customersTable.PrimaryKey = New DataColumn() _
            {customersTable.Columns("customerId")}

        ' Create Orders table
        Dim ordersTable As DataTable = New DataTable("Orders")
        ordersTable.Columns.Add("orderId", _
            System.Type.GetType("System.Integer")).AutoIncrement = True
        ordersTable.Columns.Add("customerId", _
            System.Type.GetType("System.Integer"))
        ordersTable.Columns.Add("amount", System.Type.GetType("System.Double"))
        ordersTable.PrimaryKey = New DataColumn() {ordersTable.Columns("orderId")}

        ' Add the tables to the DataTableCollection
        dataSet.Tables.AddRange(New DataTable() {customersTable, ordersTable})

        ' Remove all tables
        ' First check to see if the table can be removed and
        ' then remove it.
        '
        ' You cannot use a For Each loop to remove items
        ' from a collection.
        Do While (dataSet.Tables.Count > 0)
            Dim table As DataTable
            table = dataSet.Tables(0)
            If (dataSet.Tables.CanRemove(table)) Then
                dataSet.Tables.RemoveAt(0)
            End If
        Loop

        Console.WriteLine("dataSet has {0} tables", dataSet.Tables.Count)
    End Sub

    Private Sub Collection_Changing(ByVal sender As Object, _
        ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        ' Implementing this event allows you to abort a change
        ' to the collection by raising an exception which you can
        ' catch.
        Console.WriteLine( _
            "Collection_Changing Event: '{0}'\table element={1}", _
            e.Action.ToString(), e.Element.ToString())
    End Sub
    ' </Snippet1>
End Module
