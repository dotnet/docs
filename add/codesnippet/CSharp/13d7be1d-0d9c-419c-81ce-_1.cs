            List<SyndicationItem> items = new List<SyndicationItem>();
            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Summary = new TextSyndicationContent("This is Item 1's summary");
            item1.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Summary = new TextSyndicationContent("This is Item 2's summary");
            item2.Authors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now, items);