    Sub Main()
        Dim builder As New DbConnectionStringBuilder
        builder.ConnectionString = _
         "Provider=MSDataShape.1;Persist Security Info=False;" & _
         "Data Provider=MSDAORA;Data Source=orac;" & _
         "user id=username;password=*******"

        For Each value As String In builder.Values
            Console.WriteLine(value)
        Next
    End Sub