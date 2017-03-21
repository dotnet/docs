    Private Sub CreateSqlParameterNullable()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.IsNullable = True
        parameter.Direction = ParameterDirection.Output
    End Sub