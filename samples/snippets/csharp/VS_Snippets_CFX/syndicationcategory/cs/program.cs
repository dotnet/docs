// <Snippet0>
using System;
using System.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SyndicationCategorySample
{
    class Program
    {
        static void Main(string[] args)
        {
            SyndicationFeed myFeed = new SyndicationFeed("My Test Feed",
                                                        "This is a test feed",
                                                        new Uri("http://FeedServer/Test"), "MyFeedId", DateTime.Now);
            SyndicationItem myItem = new SyndicationItem("Item One Title",
                                                         "Item One Content",
                                                         new Uri("http://FeedServer/Test/ItemOne"));
            myItem.Categories.Add(new SyndicationCategory("MyCategory"));
            Collection<SyndicationItem> items = new Collection<SyndicationItem>();
            items.Add(myItem);
            myFeed.Items = items;
        }
    }
}
// </Snippet0>