Using reader As XmlReader = XmlReader.Create("books.xml")
  reader.ReadToFollowing("book")
  Do
    Console.WriteLine("ISBN: {0}", reader.GetAttribute("ISBN"))
  Loop While reader.ReadToNextSibling("book")
End Using