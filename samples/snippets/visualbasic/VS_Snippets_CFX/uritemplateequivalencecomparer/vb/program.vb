
Imports System
Imports System.Collections.Generic
Imports System.Text

Module program
    Sub Main()
        '<Snippet0>
        'Define two structurally equivalent templates
        Dim temp1 As UriTemplate = New UriTemplate("weather/{state}/{city}")
        Dim temp2 As UriTemplate = New UriTemplate("weather/{country}/{village}")

        'Notice they are not reference equal, in other words
        'they are do not refer to the same object
        If temp1.Equals(temp2) Then
            Console.WriteLine("{0} and {1} are reference equal", temp1, temp2)
        Else
            Console.WriteLine("{0} and {1} are NOT reference equal", temp1, temp2)
        End If

        'Notice they are structrually equal
        If (temp1.IsEquivalentTo(temp2)) Then
            Console.WriteLine("{0} and {1} are structurally equal", temp1, temp2)
        Else
            Console.WriteLine("{0} and {1} are NOT structurally equal", temp1, temp2)
        End If

        '<Snippet1>
        'Create a dictionary and use UriTemplateEquivalenceComparer as the comparer
        Dim templates As Dictionary(Of UriTemplate, Object) = New Dictionary(Of UriTemplate, Object)(New UriTemplateEquivalenceComparer())
        '</Snippet1>

        'Add template 1 into the dictionary
        templates.Add(temp1, "template1")

        'The UriTemplateEquivalenceComparer will be used here to compare the template in the table with template2
        'they are structurally equivalent, so ContainsKey will return true.
        If (templates.ContainsKey(temp2)) Then
            Console.WriteLine("Both templates hash to the same value")
        Else
            Console.WriteLine("Both templates do NOT hash to the same value")
        End If
        '</Snippet0>
    End Sub

End Module
