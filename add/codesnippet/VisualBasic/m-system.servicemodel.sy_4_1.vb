        Dim reader As XmlReader = XmlReader.Create("http:'localhost/feeds/serializedFeed.xml")
        Dim feed As SyndicationFeed = SyndicationFeed.Load(reader)