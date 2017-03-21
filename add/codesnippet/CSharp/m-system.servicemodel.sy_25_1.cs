            MySyndicationItem item = new MySyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://localhost/ItemOne"), "TestItemID", DateTime.Now);

            item.Links.Add(new SyndicationLink(new Uri("http://someuri"), "alternate", "MyItemLink", "text/html", 100));
            item.PublishDate = new DateTime(1968, 2, 23);
            item.LastUpdatedTime = DateTime.Today;
            item.SourceFeed = new SyndicationFeed();
            item.Summary = new TextSyndicationContent("This the item summary");

            XmlWriter atomWriter = XmlWriter.Create("AtomItem.xml");
            Atom10ItemFormatter<MySyndicationItem> formatter = new Atom10ItemFormatter<MySyndicationItem>(item);