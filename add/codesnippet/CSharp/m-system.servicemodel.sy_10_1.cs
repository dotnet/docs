            XmlReader rssReader = XmlReader.Create("http://contoso/Feeds/RSS/MyFeed");
            Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter();
            rssFormatter.ReadFrom(rssReader);
            rssReader.Close();