    Public Sub createOracleConnection()
        Using connection As New OracleConnection()
            connection.ConnectionString = _
               "Data Source=Oracle8i;Integrated Security=yes"
            connection.Open()
            Console.WriteLine("Connection State: " & connection.State)
        End Using
    End Sub