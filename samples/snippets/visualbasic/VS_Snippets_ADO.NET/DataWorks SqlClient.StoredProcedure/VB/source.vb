Imports System.Data
Imports System.Data.SqlClient

Class Program

    '<Snippet1>
    Shared Sub GetSalesByCategory(ByVal connectionString As String, _
        ByVal categoryName As String)

        Using connection As New SqlConnection(connectionString)

            ' Create the command and set its properties.
            Dim command As SqlCommand = New SqlCommand()
            command.Connection = connection
            command.CommandText = "SalesByCategory"
            command.CommandType = CommandType.StoredProcedure

            ' Add the input parameter and set its properties.
            Dim parameter As New SqlParameter()
            parameter.ParameterName = "@CategoryName"
            parameter.SqlDbType = SqlDbType.NVarChar
            parameter.Direction = ParameterDirection.Input
            parameter.Value = categoryName

            ' Add the parameter to the Parameters collection.
            command.Parameters.Add(parameter)

            ' Open the connection and execute the reader.
            connection.Open()
            Using reader As SqlDataReader = command.ExecuteReader()

                If reader.HasRows Then
                    Do While reader.Read()
                        Console.WriteLine("{0}: {1:C}", _
                          reader(0), reader(1))
                    Loop
                Else
                    Console.WriteLine("No rows returned.")
                End If
            End Using
        End Using
    End Sub
    '</Snippet1>

End Class
