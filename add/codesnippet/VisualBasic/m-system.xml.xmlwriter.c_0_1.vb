Using writer As XmlWriter = XmlWriter.Create(Console.Out)
  writer.WriteStartElement("book")
  writer.WriteElementString("price", "19.95")
  writer.WriteEndElement()
  writer.Flush()
End Using