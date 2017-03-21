            List<SyndicationItem> items = new List<SyndicationItem>();

            SyndicationItem item1 = new SyndicationItem();
            item1.Title = new TextSyndicationContent("Item 1");
            item1.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 1");
            items.Add(item1);

            SyndicationItem item2 = new SyndicationItem();
            item2.Title = new TextSyndicationContent("Item 2");
            item2.Content = SyndicationContent.CreatePlaintextContent("This is the content for Item 2");
            items.Add(item2);

            SyndicationFeed feed = new SyndicationFeed();
            feed.Items = items;