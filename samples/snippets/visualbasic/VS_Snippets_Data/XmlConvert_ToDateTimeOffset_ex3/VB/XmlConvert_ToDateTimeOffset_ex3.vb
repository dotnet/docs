'<snippet1>
Imports System
Imports System.Xml

Module Module1
    Sub Main()
        ' Create an XmlReader, read to the "time" element, and read contents as type string
        Dim reader As XmlReader = XmlReader.Create("transactions.xml")
        reader.ReadToFollowing("time")
        Dim time As String = reader.ReadElementContentAsString()

        ' Specify formats against which time will be validated before conversion to DateTimeOffset
        ' If time does not match one of the specified formats, a FormatException will be thrown.
        ' Each specified format must be a subset of the W3C Recommendation for the XML dateTime type
        Dim formats As String() = {"yyyy-MM-ddTHH:mm:sszzzzzzz", "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-dd"}
        Try
            ' Read the element contents as a string and covert to DateTimeOffset type
            Dim transaction_time As DateTimeOffset = XmlConvert.ToDateTimeOffset(time, formats)
            Console.WriteLine(transaction_time)
        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub
End Module
'</snippet1>