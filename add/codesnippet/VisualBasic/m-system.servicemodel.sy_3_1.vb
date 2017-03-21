        Dim reader = XmlReader.Create("http:' localhost/items/serializedItem.xml")
        Dim myItem As MySyndicationItem = SyndicationItem.Load(Of MySyndicationItem)(reader)
        reader.Close()