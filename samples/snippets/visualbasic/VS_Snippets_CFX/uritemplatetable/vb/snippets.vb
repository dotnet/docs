Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class Snippets
    Public Shared Sub Snippet2()

        '<Snippet2>
        '<Snippet5>
        ' Create a series of templates
        Dim weatherByCity As New UriTemplate("weather/{state}/{city}")
        Dim weatherByCountry As New UriTemplate("weather/{country}/{village}")
        Dim weatherByState As New UriTemplate("weather/{state}")
        Dim traffic As New UriTemplate("traffic/*")
        Dim wildcard As New UriTemplate("*")

        ' Add each template to the table with some associated data
        Dim list As New List(Of KeyValuePair(Of UriTemplate, Object))()
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        'Create a template table
        Dim table As New UriTemplateTable(list)
        table.BaseAddress = New Uri("http://localhost/")
        table.MakeReadOnly(True)
        '</Snippet5>
        '</Snippet2>
    End Sub


    Public Shared Sub Snippet4()
        '<Snippet6>
        '<Snippet4>
        Dim baseAddress As New Uri("http://localhost/")
        ' Create a series of templates
        Dim weatherByCity = New UriTemplate("weather/{state}/{city}")
        Dim weatherByCountry = New UriTemplate("weather/{country}/{village}")
        Dim weatherByState = New UriTemplate("weather/{state}")
        Dim traffic = New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Add each template to the table with some associated data
        Dim list As New List(Of KeyValuePair(Of UriTemplate, Object))()
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        list.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        ' Create a template table
        Dim table As New UriTemplateTable(baseAddress, list)
        table.MakeReadOnly(True)
        '</Snippet4>
        If (table.IsReadOnly) Then
            Console.WriteLine("UriTemplateTable is read only")
        Else
            Console.WriteLine("UriTemplateTable is not read only")
        End If
        '</Snippet6>
    End Sub

    Public Shared Sub Snippet7()
        '<Snippet7>
        Dim prefix As New Uri("http://localhost/")

        ' Create a series of templates
        Dim weatherByCity = New UriTemplate("weather/ state}/ city}")
        Dim weatherByCountry = New UriTemplate("weather/ country}/ village}")
        Dim weatherByState = New UriTemplate("weather/ state}")
        Dim traffic = New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Create a template table
        Dim table As New UriTemplateTable(prefix)
        ' Add each template to the table with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        table.MakeReadOnly(True)

        Console.WriteLine("KeyValuePairs:")
        For Each keyPair As KeyValuePair(Of UriTemplate, Object) In table.KeyValuePairs
            Console.WriteLine("     0},  1}", keyPair.Key, keyPair.Value)
        Next

        Console.WriteLine()
        '</Snippet7>
    End Sub

    Public Shared Sub Snippet9()
        ' <Snippet9>
        Dim prefix As New Uri("http://localhost/")

        ' Create a series of templates
        Dim weatherByCity = New UriTemplate("weather/ state}/ city}")
        Dim weatherByCountry = New UriTemplate("weather/ country}/ village}")
        Dim weatherByState = New UriTemplate("weather/ state}")
        Dim traffic = New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Create a template table
        Dim table As New UriTemplateTable(prefix)
        ' Add each template to the table with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        table.MakeReadOnly(True)

        ' Call Match to retrieve some match results:
        Dim results As ICollection(Of UriTemplateMatch)
        results = Nothing
        Dim weatherInSeattle As New Uri("http://localhost/weather/Washington/Seattle")

        results = table.Match(weatherInSeattle)
        If (results IsNot Nothing) Then

            Console.WriteLine("Matching templates:")
            For Each match As UriTemplateMatch In results
                Console.WriteLine("    0}", match.Template)
            Next
        End If
        '</Snippet9>
    End Sub

    Public Shared Sub Snippet10()
        ' <Snippet10>
        Dim prefix As New Uri("http://localhost/")

        ' Create a series of templates
        Dim weatherByCity As New UriTemplate("weather/ state}/ city}")
        Dim weatherByCountry As New UriTemplate("weather/ country}/ village}")
        Dim weatherByState As New UriTemplate("weather/ state}")
        Dim traffic As New UriTemplate("traffic/*")
        Dim wildcard = New UriTemplate("*")

        ' Create a template table
        Dim table As New UriTemplateTable(prefix)
        ' Add each template to the table with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        table.MakeReadOnly(True)

        ' Call MatchSingle to retrieve some match results:
        Dim weatherInSeattle As New Uri("http://localhost/weather/Washington/Seattle")
        Dim match As UriTemplateMatch
        match = table.MatchSingle(weatherInSeattle)

        Console.WriteLine("Matching template: {0}", match.Template.ToString())
        '</Snippet10>
    End Sub

End Class
