Module StringFormat
    Public Sub Snippets()
        ShowDefaultToString()
        ShowCultureSpecificToString()
        ShowDefaultFullDateAndTime()
        ShowCultureSpecificFullDateAndTime()
        ShowIsoDateTime()
    End Sub

    Private Sub ShowDefaultToString()
        ' <Snippet1>
        Dim date1 As Date = #3/1/2008 7:00AM#
        Console.WriteLine(date1.ToString())
        ' For en-US culture, displays 3/1/2008 7:00:00 AM
        ' </Snippet1>
    End Sub

    Private Sub ShowCultureSpecificToString()
        ' <Snippet2>
        Dim date1 As Date = #3/1/2008 7:00AM#
        Console.WriteLine(date1.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")))
        ' Displays 01/03/2008 07:00:00
        ' </Snippet2>
    End Sub

    Private Sub ShowDefaultFullDateAndTime()
        ' <Snippet3>
        Dim date1 As Date = #3/1/2008 7:00AM#
        Console.WriteLine(date1.ToString("F"))
        ' Displays Saturday, March 01, 2008 7:00:00 AM
        ' </Snippet3>
    End Sub

    Private Sub ShowCultureSpecificFullDateAndTime()
        ' <Snippet4>
        Dim date1 As Date = #3/1/2008 7:00AM#
        Console.WriteLine(date1.ToString("F", New System.Globalization.CultureInfo("fr-FR")))
        ' Displays samedi 1 mars 2008 07:00:00
        ' </Snippet4>
    End Sub

    Private Sub ShowIsoDateTime()
        ' <Snippet5>
        Dim date1 As DateTime = New DateTime(2008, 3, 1, 7, 0, 0, DateTimeKind.Utc)
        Console.WriteLine(date1.ToString("yyyy-MM-ddTHH:mm:sszzz", System.Globalization.CultureInfo.InvariantCulture))
        ' Displays 2008-03-01T07:00:00+00:00
        ' </Snippet5>
    End Sub

End Module
