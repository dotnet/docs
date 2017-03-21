    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("longValue")
      Dim number As Long = reader.ReadElementContentAsLong()
      ' Do some processing with the number object.
    End Using