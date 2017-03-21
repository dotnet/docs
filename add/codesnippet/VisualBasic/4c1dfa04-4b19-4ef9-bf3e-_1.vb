    Private Sub AddSqlParameter(ByVal command As SqlCommand, _
        ByVal paramValue As String)

        Dim parameter As New SqlParameter("@Description", _
            SqlDbType.VarChar)
        With parameter
            .IsNullable = True
            .Direction = ParameterDirection.Output
            .Size = 88
            .Value = paramValue
        End With

        command.Parameters.Add(parameter)
    End Sub