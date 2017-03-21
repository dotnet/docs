            SyndicationItem item = new SyndicationItem("Test Item", "This is the content for Test Item", new Uri("http://Contoso/ItemOne"), "TestItemID", DateTime.Now);

            XmlWriter rssWriter = XmlWriter.Create("RSS.xml");
            Rss20ItemFormatter rssFormatter = new Rss20ItemFormatter(item);
            
            rssFormatter.WriteTo(rssWriter);
            rssWriter.Close();