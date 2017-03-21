    Private Sub CreateSqlParameterVersion()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.Value = "garden hose"
    End Sub