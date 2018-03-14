Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Collections.Specialized

Public Class Snippets
    Public Shared Sub Snippet0()
        '<Snippet0>
        '<Snippet1>
        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        '</Snippet1>
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
        '</Snippet0>
    End Sub
    Public Shared Sub Snippet2()
        '<Snippet2>
        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")

        Dim prefix As Uri = New Uri("http://localhost")

        Console.WriteLine("PathSegmentVariableNames:")
        For Each name As String In template.PathSegmentVariableNames
            Console.WriteLine("     {0}", name)
        Next
        '</Snippet2>
    End Sub

    Public Shared Sub Snippet3()
        '<Snippet3>
        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim prefix As Uri = New Uri("http://localhost")

        Console.WriteLine("QueryValueVariableNames:")
        For Each name As String In template.QueryValueVariableNames
            Console.WriteLine("     {0}", name)
        Next
        '</Snippet3>
    End Sub

    Public Shared Sub Snippet4()
        '<Snippet4>
        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim prefix As Uri = New Uri("http://localhost")

        Dim parameters As NameValueCollection = New NameValueCollection()
        parameters.Add("state", "Washington")
        parameters.Add("city", "Redmond")
        parameters.Add("day", "Today")
        Dim namedUri As Uri = template.BindByName(prefix, parameters)
        '</Snippet4>
    End Sub

    Public Shared Sub Snippet5()
        '<Snippet5>
        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim prefix As Uri = New Uri("http://localhost")

        Dim positionalUri As Uri = template.BindByPosition(prefix, "Washington", "Redmond", "Today")
        '</Snippet5>
    End Sub

    Public Shared Sub Snippet6()
        '<Snippet6>
        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Dim template2 As UriTemplate = New UriTemplate("weather/{country}/{village}?forecast={type}")

        Dim equiv As Boolean = template.IsEquivalentTo(template2)
        '</Snippet6>
    End Sub

    Public Shared Sub Snippet7()
        '<Snippet7>
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
        '</Snippet7>
    End Sub

    Public Shared Sub Snippet8()
        '<Snippet8>
        Dim template As UriTemplate = New UriTemplate("weather/{state}/{city}?forecast={day}")
        Console.WriteLine(template.ToString())
        '</Snippet8>
    End Sub
End Class
