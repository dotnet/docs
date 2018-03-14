Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()

    End Sub

    ' <Snippet1>
    Public Function CreateSqlDataAdapter(ByVal commandText As String, _
        ByVal connection As SqlConnection) As SqlDataAdapter

        Dim adapter As SqlDataAdapter = New SqlDataAdapter(commandText, connection)

        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ' Create the commands.
        adapter.InsertCommand = New SqlCommand( _
            "INSERT INTO Customers (CustomerID, CompanyName) " & _
             "VALUES (@CustomerID, @CompanyName)")

        adapter.UpdateCommand = New SqlCommand( _
            "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " & _
            "WHERE CustomerID = @oldCustomerID")

        adapter.DeleteCommand = New SqlCommand( _
            "DELETE FROM Customers WHERE CustomerID = @CustomerID")

        ' Create the parameters.
        adapter.InsertCommand.Parameters.Add("@CustomerID", _
            SqlDbType.Char, 5, "CustomerID")
        adapter.InsertCommand.Parameters.Add("@CompanyName", _
            SqlDbType.VarChar, 40, "CompanyName")

        adapter.UpdateCommand.Parameters.Add("@CustomerID", _
            SqlDbType.Char, 5, "CustomerID")
        adapter.UpdateCommand.Parameters.Add("@CompanyName", _
            SqlDbType.VarChar, 40, "CompanyName")
        adapter.UpdateCommand.Parameters.Add("@oldCustomerID", _
            SqlDbType.Char, 5, "CustomerID").SourceVersion = DataRowVersion.Original

        adapter.DeleteCommand.Parameters.Add("@CustomerID", _
            SqlDbType.Char, 5, "CustomerID").SourceVersion = DataRowVersion.Original

        Return adapter
    End Function
    ' </Snippet1>
End Module
