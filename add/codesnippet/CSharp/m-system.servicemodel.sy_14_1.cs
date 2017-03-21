            MySyndicationFeed feed = new MySyndicationFeed("Test Feed", "This is a test feed", new Uri("http://Contoso/testfeed"), "TestFeedID", DateTime.Now);
            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://someuri"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = feed;
            item.Summary = new TextSyndicationContent("This the item summary");

            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item);
            feed.Items = items;
            
            XmlWriter atomWriter = XmlWriter.Create("Atom.xml");
            Atom10FeedFormatter<MySyndicationFeed> atomFormatter = new Atom10FeedFormatter<MySyndicationFeed>(feed);
            atomFormatter.WriteTo(atomWriter);
            atomWriter.Close();