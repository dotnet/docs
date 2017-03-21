            Rss20FeedFormatter feedFormatter = new Rss20FeedFormatter();
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            if (feedFormatter.CanRead(rssReader))
            {
                feedFormatter.ReadFrom(rssReader);
                rssReader.Close();
            }