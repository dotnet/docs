        Dim prefix As New Uri("http://localhost/")

        ' Create some templates:
        Dim weatherByCity As New UriTemplate("weather/ state}/ city}")
        Dim weatherByState As New UriTemplate("weather/ state}")
        Dim traffic As New UriTemplate("traffic/*")
        Dim wildcard As New UriTemplate("*")

        'Create a template table
        Dim table As UriTemplateTable = New UriTemplateTable(prefix)

        'Add the templates to the template table along with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        'Match a URI to a template
        Dim candidateUri As New Uri("http://localhost/weather/WA/Redmond")
        Dim results As UriTemplateMatch = table.MatchSingle(candidateUri)

        If (results IsNot Nothing) Then

            'Get the data associated with the matching template
            Dim data As String = CType(results.Data, String)
            Console.WriteLine("Matching data is  0}", Data)
        End If