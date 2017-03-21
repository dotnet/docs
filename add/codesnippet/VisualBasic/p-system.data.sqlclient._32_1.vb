    Private Sub UpdateDemographics(ByVal customerID As Integer, _
        ByVal demoXml As String, _
        ByVal connectionString As String)

        ' Update the demographics for a store, which is stored 
        ' in an xml column.
        Dim commandText As String = _
         "UPDATE Sales.Store SET Demographics = @demographics " _
         & "WHERE CustomerID = @ID;"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(commandText, connection)

            ' Add CustomerID parameter for WHERE clause.
            command.Parameters.Add("@ID", SqlDbType.Int)
            command.Parameters("@ID").Value = customerID

            ' Use AddWithValue to assign Demographics.
            ' SQL Server will implicitly convert strings into XML.
            command.Parameters.AddWithValue("@demographics", demoXml)

            Try
                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                Console.WriteLine("RowsAffected: {0}", rowsAffected)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
    End Sub