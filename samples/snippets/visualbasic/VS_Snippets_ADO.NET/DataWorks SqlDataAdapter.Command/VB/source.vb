Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

    Sub Main()

    End Sub

    '<Snippet1>
    Public Function CreateCustomerAdapter( _
      ByVal connection As SqlConnection) As SqlDataAdapter

        Dim adapter As SqlDataAdapter = New SqlDataAdapter()

        ' Create the SelectCommand.
        Dim command As SqlCommand = New SqlCommand( _
            "SELECT * FROM Customers " & _
            "WHERE Country = @Country AND City = @City", connection)

        ' Add the parameters for the SelectCommand.
        command.Parameters.Add("@Country", SqlDbType.NVarChar, 15)
        command.Parameters.Add("@City", SqlDbType.NVarChar, 15)

        adapter.SelectCommand = command

        ' Create the InsertCommand.
        command = New SqlCommand( _
            "INSERT INTO Customers (CustomerID, CompanyName) " & _
            "VALUES (@CustomerID, @CompanyName)", connection)

        ' Add the parameters for the InsertCommand.
        command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
        command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName")

        adapter.InsertCommand = command

        ' Create the UpdateCommand.
        command = New SqlCommand( _
            "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " & _
            "WHERE CustomerID = @oldCustomerID", connection)

        ' Add the parameters for the UpdateCommand.
        command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID")
        command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName")
        Dim parameter As SqlParameter = command.Parameters.Add( _
            "@oldCustomerID", SqlDbType.NChar, 5, "CustomerID")
        parameter.SourceVersion = DataRowVersion.Original

        adapter.UpdateCommand = command

        ' Create the DeleteCommand.
        command = New SqlCommand( _
            "DELETE FROM Customers WHERE CustomerID = @CustomerID", connection)

        ' Add the parameters for the DeleteCommand.
        command.Parameters.Add( _
            "@CustomerID", SqlDbType.NChar, 5, "CustomerID")
        parameter.SourceVersion = DataRowVersion.Original

        adapter.DeleteCommand = command

        Return adapter
    End Function
    '</Snippet1>

End Module
