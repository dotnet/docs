            SyndicationItem item = new SyndicationItem("My Item", "This is some content", new Uri("http://SomeServer/MyItem"), "Item ID", DateTime.Now);
            item.Authors.Add(new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://contoso/jesper"));
            item.Categories.Add(new SyndicationCategory("Category One"));
            item.Contributors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://contoso/lene"));
            item.Copyright = new TextSyndicationContent("Copyright 2007");
            item.Links.Add(new SyndicationLink(new Uri("http://OtherServer/Item"), "alternate", "Alternate Link", "text/html", 1000));
            item.PublishDate = new DateTime(2007, 2, 23);
            item.Summary = new TextSyndicationContent("this is a summary for my item");
            XmlQualifiedName xqName = new XmlQualifiedName("itemAttrib", "http://FeedServer/tags");
            item.AttributeExtensions.Add(xqName, "ItemAttribValue");

            SyndicationFeed feed = new SyndicationFeed();
            Collection<SyndicationItem> items = new Collection<SyndicationItem>();
            items.Add(item);
            feed.Items = items;