        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Console.WriteLine(template.ToString())