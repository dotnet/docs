    Public Sub CreateSqlParameter()
        Dim parameter As New SqlParameter( _
            "@Description", SqlDbType.VarChar)
        parameter.IsNullable = True
        parameter.Direction = ParameterDirection.Output
        parameter.SourceColumn = "Description"
    End Sub 