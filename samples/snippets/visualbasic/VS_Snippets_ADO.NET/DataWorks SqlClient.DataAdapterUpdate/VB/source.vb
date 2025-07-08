Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Class1

    Sub Main()
        Dim connectionString As String = _
            GetConnectionString()
        AdapterUpdate(connectionString)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub AdapterUpdate(ByVal connectionString As String)

        Using connection As SqlConnection = New SqlConnection( _
           connectionString)

            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
              "SELECT CategoryID, CategoryName FROM dbo.Categories", _
              connection)

            adapter.UpdateCommand = New SqlCommand( _
              "UPDATE Categories SET CategoryName = @CategoryName " & _
               "WHERE CategoryID = @CategoryID", connection)

            adapter.UpdateCommand.Parameters.Add( _
               "@CategoryName", SqlDbType.NVarChar, 15, "CategoryName")

            Dim parameter As SqlParameter = _
               adapter.UpdateCommand.Parameters.Add( _
               "@CategoryID", SqlDbType.Int)
            parameter.SourceColumn = "CategoryID"
            parameter.SourceVersion = DataRowVersion.Original

            Dim categoryTable As New DataTable
            adapter.Fill(categoryTable)

            Dim categoryRow As DataRow = categoryTable.Rows(0)
            categoryRow("CategoryName") = "New Beverages"

            adapter.Update(categoryTable)

            Console.WriteLine("Rows after update.")
            Dim row As DataRow
            For Each row In categoryTable.Rows
                Console.WriteLine("{0}: {1}", row(0), row(1))
            Next
        End Using
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
