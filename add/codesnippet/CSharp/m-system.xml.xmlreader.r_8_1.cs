  using (XmlReader reader = XmlReader.Create("dataFile.xml")) {
       reader.ReadToFollowing("date");
       DateTime date = reader.ReadElementContentAsDateTime();
	
       // If the current culture is "en-US",
       // this writes "Wednesday, January 8, 2003".
       Console.WriteLine(date.ToLongDateString());
  }