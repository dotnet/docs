            SyndicationFeed feed = new SyndicationFeed();

            //Attribute extensions are stored in a dictionary indexed by XmlQualifiedName
            feed.AttributeExtensions.Add(new XmlQualifiedName("myAttribute", ""), "someValue");