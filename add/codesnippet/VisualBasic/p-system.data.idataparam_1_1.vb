    Public Sub CreateSqlParameter()
        Dim parameter As New SqlParameter( _
            "@Description", SqlDbType.VarChar)
        parameter.Direction = ParameterDirection.Output
    End Sub 