    Public Function AddPooling(ByVal connectionString As String) As String
        Dim builder As New StringBuilder(connectionString)
        DbConnectionStringBuilder.AppendKeyValuePair(builder, "Pooling", "True")
        Return builder.ToString()
    End Function