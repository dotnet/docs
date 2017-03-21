XmlReaderSettings settings = new XmlReaderSettings();
settings.IgnoreWhitespace = true;
using (XmlReader reader = XmlReader.Create("books.xml", settings)) {

  // Position the reader on the second book node
  reader.ReadToFollowing("Book");
  reader.Skip();
       
  // Create another reader that contains just the second book node.
  XmlReader inner = reader.ReadSubtree();

  inner.ReadToDescendant("Title");
  Console.WriteLine(inner.Name);

  // Do additional processing on the inner reader. After you 
  // are done, call Close on the inner reader and 
  // continue processing using the original reader.
  inner.Close(); 

}