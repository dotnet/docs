'<snippet1>
Imports System
Imports System.Xml

Module Module1      
    Sub Main()
        ' Create an XmlReader, read to the "time" element, and read contents as type string
        Dim reader As XmlReader = XmlReader.Create("transactions.xml")
        reader.ReadToFollowing("time")
        Dim time As String = reader.ReadElementContentAsString()

        ' Specify a format against which time will be validated before conversion to DateTimeOffset
        ' If time does not match the format, a FormatException will be thrown.
        ' The specified format must be a subset of the W3C Recommendation for the XML dateTime type
        Dim format As String = "yyyy-MM-ddTHH:mm:sszzzzzzz"
        Try
            ' Read the element contents as a string and covert to DateTimeOffset type
            Dim transaction_time As DateTimeOffset = XmlConvert.ToDateTimeOffset(time, format)
            Console.WriteLine(transaction_time)
        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub 'Main
End Module
'</snippet1>
