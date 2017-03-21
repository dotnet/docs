    Public Sub CreateSqlParameter()
        Dim parameter As New SqlParameter( _
            "@Description", SqlDbType.VarChar)
        parameter.IsNullable = True
        parameter.SourceColumn = "Description"
        parameter.SourceVersion = DataRowVersion.Current
        parameter.Direction = ParameterDirection.Output
    End Sub 