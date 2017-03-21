        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim prefix As Uri = New Uri("http://localhost")

        Dim fullUri As Uri = New Uri("http://localhost/weather/Washington/Redmond?forecast=today")
        Dim results As UriTemplateMatch = template.Match(prefix, fullUri)

        Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString())

        If results IsNot Nothing Then
            For Each variableName As String In results.BoundVariables.Keys
                Console.WriteLine("   {0}: {1}", variableName, results.BoundVariables(variableName))
            Next
        End If