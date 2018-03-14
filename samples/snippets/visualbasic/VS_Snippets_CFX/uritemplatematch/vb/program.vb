Imports System
Imports System.Collections.Generic
Imports System.Text

Module Program

    Sub Main()
        '<Snippet0>
        Dim template As New UriTemplate("weather/{state}/{city}?forecast=today")
        Dim baseAddress As New Uri("http://localhost")
        Dim fullUri As New Uri("http://localhost/weather/WA/Seattle?forecast=today")

        Console.WriteLine("Matching {0} to {1}", template.ToString(), fullUri.ToString())

        'Match a URI to a template
        Dim results As UriTemplateMatch = template.Match(baseAddress, fullUri)
        If (results IsNot Nothing) Then

            'BaseUri
            Console.WriteLine("BaseUri: {0}", results.BaseUri)

            Console.WriteLine("BoundVariables:")
            For Each variableName As String In results.BoundVariables.Keys
                Console.WriteLine("    {0}: {1}", variableName, results.BoundVariables(variableName))
            Next

            Console.WriteLine("QueryParameters:")
            For Each queryName As String In results.QueryParameters.Keys
                Console.WriteLine("    {0} : {1}", queryName, results.QueryParameters(queryName))
            Next
            Console.WriteLine()

            Console.WriteLine("RelativePathSegments:")
            For Each segment As String In results.RelativePathSegments
                Console.WriteLine("     {0}", segment)
            Next
            Console.WriteLine()

            Console.WriteLine("RequestUri:")
            Console.WriteLine(results.RequestUri)

            Console.WriteLine("Template:")
            Console.WriteLine(results.Template)

            Console.WriteLine("WildcardPathSegments:")
            For Each segment As String In results.WildcardPathSegments
                Console.WriteLine("     {0}", segment)
            Next
            Console.WriteLine()
        End If
        '</Snippet0>

    End Sub

End Module
