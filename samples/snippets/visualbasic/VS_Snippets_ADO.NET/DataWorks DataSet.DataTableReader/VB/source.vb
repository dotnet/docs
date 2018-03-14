Option Explicit
Option Strict



Imports System.Data

Module Module1
' <Snippet1>
  Sub Main()
    Dim dataSet As New DataSet
    ' Add some DataTables to the DataSet, including
    ' an empty DataTable:
    dataSet.Tables.Add(GetCustomers())
    dataSet.Tables.Add(New DataTable())
    dataSet.Tables.Add(GetProducts())
    TestCreateDataReader(dataSet)

    Console.WriteLine("Press any key to continue.")
    Console.ReadKey()
  End Sub

  Private Sub TestCreateDataReader(ByVal dataSet As DataSet)
    ' Given a DataSet, retrieve a DataTableReader
    ' allowing access to all the DataSet's data:
    Using reader As DataTableReader = dataSet.CreateDataReader()
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


