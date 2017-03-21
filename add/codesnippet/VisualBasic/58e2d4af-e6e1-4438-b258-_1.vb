        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim prefix As Uri = New Uri("http://localhost")

        Dim parameters As NameValueCollection = New NameValueCollection()
        parameters.Add("state", "Washington")
        parameters.Add("city", "Redmond")
        parameters.Add("day", "Today")
        Dim namedUri As Uri = template.BindByName(prefix, parameters)