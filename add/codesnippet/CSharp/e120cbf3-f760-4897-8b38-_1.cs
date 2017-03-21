            Rss20ItemFormatter feedFormatter = new Rss20ItemFormatter();
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed");
            if (feedFormatter.CanRead(rssReader))
            {
                feedFormatter.ReadFrom(rssReader);
                rssReader.Close();
            }