    Public Shared Sub WriteXml(doc As XmlDocument)
        Dim writer As New XmlTextWriter(Console.Out)
        writer.Formatting = Formatting.Indented
        doc.WriteTo(writer)
        writer.Flush()
        Console.WriteLine()
    End Sub 'WriteXml