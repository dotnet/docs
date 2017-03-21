Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.OmitXmlDeclaration = True
Using writer As XmlWriter = XmlWriter.Create(Console.Out, settings)
  writer.WriteStartElement("root")
  writer.WriteAttributeString("xmlns", "x", Nothing, "urn:abc")
  writer.WriteStartElement("item")
  writer.WriteStartAttribute("href", Nothing)
  writer.WriteString("#")
  writer.WriteQualifiedName("test", "urn:abc")
  writer.WriteEndAttribute()
  writer.WriteEndElement()
  writer.WriteEndElement()
End Using