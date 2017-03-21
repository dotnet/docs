            SyndicationItem item = new SyndicationItem("Item Title", "Item Content", new Uri("http://Item/Alternate/Link"), "itemID", DateTimeOffset.Now);
            Rss20ItemFormatter rssFormatter = item.GetRss20Formatter();
            XmlWriter writer = XmlWriter.Create("output.xml");
            rssFormatter.WriteTo(writer);
            writer.Close();