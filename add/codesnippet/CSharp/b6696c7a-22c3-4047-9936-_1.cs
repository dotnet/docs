            SyndicationFeed feed = new SyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item);
            feed.Items = items;

            XmlWriter atomWriter = XmlWriter.Create("Atom.xml");
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
            atomFormatter.WriteTo(atomWriter);
            atomWriter.Close();