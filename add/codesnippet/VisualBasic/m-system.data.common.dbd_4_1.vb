    Public Function CreateCmdsAndUpdate(ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Using connection As New OleDbConnection(connectionString)
            Dim adapter As New OleDbDataAdapter()
            adapter.SelectCommand = New OleDbCommand(queryString, connection)
            Dim builder As OleDbCommandBuilder = New OleDbCommandBuilder(adapter)

            connection.Open()

            Dim customers As DataSet = New DataSet
            adapter.Fill(customers)

            ' Code to modify data in DataSet here 

            adapter.Update(customers)

            Return customers
        End Using
    End Function