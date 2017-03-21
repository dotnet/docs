    Private Sub CreateSqlParameterPrecisionScale()
        Dim parameter As New SqlParameter("Price", SqlDbType.Decimal)
        parameter.Value = 3.1416
        parameter.Precision = 8
        parameter.Scale = 4
    End Sub