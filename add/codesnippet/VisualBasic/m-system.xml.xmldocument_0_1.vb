    Public Shared Sub WriteXml(doc As XmlDocument)
        Dim writer As New XmlTextWriter(Console.Out)
        writer.Formatting = Formatting.Indented
        doc.WriteContentTo(writer)
        writer.Flush()
        Console.WriteLine()
    End Sub 'WriteXml