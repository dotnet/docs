        Dim atomReader As XmlReader = XmlReader.Create("AtomFeed.xml")
        Dim atomFormatter As Atom10FeedFormatter = New Atom10FeedFormatter()
        atomFormatter.ReadFrom(atomReader)
        atomReader.Close()