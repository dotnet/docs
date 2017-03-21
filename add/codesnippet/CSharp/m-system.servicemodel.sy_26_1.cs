            Atom10FeedFormatter myFeedAtomFormatter = new Atom10FeedFormatter(typeof(MySyndicationFeed));
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            myFeedAtomFormatter.ReadFrom(atomReader);
            atomReader.Close();