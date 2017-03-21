// Load the file and ignore all white space.
XmlReaderSettings settings = new XmlReaderSettings();
settings.IgnoreWhitespace = true;
using (XmlReader reader = XmlReader.Create("2books.xml")) {

  // Moves the reader to the root element.
  reader.MoveToContent();
 
  // Moves to book node.
  reader.Read(); 

  // Note that ReadInnerXml only returns the markup of the node's children
  // so the book's attributes are not returned.
  Console.WriteLine("Read the first book using ReadInnerXml...");
  Console.WriteLine(reader.ReadInnerXml());

  // ReadOuterXml returns the markup for the current node and its children
  // so the book's attributes are also returned.
  Console.WriteLine("Read the second book using ReadOuterXml...");
  Console.WriteLine(reader.ReadOuterXml());      

}