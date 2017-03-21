    Private Sub AddSqlParameter(ByVal command As SqlCommand)

        Dim parameter As New SqlParameter()
        With parameter
            .ParameterName = "@Description"
            .IsNullable = True
            .DbType = DbType.String
            .Direction = ParameterDirection.Output
        End With

        command.Parameters.Add(parameter)
    End Sub