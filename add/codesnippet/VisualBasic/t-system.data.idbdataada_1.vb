    Public Function SelectRows( _
        ByVal dataSet As DataSet, ByVal connectionString As String, _
        ByVal queryString As String) As DataSet

        Using connection As New SqlConnection(connectionString)
            Dim adapter As New SqlDataAdapter()
            adapter.SelectCommand = New SqlCommand( _
                queryString, connection)
            adapter.Fill(dataSet)
            Return dataSet
        End Using
    End Function