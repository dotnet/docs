    Public Sub CreateOracleParameter()
        Dim parameter As New OracleParameter( _
            "DName", OracleType.VarChar, 11, _
            ParameterDirection.Output, True, 0, 0, _
            "DName", DataRowVersion.Current, "ENGINEERING")
        Console.WriteLine(parameter.ToString())
    End Sub 