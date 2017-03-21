    Private Function AddNamespaces() As XmlSerializerNamespaces
        Dim xmlNamespaces As New XmlSerializerNamespaces()
        
        ' Add three prefix-namespace pairs.
        xmlNamespaces.Add("money", "http://www.cpandl.com")
        xmlNamespaces.Add("books", "http://www.cohowinery.com")
        xmlNamespaces.Add("software", "http://www.microsoft.com")
        
        Return xmlNamespaces
    End Function
    