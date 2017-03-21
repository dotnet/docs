    Public Sub CreateOleDbParameter()
        Dim parameter As New OleDbParameter("Description", OleDbType.VarChar)
        parameter.Direction = ParameterDirection.Output
        parameter.Size = 88
    End Sub 