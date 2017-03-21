        Dim link As New SyndicationLink(New Uri("http://server/link"))
        link.AttributeExtensions.Add(New XmlQualifiedName("myAttribute", ""), "someValue")