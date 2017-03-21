            TextSyndicationContent content = new TextSyndicationContent("Item Content");
            Uri uri = new Uri("http://Item/Alternate/Link");
            SyndicationItem item = new SyndicationItem("Item Title", content, uri, "itemID", DateTimeOffset.Now);