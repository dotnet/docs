            Rss20FeedFormatter myFeedRssFormatter = new Rss20FeedFormatter(typeof(MySyndicationFeed));
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            myFeedRssFormatter.ReadFrom(rssReader);
            rssReader.Close();