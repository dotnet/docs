    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("double")
      Dim number As [Double] = reader.ReadElementContentAsDouble()
      ' Do some processing with the number object.
    End Using