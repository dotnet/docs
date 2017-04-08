Option Explicit
Option Strict

Imports System
Imports System.Data

    


Module Module1
  ' <Snippet1>
  Sub Main()
    Dim dataSet As New DataSet
    Dim table As DataTable

    Dim reader As DataTableReader = GetReader()

    ' The tables listed as parameters for the Load method 
    ' should be in the same order as the tables within the IDataReader.
    dataSet.Load(reader, LoadOption.Upsert, "Customers", "Products")
    For Each table In dataSet.Tables
      PrintColumns(table)
    Next

    ' Now try the example with the DataSet
    ' already filled with data:
    dataSet = New DataSet
    dataSet.Tables.Add(GetCustomers())
    dataSet.Tables.Add(GetProducts())

    ' Retrieve a data reader containing changed data:
    reader = GetReader()

    ' Load the data into the existing DataSet. Retrieve the order of the
    ' the data in the reader from the
    ' list of table names in the parameters. If you specify
    ' a new table name here, the Load method will create
    ' a corresponding new table.
    dataSet.Load(reader, LoadOption.Upsert, "NewCustomers", "Products")
    For Each table In dataSet.Tables
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
    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))
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
    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))
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
