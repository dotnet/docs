        Dim feed As SyndicationFeed = New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)

        Dim link As SyndicationLink = New SyndicationLink(New Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000)
        feed.Links.Add(link)