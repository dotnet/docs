while (reader.Read()) {
  if (reader.IsStartElement()) {
    if (reader.IsEmptyElement)
      Console.WriteLine("<{0}/>", reader.Name);
    else {
      Console.Write("<{0}> ", reader.Name);
      reader.Read(); // Read the start tag.
      if (reader.IsStartElement())  // Handle nested elements.
        Console.Write("\r\n<{0}>", reader.Name);
      Console.WriteLine(reader.ReadString());  //Read the text content of the element.
    }
  } 
} 