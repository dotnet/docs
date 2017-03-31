Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.Odbc

Module Module1

    Sub Main()
        'Dim connectionString As String = _
        '"Driver={Microsoft Access Driver (*.mdb)};DBQ=C:\Samples\Northwind.mdb"
        'dim x as String="DRIVER={SQL Server};SERVER=MyServer;Trusted_connection=yes;DATABASE=Northwind;"
    End Sub

    ' <Snippet1>
    Public Function CreateDataAdapter( _
        ByVal connection As OdbcConnection) As OdbcDataAdapter

        Dim selectCommand As String = _
            "SELECT CustomerID, CompanyName FROM Customers"
        Dim adapter As OdbcDataAdapter = _
            New OdbcDataAdapter(selectCommand, connection)

        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ' Create the Insert, Update and Delete commands.
        adapter.InsertCommand = New OdbcCommand( _
            "INSERT INTO Customers (CustomerID, CompanyName) " & _
             "VALUES (?, ?)")

        adapter.UpdateCommand = New OdbcCommand( _
            "UPDATE Customers SET CustomerID = ?, CompanyName = ? " & _
            "WHERE CustomerID = ?")

        adapter.DeleteCommand = New OdbcCommand( _
            "DELETE FROM Customers WHERE CustomerID = ?")

        ' Create the parameters.
        adapter.InsertCommand.Parameters.Add( _
            "@CustomerID", OdbcType.Char, 5, "CustomerID")
        adapter.InsertCommand.Parameters.Add( _
            "@CompanyName", OdbcType.VarChar, 40, "CompanyName")

        adapter.UpdateCommand.Parameters.Add( _
            "@CustomerID", OdbcType.Char, 5, "CustomerID")
        adapter.UpdateCommand.Parameters.Add( _
            "@CompanyName", OdbcType.VarChar, 40, "CompanyName")
        adapter.UpdateCommand.Parameters.Add( _
            "@oldCustomerID", OdbcType.Char, 5, "CustomerID").SourceVersion = _
            DataRowVersion.Original

        adapter.DeleteCommand.Parameters.Add( _
            "@CustomerID", OdbcType.Char, 5, "CustomerID").SourceVersion = _
            DataRowVersion.Original

        Return adapter
    End Function
    ' </Snippet1>
End Module
