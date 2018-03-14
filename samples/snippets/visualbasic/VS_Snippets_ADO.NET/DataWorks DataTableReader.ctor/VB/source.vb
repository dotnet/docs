Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1

   Sub Main()
      TestConstructor()
   End Sub
' <Snippet1>
   Private Sub TestConstructor()
      ' Create two data adapters, one for each of the two
      ' DataTables to be filled.
      Dim customerDataTable As DataTable = GetCustomers()
      Dim productDataTable As DataTable = GetProducts()

      ' Create the new DataTableReader.
      Using reader As New DataTableReader( _
         New DataTable() {customerDataTable, productDataTable})

         ' Print the contents of each of the result sets.
         Do
            PrintColumns(reader)
         Loop While reader.NextResult()
      End Using

      Console.WriteLine("Press Enter to finish.")
      Console.ReadLine()

   End Sub

   Private Function GetCustomers() As DataTable
      ' Create sample Customers table, in order
      ' to demonstrate the behavior of the DataTableReader.
      Dim table As New DataTable

      ' Create two columns, ID and Name.
      Dim idColumn As DataColumn = table.Columns.Add("ID", _
        GetType(Integer))
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
      Dim idColumn As DataColumn = table.Columns.Add("ID", _
        GetType(Integer))
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

