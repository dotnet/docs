    Private Sub AddSqlParameter(ByVal command As SqlCommand)

        Dim parameter As New SqlParameter()
        With parameter
            .ParameterName = "@Description"
            .IsNullable = True
            .SqlDbType = SqlDbType.VarChar
            .Direction = ParameterDirection.Output
            .Size = 88
        End With

        command.Parameters.Add(parameter)
    End Sub