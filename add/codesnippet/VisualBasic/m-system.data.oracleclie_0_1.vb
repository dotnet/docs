    Public Sub CreateOracleConnection()
        Dim connectionString As String = _
           "Data Source=Oracle8i;Integrated Security=yes"

        Using connection As New OracleConnection(connectionString)
            connection.Open()
            Console.WriteLine("ServerVersion: " + connection.ServerVersion _
               + ControlChars.NewLine + "DataSource: " + connection.DataSource)
        End Using
    End Sub