        ' Create a series of templates
        Dim weatherByCity As New UriTemplate("weather/{state}/{city}")
        Dim weatherByCountry As New UriTemplate("weather/{country}/{village}")
        Dim weatherByState As New UriTemplate("weather/{state}")
        Dim traffic As New UriTemplate("traffic/*")
        Dim wildcard As New UriTemplate("*")

        ' Add each template to the table with some associated data
        Dim list As New List(Of KeyValuePair(Of UriTemplate, Object))()
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        'Create a template table
        Dim table As New UriTemplateTable(list)
        table.BaseAddress = New Uri("http://localhost/")
        table.MakeReadOnly(True)