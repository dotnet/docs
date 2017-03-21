    Public Sub CreateOracleParameter()
        Dim parameter As New OracleParameter("DName", OracleType.VarChar, 14, "DName")
        parameter.Direction = ParameterDirection.Output
    End Sub 