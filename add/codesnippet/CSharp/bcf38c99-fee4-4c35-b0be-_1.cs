            Atom10FeedFormatter feedFormatter = new Atom10FeedFormatter();
            XmlReader atomReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            if (feedFormatter.CanRead(atomReader))
            {
                feedFormatter.ReadFrom(atomReader);
                atomReader.Close();
            }