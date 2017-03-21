    Public Sub CreateOleDbParameter()
        Dim parameter As New OleDbParameter( _
            "Description", OleDbType.VarChar, 88, "Description")
        parameter.Direction = ParameterDirection.Output
    End Sub 