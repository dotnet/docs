        If xsc.Contains("urn:bookstore-schema") Then
            Dim schema As XmlSchema = xsc("urn:bookstore-schema")
            Dim sw As New StringWriter()
            Dim xmlWriter As New XmlTextWriter(sw)
            xmlWriter.Formatting = Formatting.Indented
            xmlWriter.Indentation = 2
            schema.Write(xmlWriter)
            Console.WriteLine(sw.ToString())
        End If