  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("double");
       Double number = reader.ReadElementContentAsDouble();
       // Do some processing with the number object.	
  }