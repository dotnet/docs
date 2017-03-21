Dim price As [Double] = 9.95
Dim [date] As New DateTime(2004, 5, 20)
        
Using writer As XmlWriter = XmlWriter.Create("data.xml")
  writer.WriteStartElement("book")
  writer.WriteStartAttribute("pub-date")
  writer.WriteValue([date])
  writer.WriteEndAttribute()
            
  writer.WriteStartElement("price")
  writer.WriteValue(price)
  writer.WriteEndElement()
            
  writer.WriteEndElement()
  writer.Flush()
End Using