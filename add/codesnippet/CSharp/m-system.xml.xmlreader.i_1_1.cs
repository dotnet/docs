  // Parse the file and display each price node.
  while (reader.Read()) {
    if (reader.IsStartElement("price")) {
       Console.WriteLine(reader.ReadInnerXml());
    }
  }   