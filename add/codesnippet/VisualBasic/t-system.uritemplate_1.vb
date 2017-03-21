        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim prefix As Uri = New Uri("http://localhost")

        Console.WriteLine("PathSegmentVariableNames:")
        For Each name As String In template.PathSegmentVariableNames
            Console.WriteLine("     {0}", name)
        Next

        Console.WriteLine()
        Console.WriteLine("QueryValueVariableNames:")
        For Each name As String In template.QueryValueVariableNames
            Console.WriteLine("     {0}", name)
        Next
        Console.WriteLine()

        Dim positionalUri As Uri = template.BindByPosition(prefix, "Washington", "Redmond", "Today")

        Dim parameters As NameValueCollection = New NameValueCollection()
        parameters.Add("state", "Washington")
        parameters.Add("city", "Redmond")
        parameters.Add("day", "Today")
        Dim namedUri As Uri = template.BindByName(prefix, parameters)

        Dim fullUri As Uri = New Uri("http://localhost/weather/Washington/Redmond?forecast=today")
        Dim results As UriTemplateMatch = template.Match(prefix, fullUri)

        Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString())

        If results IsNot Nothing Then
            For Each variableName As String In results.BoundVariables.Keys
                Console.WriteLine("   {0}: {1}", variableName, results.BoundVariables(variableName))
            Next
        End If