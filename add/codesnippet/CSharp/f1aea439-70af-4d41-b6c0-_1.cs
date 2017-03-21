            SyndicationFeed feed = new SyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

	    List<SyndicationItem> items = new List<SyndicationItem>();
	    items.Add(item);
            feed.Items = items;

            XmlWriter rssWriter = XmlWriter.Create("RSS.xml");
            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed);