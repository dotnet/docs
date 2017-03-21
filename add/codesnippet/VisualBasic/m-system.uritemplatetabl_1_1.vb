        Dim prefix As New Uri("http://localhost/")

        ' Create a series of templates
        Dim weatherByCity As New UriTemplate("weather/ state}/ city}")
        Dim weatherByCountry As New UriTemplate("weather/ country}/ village}")
        Dim weatherByState As New UriTemplate("weather/ state}")
        Dim traffic As New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Create a template table
        Dim table As New UriTemplateTable(prefix)
        ' Add each template to the table with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        table.MakeReadOnly(True)

        ' Call MatchSingle to retrieve some match results:
        Dim weatherInSeattle As New Uri("http://localhost/weather/Washington/Seattle")
        Dim match As UriTemplateMatch
        match = table.MatchSingle(weatherInSeattle)

        Console.WriteLine("Matching template: {0}", match.Template.ToString())