Imports System
Imports System.Collections.Generic
Imports System.Text
Module Program1

    Sub Main()
        ' <Snippet0>
        ' <Snippet1>
        ' <Snippet3>
        Dim prefix As New Uri("http://localhost/")

        ' Create a series of templates
        Dim weatherByCity As New UriTemplate("weather/ state}/ city}")
        Dim weatherByCountry As New UriTemplate("weather/ country}/ village}")
        Dim weatherByState As New UriTemplate("weather/ state}")
        Dim traffic As New UriTemplate("traffic/*")
        Dim wildcard As New UriTemplate("*")

        ' Create a template table
        Dim table As New UriTemplateTable(prefix)
        ' Add each template to the table with some associated data
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCity, "weatherByCity"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByCountry, "weatherByCountry"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(weatherByState, "weatherByState"))
        table.KeyValuePairs.Add(New KeyValuePair(Of UriTemplate, Object)(traffic, "traffic"))

        table.MakeReadOnly(True)
        '</Snippet3>
        '</Snippet1>
        Console.WriteLine("KeyValuePairs:")
        For Each keyPair As KeyValuePair(Of UriTemplate, Object) In table.KeyValuePairs
            Console.WriteLine("     0},  1}", keyPair.Key, keyPair.Value)
        Next

        Console.WriteLine()

        ' Call MatchSingle to retrieve some match results:
        Dim results As System.Collections.Generic.ICollection(Of UriTemplateMatch) = Nothing
        Dim weatherInSeattle As Uri = New Uri("http://localhost/weather/Washington/Seattle")

        results = table.Match(weatherInSeattle)
        If results IsNot Nothing Then
            Console.WriteLine("Matching templates:")
            For Each match As UriTemplateMatch In results
                Console.WriteLine("    0}", match.Template)
            Next
        End If

        '</Snippet0>
    End Sub

End Module
