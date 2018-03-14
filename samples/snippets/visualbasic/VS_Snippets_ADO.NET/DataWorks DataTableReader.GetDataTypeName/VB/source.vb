Option Explicit
Option Strict

Imports System
Imports System.Data

    
Module Module1

   Sub Main()
      TestGetTypeName()
   End Sub
' <Snippet1>
   Private Sub TestGetTypeName()
      Dim table As DataTable = GetCustomers()
      Using reader As New DataTableReader(table)
         For i As Integer = 0 To reader.FieldCount - 1
            Console.WriteLine("{0}: {1}", _
               reader.GetName(i), reader.GetDataTypeName(i))
         Next
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
' </Snippet1>
End Module

