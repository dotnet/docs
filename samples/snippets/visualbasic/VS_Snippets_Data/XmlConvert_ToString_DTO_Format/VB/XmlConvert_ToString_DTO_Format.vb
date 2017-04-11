'<snippet1>
Imports System
Imports System.Xml

Module Module1
    Sub Main()

        ' Create the DateTimeOffset object and set the time to the current time.
        Dim dto As DateTimeOffset
        dto = DateTimeOffset.Now

        ' Convert the DateTimeObject to a string in a specified format and display the result.
        ' The specified format must be a subset of the W3C Recommendation for the XML dateTime type.
        Dim timeAsString As [String] = XmlConvert.ToString(dto, "yyyy-MM-ddTHH:mm:sszzzzzzz")
        Console.WriteLine(timeAsString)

    End Sub
End Module
'</snippet1>