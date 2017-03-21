        Dim baseAddress As New Uri("http://localhost/")
        ' Create a series of templates
        Dim weatherByCity = New UriTemplate("weather/{state}/{city}")
        Dim weatherByCountry = New UriTemplate("weather/{country}/{village}")
        Dim weatherByState = New UriTemplate("weather/{state}")
        Dim traffic = New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Add each template to the table with some associated data
        Dim list As New List(Of KeyValuePair(Of UriTemplate, Object))()
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        ' Create a template table
        Dim table As New UriTemplateTable(baseAddress, list)
        table.MakeReadOnly(True)