        Dim myFeedAtomFormatter As New Atom10FeedFormatter(GetType(MySyndicationFeed))
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed")
        myFeedAtomFormatter.ReadFrom(atomReader)
        atomReader.Close()