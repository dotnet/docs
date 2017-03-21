            Rss20ItemFormatter myItemRssFormatter = new Rss20ItemFormatter(typeof(MySyndicationItem));
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Items");
            myItemRssFormatter.ReadFrom(rssReader);
            rssReader.Close();