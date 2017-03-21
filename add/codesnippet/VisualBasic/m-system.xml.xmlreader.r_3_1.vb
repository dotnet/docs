' Load the file and ignore all white space.
Dim settings As New XmlReaderSettings()
settings.IgnoreWhitespace = True
Using reader As XmlReader = XmlReader.Create("2books.xml")

  ' Moves the reader to the root element.
  reader.MoveToContent()
                
  ' Moves to book node.
  reader.Read()
                
  ' Note that ReadInnerXml only returns the markup of the node's children
  ' so the book's attributes are not returned.
  Console.WriteLine("Read the first book using ReadInnerXml...")
  Console.WriteLine(reader.ReadInnerXml())
                
  ' ReadOuterXml returns the markup for the current node and its children
  ' so the book's attributes are also returned.
  Console.WriteLine("Read the second book using ReadOuterXml...")
  Console.WriteLine(reader.ReadOuterXml())

End Using