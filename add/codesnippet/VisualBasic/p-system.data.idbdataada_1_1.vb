    Private Function CreateCustomerAdapter( _
        ByVal connection As OleDbConnection) As OleDbDataAdapter

        Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter()
        Dim command As OleDbCommand
        Dim parameter As OleDbParameter

        ' Create the SelectCommand.
        command = New OleDbCommand("SELECT * FROM dbo.Customers " & _
            "WHERE Country = ? AND City = ?", connection)

        command.Parameters.Add("Country", OleDbType.VarChar, 15)
        command.Parameters.Add("City", OleDbType.VarChar, 15)

        dataAdapter.SelectCommand = command

        ' Create the UpdateCommand.
        command = New OleDbCommand("UPDATE dbo.Customers " & _
            "SET CustomerID = ?, CompanyName = ? " & _
            "WHERE CustomerID = ?", connection)

        command.Parameters.Add( _
            "CustomerID", OleDbType.Char, 5, "CustomerID")
        command.Parameters.Add( _
            "CompanyName", OleDbType.VarChar, 40, "CompanyName")

        parameter = command.Parameters.Add( _
            "oldCustomerID", OleDbType.Char, 5, "CustomerID")
        parameter.SourceVersion = DataRowVersion.Original

        dataAdapter.UpdateCommand = command

        Return dataAdapter
    End Function