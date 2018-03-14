    Dim reader = 
      System.Xml.XmlReader.Create(My.Application.Info.DirectoryPath & 
                                  "\..\..\Data\books.xml")
    reader.MoveToContent()
    Dim inputXml = XDocument.ReadFrom(reader)
    Console.WriteLine(inputXml)