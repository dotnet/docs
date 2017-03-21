            Atom10ItemFormatter myItemAtomFormatter = new Atom10ItemFormatter(typeof(MySyndicationItem));
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Items");
            myItemAtomFormatter.ReadFrom(atomReader);
            atomReader.Close();