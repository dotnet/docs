  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("stringValue");
       Console.WriteLine(reader.ReadElementContentAsString());			
  }