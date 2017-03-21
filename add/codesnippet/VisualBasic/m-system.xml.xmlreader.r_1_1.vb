    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("stringValue")
      Console.WriteLine(reader.ReadElementContentAsString())
    End Using