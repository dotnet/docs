            Atom10ItemFormatter itemFormatter = new Atom10ItemFormatter();
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Item");
            if (itemFormatter.CanRead(atomReader))
            {
                itemFormatter.ReadFrom(atomReader);
                atomReader.Close();
            }