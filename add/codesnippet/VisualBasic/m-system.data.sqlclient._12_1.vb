    Private Sub AddSqlParameter(ByVal command As SqlCommand)

        Dim parameter As New SqlParameter("@Description", _
            SqlDbType.VarChar, 88, "Description")
        With parameter
            .IsNullable = True
            .Direction = ParameterDirection.Output
        End With

        command.Parameters.Add(parameter)
    End Sub