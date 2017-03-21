        Dim template As New UriTemplate("weather/ state}/ city}?forecast=today")
        Dim baseAddress As New Uri("http://localhost")
        Dim fullUri As New Uri("http://localhost/weather/WA/Seattle?forecast=today")

        Console.WriteLine("Matching  0} to  1}", template.ToString(), fullUri.ToString())

        'Match a URI to a template
        Dim results As UriTemplateMatch = template.Match(baseAddress, fullUri)
        If (results IsNot Nothing) Then

            Console.WriteLine("RequestUri:")
            Console.WriteLine(results.RequestUri)
        End If
        'Code output:
        'RequestUri:
        'http://localhost/weather/WA/Seattle?forecast=today