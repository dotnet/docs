 Public Sub CreateOdbcConnection(connectionString As String)
        Using connection As New OdbcConnection(connectionString)
            With connection
                .Open()
                Console.WriteLine("ServerVersion: " & .ServerVersion _
                   & vbCrLf + "Database: " & .Database)
            End With
        End Using 
 End Sub