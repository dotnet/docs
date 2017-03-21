    Public Sub CreateOdbcParameter()
        Dim parameter As New OdbcParameter("Description", OdbcType.VarChar)
        parameter.Direction = ParameterDirection.Output
        parameter.Size = 88
    End Sub 