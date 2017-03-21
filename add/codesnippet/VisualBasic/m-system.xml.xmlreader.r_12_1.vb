Dim settings As New XmlReaderSettings()
settings.IgnoreWhitespace = True
Using reader As XmlReader = XmlReader.Create("books.xml", settings)

  ' Position the reader on the second book node.
  reader.ReadToFollowing("Book")
  reader.Skip()
                
  ' Create another reader that contains just the second book node.
  Dim inner As XmlReader = reader.ReadSubtree()
            
  inner.ReadToDescendant("Title")
  Console.WriteLine(inner.Name)

  ' Do additional processing on the inner reader. After you 
  ' are done, call Close on the inner reader and 
  ' continue processing using the original reader.
  inner.Close()

End Using