XmlReader reader = XmlReader.Create("book2.xml");

// Parse the file.  If they exist, display the prefix and 
// namespace URI of each node.
while (reader.Read()) {
  if (reader.IsStartElement()) {
    if (reader.Prefix==String.Empty)
      Console.WriteLine("<{0}>", reader.LocalName);
    else {
      Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName);
      Console.WriteLine(" The namespace URI is " + reader.NamespaceURI);
    }
  }
}       
reader.Close();