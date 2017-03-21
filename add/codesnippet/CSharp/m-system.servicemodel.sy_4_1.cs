            XmlReader reader = XmlReader.Create("http://localhost/feeds/serializedFeed.xml");
            SyndicationFeed feed = SyndicationFeed.Load(reader);