            MySyndicationItem item = new MySyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://Contoso"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter rssWriter = XmlWriter.Create("RssItem.xml");
            Rss20ItemFormatter<MySyndicationItem> formatter = new Rss20ItemFormatter<MySyndicationItem>(item);
            formatter.WriteTo(rssWriter);
            rssWriter.Close();