        Dim reader As XmlReader = XmlReader.Create("http:' localhost/items/serializedItem.xml")
        Dim item As SyndicationItem = SyndicationItem.Load(reader)
        reader.Close()