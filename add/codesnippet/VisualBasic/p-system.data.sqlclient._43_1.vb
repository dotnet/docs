    Private Sub CreateSqlParameterOffset()
        Dim parameter As New SqlParameter("pDName", SqlDbType.VarChar)
        parameter.IsNullable = True
        parameter.Offset = 3
    End Sub