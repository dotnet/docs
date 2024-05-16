Module Instantiation

    Public Sub Snippets()
        InstantiateWithConstructor()
        InstantiateWithCompilerSyntax()
        InstantiateWithReturnValue()
        InstantiateFromString()
        InstantiateUsingDftCtor()
    End Sub

    Private Sub InstantiateWithConstructor()
        ' <Snippet1>
        Dim date1 As New Date(2008, 5, 1, 8, 30, 52)
        ' </Snippet1>
    End Sub

    Private Sub InstantiateWithCompilerSyntax()
        ' <Snippet2>
        Dim date1 As Date = #5/1/2008 8:30:52AM#
        ' </Snippet2>  
    End Sub

    Private Sub InstantiateWithReturnValue()
        ' <Snippet3>
        Dim date1 As Date = Date.Now
        Dim date2 As Date = Date.UtcNow
        Dim date3 As Date = Date.Today
        ' </Snippet3>
    End Sub

    Private Sub InstantiateFromString()
        ' <Snippet4>
        Dim dateString As String = "5/1/2008 8:30:52 AM"
        Dim date1 As Date = Date.Parse(dateString,
                               System.Globalization.CultureInfo.InvariantCulture)
        Dim iso8601String As String = "20080501T08:30:52Z"
        Dim dateISO8602 As Date = DateTime.ParseExact(iso8601String, "yyyyMMddTHH:mm:ssZ",
                                      System.Globalization.CultureInfo.InvariantCulture)
        Console.WriteLine(dateISO8602)

        ' </Snippet4>
        Console.WriteLine(date1)
    End Sub

    Private Sub InstantiateUsingDftCtor()
        ' <Snippet5>
        Dim dat1 As DateTime
        ' The following method call displays 1/1/0001 12:00:00 AM.
        Console.WriteLine(dat1.ToString(System.Globalization.CultureInfo.InvariantCulture))
        ' The following method call displays True.
        Console.WriteLine(dat1.Equals(Date.MinValue))

        Dim dat2 As New DateTime()
        ' The following method call displays 1/1/0001 12:00:00 AM.
        Console.WriteLine(dat2.ToString(System.Globalization.CultureInfo.InvariantCulture))
        ' The following method call displays True.
        Console.WriteLine(dat2.Equals(Date.MinValue))
        ' </Snippet5>
    End Sub

End Module
