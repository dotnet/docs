            XmlReader reader = XmlReader.Create("http://localhost/items/serializedItem.xml");
            MySyndicationItem myItem = SyndicationItem.Load<MySyndicationItem>(reader);
            reader.Close();