'<snippet1>
Imports System
Imports System.Xml

Module Module1
    Sub Main()
        ' Create an XmlReader, read to the "time" element, and read contents as type string
        Dim reader As XmlReader = XmlReader.Create("transactions.xml")
        reader.ReadToFollowing("time")
        Dim time As String = reader.ReadElementContentAsString()

        ' Read the element contents as a string and covert to DateTimeOffset type
	' The format of time must be a subset of the W3C Recommendation for the XML dateTime type
        Dim transaction_time As DateTimeOffset = XmlConvert.ToDateTimeOffset(time)
        Console.WriteLine(transaction_time)
    End Sub 'Main
End Module
'</snippet1>
