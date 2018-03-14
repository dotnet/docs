Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Public Function CreateDataAdapter( _
        ByVal connection As OleDbConnection) As OleDbDataAdapter

        Dim selectCommand As String = _
            "SELECT CustomerID, CompanyName FROM Customers"
        Dim adapter As OleDbDataAdapter = _
            New OleDbDataAdapter(selectCommand, connection)

        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

        ' Create the commands.
        adapter.InsertCommand = New OleDbCommand( _
            "INSERT INTO Customers (CustomerID, CompanyName) " & _
             "VALUES (?, ?)")

        adapter.UpdateCommand = New OleDbCommand( _
            "UPDATE Customers SET CustomerID = ?, CompanyName = ? " & _
            "WHERE CustomerID = ?")

        adapter.DeleteCommand = New OleDbCommand( _
            "DELETE FROM Customers WHERE CustomerID = ?")

        ' Create the parameters.
        adapter.InsertCommand.Parameters.Add( _
            "@CustomerID", OleDbType.Char, 5, "CustomerID")
        adapter.InsertCommand.Parameters.Add( _
            "@CompanyName", OleDbType.VarChar, 40, "CompanyName")

        adapter.UpdateCommand.Parameters.Add( _
            "@CustomerID", OleDbType.Char, 5, "CustomerID")
        adapter.UpdateCommand.Parameters.Add( _
            "@CompanyName", OleDbType.VarChar, 40, "CompanyName")
        adapter.UpdateCommand.Parameters.Add( _
            "@oldCustomerID", OleDbType.Char, 5, "CustomerID").SourceVersion = _
            DataRowVersion.Original

        adapter.DeleteCommand.Parameters.Add( _
            "@CustomerID", OleDbType.Char, 5, "CustomerID").SourceVersion = _
            DataRowVersion.Original

        Return adapter
    End Function
    ' </Snippet1>
End Module
