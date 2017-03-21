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