            XmlReader reader = XmlReader.Create("http://localhost/items/serializedItem.xml");
            SyndicationItem item = SyndicationItem.Load(reader);
            reader.Close();