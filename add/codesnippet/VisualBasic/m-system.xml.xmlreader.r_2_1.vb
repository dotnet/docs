    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("stringValue")
      Console.WriteLine(reader.ReadElementContentAsString("stringValue", ""))
    End Using