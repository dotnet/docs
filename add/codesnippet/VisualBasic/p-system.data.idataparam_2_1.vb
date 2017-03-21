    Public Sub CreateSqlParameter()
        Dim parameter As New SqlParameter( _
            "@Description", SqlDbType.VarChar)
        parameter.Value = "garden hose"
        parameter.Size = 11
    End Sub 