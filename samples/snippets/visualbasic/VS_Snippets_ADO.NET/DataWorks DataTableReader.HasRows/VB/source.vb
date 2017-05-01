Option Explicit
Option Strict

Imports System.Data

Module Module1
   Sub Main()
      TestHasRows()
   End Sub
' <Snippet1>
   Private Sub TestHasRows()
      'Retrieve one row from the Store table:
      Dim customerTable As DataTable = GetCustomers()
      Dim productsTable As DataTable = GetProducts()

      Using reader As New DataTableReader( _
         New DataTable() {customerTable, productsTable})

         Do
            If reader.HasRows Then
               PrintData(reader)
            End If
         Loop While reader.NextResult()
      End Using

      Console.WriteLine("Press Enter to finish.")
      Console.ReadLine()
   End Sub

   Private Sub PrintData( _
      ByVal reader As DataTableReader)

      ' Loop through all the rows in the DataTableReader.
      Do While reader.Read()
         For i As Integer = 0 To reader.FieldCount - 1
            Console.Write("{0} ", reader(i))
         Next
         Console.WriteLine()
      Loop
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

      Return table
   End Function
' </Snippet1>
End Module


