    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("date")
      Dim [date] As DateTime = CType(reader.ReadElementContentAs(GetType(System.DateTime), Nothing), DateTime)
                
      ' If the current culture is "en-US",
      ' this writes "Wednesday, January 8, 2003".
      Console.WriteLine([date].ToLongDateString())
    End Using