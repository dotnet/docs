    Public Function GetDataSetFromAdapter( _
        ByVal dataSet As DataSet, ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Using connection As New OleDbConnection(connectionString)
            Dim adapter As New OleDbDataAdapter(queryString, connection)

            ' Set the parameters.
            adapter.SelectCommand.Parameters.Add( _
                "@CategoryName", OleDbType.VarChar, 80).Value = "toasters"
            adapter.SelectCommand.Parameters.Add( _
             "@SerialNum", OleDbType.Integer).Value = 239

            ' Open the connection and fill the DataSet.
            Try
                connection.Open()
                adapter.Fill(dataSet)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
            ' The connection is automatically closed when the
            ' code exits the Using block.
        End Using

        Return dataSet
    End Function