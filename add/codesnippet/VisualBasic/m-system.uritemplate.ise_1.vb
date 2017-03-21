        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim template2 As UriTemplate = New UriTemplate("weather/{country}/{village}?forecast={type}")

        Dim equiv As Boolean = template.IsEquivalentTo(template2)