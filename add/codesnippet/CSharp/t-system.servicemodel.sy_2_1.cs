            MySyndicationFeed feed = new MySyndicationFeed("Test Feed",
 "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);

            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("This the item summary");

 	    List<SyndicationItem> items = new List<SyndicationItem>();
	    items.Add(item);
            feed.Items = items;

            XmlWriter rssWriter = XmlWriter.Create("Rss.xml");
            Rss20FeedFormatter<MySyndicationFeed> rssFormatter = new Rss20FeedFormatter<MySyndicationFeed>(feed);
            rssFormatter.WriteTo(rssWriter);
            rssWriter.Close();