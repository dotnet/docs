    Public Sub ShowSqlException(ByVal connectionString As String)
        Dim queryString As String = "EXECUTE NonExistantStoredProcedure"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)

            Try
                command.Connection.Open()
                command.ExecuteNonQuery()

            Catch ex As SqlException
                DisplaySqlErrors(ex)
            End Try
        End Using
    End Sub

    Private Sub DisplaySqlErrors(ByVal exception As SqlException)
        Dim i As Integer

        For i = 0 To exception.Errors.Count - 1
            Console.WriteLine("Index #" & i & ControlChars.NewLine & _
                "Error: " & exception.Errors(i).ToString() & ControlChars.NewLine)
        Next i
        Console.ReadLine()
    End Sub