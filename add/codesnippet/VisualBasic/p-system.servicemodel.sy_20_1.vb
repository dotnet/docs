            Dim feed As New SyndicationFeed()

            'Attribute extensions are stored in a dictionary indexed by XmlQualifiedName
            feed.AttributeExtensions.Add(New XmlQualifiedName("myAttribute", ""), "someValue")