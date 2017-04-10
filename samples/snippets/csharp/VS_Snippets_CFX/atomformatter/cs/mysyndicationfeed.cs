using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.Syndication;

namespace AtomFeedFormatterSnippets
{
    public class MySyndicationFeed : SyndicationFeed
    {
        public MySyndicationFeed() { }
        public MySyndicationFeed(string title, string description, Uri feedAltLink, string id, DateTime lastUpdateTime )
            : base (title, description,feedAltLink, id, lastUpdateTime)
        {}
    }

    public class MySyndicationItem : SyndicationItem
    {
        public MySyndicationItem() { }
        public MySyndicationItem(string title, string description, Uri feedAltLink, string id, DateTime lastUpdateTime )
            : base (title, description,feedAltLink, id, lastUpdateTime)
        {}

    }

}
