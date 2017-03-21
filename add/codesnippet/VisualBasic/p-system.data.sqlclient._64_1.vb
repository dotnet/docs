    Private Sub CreateSqlParameterSourceVersion()
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar, 88)
        parameter.SourceColumn = "Description"
        parameter.SourceVersion = DataRowVersion.Current
    End Sub