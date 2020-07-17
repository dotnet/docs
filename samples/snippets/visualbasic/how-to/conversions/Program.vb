Imports System.Globalization

Module Program
    Sub Main(args As String())
        FirstExample()
        GlobalExample()
        DefaultValueExample()
        ParseExactExample()
    End Sub

    Sub FirstExample()
        ' <Snippet1>
        Dim MyString As String = "Jan 1, 2009"
        Dim MyDateTime As DateTime = DateTime.Parse(MyString)
        Console.WriteLine(MyDateTime)
        ' Displays the following output on a system whose culture is en-US:
        '       1/1/2009 00:00:00
        ' </Snippet1>
    End Sub

    Sub GlobalExample()
        ' <Snippet2>
        Dim MyCultureInfo As New CultureInfo("de-DE")
        Dim MyString As String = "12 Juni 2008"
        Dim MyDateTime As DateTime = DateTime.Parse(MyString, MyCultureInfo)
        Console.WriteLine(MyDateTime)
        ' The example displays the following output:
        '       6/12/2008 00:00:00
        ' </Snippet2>
    End Sub

    Sub DefaultValueExample()
        ' <Snippet3>
        Dim MyCultureInfo As New CultureInfo("de-DE")
        Dim MyString As String = "12 Juni 2008"
        Dim MyDateTime As DateTime = DateTime.Parse(MyString, MyCultureInfo,
                                   DateTimeStyles.NoCurrentDateDefault)
        Console.WriteLine(MyDateTime)
        ' The example displays the following output if the current culture is en-US:
        '       6/12/2008 00:00:00
        ' </Snippet3>
    End Sub

    Sub ParseExactExample()
        ' <Snippet4>
        Dim MyCultureInfo As New CultureInfo("en-US")
        Dim MyString() As String = {" Friday, April 10, 2009", "Friday, April 10, 2009"}
        For Each dateString As String In MyString
            Try
                Dim MyDateTime As DateTime = DateTime.ParseExact(dateString, "D",
                                                             MyCultureInfo)
                Console.WriteLine(MyDateTime)
            Catch e As FormatException
                Console.WriteLine("Unable to parse '{0}'", dateString)
            End Try
        Next
        ' The example displays the following output:
        '       Unable to parse ' Friday, April 10, 2009'
        '       4/10/2009 00:00:00
        ' </Snippet4>
    End Sub
End Module
