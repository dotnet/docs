        Dim prefix As New Uri("http://localhost/")

        ' Create a series of templates
        Dim weatherByCity = New UriTemplate("weather/ state}/ city}")
        Dim weatherByCountry = New UriTemplate("weather/ country}/ village}")
        Dim weatherByState = New UriTemplate("weather/ state}")
        Dim traffic = New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Create a template table
        Dim table As New UriTemplateTable(prefix)
        ' Add each template to the table with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        table.MakeReadOnly(True)

        Console.WriteLine("KeyValuePairs:")
        For Each keyPair As KeyValuePair(Of UriTemplate, Object) In table.KeyValuePairs
            Console.WriteLine("     0},  1}", keyPair.Key, keyPair.Value)
        Next

        Console.WriteLine()