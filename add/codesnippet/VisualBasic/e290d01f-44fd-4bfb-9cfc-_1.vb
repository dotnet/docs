    Public Sub CreateOracleParameter()
        Dim parameter As New OracleParameter("DName", OracleType.VarChar, 14)
        parameter.Direction = ParameterDirection.Output
    End Sub 