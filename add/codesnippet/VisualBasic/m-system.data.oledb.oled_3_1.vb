    Public Sub CreateOleDbParameter()
        Dim parameter As New OleDbParameter()
        parameter.ParameterName = "Description"
        parameter.OleDbType = OleDbType.VarChar
        parameter.Direction = ParameterDirection.Output
        parameter.Size = 88
    End Sub 