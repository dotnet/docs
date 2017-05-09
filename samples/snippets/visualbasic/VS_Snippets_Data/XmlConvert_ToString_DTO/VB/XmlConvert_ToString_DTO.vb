'<snippet1>
Imports System
Imports System.Xml

Module Module1
    Sub Main()

        ' Create the DateTimeOffset object and set the time to the current time
        Dim dto As DateTimeOffset
        dto = DateTimeOffset.Now

        ' Convert the DateTimeOffset object to a string and display the result
        Dim timeAsString As String = XmlConvert.ToString(dto)
        Console.WriteLine(timeAsString)

    End Sub
End Module
'</snippet1>