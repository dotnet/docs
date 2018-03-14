Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1
   Sub Main()
      TestGetSchemaTable()
   End Sub
' <Snippet1>
   Private Sub TestGetSchemaTable()
      ' Set up the data adapter, using information from 
      ' the AdventureWorks sample database.
      ' Modify the SQL expression to retrieve 
      ' data from a different table.
      Dim adapter As SqlDataAdapter = _
         SetupDataAdapter("SELECT * FROM Sales.Customer")

      ' Fill the DataTable, retrieving all the schema information.
      adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
      Dim table As New DataTable
      adapter.Fill(table)

      ' Create the DataTableReader, and close it when done.
      Using reader As New DataTableReader(table)
         ' Modify the column number to display information
         ' about a column other than column 0.
         DisplaySchemaTableInfo(reader, 0)
      End Using

      Console.WriteLine()
      Console.WriteLine("Press Enter to finish.")
      Console.ReadLine()
   End Sub

   Private Sub DisplaySchemaTableInfo( _
      ByVal reader As DataTableReader, ByVal ordinal As Integer)

      ' Given a DataTableReader, display schema
      ' information about a particular column.
      Try
         Dim schemaTable As DataTable = reader.GetSchemaTable()
         Dim row As DataRow = schemaTable.Rows(ordinal)
         For Each col As DataColumn In schemaTable.Columns
            Console.WriteLine("{0}: {1}", _
               col.ColumnName, row(col.Ordinal))
         Next
      Catch ex As IndexOutOfRangeException
         Console.WriteLine("{0} is an invalid column number.", _
            ordinal)
      End Try
   End Sub

   Private Function SetupDataAdapter( _
      ByVal sqlString As String) As SqlDataAdapter
      ' Assuming all the default settings, create a SqlDataAdapter
      ' working with the AdventureWorks sample database that's 
      ' available with SQL Server.
      Dim connectionString As String = _
         "Data Source=(local);" & _
         "Initial Catalog=AdventureWorks;" & _
         "Integrated Security=true"
      Return New SqlDataAdapter(sqlString, connectionString)
   End Function
' </Snippet1>
End Module

