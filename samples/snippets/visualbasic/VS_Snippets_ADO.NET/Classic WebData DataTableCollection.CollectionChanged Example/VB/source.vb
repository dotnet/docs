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
    Public Sub TableCollectionCollectionChanged()
        ' create a DataSet with two tables
        Dim dataSet As DataSet = New DataSet()

        AddHandler dataSet.Tables.CollectionChanging, _
            AddressOf Collection_Changed

        ' create Customer table
        Dim custTable As DataTable = New DataTable("Customers")
        custTable.Columns.Add("customerId", _
            System.Type.GetType("System.Integer")).AutoIncrement = True
        custTable.Columns.Add("name", System.Type.GetType("System.String"))
        custTable.PrimaryKey = New DataColumn() {custTable.Columns("customerId")}

        ' create Orders table
        Dim orderTable As DataTable = New DataTable("Orders")
        orderTable.Columns.Add("orderId", _
            System.Type.GetType("System.Integer")).AutoIncrement = True
        orderTable.Columns.Add("customerId", System.Type.GetType("System.Integer"))
        orderTable.Columns.Add("amount", System.Type.GetType("System.Double"))
        orderTable.PrimaryKey = New DataColumn() {orderTable.Columns("orderId")}

        dataSet.Tables.AddRange(New DataTable() {custTable, orderTable})

        ' Now remove all tables.
        ' First check to see if the table can be removed,
        ' then remove it from the collection.
        '
        ' You cannot use a For Each loop when
        ' removing items from a collection.
        Do While (dataSet.Tables.Count > 0)
            Dim table As DataTable = dataSet.Tables(0)
            If (dataSet.Tables.CanRemove(table)) Then
                dataSet.Tables.RemoveAt(0)
            End If
        Loop

        Console.WriteLine("dataSet has {0} tables", dataSet.Tables.Count)
    End Sub

    Private Sub Collection_Changed(ByVal sender As Object, _
        ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        Console.WriteLine("Collection_Changed Event: '{0}'\table element={1}", _
            e.Action.ToString(), e.Element.ToString())
    End Sub
    ' </Snippet1>
End Module
