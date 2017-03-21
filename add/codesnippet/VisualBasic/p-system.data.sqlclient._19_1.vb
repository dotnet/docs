    Private Sub CreateSqlParameterSize()
        Dim description As String = "12 foot scarf - multiple colors, one previous owner"
        Dim parameter As New SqlParameter("Description", SqlDbType.VarChar)
        parameter.Direction = ParameterDirection.InputOutput
        parameter.Size = description.Length
        parameter.Value = description
    End Sub