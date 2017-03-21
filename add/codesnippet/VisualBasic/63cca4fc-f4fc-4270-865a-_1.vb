    Private Sub AddSqlParameter(ByVal command As SqlCommand, _
        ByVal paramValue As String)

        Dim parameter As New SqlParameter("@Description", _
            SqlDbType.VarChar, 88)
        With parameter
            .IsNullable = True
            .Direction = ParameterDirection.Output
            .Value = paramValue
        End With

        command.Parameters.Add(parameter)
    End Sub