        Dim item As New SyndicationItem("Item Title", "Item Content", New Uri("http:' Item/Alternate/Link"), "itemID", DateTimeOffset.Now)
        Dim clone As SyndicationItem = item.Clone()