            XmlReader atomReader = XmlReader.Create("AtomFeed.xml");
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter();
            atomFormatter.ReadFrom(atomReader);
            atomReader.Close();