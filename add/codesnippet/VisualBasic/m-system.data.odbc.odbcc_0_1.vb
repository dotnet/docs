    Private Sub CreateOdbcConnection(ByVal connectionString As String)
        Using connection As New OdbcConnection(connectionString)
            With connection
                .Open()
                Console.WriteLine("ServerVersion: " & .ServerVersion _
                   & vbCrLf + "Database: " & .Database)
            End With

            ' The connection is automatically closed
            ' at the end of the Using block.
        End Using 
    End Sub