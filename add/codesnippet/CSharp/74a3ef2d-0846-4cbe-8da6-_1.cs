            Rss20ItemFormatter itemFormatter = new Rss20ItemFormatter();
            XmlReader rssReader = XmlReader.Create("http://Contoso/Feeds/MyFeed/Item");
            if (itemFormatter.CanRead(rssReader))
            {
                itemFormatter.ReadFrom(rssReader);
                rssReader.Close();
            }