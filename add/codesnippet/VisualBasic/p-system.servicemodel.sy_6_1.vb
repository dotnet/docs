        Dim sp As New SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg")
        sp.AttributeExtensions.Add(New XmlQualifiedName("myAttribute", ""), "someValue")