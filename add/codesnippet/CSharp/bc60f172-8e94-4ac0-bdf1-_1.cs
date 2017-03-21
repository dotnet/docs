            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);
            // ...
            XmlWriter xmlWriter = XmlWriter.Create("TestRSSFile.xml");
            feed.SaveAsRss20(xmlWriter);