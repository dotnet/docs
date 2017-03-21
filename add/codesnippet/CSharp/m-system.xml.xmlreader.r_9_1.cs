  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("longValue");
       long number = reader.ReadElementContentAsLong();
       // Do some processing with the number object.
  }