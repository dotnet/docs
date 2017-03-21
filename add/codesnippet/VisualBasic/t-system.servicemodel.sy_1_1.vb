        Dim feed As New SyndicationFeed("Feed Title", "Feed Description", New Uri("http://Feed/Alternate/Link"), "FeedID", DateTime.Now)
        Dim sp As New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg")
        feed.Authors.Add(sp)