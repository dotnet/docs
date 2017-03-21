        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim prefix As Uri = New Uri("http://localhost")

        Dim positionalUri As Uri = template.BindByPosition(prefix, "Washington", "Redmond", "Today")