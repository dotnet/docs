Dim settings As New XmlWriterSettings()
settings.OmitXmlDeclaration = True
Dim sw As New StringWriter()
        
Using writer As XmlWriter = XmlWriter.Create(sw, settings)
  writer.WriteStartElement("book")
  writer.WriteElementString("price", "19.95")
  writer.WriteEndElement()
  writer.Flush()
            
  Dim output As String = sw.ToString()
End Using