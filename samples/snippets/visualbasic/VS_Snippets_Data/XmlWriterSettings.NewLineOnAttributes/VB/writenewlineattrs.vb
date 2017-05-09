Imports System
Imports System.IO
Imports System.Xml

Public class Sample 

  public shared sub Main() 
  
    Dim writer as XmlWriter = Nothing

    try 
'<snippet1>
Dim settings As XmlWriterSettings = New XmlWriterSettings()
settings.Indent = true
settings.OmitXmlDeclaration = true
settings.NewLineOnAttributes = true
       
writer = XmlWriter.Create(Console.Out, settings)

writer.WriteStartElement("order")
writer.WriteAttributeString("orderID", "367A54")
writer.WriteAttributeString("date", "2001-05-03")
writer.WriteElementString("price", "19.95")
writer.WriteEndElement()
	
writer.Flush()
'</snippet1>
     
      Finally
         If Not (writer Is Nothing) Then
            writer.Close()
         End If
      End Try

   End Sub 
End Class 