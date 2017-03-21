    Public Sub OpenConnection(ByVal connectionString As String)

        Using connection As New OleDbConnection(connectionString)
            Try
                connection.Open()
                Console.WriteLine("Connection.State: {0}", _
                    connection.State)

                connection.Close()
                OleDbConnection.ReleaseObjectPool()
                Console.WriteLine("Connection.State: {0}", _
                    connection.State)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub