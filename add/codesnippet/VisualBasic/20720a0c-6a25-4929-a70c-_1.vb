        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http:'Feed/Alternate/Link"), "FeedID", DateTime.Now)
        ' ...
        Dim xmlWriter As XmlWriter = xmlWriter.Create("TestAtomFile.xml")
        feed.SaveAsAtom10(XmlWriter)