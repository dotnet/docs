' <Snippet1>
Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Module Class1

    Sub Main()
        Dim connectionString As String = _
            GetConnectionString()
        ReturnIdentity(connectionString)
        ' Console.ReadLine()
    End Sub


    Private Sub ReturnIdentity(ByVal connectionString As String)
        Using connection As SqlConnection = New SqlConnection( _
           connectionString)

            ' Create a SqlDataAdapter based on a SELECT query.
            Dim adapter As SqlDataAdapter = New SqlDataAdapter( _
               "SELECT CategoryID, CategoryName FROM dbo.Categories", _
               connection)

            ' Create a SqlCommand to execute the stored procedure.
            adapter.InsertCommand = New SqlCommand("dbo.InsertCategory", _
               connection)
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure

            ' Create a parameter for the ReturnValue.
            Dim parameter As SqlParameter = _
               adapter.InsertCommand.Parameters.Add( _
              "@RowCount", SqlDbType.Int)
            parameter.Direction = ParameterDirection.ReturnValue

            ' Create an input parameter for the CategoryName.
            ' You do not need to specify direction for input parameters.
            adapter.InsertCommand.Parameters.Add( _
              "@CategoryName", SqlDbType.NChar, 15, "CategoryName")

            ' Create an output parameter for the new identity value.
            parameter = adapter.InsertCommand.Parameters.Add( _
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

            ' Retrieve the ReturnValue.
            Dim rowCount As Int32 = _
               CInt(adapter.InsertCommand.Parameters("@RowCount").Value)

            Console.WriteLine("ReturnValue: {0}", rowCount.ToString())
            Console.WriteLine("All Rows:")
            Dim row As DataRow
            For Each row In categories.Rows
                Console.WriteLine("  {0}: {1}", row(0), row(1))
            Next
        End Using
    End Sub

    Private Function GetConnectionString() As String
        Throw New NotImplementedException()
    End Function

End Module
' </Snippet1>
