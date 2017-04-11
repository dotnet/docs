Option Explicit On
Option Strict On

Imports System
Imports System.Data

Module Module1
    ' <Snippet1>
    Sub Main()
        Dim dataSet As New DataSet

        Dim customerTable As New DataTable
        Dim productTable As New DataTable

        ' This information is cosmetic, only.
        customerTable.TableName = "Customers"
        productTable.TableName = "Products"

        ' Add the tables to the DataSet:
        dataSet.Tables.Add(customerTable)
        dataSet.Tables.Add(productTable)

        ' Load the data into the existing DataSet. 
        Dim reader As DataTableReader = GetReader()
        dataSet.Load(reader, LoadOption.OverwriteChanges, _
            customerTable, productTable)

        ' Print out the contents of each table:
        For Each table As DataTable In dataSet.Tables
            PrintColumns(table)
        Next

        Console.WriteLine("Press any key to continue.")
        Console.ReadKey()
    End Sub

    Private Function GetCustomers() As DataTable
        ' Create sample Customers table.
        Dim table As New DataTable
        table.TableName = "Customers"

        ' Create two columns, ID and Name.
        Dim idColumn As DataColumn = table.Columns.Add("ID", _
            GetType(Integer))
        table.Columns.Add("Name", GetType(String))

        ' Set the ID column as the primary key column.
        table.PrimaryKey = New DataColumn() {idColumn}

        table.Rows.Add(New Object() {0, "Mary"})
        table.Rows.Add(New Object() {1, "Andy"})
        table.Rows.Add(New Object() {2, "Peter"})
        table.AcceptChanges()
        Return table
    End Function

    Private Function GetProducts() As DataTable
        ' Create sample Products table, in order
        ' to demonstrate the behavior of the DataTableReader.
        Dim table As New DataTable
        table.TableName = "Products"

        ' Create two columns, ID and Name.
        Dim idColumn As DataColumn = table.Columns.Add("ID", _
            GetType(Integer))
        table.Columns.Add("Name", GetType(String))

        ' Set the ID column as the primary key column.
        table.PrimaryKey = New DataColumn() {idColumn}

        table.Rows.Add(New Object() {0, "Wireless Network Card"})
        table.Rows.Add(New Object() {1, "Hard Drive"})
        table.Rows.Add(New Object() {2, "Monitor"})
        table.Rows.Add(New Object() {3, "CPU"})
        Return table
    End Function

    Private Function GetReader() As DataTableReader
        ' Return a DataTableReader containing multiple
        ' result sets, just for the sake of this demo.
        Dim dataSet As New DataSet
        dataSet.Tables.Add(GetCustomers())
        dataSet.Tables.Add(GetProducts())
        Return dataSet.CreateDataReader()
    End Function

    Private Sub PrintColumns( _
       ByVal table As DataTable)

        Console.WriteLine()
        Console.WriteLine(table.TableName)
        Console.WriteLine("=========================")
        ' Loop through all the rows in the table.
        For Each row As DataRow In table.Rows
            For Each col As DataColumn In table.Columns
                Console.Write(row(col).ToString() & " ")
            Next
            Console.WriteLine()
        Next
    End Sub
    ' </Snippet1>
End Module
