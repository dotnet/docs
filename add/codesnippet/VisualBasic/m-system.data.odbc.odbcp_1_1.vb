    Public Sub CreateOdbcParameter()
        Dim parameter As New OdbcParameter()
        parameter.ParameterName = "Description"
        parameter.OdbcType = OdbcType.VarChar
        parameter.Direction = ParameterDirection.Output
        parameter.Size = 88
    End Sub 