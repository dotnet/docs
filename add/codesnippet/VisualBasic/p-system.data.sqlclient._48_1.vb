    Private Sub CreateSqlParameterSourceColumn()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.SourceColumn = "Description"
    End Sub