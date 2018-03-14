Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class Snippets
    Public Shared Sub Snippet1()

        '<Snippet1>
        Dim template As New UriTemplate("weather/ state}/ city}?forecast=today")
        Dim baseAddress As New Uri("http://localhost")
        Dim fullUri As New Uri("http://localhost/weather/WA/Seattle?forecast=today")

        Console.WriteLine("Matching  0} to  1}", template.ToString(), fullUri.ToString())

        'Match a URI to a template
        Dim results As UriTemplateMatch = template.Match(baseAddress, fullUri)
        If (results IsNot Nothing) Then

            'BaseUri
            Console.WriteLine("BaseUri:  0}", results.BaseUri)
        End If
        'output:
        'BaseUri: http://localhost
        '</Snippet1>
    End Sub

    Public Shared Sub Snippet2()

        '<Snippet2>
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
        '</Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        '<Snippet3>
        Dim prefix As New Uri("http://localhost/")

        ' Create some templates:
        Dim weatherByCity As New UriTemplate("weather/ state}/ city}")
        Dim weatherByState As New UriTemplate("weather/ state}")
        Dim traffic As New UriTemplate("traffic/*")
        Dim wildcard As New UriTemplate("*")

        'Create a template table
        Dim table As UriTemplateTable = New UriTemplateTable(prefix)

        'Add the templates to the template table along with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        'Match a URI to a template
        Dim candidateUri As New Uri("http://localhost/weather/WA/Redmond")
        Dim results As UriTemplateMatch = table.MatchSingle(candidateUri)

        If (results IsNot Nothing) Then

            'Get the data associated with the matching template
            Dim data As String = CType(results.Data, String)
            Console.WriteLine("Matching data is  0}", Data)
        End If
        '</Snippet3>
    End Sub

    Public Shared Sub Snippet4()
        '<Snippet4>
        Dim template As New UriTemplate("weather/ state}/ city}?forecast=today")
        Dim baseAddress As New Uri("http://localhost")
        Dim fullUri As New Uri("http://localhost/weather/WA/Seattle?forecast=today")

        Console.WriteLine("Matching  0} to  1}", template.ToString(), fullUri.ToString())

        'Match a URI to a template
        Dim results As UriTemplateMatch = template.Match(baseAddress, fullUri)
        If (results IsNot Nothing) Then

            Console.WriteLine("QueryParameters:")
            For Each queryName As String In results.QueryParameters.Keys
                Console.WriteLine("     0} :  1}", queryName, results.QueryParameters(queryName))
            Next
            Console.WriteLine()
        End If
        'Code output:
        ' QueryParameters:
        ' forecast : today
        '</Snippet4>
    End Sub

    Public Shared Sub Snippet5()
        '<Snippet5>
        Dim template As New UriTemplate("weather/ state}/ city}?forecast=today")
        Dim baseAddress As New Uri("http://localhost")
        Dim fullUri As New Uri("http://localhost/weather/WA/Seattle?forecast=today")

        Console.WriteLine("Matching  0} to  1}", template.ToString(), fullUri.ToString())

        'Match a URI to a template
        Dim results As UriTemplateMatch = template.Match(baseAddress, fullUri)
        If (results IsNot Nothing) Then

            Console.WriteLine("RelativePathSegments:")
            For Each segment As String In results.RelativePathSegments
                Console.WriteLine("      0}", segment)
            Next
        End If
        'Code output:
        'RelativePathSegments:
        '  weather
        '  wa
        '  seattle
        '</Snippet5>
    End Sub

    Public Shared Sub Snippet6()
        '<Snippet6>
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
        '</Snippet6>
    End Sub

    Public Shared Sub Snippet7()
        '<Snippet7>
        Dim template As New UriTemplate("weather/ state}/ city}?forecast=today")
        Dim baseAddress As New Uri("http://localhost")
        Dim fullUri As New Uri("http://localhost/weather/WA/Seattle?forecast=today")

        Console.WriteLine("Matching  0} to  1}", template.ToString(), fullUri.ToString())

        'Match a URI to a template
        Dim results As UriTemplateMatch = template.Match(baseAddress, fullUri)
        If (results IsNot Nothing) Then
            Console.WriteLine("Template:")
            Console.WriteLine(results.Template)
        End If
        'Code output:
        'Template:
        'weather/ state}/ city}?forecast=today

        '</Snippet7>
    End Sub
End Class
