Dim settings As New XmlReaderSettings()
settings.DtdProcessing = DtdProcessing.Parse
Dim reader As XmlReader = XmlReader.Create("items.xml", settings)
reader.MoveToContent()
' Parse the file and display each of the nodes.
While reader.Read()
  Select Case reader.NodeType
    Case XmlNodeType.Element
      Console.Write("<{0}>", reader.Name)
    Case XmlNodeType.Text
      Console.Write(reader.Value)
    Case XmlNodeType.CDATA
      Console.Write("<![CDATA[{0}]]>", reader.Value)
    Case XmlNodeType.ProcessingInstruction
      Console.Write("<?{0} {1}?>", reader.Name, reader.Value)
    Case XmlNodeType.Comment
      Console.Write("<!--{0}-->", reader.Value)
    Case XmlNodeType.XmlDeclaration
      Console.Write("<?xml version='1.0'?>")
    Case XmlNodeType.Document
    Case XmlNodeType.DocumentType
      Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value)
    Case XmlNodeType.EntityReference
      Console.Write(reader.Name)
    Case XmlNodeType.EndElement
      Console.Write("</{0}>", reader.Name)
  End Select
End While