    Public Sub CreateOracleParameter()
        Dim parameter As New OracleParameter("DName", OracleType.VarChar)
        parameter.Direction = ParameterDirection.Output
        parameter.Size = 14
    End Sub 