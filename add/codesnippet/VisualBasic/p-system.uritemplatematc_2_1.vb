        Dim template As New UriTemplate("weather/ state}/ city}?forecast=today")
        Dim baseAddress As New Uri("http://localhost")
        Dim fullUri As New Uri("http://localhost/weather/WA/Seattle?forecast=today")

        Console.WriteLine("Matching  0} to  1}", template.ToString(), fullUri.ToString())

        'Match a URI to a template
        Dim results As UriTemplateMatch = template.Match(baseAddress, fullUri)
        If (results IsNot Nothing) Then

            'BaseUri
            Console.WriteLine("BaseUri:  0}", results.BaseUri)

            Console.WriteLine("BoundVariables:")
            For Each variableName As String In results.BoundVariables.Keys
                Console.WriteLine("     0}:  1}", variableName, results.BoundVariables(variableName))
            Next
        End If
        'Code output:
        'BaseUri: http://localhost/
        'BoundVariables:
        ' state: wa
        ' city: seattleConsole.WriteLine("BaseUri:  0}", results.BaseUri) 