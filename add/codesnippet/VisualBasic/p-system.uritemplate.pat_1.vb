        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")

        Dim prefix As Uri = New Uri("http://localhost")

        Console.WriteLine("PathSegmentVariableNames:")
        For Each name As String In template.PathSegmentVariableNames
            Console.WriteLine("     {0}", name)
        Next