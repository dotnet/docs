    Public Sub CreateOdbcParameter()
        Dim parameter As New OdbcParameter("Description", OdbcType.VarChar, 88)
        parameter.Direction = ParameterDirection.Output
    End Sub 