    Private Sub CreateOdbcConnection()

        Dim connectionString As String = _
           "Driver={SQL Native Client};Server=(local);Trusted_Connection=Yes;Database=AdventureWorks;"

        Using connection As New OdbcConnection(connectionString)
            With connection
                .Open()
                Console.WriteLine("ServerVersion: " & .ServerVersion _
                   & vbCrLf + "Database: " & .Database)
                .ChangeDatabase("master")
                Console.WriteLine("ServerVersion: " & .ServerVersion _
                   & vbCrLf + "Database: " & .Database)
                Console.ReadLine()
            End With
        End Using
    End Sub