            SyndicationFeed feed = new SyndicationFeed("Feed Title", "Feed Description", new Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now);

            SyndicationLink link = new SyndicationLink(new Uri("http://server/link"));
            feed.Links.Add(link);