using (XmlReader reader = XmlReader.Create("2books.xml")) {

  // Move the reader to the second book node.
  reader.MoveToContent(); 
  reader.ReadToDescendant("book");
  reader.Skip(); //Skip the first book.

  // Parse the file starting with the second book node.
  do {
     switch (reader.NodeType) {
        case XmlNodeType.Element:
           Console.Write("<{0}", reader.Name);
           while (reader.MoveToNextAttribute()) {
               Console.Write(" {0}='{1}'", reader.Name, reader.Value);
           }
           Console.Write(">");
           break;
        case XmlNodeType.Text:
           Console.Write(reader.Value);
           break;
        case XmlNodeType.EndElement:
           Console.Write("</{0}>", reader.Name);
           break;
     }       
  }  while (reader.Read());    

}