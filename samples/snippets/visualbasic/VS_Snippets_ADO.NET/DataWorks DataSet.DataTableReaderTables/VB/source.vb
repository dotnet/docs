Option Explicit
Option Strict

Imports System
Imports System.Data

    


Module Module1
' <Snippet1>
  Private emptyTable As DataTable
  Private customerTable As DataTable
  Private productTable As DataTable

  Sub Main()
    Dim dataSet As New DataSet
    ' Add some DataTables to the DataSet, including
    ' an empty DataTable:

    emptyTable = New DataTable()
    productTable = GetProducts()
    customerTable = GetCustomers()

    dataSet.Tables.Add(customerTable)
    dataSet.Tables.Add(emptyTable)
    dataSet.Tables.Add(productTable)
    TestCreateDataReader(dataSet)

    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub

  Private Sub TestCreateDataReader(ByVal dataSet As DataSet)
    ' Given a DataSet, retrieve a DataTableReader
    ' allowing access to all the DataSet's data.
    ' Even though the dataset contains three DataTables,
    ' this code will only display the contents of two of them,
    ' because the code has limited the results to the 
    ' DataTables stored in the tables array. Because this
    ' parameter is declared using the ParamArray keyword, 
    ' you could also include a list of DataTable instances 
    ' individually, as opposed to supplying an array of 
    ' DataTables, as in this example:
    Using reader As DataTableReader = _
      dataSet.CreateDataReader(productTable, emptyTable)
      Do
        If Not reader.HasRows Then
          Console.WriteLine("Empty DataTableReader")
        Else
          PrintColumns(reader)
        End If
        Console.WriteLine("========================")
      Loop While reader.NextResult()
    End Using
  End Sub

  Private Function GetCustomers() As DataTable
    ' Create sample Customers table, in order
    ' to demonstrate the behavior of the DataTableReader.
    Dim table As New DataTable

    ' Create two columns, ID and Name.
    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))
    table.Columns.Add("Name", GetType(String))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {1, "Mary"})
    table.Rows.Add(New Object() {2, "Andy"})
    table.Rows.Add(New Object() {3, "Peter"})
    table.Rows.Add(New Object() {4, "Russ"})
    Return table
  End Function

  Private Function GetProducts() As DataTable
    ' Create sample Products table, in order
    ' to demonstrate the behavior of the DataTableReader.
    Dim table As New DataTable

    ' Create two columns, ID and Name.
    Dim idColumn As DataColumn = table.Columns.Add("ID", GetType(Integer))
    table.Columns.Add("Name", GetType(String))

    ' Set the ID column as the primary key column.
    table.PrimaryKey = New DataColumn() {idColumn}

    table.Rows.Add(New Object() {1, "Wireless Network Card"})
    table.Rows.Add(New Object() {2, "Hard Drive"})
    table.Rows.Add(New Object() {3, "Monitor"})
    table.Rows.Add(New Object() {4, "CPU"})
    Return table
  End Function

  Private Sub PrintColumns( _
     ByVal reader As DataTableReader)

    ' Loop through all the rows in the DataTableReader.
    Do While reader.Read()
      For i As Integer = 0 To reader.FieldCount - 1
        Console.Write(reader(i).ToString() & " ")
      Next
      Console.WriteLine()
    Loop
  End Sub
' </Snippet1>
End Module
