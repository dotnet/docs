    Public Sub CreateOleDbParameter()
        Dim parameter As New OleDbParameter("Description", OleDbType.VarChar, 88)
        parameter.Direction = ParameterDirection.Output
    End Sub 