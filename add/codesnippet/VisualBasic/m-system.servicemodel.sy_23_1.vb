        Dim myItemAtomFormatter As New Atom10ItemFormatter(GetType(MySyndicationItem))
        Dim atomReader As XmlReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Items")
        myItemAtomFormatter.ReadFrom(atomReader)
        atomReader.Close()