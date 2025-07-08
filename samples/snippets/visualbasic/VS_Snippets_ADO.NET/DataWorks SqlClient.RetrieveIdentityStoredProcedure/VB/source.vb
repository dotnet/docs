Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Class1

    Sub Main()
        Dim connectionString As String = _
            GetConnectionString()
        RetrieveIdentity(connectionString)
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub RetrieveIdentity(ByVal connectionString As String)
        Using connection As SqlConnection = New SqlConnection( _
           connectionString)

            ' Create a SqlDataAdapter based on a SELECT query.
            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
               "SELECT CategoryID, CategoryName FROM dbo.Categories", _
               connection)

            ' Create the SqlCommand to execute the stored procedure.
            adapter.InsertCommand = New SqlCommand("dbo.InsertCategory", _
               connection)
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure

            ' Add the parameter for the CategoryName. Specifying the
            ' ParameterDirection for an input parameter is not required.
            adapter.InsertCommand.Parameters.Add( _
              "@CategoryName", SqlDbType.NVarChar, 15, "CategoryName")

            ' Add the SqlParameter to retrieve the new identity value.
            ' Specify the ParameterDirection as Output.
            Dim parameter As SqlParameter = _
               adapter.InsertCommand.Parameters.Add( _
              "@Identity", SqlDbType.Int, 0, "CategoryID")
            parameter.Direction = ParameterDirection.Output

            ' Create a DataTable and fill it.
            Dim categories As DataTable = New DataTable
            adapter.Fill(categories)

            ' Add a new row.
            Dim newRow As DataRow = categories.NewRow()
            newRow("CategoryName") = "New Category"
            categories.Rows.Add(newRow)

            ' Update the database.
            adapter.Update(categories)

            Console.WriteLine("List All Rows:")
            Dim row As DataRow
            For Each row In categories.Rows
                Console.WriteLine("{0}: {1}", row(0), row(1))
            Next
        End Using
    End Sub
    ' </Snippet1>

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
