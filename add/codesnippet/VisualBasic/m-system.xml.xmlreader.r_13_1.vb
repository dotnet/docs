Using reader As XmlReader = XmlReader.Create("2books.xml")

  ' Move the reader to the second book node.
  reader.MoveToContent()
  reader.ReadToDescendant("book")
  reader.Skip() 'Skip the first book.
  ' Parse the file starting with the second book node.
  Do
    Select Case reader.NodeType
      Case XmlNodeType.Element
        Console.Write("<{0}", reader.Name)
        While reader.MoveToNextAttribute()
            Console.Write(" {0}='{1}'", reader.Name, reader.Value)
        End While
        Console.Write(">")
      Case XmlNodeType.Text
        Console.Write(reader.Value)
      Case XmlNodeType.EndElement
        Console.Write("</{0}>", reader.Name)
    End Select
  Loop While reader.Read()

End Using